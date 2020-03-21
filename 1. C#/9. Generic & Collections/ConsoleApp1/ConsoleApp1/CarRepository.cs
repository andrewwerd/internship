using System;

namespace ConsoleApp1
{
    public class CarListUpdate
    {
        static public void WorkWithCars(Repository<Car> Cars, Repository<Owner> Owners, Owner CurrentOwner)
        {
            Console.WriteLine("" +
              "Add new car [Add] \n" +
              "Read about some car [Read] \n" +
              "Read about all cars [ReadAll] \n" +
              "Update information [Update] \n" +
              "Delete car [Delete] \n" +
              "Sell car [sell] \n" +
              "Filter list [Filter]\n" +
              "Exit");
            while (true)
            {
                string command = Console.ReadLine();
                switch (command.ToLower())
                {
                    case "add":
                        {
                            Car NewCar = new Car();
                            Console.Write("Enter properties of car: \nName: ");
                            NewCar.Name = Console.ReadLine();
                            Console.Write("Category: ");
                            NewCar.Category = Console.ReadLine();
                            Console.Write("Age: ");
                            NewCar.Age = int.Parse(Console.ReadLine());
                            NewCar.OwnerId = CurrentOwner.ID;
                            Cars.Add(NewCar);
                            CurrentOwner.CarsId.Add(NewCar.ID);
                            break;
                        }
                    case "read":
                        {
                            if (CurrentOwner.CarsId != null)
                            {
                                Console.Write("Give me Car ID = ");
                                int CarId = int.Parse(Console.ReadLine());
                                bool flag = true;
                                for (int i = 0; i < CurrentOwner.CarsId.Count; i++)
                                {
                                    if (CarId == CurrentOwner.CarsId[i])
                                    {
                                        Console.WriteLine(Cars.GetById(CarId));
                                        flag = false;
                                        break;
                                    }
                                }
                                if(flag)
                                Console.WriteLine("This owner hasn't such car");
                            }
                            else
                                Console.WriteLine("This owner hasn't cars");
                            break;
                        }
                    case "readall":
                        {
                            if (CurrentOwner.CarsId != null)
                            {
                                foreach (var i in Cars.GetAll())
                                {
                                    Console.WriteLine(i.ToString());
                                }
                            }
                            else
                                Console.WriteLine("This owner hasn't cars");

                            break;
                        }
                    case "update":
                        {
                            Console.Write("Give me Car ID = ");
                            int Id = int.Parse(Console.ReadLine());
                            Car CurrentCar = Cars.GetById(Id);
                            Console.WriteLine("Choose field to change [Name],[Category],[Age]");
                            string command1 = Console.ReadLine();
                            switch (command1.ToLower())
                            {
                                case "name":
                                    {
                                        Console.Write("\nEnter new name: ");
                                        CurrentCar.Name = Console.ReadLine();
                                        break;
                                    }
                                case "age":
                                    {
                                        Console.Write("\nEnter new age: ");
                                        CurrentCar.Age = int.Parse(Console.ReadLine());
                                        break;
                                    }
                                case "category":
                                    {
                                        Console.Write("\nEnter new gender: ");
                                        CurrentCar.Category = Console.ReadLine();
                                        break;
                                    }
                            }
                            Cars.Update(CurrentCar);
                            Cars.Delete(CurrentCar);
                            break;
                        }
                    case "delete":
                        {
                            if (CurrentOwner.CarsId != null)
                            {
                                Console.Write("Give me Car ID = ");
                                int CarId = int.Parse(Console.ReadLine());
                                bool flag = true;
                                for (int i = 0; i < CurrentOwner.CarsId.Count; i++)
                                {
                                    if (CarId == CurrentOwner.CarsId[i])
                                    {
                                        Cars.Delete(Cars.GetById(CarId));
                                        CurrentOwner.CarsId.RemoveAt(i);
                                        flag = false;
                                        break;
                                    }
                                }
                                if (flag)
                                Console.WriteLine("This owner hasn't such car");

                            }
                            else
                                Console.WriteLine("This owner hasn't cars");
                            break;
                        }
                    case "sell":
                        {
                            if (CurrentOwner.CarsId != null)
                            {
                                Console.Write("Give me Car ID = ");
                                int CarId = int.Parse(Console.ReadLine());
                                bool flag = true;
                                for (int i = 0; i < CurrentOwner.CarsId.Count; i++)
                                {
                                    if (CarId == CurrentOwner.CarsId[i])
                                    {
                                        Console.WriteLine("Enter Id next owner of the car: ");
                                        Owner NextOwner = Owners.GetById(int.Parse(Console.ReadLine()));
                                        NextOwner.CarsId.Add(CarId);
                                        CurrentOwner.CarsId.RemoveAt(i);
                                        Cars.GetById(CarId).OwnerId = NextOwner.ID;
                                        flag = false;
                                        break;
                                    }
                                }
                                if (flag)Console.WriteLine("This owner hasn't such car");

                            }
                            else
                                Console.WriteLine("This owner hasn't cars");
                            break;
                        }
                    case "exit":
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Back to the owners!");
                            Console.ResetColor();
                            return;
                        }
                }
            }
        }
    }
}
