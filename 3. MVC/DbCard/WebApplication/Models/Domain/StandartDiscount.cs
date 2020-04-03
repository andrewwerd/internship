using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication.Models
{
    public class StandartDiscount:Entity<long>
    {
        public decimal AmountOfDiscount { get; set; }
        public decimal DiscountPercent { get; set; }
        public long PartnerId { get; set; }
        public virtual Partner Partner { get; set; }
    }
}
