using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Infrastructure.DTO.User
{
    public class UserForLogin
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Это поле обязательно для ввода!")]
        [Display(Name ="Логин")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Это поле обязательно для ввода!")]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
