using System.ComponentModel.DataAnnotations;

namespace WebApi.Infrastructure.DTO.Filial
{
    public class Filial
    {
        [Required]
        public string Region { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string HouseNumber { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
