using DbCard.Infrastructure.Dto.User;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace DbCard.Infrastructure.Dto.Customer
{
    public class CustomerForRegistration : UserForRegistration
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long DateOfBirth { get; set; }
        public string Gender { get; set; }
        public IFormFile Avatar { get; set; }
    }
}
