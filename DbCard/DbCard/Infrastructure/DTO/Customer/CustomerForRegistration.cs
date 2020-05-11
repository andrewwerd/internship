using DbCard.Infrastructure.Dto.User;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace DbCard.Infrastructure.Dto.Customer
{
    public class CustomerForRegistration : UserForRegistration
    {
        public string FirstName { get; set; }

        [Display(Name = "Фамилия :")]
        public string LastName { get; set; }

        [Display(Name = "Дата рождения :")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Пол :")]
        public string Gender { get; set; }

        [Display(Name = "Номер телефона :")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Фото :")]
        public IFormFile[] Avatar { get; set; }
    }
}
