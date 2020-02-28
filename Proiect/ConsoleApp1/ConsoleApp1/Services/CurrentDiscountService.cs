using System;
using Proiect.Models;
using System.Linq;
using Proiect.Repository;

namespace Proiect.Services
{
    class CurrentDiscountService
    {
        private readonly IPartnerService service;

        public CurrentDiscountService()
        {
            this.service = ServiceLocator.GetService<IPartnerService>();
        }

        public void Update(CurrentDiscount discount)
        {
            service.GetDiscount(discount);
        }
    }
}
