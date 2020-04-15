using DbCard.Infrastructure.ValidationAttributes;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Infrastructure.DTO.CustomerDTO
{
    public class CustomerForRegistrationDTO
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        [Display(Name ="Имя :")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия :")]
        public string LastName { get; set; }

        [BirthdayValidation]
        [Display(Name = "Дата рождения :")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Пол :")]
        public Gender Gender { get; set; }

        [Display(Name = "Номер телефона :")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Фото :")]
        public IFormFile[] Avatar { get; set; }
    }
    public enum Gender
    {
        Female = 0,
        Male = 1
    }
}
