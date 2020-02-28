using System;

namespace Proiect.Models
{
    public class CurrentDiscount : Entity
    {
        public Guid CustomerId { get; set; }
        public Discount Discount { get; set; }
        public decimal Balance { get; set; }
        private decimal accumulationPercent;
        public decimal AccumulationPercent
        {
            get => accumulationPercent;
            set => accumulationPercent = Discount.AccumulationPercent;
        }
        private decimal discountPercent;
        public decimal DiscountPercent
        {
            get => discountPercent;
            set => discountPercent = Discount.DiscountPercent;

        }
    }
}