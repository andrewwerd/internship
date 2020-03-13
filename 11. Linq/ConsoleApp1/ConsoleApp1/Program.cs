using System;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository<Owner> Owners = new Repository<Owner>();
            Repository<Car> Cars = new Repository<Car>();
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

            foreach (var item in Cars.GetAll())
            {
                var current = Owners.GetById(item.Owner.ID);
                current.Cars.Add(item);
            }
             
            var result =
                Owners.GetAll()
                .SelectMany(owner => owner.Cars, (owner, car) => new { Owner = owner, Car = car.Name })
                .Where(ownerWithCar => ownerWithCar.Car == "Nissan")
                .Select(z => z.Owner)
                .Distinct();

            var r1 = Owners.GetAll()
                .GroupJoin(Cars._context,
                owner => owner,
                car => car.Owner,
                (owner, car) =>
                new { Owner = owner, Car = car });

            foreach (var item in r1)
            {
                Console.WriteLine(item.Owner);
                foreach (var i1 in item.Car)
                {
                    Console.WriteLine(i1);
                }
            }

            Console.WriteLine();
            Console.WriteLine();

            var result1 = Cars.GetAll().Where(x => x.Name == "Nissan").Select(x => x.Owner).Distinct();

            foreach (var item in result1)
            {
                Console.WriteLine(item.ToString());
            }
            
        }
    }
}
