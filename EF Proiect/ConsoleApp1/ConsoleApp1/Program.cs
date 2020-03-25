using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var db = new dbCardContext())
            {
                var users = db.Users.ToList();

                foreach(var i in users)
                    Console.WriteLine($"{i.Id}");
            }
        }
    }
}
