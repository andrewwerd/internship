using System;
using System.Linq;
using System.Text;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            using (var db = new TestADOContext())
            {
                Customers user1 = new Customers { FirstName = "Tom", LastName = "Arnold" };
                Customers user2 = new Customers { FirstName = "John", LastName = "Doe" };
                Customers user3 = new Customers { FirstName = "Joshua", LastName = "Doe" };
                Customers user4 = new Customers { FirstName = "Jane", LastName = "Brooks" };
                Customers user5 = new Customers { FirstName = "Patricia", LastName = "Moody" };
                Customers user6 = new Customers { FirstName = "Sabrina", LastName = "Burns" };
                Customers user7 = new Customers { FirstName = "John", LastName = "McBride" };

                db.Customers.Add(user1);
                db.Customers.Add(user2);
                db.Customers.Add(user3);
                db.Customers.Add(user4);
                db.Customers.Add(user5);
                db.Customers.Add(user6);
                db.Customers.Add(user7);
                db.SaveChanges();
                var order1 = new Orders { OrderName = "Apples", Price = 25, Quantity = 2, CustomerId = user1.CustomerId };
                var order2 = new Orders { OrderName = "Smartphone", Price = 2000, Quantity = 1, CustomerId = user1.CustomerId };
                var order3 = new Orders { OrderName = "Marshmallows", Price = 30, Quantity = 10, CustomerId = user1.CustomerId };
                var order4 = new Orders { OrderName = "Cake", Price = 100, Quantity = 6, CustomerId = user3.CustomerId };
                var order5 = new Orders { OrderName = "Pie", Price = 25, Quantity = 2, CustomerId = user7.CustomerId };
                var order6 = new Orders { OrderName = "Apples", Price = 25, Quantity = 13, CustomerId = user5.CustomerId };
                var order7 = new Orders { OrderName = "Smartphone", Price = 3000, Quantity = 2, CustomerId = user4.CustomerId };
                var order8 = new Orders { OrderName = "Cheese", Price = 34, Quantity = 8, CustomerId = user3.CustomerId };
                var order9 = new Orders { OrderName = "Cola", Price = 20, Quantity = 5, CustomerId = user2.CustomerId };
                var order10 = new Orders { OrderName = "Dress", Price = 300, Quantity = 1, CustomerId = user3.CustomerId };

                db.Orders.Add(order1);
                db.Orders.Add(order2);
                db.Orders.Add(order3);
                db.Orders.Add(order4);
                db.Orders.Add(order5); 
                db.Orders.Add(order6); 
                db.Orders.Add(order7); 
                db.Orders.Add(order8); 
                db.Orders.Add(order9); 
                db.Orders.Add(order10);

                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");

                var users = db.Customers.ToList();
                var orders = db.Orders.ToList();

                Console.WriteLine("Список объектов:");
                foreach (var u in users)
                {
                    Console.WriteLine($"{u.CustomerId}. {u.FirstName} - {u.LastName}");
                    foreach (var o in orders)
                    { if(u.CustomerId==o.CustomerId)
                        Console.WriteLine($"{o.OrderName}, {o.Price}, {o.Quantity}");
                    }
                }
            }
            Console.Read();
        }
    }
}
