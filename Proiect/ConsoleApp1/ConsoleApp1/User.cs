using System;
using System.Collections.Generic;
using System.Text;

namespace Proiect
{
    public abstract class User
    {
        public string Name;
        public string Email;
        public string Password;
        public int ID { get; }
    }
}