using System;
using System.Collections.Generic;
using System.Text;

namespace Proiect
{
    public class Filial
    {
        public int Id;
        public int PartnerId;
        public string Address;
        public int PhoneNumber;

        public Transaction CreateTransaction(int Amount, int CustomerId)
        {
            Transaction transaction = new Transaction();
            transaction.PartnerName = Name;
            transaction.PartnerId = PartnerId;
            transaction.Category = Category;
            transaction.FilialAddress = Address; 
            transaction.AllAmount = Amount;
            return transaction;
        }
    }
}