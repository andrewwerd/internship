using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proiect.Services
{
    class CheckRegistrationInput
    {
        static public bool CheckUserName(string userName)
        {
            char[] forbiddenSymbols = { ' ','\"', '/', '\\', '[', ']', ':', ';', '|', '=', ',', '+', '*', '?', '<', '>' };
            return userName.Intersect(forbiddenSymbols) == null;
        }
        //static public bool CheckPassword(string password)
        //{
        //    string Up = "ABCDEFGHIKLMNOPQRSTVXYZ";
        //    string Numbers = "1234567890";
        //    var passwordCheck = from p in password
        //                   from upChar in Up
        //                   from downChar in Up.ToLower()
        //                   from number in Numbers
        //                   where p == upChar && p == downChar && p == number
        //                   where p 
        //    return userName.Intersect(forbiddenSymbols) == null;
        //}
    }
    }