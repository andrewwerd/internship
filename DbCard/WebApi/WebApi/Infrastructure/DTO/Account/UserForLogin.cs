using System.ComponentModel.DataAnnotations;

namespace WebApi.Infrastructure.DTO.Account
{
    public class UserForLogin
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
