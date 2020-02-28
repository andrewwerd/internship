using System;
using System.Collections.Generic;

namespace Proiect.Models
{
    public class Customer : User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public char Gender { get; set; }
        public int Age
        {
            get;
            private set;
        }
        private DateTime dateOfBirth;
        public DateTime DateOfBirth
        {
            get => dateOfBirth;
            set
            {
               dateOfBirth = value;
                Age = (int)((DateTime.Today - value).TotalDays/365.2425);
            }
        }

        public List<Transaction> TransactionsHistory;
        public List<Partner> PreferPartners;
        public List<CurrentDiscount> Discounts;
    }
}