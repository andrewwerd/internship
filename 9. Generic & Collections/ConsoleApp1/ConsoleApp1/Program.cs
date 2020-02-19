using System;
using System.Collections.Generic;
using System.Text;
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
    class Repository<T> : IGenericRepository<T> where T : Entity
    {
        private List<T> _context;
        public Repository()
        {
            _context = new List<T>();
        }
        public void Create(T item)
        {
            _context.Add(item);
        }
        public void Delete(T item)
        {
            _context.Remove(item);
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
            _context.Insert(_context.IndexOf(item), item);
        }
    }
    public abstract class Entity
    {
        public int ID { get; protected set; }
    }
    public class Customer : Entity
    {
        public string Name { get; set; }
        public char Gender { get; set; }
        public int Age { get; set; }
        public Customer() { }
        public Customer(string name, char gender, int age, int id)
        {
            Name = name;
            Gender = gender;
            Age = age;
            ID = id;
        }
        public override string ToString()
        {
            return $"ID:{ID}\nName: {Name}, Gender: {(Gender == 'M' ? "Male" : "Female")}, Age: {Age} years";
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
               "Exit");
            Repository<Customer> customers = new Repository<Customer>();
            customers.Create(new Customer("Artur", 'M', 18, 102));
            customers.Create(new Customer("Andrew", 'M', 25, 100));
            customers.Create(new Customer("Grace", 'F', 20, 101));
            customers.Create(new Customer("Megane", 'F', 35, 103));
            customers.Create(new Customer("Forest", 'M', 43, 104));
            while (true)
            {
                string command = Console.ReadLine();
                switch (command.ToLower())
                {
                    case "create":
                        {
                            Customer current = new Customer();
                            Console.Write("Enter properties of customer: \nName: ");
                            current.Name = Console.ReadLine();
                            Console.Write("Gender: ");
                            current.Gender = Console.ReadLine()[0];
                            Console.Write("Age: ");
                            current.Age = int.Parse(Console.ReadLine());
                            customers.Create(current);
                            break;
                        }
                    case "read":
                        {
                            Console.Write("Give me ID = ");
                            int id = int.Parse(Console.ReadLine());
                            Console.WriteLine(customers.GetById(id).ToString());
                            break;
                        }
                    case "readall":
                        {
                            foreach (var i in customers.GetAll())
                            {
                                Console.WriteLine(i.ToString());
                            }
                            break;
                        }
                    case "update":
                        {
                            Console.Write("Give me ID = ");
                            int id = int.Parse(Console.ReadLine());
                            Customer current = customers.GetById(id);
                            break;
                        }
                    case "delete":
                        {
                            Console.Write("Give me ID = ");
                            Customer current = customers.GetById(int.Parse(Console.ReadLine()));

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
