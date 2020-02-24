using System;

namespace Proiect
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository <Partner> Partners = new Repository<Partner>();
            for (int i = 0; i < 10; i++) 
            Partners.Add(new Partner());
            foreach (var i in Partners.GetAll())
                Console.WriteLine(i.Id);
        }
    }
}
