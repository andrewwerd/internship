using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DbCard.Infrastructure.Dto.Balance
{
    public class CustomerBalance
    {
        public long Id { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
        public decimal CurrentAmount { get; set; }
        public decimal? NextAmount
        {
            get
            {
                var d = Discounts.OrderBy(x=>x.PriceOfDiscount).FirstOrDefault(x => x.PriceOfDiscount > CurrentAmount);
                return (d != null) ? d.PriceOfDiscount : Discounts.Last().PriceOfDiscount;
            }
        }
        public decimal? PremiumAmount { get; set; }
        public DateTime? ResetDate { get; set; }
        public decimal? DiscountPercent => CurDiscount.DiscountPercent;
        public decimal? AccumulatingPercent=> CurDiscount.AccumulatingPercent;
        public PremiumDiscount CurDiscount => PremiumDiscounts.LastOrDefault(x => x.PriceOfDiscount < CurrentAmount);
        public List<PremiumDiscount> PremiumDiscounts { get; set; }
        public List<StandartDiscount> StandartDiscounts { get; set; }
    }
}
