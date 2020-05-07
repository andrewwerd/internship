using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DbCard.Infrastructure.DTO.Balance
{
    public class PremiumBalanceDto
    {
        public long Id { get; set; }
        public IFormFile Logo { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
        public decimal CurrentAmount { get; set; }
        public PremiumDiscountDto curDiscount
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
        public List<PremiumDiscountDto> Discounts { get; set; }
    }
}
