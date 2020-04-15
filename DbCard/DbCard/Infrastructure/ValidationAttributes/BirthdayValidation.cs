using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Infrastructure.ValidationAttributes
{
    public class BirthdayValidation:ValidationAttribute
    {
        public BirthdayValidation()
        {

        }
        public override bool IsValid(object value)
        {
            var date = DateTime.Parse(value.ToString());
            return date.Year<DateTime.Now.Year-13;
        }
    }
}
