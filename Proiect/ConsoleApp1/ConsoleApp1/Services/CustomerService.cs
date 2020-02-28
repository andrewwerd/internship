using System;
using System.Collections.Generic;
using Proiect.Models;
using Proiect.Repository;

namespace Proiect.Services
{
    class CustomerService
    {
        private Repository<Customer> _customerRepository;

        public CustomerService()
        {
            _customerRepository = Repository<Customer>.Instance;
        }
        public void Create(string firstName, string lastName, string phoneNumber, char gender, DateTime dateOfBirth)
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

            _customerRepository.Add(customer);
        }
    }
}
