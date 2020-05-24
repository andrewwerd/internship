using System.ComponentModel.DataAnnotations;

namespace DbCard.Infrastructure.Dto.User
{
    public class UserForLogin
    {
        [Required]
        [Display]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
