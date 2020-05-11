using System.ComponentModel.DataAnnotations;

namespace DbCard.Infrastructure.Dto.User
{
    public class UserForLogin
    {
        [Required(ErrorMessage = "Это поле обязательно для ввода!")]
        [Display(Name = "Логин")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Это поле обязательно для ввода!")]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
