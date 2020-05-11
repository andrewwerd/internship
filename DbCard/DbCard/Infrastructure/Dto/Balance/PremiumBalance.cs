using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace DbCard.Infrastructure.Dto.Balance
{
    public class PremiumBalance
    {
        public long Id { get; set; }
        public IFormFile Logo { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
        public decimal CurrentAmount { get; set; }
        public PremiumDiscount curDiscount
        {
            get
            {
                return Discounts.LastOrDefault(x => x.PriceOfDiscount < CurrentAmount);
            }
        }
        public decimal NextAmount
        {
            get
            {
                var d = Discounts.FirstOrDefault(x => x.PriceOfDiscount > CurrentAmount);
                return (d != null) ? d.PriceOfDiscount : Discounts.Last().PriceOfDiscount;
            }
        }
        public decimal DiscountPercent
        {
            get
            {
                return curDiscount.DiscountPercent;
            }
        }
        public decimal AccumulatingPercent
        {
            get
            {
                return curDiscount.AccumulatingPercent;
            }
        }
        public List<PremiumDiscount> Discounts { get; set; }
    }
}
