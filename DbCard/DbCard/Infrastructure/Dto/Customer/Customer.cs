using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace DbCard.Infrastructure.Dto.Customer
{
    public class Customer
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Gender{ get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public string Barcode { get; set; }
    }
}
