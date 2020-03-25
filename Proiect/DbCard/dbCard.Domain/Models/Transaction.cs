using System;
using System.Collections.Generic;
using System.Text;

namespace dbCard.Domain.Models
{
    public class Transaction : Entity<long>
    {
        public string PartnerName { get; set; }
        public string FilialAddress { get; set; }
        public string Category { get; set; }
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
        public long CustomerId { get; set; }
        public long FilialId { get; set; }
    }
}