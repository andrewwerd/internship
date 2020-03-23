using System;
using Proiect.Models;

namespace Proiect.Services
{
    class DiscountFactory
    {
        public void Create(Partner partner, double accumulationPercent, double discountPercent)
        {
            var discount = new Discount();

            discount.Id = Guid.NewGuid();
            discount.PartnerId = partner.Id;
            discount.AccumulationPercent = accumulationPercent;
            discount.DiscountPercent = discountPercent;

            partner.Discounts.Add(discount);
        }
    }
}

