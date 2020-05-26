using DbCard.Infrastructure.Dto.Filial;
using DbCard.Infrastructure.Dto.User;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Infrastructure.Dto.Partner
{
    public class PartnerForRegistration: UserForRegistration
    {
        [Required]
        [StringLength(40, MinimumLength = 1)]
        public string Name { get; set; }
        public IFormFile Logo { get; set; }

        [Required]
        public long CategoryId { get; set; }

        [Required]
        public long SubcategoryId { get; set; }

        [Required]
        [StringLength(4000, MinimumLength = 5)]
        public string Description { get; set; }

        [Range(0, 100)]
        public decimal? BirthdayDiscount { get; set; }
        [Required]
        public Filial.Filial Filial { get; set; }
        public string Site { get; set; }
    }
}
