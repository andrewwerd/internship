using DbCard.Infrastructure.Dto.User;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace DbCard.Infrastructure.Dto.Customer
{
    public class CustomerForRegistration : UserForRegistration
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Gender { get; set; }
    }
}
