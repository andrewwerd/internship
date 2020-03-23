using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class Users
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public virtual Customers Customers { get; set; }
        public virtual Partners Partners { get; set; }
    }
}
