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
        [Required(ErrorMessage = "Это поле обязательно для ввода!")]
        [Display(Name = "Логин: ")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для ввода!")]
        [MinLength(8)]
        [PasswordValidation]
        [Display(Name = "Пароль: ")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для ввода!")]
        [Display(Name = "Email: ")]
        [EmailAddress(ErrorMessage ="Вы ввели неправильный Email")]
        public string Email { get; set; }
    }
}
