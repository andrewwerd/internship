using DbCard.Context;
using DbCard.Domain;
using DbCard.Infrastructure.Dto.Transaction;
using DbCard.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DbCard.Services.Implementations
{
    public class TransactionsService : ITransactionService
    {
        private readonly IDiscountService _discountService;
        private readonly IRepository<Transaction> _transactionRepository;
        private readonly DbCardContext _context;
        private readonly IBalanceService _balanceService;
        private readonly ICustomerService _customerService;

        public TransactionsService(
            IDiscountService discountService,
            DbCardContext context,
            IBalanceService balanceService,
            IRepository<Transaction> transactionRepository,
            ICustomerService customerService)
        {
            _discountService = discountService;
            _context = context;
            _balanceService = balanceService;
            _transactionRepository = transactionRepository;
            _customerService = customerService;
        }

        public async Task<PaginatedResult<TransactionGridRow>> GetPagedTransactions(PagedRequest pagedRequest)
        {
            var customer = await _customerService.GetCurrentCustomer();
            var id = customer.Id;
            Expression<Func<Transaction, bool>> predicate = null;

            var periodFilter = pagedRequest.RequestFilters.Filters.FirstOrDefault(x => x.Path == "period");
            if (periodFilter != null)
            {
                var date = DateTime.Today;

                if (Enum.TryParse<Period>(periodFilter.Value, out var parsedPeriod))
                {
                    if (parsedPeriod == Period.Week) date = date.AddDays(-7);
                    else if (parsedPeriod == Period.Month) date = date.AddMonths(-1);
                    else if (parsedPeriod == Period.Year) date = date.AddYears(-1);
                }

                predicate = transaction => transaction.CustomerId == id && transaction.DateTime >= date;
                pagedRequest.RequestFilters.Filters.Remove(periodFilter);
            }

            return await _transactionRepository.GetPagedData<TransactionGridRow>(pagedRequest, predicate);
        }
        public async Task<Transaction> DeleteTransactionAsync(long id)
        {
            var transaction = _transactionRepository.Delete(id);
            return await transaction;
        }
        public async Task CreateTransactionAsync(Customer customer, Filial filial, decimal amount, DateTime? date = null)
        {
            var transaction = new Transaction()
            {
                AllAmount = amount,
                Filial = filial,
                Customer = customer,
                DateTime = date ?? DateTime.Now,
                PartnerName = filial.Partner.Name,
                CategoryId = filial.Partner.CategoryId,
                SubcategoryId = filial.Partner.SubcategoryId,
                Address = filial.Street + ' ' + filial.HouseNumber
            };
            var balance = await _context.CustomersBalances.Where(x => x.PartnerId == filial.PartnerId && x.CustomerId == customer.Id).SingleOrDefaultAsync();
            if (balance == null)
            {
                var newBalance = new CustomersBalance()
                {
                    ResetDate = DateTime.Today,
                    IsPremium = false,
                    Partner = filial.Partner
                };
                customer.CustomersBalances.Add(newBalance);
            }
            if (balance.IsPremium)
            {
                CalculatePremiumDiscount(transaction, balance);
            }
            else
            {
                await CalculateStandartDiscount(transaction, balance);
            }
            await _context.Transactions.AddAsync(transaction);
        }

        private void CalculatePremiumDiscount(Transaction transaction, CustomersBalance balance)
        {
            var discount = _discountService.GetPremiumDiscountByBalanceAsync(balance);
            transaction.AccumulationAmount = transaction.AllAmount * discount.AccumulationPercent / 100;
            transaction.DiscountAmount = transaction.AllAmount * discount.DiscountPercent / 100;
            transaction.AmountForPay = transaction.AllAmount - transaction.DiscountAmount;
            balance.Amount += transaction.AccumulationAmount;
        }

        private async Task CalculateStandartDiscount(Transaction transaction, CustomersBalance balance)
        {
            var discount =  _discountService.GetStandartDiscountByBalanceAsync(balance, transaction.AllAmount);
            transaction.AccumulationAmount = 0;
            transaction.DiscountAmount = transaction.AllAmount * discount.DiscountPercent / 100;
            transaction.AmountForPay = transaction.AllAmount - transaction.DiscountAmount;
            balance.Amount += transaction.AmountForPay;
            await _balanceService.CheckBalance(balance);
        }
    }
}
