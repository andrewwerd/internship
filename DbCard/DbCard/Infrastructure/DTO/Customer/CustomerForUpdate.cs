using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace DbCard.Infrastructure.Dto.Customer
{
    public class CustomerForUpdate
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public IFormFile[] Avatar { get; set; }
    }
}
