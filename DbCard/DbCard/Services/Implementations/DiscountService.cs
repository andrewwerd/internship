using DbCard.Context;
using DbCard.Domain;
using DbCard.Infrastructure.Dto.Balance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Services.Implementations
{
    public class DiscountService: IDiscountService
    {
        private readonly DbCardContext _context;
        private readonly ICustomerService _customerService;

        public DiscountService(
            ICustomerService customerService,
            DbCardContext context)
        {
            _customerService = customerService;
            _context = context;
        }
        public async Task<IEnumerable<MyDiscount>> GetMyDiscounts(string barcode)
        {
            var _balances = _context.CustomersBalances.Where(x => x.IsPremium && x.Customer.Barcode == barcode);
            var discount = _balances
                .Select(x => _context.Partners
                    .Where(p => p.Id == x.PartnerId)
                    .SelectMany(
                       premiumDiscount => premiumDiscount.PremiumDiscounts, 
                       (partner, premiumDiscount) => new { premiumDiscount, partner })
                    .OrderBy(z => z.premiumDiscount.PriceOfDiscount)
                    .LastOrDefault(p => p.premiumDiscount.PriceOfDiscount < x.Amount));
            var myDiscounts = discount
                  .Select(x => new MyDiscount()
                  {
                      Id = x.premiumDiscount.Id,
                      AccumulationPercent = x.premiumDiscount.AccumulatingPercent,
                      DiscountPercent = x.premiumDiscount.DiscountPercent,
                      PartnerId = x.premiumDiscount.PartnerId,
                      PartnerName = x.partner.Name
                  }).ToListAsync();
            return await myDiscounts;
        }

        public async Task<Domain.PremiumDiscount> GetPremiumDiscountByBalanceAsync(CustomersBalance balance)
        {
            var discounts = _context.Partners
                 .Where(i => i.Id == balance.PartnerId)
                 .SelectMany(s => s.PremiumDiscounts)
                 .OrderBy(x => x.PriceOfDiscount); 
            var discount = discounts.LastOrDefaultAsync(p => p.PriceOfDiscount < balance.Amount);
            if (await discount == null) discount = discounts.LastAsync();
            return await discount;
        }

        public async Task<Domain.StandartDiscount> GetStandartDiscountByBalanceAsync(CustomersBalance balance, decimal amount)
        {
            var discounts = _context.Partners
                .Where(i => i.Id == balance.PartnerId)
                .SelectMany(s => s.StandartDiscounts)
                .OrderBy(x => x.AmountOfDiscount);
             var discount = discounts.LastOrDefaultAsync(d => d.AmountOfDiscount > amount);
            if ((await discount) == null) discount = discounts.LastAsync();
            return await discount;
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
