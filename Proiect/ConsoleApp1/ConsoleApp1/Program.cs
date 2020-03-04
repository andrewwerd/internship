using System;
using System.Globalization;
using System.Linq;
using Proiect.Repository;
using Proiect.Models;
using Proiect.Services;
namespace Proiect
{
    class Program
    {
        static void Main(string[] args)
        {
           // ServiceLocator.Register<CurrentDiscountService>();
            ServiceLocator.Register<PartnerService, IPartnerService>();

            var Partners = Repository<Partner>.Instance;
           // Partners.Add(new Partner("№1", "FoodMarket", "str. Nicolae Testimitanu", 60000000));
            //TransactionService Transactions = new TransactionService();
            var Customers = Repository<Customer>.Instance;
            CustomerFactory.Create(firstName: "Andrei", lastName: "Tirsina", phoneNumber: "067729269", gender: 'M', dateOfBirth: DateTime.Parse("03.09.1999", CultureInfo.CurrentCulture));
            foreach(var i in Customers.ToList())
            Console.WriteLine(i.FirstName);
            //Console.WriteLine(Partners.ToList()[0].Id);
            //Transactions.Add(Partners.ToList().First().Filials.First(), 1000, Customers.ToList()[0].Id, Customers, Partners);
        }
    }
}
