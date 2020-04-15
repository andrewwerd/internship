using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DbCard.Infrastructure.ValidationAttributes
{
    public class PasswordValidation : ValidationAttribute
    {
        public PasswordValidation()
        {

        }
        public override bool IsValid(object value)
        {
            var numbers = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            var requiredCharacters = new char[] { ' ', '!', '\"', '#', '$', '%', '&', '\'', '(', ')', '*', '+', ',', '-', '.', '/', ':', ';', '<', '=', '>', '?', '@', '[', '\\', ']', '^', '_', '{', '|', '}', '~' };
            var upperSymbols = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            var lowerSymbols = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            var v = (string)value;
            return v.Intersect(requiredCharacters).Any() 
                && v.Intersect(numbers).Any()
                && v.Intersect(upperSymbols).Any()
                && v.Intersect(lowerSymbols).Any();
        }
    }
}
