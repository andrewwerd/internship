using System;
using System.Globalization;
using System.Linq;

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





            var result = Owners.GetAll().SelectMany(x => x.Cars, (x, car) =>);
            var result = Owners.GetAll().Where(x => (x.Cars.Where(y => y.Name == "Volvo").Count() > 0));
           



            var item1 = Owners.GetAll().Where(x => x.Cars.Any(y => y.Name == "Volvo"));
            foreach (var item in item1)
            {
                Console.WriteLine(item.ToString());
            }














            //Console.WriteLine("Filter by gender, and sorted by age\n Enter gender: ");
            //string gender = Console.ReadLine();
            //var filteredList = from t in Owners.GetAll()
            //                   where t.Gender.ToUpper() == gender.ToUpper()
            //                   orderby (t.Age)
            //                   select t;

            //var andrewsCars = Cars.GetAll()
            //    .Where(x => x.Owner.Name.Contains("Andrew"))
            //    .Where(x => x.Name.Contains("Nissan"))
            //    .OrderByDescending(x => x.Price);


            //var sdas = Owners.GetAll()
            //    .SelectMany(x => x.Cars, (x, car) => new { Name = x.Name, Car = car });
            //foreach (var item in andrewsCars)
            //{
            //    Console.WriteLine($"{item.ToString()}");
            //}
            //foreach (var i in filteredList)
            //    Console.WriteLine(i);
            //Console.WriteLine("Show cars and owners");
            //var AutoparcInfo = Owners.GetAll()
            //    .Select(x =>
            //    new
            //    {
            //        Name = x.Name,
            //        AutoparcPrice = Cars.GetAll().Where(y => y.Owner == x).Select(y => y.Price).Aggregate((sum, price) => sum + price),
            //        Cars = Cars.GetAll().Where(y => y.Owner == x).ToList()
            //    })
            //    .ToList()
            //    .OrderBy(x => x.Name);

            //var AutoParcInfo2 = Owners.GetAll()
            //    .GroupBy(
            //    x => x.Name,
            //    x => x.Cars,
            //    (OwnerName, cars) =>
            //    new
            //    {
            //        Name = OwnerName,
            //        Count = cars.Count()
            //    });
            //foreach (var item in AutoParcInfo2)
            //{
            //    Console.WriteLine($"{item.Name} - {item.Count} ");
            //}
            //foreach (var item in AutoparcInfo)
            //{
            //    Console.WriteLine($"{item.Name} - Price of autoparc = {item.AutoparcPrice.ToString("C",CultureInfo.InvariantCulture)}\n");
            //    foreach (var i in item.Cars)
            //    {
            //        Console.WriteLine($"{i.ToString()}");
        }
    }
    }
