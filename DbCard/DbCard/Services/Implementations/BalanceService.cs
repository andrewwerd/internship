using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly IDiscountService _discountService;
        private readonly ICustomerService _customerService;
        private readonly IRepository<CustomersBalance> _customersBalanceRepository;

        public BalanceService(
            IDiscountService discountService,
            ICustomerService customerService,
            IRepository<CustomersBalance> customersBalanceRepository,
            IMapper mapper
            )
        {
            _mapper = mapper;
            _discountService = discountService;
            _customerService = customerService;
            _customersBalanceRepository = customersBalanceRepository;
        }
        public async Task CheckBalance(CustomersBalance balance)
        {
            var price = await _discountService.GetPremiumPrice(balance.Id);
            if (price < balance.Amount)
            {
                balance.IsPremium = true;
                balance.Amount -= price;
                balance.ResetDate = null;
            }
            return;
        }

        public async Task<IEnumerable<CustomerBalance>> GetBalancesPaged(PagedRequest scrollRequest)
        {
            var customer = await _customerService.GetCurrentCustomer();
            var id = customer.Id;
            Expression<Func<CustomersBalance, bool>> predicate = null;
            var typeFilter = scrollRequest.RequestFilters.Filters.FirstOrDefault(x => x.Path == "type");
            var balances = new List<CustomerBalance>();
            if (typeFilter != null)
            {
                scrollRequest.RequestFilters.Filters.Remove(typeFilter);
                if (Enum.TryParse<BalanceType>(typeFilter.Value, out var parsedType))
                {
                    if (parsedType == BalanceType.Standart)
                    {
                        predicate = balance => balance.CustomerId == id && balance.IsPremium == false;
                        var standartBalance = await _customersBalanceRepository.GetScrollData<StandartBalance>(scrollRequest, predicate);
                        balances = standartBalance.Select(x => _mapper.Map<CustomerBalance>(x)).ToList();
                    }
                    else if (parsedType == BalanceType.Premium)
                    {
                        predicate = balance => balance.CustomerId == id && balance.IsPremium == true;
                        var premiumBalance = await _customersBalanceRepository.GetScrollData<PremiumBalance>(scrollRequest, predicate);
                        balances = premiumBalance.Select(x => _mapper.Map<CustomerBalance>(x)).ToList();
                    }
                }
            }
            return balances;
        }
    }
}