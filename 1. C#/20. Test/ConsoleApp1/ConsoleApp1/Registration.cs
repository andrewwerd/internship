using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Registration
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public EmailRepository Emails;
        public class VerifyEnterData
        {
            public static bool UserName(string username)
            {
                char[] Symbols = { '/', ' ', '\'', '\\', '`' };
                return username.Intersect(Symbols).Any();
            }public static bool Email(string email)
            {
                char[] Symbols = { '/', ' ', '\'', '\\', '`' };

                return email.Intersect(Symbols).Any()&&email.Contains('@');
            }
        }
        public string SetUserName(string userName)
        {
            if (userName == "" || userName == null) return "UserName is empty";
            else if (VerifyEnterData.UserName(userName)) return "UserName is not good";
            UserName = userName;
            return "UserName is setted";
        }
        public string SetEmail(string email)
        {
            if (email == "" && email == null) return "Email is empty";
            else if (VerifyEnterData.Email(email)) return "Email is not good";
            else if (Emails.TryFind(email)) return "Email already exist";
            Emails.Add(email);
            return "Email is setted";
        }
    }
}
