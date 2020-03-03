using System;
using System.Collections.Generic;
using Proiect.Models;
using Proiect.Repository;

namespace Proiect.Services
{
    class CustomerService
    {
       public static void AddPreferPartner(Customer customer, Partner partner)
        {
            customer.PreferPartners.Add(partner);

        }
    }
}
