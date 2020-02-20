using System;
using System.Collections.Generic;
using System.Text;

namespace Proiect
{
    public class Transaction
    {
        public string PartnerName;
        public string FilialAddress;
        public string Category;
        public int AllAmount;
        public int AccumulationAmount {
            get {
                return AccumulationAmount;
            } 
            set 
            {
                AccumulationAmount = AllAmount * AccumulationPercent/100;
            }
        }
        public int DiscountAmount
        {
            get
            {
                return DiscountAmount;
            }
            set
            {
                DiscountAmount = AllAmount * DiscountPercent / 100;
            }
        }
        public DateTime DateTime;
        public int Id;
        public int CustomerId;
        public int PartnerId;

        public Customer Customer
        {
            get => default;
            set
            {
            }
        }
    }
}