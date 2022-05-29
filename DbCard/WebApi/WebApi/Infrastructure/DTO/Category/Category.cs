using System.ComponentModel.DataAnnotations;

namespace WebApi.Infrastructure.DTO.Category
{
    public class Category
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
