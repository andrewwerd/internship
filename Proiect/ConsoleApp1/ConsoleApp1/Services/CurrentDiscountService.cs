using System;
using Proiect.Models;
using System.Linq;
using Proiect.Repository;

namespace Proiect.Services
{
    class CurrentDiscountService
    {
        private Repository<CurrentDiscount> _repository;
        private IServiceLocator serviceLocator;
        public CurrentDiscountService()
        {
            _repository = Repository<CurrentDiscount>.Instance;
            serviceLocator = 
        }

        public void Create(Customer customer, Partner partner, decimal balance)
        {
            var discount = new CurrentDiscount();

            discount.Id = Guid.NewGuid();
            discount.CustomerId = customer.Id;
            discount.Discount = partner.Discounts.First();
            discount.Balance = balance;

            customer.Discounts.Add(discount);

            _repository.Add(discount);
        }
        public static void Update(CurrentDiscount discount)
        {
            var partner = Repository<Partner>.Instance.First(discount.Discount.PartnerId);
            
        }
    }
}
