using System.ComponentModel.DataAnnotations;

namespace DbCard.Infrastructure.Dto.User
{
    public class UserForRegistration
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
