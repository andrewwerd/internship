using System;
using System.Globalization;
using System.Linq;
namespace Proiect
{
    public class TransactionService
    {
        public void Add(Filial filial, int amount, Guid customerId, Repository<Customer> customers, Repository<Partner> partners)
        {
            Transaction transaction = new Transaction();
            Partner Partner = partners.GetById(filial.PartnerId);
            CurrentDiscount Discount = customers.GetById(customerId).Discounts.FirstOrDefault(y => y.PartnerId == Partner.Id);

            if (Discount == null)
            {
                customers.GetById(customerId).Discounts.Add(new CurrentDiscount(Partner.Id));
            }

            transaction.PartnerName = Partner.Name;
            transaction.PartnerId = filial.PartnerId;
            transaction.Category = Partner.Category;
            transaction.FilialAddress = filial.Address;
            transaction.AllAmount = amount;
            transaction.AccumulationAmount = amount * Discount.AccumulationPercent;
            transaction.DiscountAmount = amount * Discount.DiscountPercent;
            transaction.DateTime = DateTime.Now;
            Discount.Balance += amount * Discount.AccumulationPercent;

            customers.GetById(customerId).TransactionsHistory.Add(transaction);
        }
    }
}
