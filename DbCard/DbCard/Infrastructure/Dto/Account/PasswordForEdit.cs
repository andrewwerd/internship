using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Infrastructure.Dto.Account
{
    public class PasswordForEdit
    {
        [Required]
        [MinLength(8)]
        public string CurrentPassword { get; set; }
        [Required]
        [MinLength(8)]
        public string NewPassword { get; set; }
    }
}
