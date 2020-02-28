using System;
using Proiect.Models;

namespace Proiect.Services
{
    class DiscountService
    {
        public static void Create(Partner partner,decimal accumulationPercent, decimal discountPercent)
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

