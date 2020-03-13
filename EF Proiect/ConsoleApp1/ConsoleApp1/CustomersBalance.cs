using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class CustomersBalance
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int DiscountId { get; set; }
        public decimal Amount { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual PremiumDiscount Discount { get; set; }
    }
}
