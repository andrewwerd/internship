using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class CustomersBalance
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public long PartnerId { get; set; }
        public decimal? PaidAmount { get; set; }
        public decimal? AccumulatedAmount { get; set; }
        public bool IsPremium { get; set; }
        public DateTime? ResetDate { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual Partners Partner { get; set; }
    }
}
