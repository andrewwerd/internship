﻿using System.ComponentModel.DataAnnotations;

namespace DbCard.Infrastructure.Dto.User
{
    public class UserForRegistration
    {
        [Required]
        [MinLength(3)]
        public string UserName { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(9)]
        public string PhoneNumber { get; set; }
    }
}
