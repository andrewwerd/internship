using System;
using System.Linq;
namespace Proiect
{
    public class TransactionRepository<T> : Repository<T> where T : Transaction
    {
        public void Add(Filial Filial, int Amount, Guid CustomerId, Repository<Customer> Customers, Repository<Partner> Partners)
        {
            Transaction transaction = new Transaction();
            Partner Partner = Partners.GetById(Filial.PartnerId);
            CurrentDiscount Discount = Customers.GetById(CustomerId).Discounts.FirstOrDefault(y => y.PartnerId == Partner.Id);
            if (Discount == null) Customers.GetById(CustomerId).Discounts.Add(new CurrentDiscount(Partner.Id));
            transaction.PartnerName = Partner.Name;
            transaction.PartnerId = Filial.PartnerId;
            transaction.Category = Partner.Category;
            transaction.FilialAddress = Filial.Address;
            transaction.AllAmount = Amount;
            transaction.AccumulationAmount = Amount * Discount.AccumulationPercent;
            transaction.DiscountAmount = Amount * Discount.DiscountPercent;
            transaction.DateTime = DateTime.Now;
            Customers.GetAll().FirstOrDefault(x => x.Id == CustomerId).Transactions.Add(transaction);
            Discount.Balance += Amount * Discount.AccumulationPercent;
        }
    }
}
