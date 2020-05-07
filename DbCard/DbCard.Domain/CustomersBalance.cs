using System;
using System.Collections.Generic;
using System.Text;

namespace DbCard.Domain
{
    public class CustomersBalance : Entity<long>
    {
        public decimal Amount { get; set; }
        public DateTime? ResetDate { get; set; }
        public bool IsPremium { get; set; }
        public long CustomerId { get; set; }
        public long PartnerId { get; set; }
        public virtual Partner Partner { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
