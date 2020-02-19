using System;
using System.Collections.Generic;
using System.Text;

namespace Proiect
{
    public class Customer : User
    {
        public int PhoneNumber;
        public char Gender;
        public int Age;
        public List<Transaction> Transactions;
        public List<Partner> PreferPartners;
        public List<CurrentDiscount> Account;
    }
}