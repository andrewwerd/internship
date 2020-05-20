using DbCard.Context;
using DbCard.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Services.Implementations
{
    public class TransactionsService : ITransactionService
    {
        private readonly IRepository<Transaction> _transactionRepository;
        private readonly IDiscountService _discountService;
        private readonly DbCardContext _context;
        private readonly IBalanceService _balanceService;

        public TransactionsService(
            IRepository<Transaction> transactionRepository, 
            IDiscountService discountService, 
            DbCardContext context,
            IBalanceService balanceService)
        {
            _transactionRepository = transactionRepository;
            _discountService = discountService;
            _context = context;
            _balanceService = balanceService;
        }
        public async Task CreateTransactionAsync(Customer customer, Filial filial, decimal amount)
        {
            var transaction = new Transaction()
            {
                AllAmount = amount,
                Filial = filial,
                Customer = customer,
                DateTime = DateTime.Now,
                PartnerName = filial.Partner.Name,
                CategoryId = filial.Partner.CategoryId,
                SubcategoryId = filial.Partner.SubcategoryId,
                FilialAddress = filial.Street+' '+filial.HouseNumber
                };
            var balance = customer.CustomersBalances.Where(x => x.PartnerId == filial.PartnerId).SingleOrDefault();
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
            if(balance.IsPremium)
            {
                await CalculatePremiumDiscount(transaction, balance);
            }
            else
            {
                await CalculateStandartDiscount(transaction, balance);
            }
            await _transactionRepository.Add(transaction);
        }

        public async Task CreateTransactionAsync(Customer customer, Filial filial, decimal amount, DateTime date)
        {
            var transaction = new Transaction()
            {
                AllAmount = amount,
                Filial = filial,
                Customer = customer,
                DateTime = date,
                PartnerName = filial.Partner.Name,
                CategoryId = filial.Partner.CategoryId,
                SubcategoryId = filial.Partner.SubcategoryId,
                FilialAddress = filial.Street +' '+ filial.HouseNumber
            };
            var balance = await _context.CustomersBalances.Where(x => x.PartnerId == filial.PartnerId && x.CustomerId==customer.Id).SingleOrDefaultAsync();
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
                await CalculatePremiumDiscount(transaction, balance);
            }
            else
            {
               await CalculateStandartDiscount(transaction, balance);
            }
            await _context.Transactions.AddAsync(transaction);
        }

        private async Task CalculatePremiumDiscount(Transaction transaction, CustomersBalance balance)
        {
            var discount = await _discountService.GetPremiumDiscountByBalanceAsync(balance);
            transaction.AccumulationAmount = transaction.AllAmount * discount.AccumulatingPercent/100;
            transaction.DiscountAmount =  transaction.AllAmount * discount.DiscountPercent/100;
            transaction.AmountForPay = transaction.AllAmount -  transaction.DiscountAmount;
            balance.Amount += transaction.AccumulationAmount;
        }

        private async Task CalculateStandartDiscount(Transaction transaction, CustomersBalance balance)
        {
            var discount = await _discountService.GetStandartDiscountByBalanceAsync(balance, transaction.AllAmount);
            transaction.AccumulationAmount = 0;
            transaction.DiscountAmount = transaction.AllAmount * discount.DiscountPercent/100;
            transaction.AmountForPay = transaction.AllAmount - transaction.DiscountAmount;
            balance.Amount += transaction.AmountForPay;
            await _balanceService.CheckBalance(balance);
        }
    }
}
