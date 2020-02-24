
using System.Collections.Generic;

namespace Proiect
{
    public class Customer : User
    {
        public string FirstName;
        public string LastName;
        public int PhoneNumber;
        public char Gender;
        public int Age;
        public List<Transaction> Transactions;
        public List<Partner> PreferPartners;
        public List<CurrentDiscount> Discounts;
    }
}