using System;
using System.Linq;
using Proiect.Models;
using Proiect.Repository;



namespace Proiect.Services
{
    class CurrentDiscountFactory
    {
        public void Create(Customer customer, Filial filial, decimal balance)
        {
            var discount = new CurrentDiscount();
            var partner = Repository<Partner>.Instance.GetById(filial.PartnerId);

            discount.Id = Guid.NewGuid();
            discount.CustomerId = customer.Id;
            discount.Discount = partner.Discounts.First();
            discount.Balance = balance;

            customer.Discounts.Add(discount);
           
           Repository<CurrentDiscount>.Instance.Add(discount);
        }
    }
}
