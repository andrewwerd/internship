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
        private readonly IRepository<CustomersBalance> _balancesRepository;

        public DiscountService(IRepository<CustomersBalance> balancesRepository, DbCardContext context)
        {
            _context = context;
            _balancesRepository = balancesRepository;
        }
        public async Task<IEnumerable<MyDiscount>> GetMyDiscounts(long id)
        {
            var _balances = _context.CustomersBalances.Where(x => x.IsPremium && x.CustomerId == id);
            var discount = _balances
                .Select(x => _context.Partners
                    .Where(p => p.Id == x.PartnerId)
                    .SelectMany(
                       premiumDiscount => premiumDiscount.PremiumDiscounts, 
                       (partner, premiumDiscount) => new { premiumDiscount, partner })
                    .OrderBy(z => z.premiumDiscount.PriceOfDiscount)
                    .LastOrDefault(p => p.premiumDiscount.PriceOfDiscount < x.Amount)ue);
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
    }
}
