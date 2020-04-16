using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Infrastructure.DTO.Balance
{
    public class PremiumDiscountDto
    {
        public long Id { get; set; }
        public decimal PriceOfDiscount { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal AccumulationPercent { get; set; }
    }
}
