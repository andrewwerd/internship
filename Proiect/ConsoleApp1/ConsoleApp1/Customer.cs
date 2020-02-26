
using System;
using System.Collections.Generic;

namespace Proiect
{
    public class Customer : User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public char Gender { get; set; }
        public int Age 
        { 
            get=>default;
            set
            {
                Age = DateTime.Now.Year - YearOfBirth;
            }
        }
        public int YearOfBirth { get; set; }
        public List<Transaction> TransactionsHistory;
        public List<Partner> PreferPartners;
        public List<CurrentDiscount> Discounts;
        public Customer(string firstName, string lastName, int phoneNumber, char gender, int yearOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Gender = gender;
            YearOfBirth = yearOfBirth;
            TransactionsHistory = new List<Transaction>();
            PreferPartners = new List<Partner>();
            Discounts = new List<CurrentDiscount>();
        }
    }
}