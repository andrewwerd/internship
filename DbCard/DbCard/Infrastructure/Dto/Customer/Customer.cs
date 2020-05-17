using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace DbCard.Infrastructure.Dto.Customer
{
    public class Customer
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Barcode { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
    }
}
