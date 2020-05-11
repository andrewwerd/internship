using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace DbCard.Infrastructure.Dto.Balance
{
    public class StandartBalance
    {
        public long Id { get; set; }
        public IFormFile Logo { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
        public decimal CurrentAmount { get; set; }
        public decimal PremiumAmount { get; set; }
        public DateTime ResetDate { get; set; }
        public List<StandartDiscount> Discounts { get; set; }
    }
}
