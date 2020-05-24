using DbCard.Domain;
using DbCard.Infrastructure.Dto.Balance;
using DbCard.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DbCard.Services.Implementations
{
    public class BalanceService : IBalanceService
    {
        private readonly IDiscountService _discountService;
        private readonly ICustomerService _customerService;
        private readonly IRepository<CustomersBalance> _customersBalanceRepository;

        public BalanceService(
            IDiscountService discountService, 
            ICustomerService customerService,
            IRepository<CustomersBalance> customersBalanceRepository
            )
        {
            _discountService = discountService;
            _customerService = customerService;
            _customersBalanceRepository = customersBalanceRepository;
        }
        public void CheckBalance(CustomersBalance balance)
        {
            var price =  _discountService.GetPremiumPrice(balance);
            if (price < balance.Amount)
            {
                balance.IsPremium = true;
                balance.Amount -= price;
                balance.ResetDate = null;
            }
            return;
        }

        public async Task<IEnumerable<CustomerBalance>> GetBalancesPaged(ScrollRequest scrollRequest)
        {
            var customer = await _customerService.GetCurrentCustomer();
            var id = customer.Id;
            Expression<Func<CustomersBalance, bool>> predicate = null;

            var typeFilter = scrollRequest.RequestFilters.Filters.FirstOrDefault(x => x.Path == "type");
            if (typeFilter != null)
            {
                bool type = false;

                if (Enum.TryParse<BalanceType>(typeFilter.Value, out var parsedType))
                {
                    if (parsedType == BalanceType.Standart) type = false;
                    else if (parsedType == BalanceType.Premium) type = true;
                }

                predicate = balance => balance.CustomerId == id && balance.IsPremium == type;
                scrollRequest.RequestFilters.Filters.Remove(typeFilter);
            }
            // return await _customersBalanceRepository.CreateScrollPaginatedResultAsync<CustomersBalance>(scrollRequest, predicate);
            return null;
        }
}