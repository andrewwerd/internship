using System;
using System.Collections.Generic;
using System.Text;

namespace Proiect.Services
{
    abstract class RegisterationUser
    {
        public abstract User Create();   
    }
    class RegisterationCustomer : RegisterationUser
    {
        public override User Create()
        {
            Console.WriteLine("Enter username : ");
            string userName = Console.ReadLine();

            Console.WriteLine("Enter password : ");
            string password = Console.ReadLine();
            
            Console.WriteLine("Enter email : ");
            string email = Console.ReadLine();

            return new Customer(userName, password, email);
        }
    }
    class RegisterationPartner: RegisterationUser
    {
        public override User Create()
        {
            Console.WriteLine("Enter username : ");
            string userName = Console.ReadLine();

            Console.WriteLine("Enter password : ");
            string password = Console.ReadLine();
            
            Console.WriteLine("Enter email : ");
            string email = Console.ReadLine();

            return new Partner(userName, password, email);
        }
    }
}
