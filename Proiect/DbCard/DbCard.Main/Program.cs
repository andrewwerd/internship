using System;
using System.Linq;
using dbCard.Context;


namespace dbCard.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new dbCardContext())
            {
                var users = db.Users.ToList();
                var customers = db.Customers.ToList();
                foreach (var u in customers)
                {
                    Console.WriteLine($"{u.Id}-{u.User.UserName}");
                }
            }
            Console.Read();
        }
    }
}
