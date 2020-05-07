using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Infrastructure.DTO.Balance
{
    public class StandartBalanceDto
    {
        public long Id { get; set; }
        public IFormFile Logo { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
        public decimal CurrentAmount { get; set; }
        public decimal PremiumAmount { get; set; }
        public DateTime ResetDate { get; set; }
        public List<StandartDiscountDto> Discounts { get; set; }
    }
}
