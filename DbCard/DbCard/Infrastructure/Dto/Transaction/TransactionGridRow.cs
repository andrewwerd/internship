using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Infrastructure.Dto.Transaction
{
    public class TransactionGridRow
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public string PartnerName { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
        public decimal AllAmount { get; set; }
        public decimal AmountForPay { get; set; }
        public decimal DiscountAmount { get; set; } 
        public decimal AccumulationAmount { get; set; }
        public DateTime DateTime { get; set; }
        public string Address { get; set; }
    }
}
