using System;
using System.Linq;
namespace Proiect
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository<Partner> Partners = Repository<Partner>.Instance;
            Partners.Add(new Partner("№1","FoodMarket", "str. Nicolae Testimitanu",60000000));
            TransactionService Transactions = new TransactionService();
            Repository<Customer> Customers = Repository<Customer>.Instance;
            Customers.Add(new Customer(firstName : "Andrei", lastName: "Tirsina", phoneNumber: 67729269, gender:'M', yearOfBirth: 1999));
            Console.WriteLine(Partners.ToList()[0].Id);
            Transactions.Add(Partners.ToList().First().Filials.First(),1000, Customers.ToList()[0].Id, Customers, Partners);
        }
    }
}
