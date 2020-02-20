using System;
using System.Collections.Generic;
using System.Text;

namespace Proiect
{
    public class CurrentDiscount
    {
        public int Id;
        public int CustomerId;
        public int Balance;
        public int AccumulationPercent;
        public int DiscountPercent;

        public Customer Customer
        {
            get => default;
            set
            {
            }
        }
    }
}