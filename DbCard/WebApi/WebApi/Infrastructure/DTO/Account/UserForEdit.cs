﻿using System.ComponentModel.DataAnnotations;

namespace WebApi.Infrastructure.DTO.Account
{
    public class UserForEdit
    {
        [Required]
        [MinLength(3)]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(9)]
        public string PhoneNumber { get; set; }
    }
}
