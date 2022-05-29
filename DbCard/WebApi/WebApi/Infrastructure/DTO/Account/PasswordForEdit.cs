using System.ComponentModel.DataAnnotations;

namespace WebApi.Infrastructure.DTO.Account
{
    public class PasswordForEdit
    {
        [Required]
        [MinLength(8)]
        public string CurrentPassword { get; set; }
        [Required]
        [MinLength(8)]
        public string NewPassword { get; set; }
    }
}
