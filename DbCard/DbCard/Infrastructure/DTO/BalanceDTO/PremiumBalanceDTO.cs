using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Infrastructure.DTO.BalanceDTO
{
    public class PremiumBalanceDTO
    {
        public long Id { get; set; }
        public IFormFile Logo { get; set; }
        public string Subcategory { get; set; }
        public decimal CurrentAmount { get; set; }
        public decimal NextAmount { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal AccumulatingPercent { get; set; }
        public List<StandartDiscountDTO> Discounts { get; set; }
    }
}
