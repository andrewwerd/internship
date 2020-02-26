using System;
using System.Collections.Generic;
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
            Owners.Add(new Owner("Artur", 'M', 18));
            Owners.Add(new Owner("Andrew", 'M', 25));
            Owners.Add(new Owner("Grace", 'F', 20));
            Owners.Add(new Owner("Megane", 'F', 35));
            Owners.Add(new Owner("Forest", 'M', 43));
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
                            Owners.Add(new Owner(Name, Gender, Age));
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
                                           select new { Name = owner.Name, CarInfo = car.ToString() };
                            foreach (var i in joinList)
                            {
                                Console.WriteLine($"{i.Name} - {i.CarInfo}");
                            }
                            
                            //Use delegate to manipulate collection

                            var filteredOwners = Filter(Owners, fieldGender, filterByGender);
                            foreach (var i in filteredList)
                                Console.WriteLine(i.ToString());

                            //Use anonumous functions

                            filteredOwners = Filter(Owners, delegate ()
                            {
                                Console.WriteLine("Enter gender :");
                                var condition = Console.ReadLine()[0];
                                return condition;
                            },
                            delegate (Owner owner1, dynamic condition) { return owner1.Gender == condition; }
                            );

                            //Use lamda expression

                            filteredOwners = Filter(Owners, () => 
                            {
                                Console.WriteLine("Enter gender :");
                                var condition = Console.ReadLine()[0];
                                return condition;
                            },
                            (owner,condition)=>owner.Gender == condition);
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
        //Use delegate to manipulate collection
        #region Delegate
        public delegate bool FilterByFieldDelegate(Owner owner, dynamic condition);
        public delegate dynamic SelectFieldDelegate();
        public static List<Owner> Filter(Repository<Owner> owners,SelectFieldDelegate field, FilterByFieldDelegate filterByField)
        {
            var filteredList = new List<Owner>();
            var getField = field();
            foreach (var i in owners.GetAll())
                if (filterByField(i, getField)) filteredList.Add(i);
            if (filteredList.Count == 0)
                return null;
            else
                return filteredList;
        }
        public static dynamic fieldGender()
        {
            Console.WriteLine("Enter gender :");
            char gender = Console.ReadLine()[0];
            return gender;
        } 

        public static dynamic fieldAge()
        {
            Console.WriteLine("Enter base age :");
            int.TryParse(Console.ReadLine(), out int age);
            return age;
        }
        


        public static bool filterByGender(Owner owner, dynamic gender)
        {
            if (owner.Gender == gender)
                return true;
            else
                return false;
        }
        public static bool filterByAgeIncrease(Owner owner, dynamic age)
        {
            if (owner.Gender > age)
                return true;
            else
                return false;
        }
        public static bool filterByAgeDecrease(Owner owner, dynamic age)
        {
            if (owner.Gender < age)
                return true;
            else
                return false;
        }
        #endregion
        //Use expresion methods
 
    }
    public static class Average
    {
        public static decimal AverageAge(this Repository<Owner> owners)
        {
            int sum = 0;
            int count = owners.GetAll().Count();
            foreach (var i in owners.GetAll())
                sum += i.Age;
            return sum / count;
        }
    }
}
