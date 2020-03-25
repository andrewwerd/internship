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
                foreach (var u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.UserName} - {u.Password} - {u.Email}");
                }
            }
            Console.Read();
        }
    }
}
