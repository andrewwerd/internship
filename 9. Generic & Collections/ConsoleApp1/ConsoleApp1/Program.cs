using System;
using System.Linq;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("" +
               "Create new customer [Create] \n " +
               "Read about some customer [Read] \n " +
               "Read about all customers [ReadAll] \n " +
               "Update information [Update] \n " +
               "Delete customer [Delete] \n " +
               "Filter list [Filter]\n" +
               "Exit");
            Repository<Owner> Owners = new Repository<Owner>();
            Repository<Car> Cars = new Repository<Car>();
            Owners.Create(new Owner("Artur", 'M', 18));
            Owners.Create(new Owner("Andrew", 'M', 25));
            Owners.Create(new Owner("Grace", 'F', 20));
            Owners.Create(new Owner("Megane", 'F', 35));
            Owners.Create(new Owner("Forest", 'M', 43));
            while (true)
            {
                string command = Console.ReadLine();
                switch (command.ToLower())
                {
                    case "create":
                        {
                            Console.Write("Enter properties of customer: \nName: ");
                            string Name = Console.ReadLine();
                            Console.Write("Gender: ");
                            char Gender = Console.ReadLine()[0];
                            Console.Write("Age: ");
                            int Age = int.Parse(Console.ReadLine());
                            Owners.Create(new Owner(Name, Gender, Age));
                            break;
                        }
                    case "read":
                        {
                            Console.Write("Give me ID = ");
                            Owner current = Owners.GetById(int.Parse(Console.ReadLine()));
                            Console.WriteLine(current.ToString());
                            if (current.CarsId != null)
                            {
                                foreach (var i in current.CarsId)
                                    Console.WriteLine($"\t{Cars.GetById(i).ToString()}");
                            }
                            break;
                        }
                    case "readall":
                        {
                            foreach (var i in Owners.GetAll())
                            {
                                Console.WriteLine(i.ToString());
                                if (i.CarsId != null)
                                {
                                    foreach (var a in i.CarsId)
                                        Console.WriteLine($"\t{Cars.GetById(a).ToString()}");
                                };
                            }
                            break;
                        }
                    case "update":
                        {
                            Console.Write("Give me Owner ID = ");
                            int Id = int.Parse(Console.ReadLine());
                            Owner current = Owners.GetById(Id);
                            Console.WriteLine("Choose field to change [Name],[Age],[Gender],[Update car list]");
                            string command1 = Console.ReadLine();
                            switch (command1.ToLower())
                            {
                                case "name":
                                    {
                                        Console.Write("\nEnter new name: ");
                                        current.Name = Console.ReadLine();
                                        break;
                                    }
                                case "age":
                                    {
                                        Console.Write("\nEnter new age: ");
                                        current.Age = int.Parse(Console.ReadLine());
                                        break;
                                    }
                                case "gender":
                                    {
                                        Console.Write("\nEnter new gender: ");
                                        current.Gender = Console.ReadLine()[0];
                                        break;
                                    }
                                case "updatecarlist":
                                    {
                                        CarListUpdate.WorkWithCars(Cars, Owners, current);
                                        break;
                                    }
                            }
                            Owners.Update(current);
                            Owners.Delete(current);
                            break;
                        }
                    case "delete":
                        {
                            Console.Write("Give me ID = ");
                            Owners.Delete(Owners.GetById(int.Parse(Console.ReadLine())));
                            break;
                        }
                    case "filter":
                        {
                            Console.WriteLine("Filter by gender, and sorted by age\n Enter gender: ");
                            char gender = Console.ReadLine()[0];
                            var filteredList = from t in Owners._context
                                               where t.Gender == 'M'
                                               orderby (t.Age)
                                               select t;
                            foreach (var i in filteredList)
                                Console.WriteLine(i);
                            Console.WriteLine("Show cars and owners");
                            var joinList = from owner in Owners._context
                                           join car in Cars._context on owner.ID equals car.OwnerId
                                           select new { Name = owner.Name, CarInfo = car.ToString()};
                            foreach (var i in joinList)
                            {
                                Console.WriteLine($"{i.Name} - {i.CarInfo}");
                            }
                            break;
                        }
                    case "exit":
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("GoodBye!");
                            Console.ResetColor();
                            return;
                        }
                }
            }
        }
    }
}
