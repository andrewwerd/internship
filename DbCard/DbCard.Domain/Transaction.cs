using System;
using System.Collections.Generic;
using System.Text;

namespace DbCard.Domain
{
    public class Transaction : Entity<long>
    {
        public string PartnerName { get; set; }
        public string Address { get; set; }

        public decimal AllAmount { get; set; }
        private decimal amountForPay;
        public decimal AmountForPay
        {
            get => amountForPay;
            set => amountForPay = AllAmount - AccumulationAmount - DiscountAmount;
        }
        public decimal AccumulationAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public DateTime DateTime { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Filial Filial { get; set; }
        public virtual Category Category { get; set; }
        public virtual Subcategory Subcategory { get; set; }
        public long CustomerId { get; set; }
        public long? FilialId { get; set; }
        public long SubcategoryId { get; set; }
        public long CategoryId { get; set; }
    }
}