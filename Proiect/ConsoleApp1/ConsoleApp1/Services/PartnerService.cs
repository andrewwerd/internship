using System;
using Proiect.Models;
using Proiect.Repository;

namespace Proiect.Services
{
    internal class PartnerService : IPartnerService
    {
        public void GetDiscount(CurrentDiscount discount)
        {
            var partner = Repository<Partner>.Instance.GetById(discount.Discount.PartnerId);
            var level = partner.Levels.FindLastIndex(x => x < discount.Balance);
            discount.Discount = partner.Discounts[level];
        }
    }

}
