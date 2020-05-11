using System.ComponentModel.DataAnnotations;

namespace DbCard.Infrastructure.Dto.User
{
    public class UserForRegistration
    {
        [Required(ErrorMessage = "Это поле обязательно для ввода!")]
        [Display(Name = "Логин: ")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для ввода!")]
        [Display(Name = "Пароль: ")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для ввода!")]
        [Display(Name = "Email: ")]
        [EmailAddress(ErrorMessage = "Вы ввели неправильный Email")]
        public string Email { get; set; }
    }
}
