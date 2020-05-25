using System;
using System.ComponentModel.DataAnnotations;

namespace DbCard.Infrastructure.Dto.Partner
{
    public class PartnerForUpdate
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        [Required]
        [StringLength(40, MinimumLength = 1)]
        public string Name { get; set; }
        [Required]
        [StringLength(40, MinimumLength = 1)]
        public string Category { get; set; }
        [Required]
        [StringLength(4000, MinimumLength = 5)]
        public string Description { get; set; }
        [Required]
        [Range(0, 100)]
        public decimal BirthdayDiscount { get; set; }
    }
}
