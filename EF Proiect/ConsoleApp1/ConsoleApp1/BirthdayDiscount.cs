using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class BirthdayDiscount
    {
        public int Id { get; set; }
        public decimal DiscountPercent { get; set; }
        public int PartnerId { get; set; }

        public virtual Partners Partner { get; set; }
    }
}
