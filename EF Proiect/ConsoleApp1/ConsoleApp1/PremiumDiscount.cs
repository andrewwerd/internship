using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class PremiumDiscount
    {
        public PremiumDiscount()
        {
            CustomersBalance = new HashSet<CustomersBalance>();
        }

        public int Id { get; set; }
        public decimal PriceOfDiscount { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal AccumulationPercent { get; set; }
        public int PartnerId { get; set; }

        public virtual Partners Partner { get; set; }
        public virtual ICollection<CustomersBalance> CustomersBalance { get; set; }
    }
}
