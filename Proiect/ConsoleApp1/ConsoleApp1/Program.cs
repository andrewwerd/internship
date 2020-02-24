using System;

namespace Proiect
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository <Partner> Partners = new Repository<Partner>();
            Partners.Add(new Partner("№1","FoodMarket", "str. Nicolae Testimitanu",60000000));
        }
    }
}
