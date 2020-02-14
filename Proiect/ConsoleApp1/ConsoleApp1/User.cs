using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class User
    {
        private string Name;
        public string Email;
        private string Password;
        public int ID;

        public bool LoginVerify() {
            return true;
        }

    }
}