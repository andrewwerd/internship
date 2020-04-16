using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Infrastructure.DTO.Customer
{
    public class CustomerForUpdate
    {
        public long Id { get; set; }
        public long UserId { get; set;}
        [Required(ErrorMessage = "Это поле обязательно для ввода!")]
        [Display(Name ="Имя :")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Это поле обязательно для ввода!")]
        [Display(Name = "Фамилия :")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Это поле обязательно для ввода!")]
        [Display(Name = "Дата рождения :")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Это поле обязательно для ввода!")]
        [Display(Name = "Пол :")]
        public Gender Gender { get; set; }
        [Required(ErrorMessage = "Это поле обязательно для ввода!")]
        [Display(Name = "Номер телефона :")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Фото :")]
        public IFormFile[] Avatar { get; set; }
    }
}
