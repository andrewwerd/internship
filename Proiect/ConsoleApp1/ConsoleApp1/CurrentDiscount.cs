using System;
using System.Collections.Generic;
using System.Text;

namespace Proiect
{
    public class CurrentDiscount : Entity
    {
        public Guid CustomerId;
        public Guid PartnerId;
        public decimal Balance;
        public decimal AccumulationPercent;
        public decimal DiscountPercent;

        public CurrentDiscount(Guid partnerId)
        {
            Balance = 0;
            PartnerId = partnerId;
            AccumulationPercent = DiscountPercent = 0;
        }
        private void SetDiscount(Repository<Partner> Partners)
        {
            (AccumulationPercent, DiscountPercent) = Partners.GetById(PartnerId).GetDiscount(Balance);
        }
    }
}