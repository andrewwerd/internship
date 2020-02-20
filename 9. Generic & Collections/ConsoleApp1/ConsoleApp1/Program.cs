using System;
using System.Collections.Generic;
using System.Linq;
namespace ConsoleApp1
{
    public interface IGenericRepository<T> where T : Entity
    {
        void Create(T item);
        T GetById(int Id);
        IEnumerable<T> GetAll();
        void Delete(T item);
        void Update(T item);
    }
    public class Repository<T> : IGenericRepository<T> where T : Entity
    {
        public List<T> _context;
        public Repository()
        {
            _context = new List<T>();
        }
        public void Create(T item)
        {
            if (_context.Count > 0)
                item.ID = _context[_context.Count - 1].ID + 1;
            _context.Add(item);

        }
        public void Delete(T item)
        {
            for (int i = 0; i < _context.Count; i++)
                if (item.ID == _context[i].ID)
                {
                    _context.RemoveAt(i);
                    break;
                }
        }
        public T GetById(int id)
        {
            T item = _context.Find(x => x.ID == id);
            if (item == null) throw new Exception();
            return item;
        }
        public IEnumerable<T> GetAll()
        {
            return _context;
        }
        public void Update(T item)
        {
            for (int i = 0; i < _context.Count; i++)
                if (item.ID == _context[i].ID)
                {
                    _context.Insert(i, item);
                    break;
                }
        }
    }
    public abstract class Entity : IComparable
    {
        public int ID { get; set; }

        public int CompareTo(object obj)
        {
            if (obj != null)
            {
                Entity a = (Entity)obj;
                return this.ID.CompareTo(a.ID);
            }
            else
                throw new NotImplementedException();
        }
    }
    public class Owner : Entity
    {
        public string Name { get; set; }
        public char Gender { get; set; }
        public int Age { get; set; }
        public List<int>? CarsId;
        public Owner() { }
        public Owner(string name, char gender, int age)
        {
            Name = name;
            Gender = gender;
            Age = age;
            CarsId = new List<int>();
        }
        public override string ToString()
        {
            return $"Owner ID:{ID}\nName: {Name}, Gender: {(Gender == 'M' ? "Male" : "Female")}, Age: {Age} years";
        }
    }
    public class Car : Entity
    {
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int MaxSpeed
        {
            get
            {
                return MaxSpeed;
            }
            set
            {
                switch (Category)
                {
                    case "SimpleCar":
                        {
                            MaxSpeed = 120;
                            break;
                        }
                    case "SportCar":
                        {
                            MaxSpeed = 250;
                            break;
                        }
                    case "SUV":
                        {
                            MaxSpeed = 100;
                            break;
                        }
                }
            }
        }
        public int Power
        {

            get
            {
                return Power;
            }
            set
            {
                switch (Category)
                {
                    case "SimpleCar":
                        {
                            Power = 750;
                            break;
                        }
                    case "SportCar":
                        {
                            Power = 500;
                            break;
                        }
                    case "SUV":
                        {
                            Power = 1000;
                            break;
                        }
                }
            }
        }
        public int Age { get; set; }
        public Car() { }
        public Car(string name, string category, int age, int ownerId)
        {
            Name = name;
            Age = age;
            Category = category;
            OwnerId = ownerId;
        }
        public Car(string name, string category, int age)
        {
            Name = name;
            Age = age;
            Category = category;
        }
        public override string ToString()
        {
            return $"Car ID:{ID}\n\tName: {Name}, Category: {Category}, Age: {Age} years, Max Speed: {MaxSpeed}, Power: {Power}";
        }
    }
    public class CarRepository
    {
        static public void WorkWithCars(Repository<Car> Cars, Repository<Owner> Owners, Owner CurrentOwner)
        {
            Console.WriteLine("" +
              "Add new car [Create] \n " +
              "Read about some car [Read] \n " +
              "Read about all cars [ReadAll] \n " +
              "Update information [Update] \n " +
              "Delete car [Delete] \n " +
              "Sell car [sell] \n " +
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
                            Cars.Create(NewCar);
                            CurrentOwner.CarsId.Add(NewCar.ID);
                            break;
                        }
                    case "read":
                        {
                            if (CurrentOwner.CarsId != null)
                            {
                                Console.Write("Give me Car ID = ");
                                int CarId = int.Parse(Console.ReadLine());
                                for (int i = 0; i < CurrentOwner.CarsId.Count; i++)
                                {
                                    if (CarId == CurrentOwner.CarsId[i])
                                    {
                                        Console.WriteLine(Cars.GetById(CarId));
                                        break;
                                    }
                                }
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
                                case "gender":
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
                                for (int i = 0; i < CurrentOwner.CarsId.Count; i++)
                                {
                                    if (CarId == CurrentOwner.CarsId[i])
                                    {
                                        Cars.Delete(Cars.GetById(CarId));
                                        CurrentOwner.CarsId.RemoveAt(i);
                                        break;
                                    }
                                }
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
                                for (int i = 0; i < CurrentOwner.CarsId.Count; i++)
                                {
                                    if (CarId == CurrentOwner.CarsId[i])
                                    {
                                        Console.WriteLine("Enter Id next owner of the car: ");
                                        Owner NextOwner = new Owner();
                                        NextOwner.CarsId.Add(CarId);
                                        CurrentOwner.CarsId.RemoveAt(i);
                                        Cars.GetById(CarId).OwnerId = NextOwner.ID;
                                        break;
                                    }
                                }
                                Console.WriteLine("This owner hasn't such car");

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
                                    Console.WriteLine($"\t{i.ToString()}");
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
                                        Console.WriteLine($"\t{a.ToString()}");
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
                                        CarRepository.WorkWithCars(Cars, Owners, current);
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
                            var filteredList = from t in Owners._context
                                               where t.Gender == 'M'
                                               orderby (t.Age)
                                               select t;
                            foreach (var i in filteredList)
                                Console.WriteLine(i);
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
