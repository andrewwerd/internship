using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Infrastructure.Dto.Balance
{
    public class MyDiscount
    {
        public long Id { get; set; }
        public long PartnerId { get; set; }
        public string PartnerName { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal AccumulationPercent { get; set; }
    }
}
