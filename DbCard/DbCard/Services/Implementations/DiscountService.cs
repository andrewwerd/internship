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
        private readonly DbCardContext _context;
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public DiscountService(
            ICustomerService customerService,
            DbCardContext context,
            IMapper mapper)
        {
            _customerService = customerService;
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<MyDiscount>> GetMyDiscountsPaged(ScrollRequest scrollRequest)
        {
            var customer = await _customerService.GetCurrentUser();
            var _balances = _context.CustomersBalances.Where(x => x.IsPremium && x.Customer.Id == customer.Id);
            var discounts = _balances
                .Select(x => _context.Partners
                    .Where(p => p.Id == x.PartnerId)
                    .SelectMany(
                       partner => partner.PremiumDiscounts)
                    .OrderBy(z => z.PriceOfDiscount)
                    .LastOrDefault(p => p.PriceOfDiscount < x.Amount));
            var myDiscounts = discounts.CreateScrollPaginatedResultAsync<Domain.PremiumDiscount, MyDiscount>(scrollRequest, _mapper);
            return await myDiscounts;
        }

        public async Task<Domain.PremiumDiscount> GetPremiumDiscountByBalanceAsync(CustomersBalance balance)
        {
            var discounts = _context.Partners
                 .Where(i => i.Id == balance.PartnerId)
                 .SelectMany(s => s.PremiumDiscounts)
                 .OrderBy(x => x.PriceOfDiscount);
            var discount = await discounts.LastOrDefaultAsync(p => p.PriceOfDiscount < balance.Amount);
            return discount ?? await discounts.LastAsync();
        }

        public async Task<Domain.StandartDiscount> GetStandartDiscountByBalanceAsync(CustomersBalance balance, decimal amount)
        {
            var discounts = _context.Partners
                .Where(i => i.Id == balance.PartnerId)
                .SelectMany(s => s.StandartDiscounts)
                .OrderBy(x => x.AmountOfDiscount);
            var discount = await discounts.LastOrDefaultAsync(d => d.AmountOfDiscount > amount);
            return discount ?? await discounts.LastAsync();
        }
        public async Task<decimal> GetPremiumPrice(CustomersBalance balance)
        {
            var price = (await _context.Partners
                .Where(i => i.Id == balance.PartnerId)
                .SelectMany(s => s.PremiumDiscounts)
                .OrderBy(x => x.PriceOfDiscount)
                .FirstAsync()).PriceOfDiscount;
            return price;
        }
    }
}
