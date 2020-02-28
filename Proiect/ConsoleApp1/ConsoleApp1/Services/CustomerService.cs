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
       
    }
}
