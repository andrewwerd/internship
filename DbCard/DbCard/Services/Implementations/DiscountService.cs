using DbCard.Context;
using DbCard.Domain;
using DbCard.Infrastructure.Dto.Balance;
using DbCard.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using DbCard.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace DbCard.Services.Implementations
{
    public class DiscountService : IDiscountService
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        private readonly IRepository<CustomersBalance> _customerBalancesRepository;

        public DiscountService(
            ICustomerService customerService,
            IMapper mapper,
            IRepository<CustomersBalance> customerBalancesRepository)
        {
            _customerService = customerService;
            _mapper = mapper;
            _customerBalancesRepository = customerBalancesRepository;
        }
        public async Task<IEnumerable<MyDiscount>> GetMyDiscountsPaged(PagedRequest scrollRequest)
        {
            var customer = await _customerService.GetCurrentCustomer();
            var discounts = _customerBalancesRepository
                .Get()
                .Where(x => x.IsPremium && x.CustomerId == customer.Id)
                .SelectMany(
                    x => x.Partner.PremiumDiscounts
                    .OrderByDescending(z => z.PriceOfDiscount)
                    .Where(p => p.PriceOfDiscount < x.Amount)
                    .Take(1));
            var myDiscounts = await discounts.CreateScrollPaginatedResultAsync<Domain.PremiumDiscount, MyDiscount>(scrollRequest, _mapper);
            return myDiscounts;
        }

        public PremiumDiscount GetPremiumDiscountByBalanceAsync(CustomersBalance balance)
        {
            var discounts = balance.Partner.PremiumDiscounts.OrderBy(x => x.PriceOfDiscount);
            var discount = discounts.LastOrDefault(p => p.PriceOfDiscount < balance.Amount);
            return discount ?? discounts.Last();
        }

        public StandartDiscount GetStandartDiscountByBalanceAsync(CustomersBalance balance, decimal amount)
        {
            var discounts = balance.Partner.StandartDiscounts.OrderBy(x => x.AmountOfDiscount);
            var discount = discounts.LastOrDefault(d => d.AmountOfDiscount > amount);
            return discount ?? discounts.Last();
        }
        public async Task<decimal> GetPremiumPrice(long id)
        {
            var balance = await _customerBalancesRepository.GetById(id);
            var discount = balance.Partner.PremiumDiscounts.OrderBy(x => x.PriceOfDiscount).First();
            var price = discount.PriceOfDiscount;
            return price;
        }
    }
}
