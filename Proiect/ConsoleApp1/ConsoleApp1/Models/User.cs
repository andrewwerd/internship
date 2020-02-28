using System;
using System.Collections.Generic;
using System.Text;

namespace Proiect.Models
{
    public abstract class User : Entity
    {
        protected string UserName;
        protected string Email;
        protected string Password;

        public User () { }
        public User (string userName, string password, string email)
        {
            UserName = userName;
            Password = password;
            Email = email;
        }
    }
}