using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DbCard.Infrastructure.ValidationAttributes;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Infrastructure.DTO.User
{
    public class UserForRegistration
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Это поле обязательно для ввода!")]
        [Display(Name = "Логин: ")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для ввода!")]
        [MinLength(8)]
        [PasswordValidation]
        [Display(Name = "Пароль: ")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для ввода!")]
        [Display(Name = "Повторить пароль: ")]
        [Compare(nameof(Password))]
        public string RepeatePassword { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для ввода!")]
        [Display(Name = "Email: ")]
        [EmailAddress(ErrorMessage ="Вы ввели неправильный Email")]
        public string Email { get; set; }

        public UserType UserType { get; set; }
    }
    public enum UserType
    {
        Customer=0,
        Partner=1
    }
}
