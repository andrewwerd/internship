using System;
using System.Collections.Generic;
using Proiect.Models;
using Proiect.Repository;

namespace Proiect.Services
{
    class CustomerFactory
    {
        public static void Create(string firstName, string lastName, string phoneNumber, char gender, DateTime dateOfBirth)
        {
            var customer = new Customer();

            customer.Id = Guid.NewGuid();
            customer.FirstName = firstName;
            customer.LastName = lastName;
            customer.PhoneNumber = phoneNumber;
            customer.Gender = gender;
            customer.DateOfBirth = dateOfBirth;

            customer.TransactionsHistory = new List<Transaction>();

            customer.PreferPartners = new List<Partner>();

            customer.Discounts = new List<CurrentDiscount>();
            customer.Notifications = new List<Notification>();

            Repository<Customer>.Instance.Add(customer);
        }
    }
}
