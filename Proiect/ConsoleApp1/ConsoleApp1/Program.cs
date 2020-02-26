using System;
using System.Linq;
namespace Proiect
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository <Partner> Partners = new Repository<Partner>();
            Partners.Add(new Partner("№1","FoodMarket", "str. Nicolae Testimitanu",60000000));
            TransactionRepository Transactions = new TransactionRepository();
            Repository<Customer> Customers = new Repository<Customer>();
            Customers.Add(new Customer(firstName : "Andrei", lastName: "Tirsina", phoneNumber: 67729269, gender:'M', yearOfBirth: 1999));
            Console.WriteLine(Partners.ToList()[0].Id);
            Transactions.Add(Partners.ToList()[0].Filials.First(),1000, Customers.ToList()[0].Id, Customers, Partners);
        }
    }
}
