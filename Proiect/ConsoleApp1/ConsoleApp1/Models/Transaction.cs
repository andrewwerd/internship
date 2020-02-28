using System;
using System.Collections.Generic;
using System.Text;

namespace Proiect.Models
{
    public class Transaction : Entity
    {
        public string PartnerName;
        public string FilialAddress;
        public string Category;
        public decimal AllAmount;
        public decimal amountForPay;
        public decimal AmountForPay { set
            {
                amountForPay = AllAmount - AccumulationAmount - DiscountAmount;
            } 
        }
        public decimal AccumulationAmount;
        public decimal DiscountAmount;
        public DateTime DateTime;
        public Guid CustomerId;
        public Guid PartnerId;
    }
}