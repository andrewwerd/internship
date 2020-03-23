﻿using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class PremiumDiscount
    {
        public long Id { get; set; }
        public decimal PriceOfDiscount { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal AccumulationPercent { get; set; }
        public long PartnerId { get; set; }

        public virtual Partners Partner { get; set; }
    }
}
