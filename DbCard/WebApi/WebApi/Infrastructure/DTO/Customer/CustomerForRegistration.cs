using System.ComponentModel.DataAnnotations;
using WebApi.Infrastructure.DTO.Account;

namespace WebApi.Infrastructure.DTO.Customer
{
    public class CustomerForRegistration : UserForRegistration
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Gender { get; set; }
    }
}
