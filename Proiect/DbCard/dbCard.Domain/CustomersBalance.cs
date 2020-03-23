using System;
using System.Collections.Generic;
using System.Text;

namespace dbCard.Domain
{
    public class CustomersBalance : Entity<long>
    {
        public decimal? AccumulatedAmount { get; set; }
        public decimal? PaidAmount { get; set; }
        public DateTime? ResetDate { get; set; }
        public bool IsPremium { get; set; }
        public long CustomerId { get; set; }
        public long PartnerId { get; set; }
        public virtual Partner Partner { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
