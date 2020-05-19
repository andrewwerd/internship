using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Infrastructure.Dto.Balance
{
    public class MyDiscount
    {
        public long Id;
        public long PartnerId;
        public string PartnerName;
        public decimal DiscountPercent;
        public decimal AccumulationPercent;
    }
}
