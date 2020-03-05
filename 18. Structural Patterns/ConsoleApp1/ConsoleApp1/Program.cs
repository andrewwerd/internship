using System;
using ConsoleApp1.Proxy;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            InitialzeRepository(out Repository<Owner> Owners, out Repository<Car> Cars);
            #region Proxy
            var inspector = new Inspector();
            var carInfoPrixy = new CarInfoProxy(Cars);
            foreach(var i in carInfoPrixy.CarsInfo(inspector))
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("\n\nCars by owner access level\n");
            foreach(var i in carInfoPrixy.CarsInfo(Owners.GetById(1)))
            {
                Console.WriteLine(i);
            }
            #endregion
        }





        static void InitialzeRepository(out Repository<Owner> Owners, out Repository<Car> Cars)
        {
            Owners = new Repository<Owner>();
            Cars = new Repository<Car>();
            Owners.Add(new Owner("Artur", "Male", 18));
            Owners.Add(new Owner("Andrew", "Male", 25));
            Owners.Add(new Owner("Grace", "Female", 20));
            Owners.Add(new Owner("Megane", "Female", 35));
            Owners.Add(new Owner("Forest", "Male", 43));
            Cars.Add(new Car("Volvo", "SUV", 5, 10000, Owners.GetById(0)));
            Cars.Add(new Car("Nissan", "SpotCar", 1, 7500, Owners.GetById(0)));
            Cars.Add(new Car("Lada", "SimpleCar", 10, 2500, Owners.GetById(1)));
            Cars.Add(new Car("Renault", "SimpleCar", 5, 5000, Owners.GetById(2)));
            Cars.Add(new Car("Ferari", "SporCar", 5, 15000, Owners.GetById(0)));
            Cars.Add(new Car("Volvo", "SimpleCar", 2, 5000, Owners.GetById(0)));
            Cars.Add(new Car("Renault", "SUV", 5, 6000, Owners.GetById(3)));
            Cars.Add(new Car("Chevrolet", "SUV", 5, 8500, Owners.GetById(2)));
            Cars.Add(new Car("Ford", "SporCar", 3, 8000, Owners.GetById(4)));
            Cars.Add(new Car("Volvo", "SUV", 1, 9500, Owners.GetById(2)));
            Cars.Add(new Car("Nissan", "SimpleCar", 5, 10000, Owners.GetById(1)));
            Cars.Add(new Car("Volvo", "SUV", 3, 8000, Owners.GetById(4)));
            Cars.Add(new Car("Ferari", "SporCar", 5, 6900, Owners.GetById(2)));
            Cars.Add(new Car("Nissan", "SUV", 5, 8700, Owners.GetById(1)));
            Cars.Add(new Car("Volvo", "SimpleCar", 5, 5200, Owners.GetById(4)));
            Cars.Add(new Car("Ford", "SUV", 5, 8650, Owners.GetById(0)));
        }
    }
}
