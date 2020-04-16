using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Infrastructure.DTO.Partner
{
    public class PartnerForRegistration
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        [Required(ErrorMessage = "Это поле обязательно для ввода!")]
        [StringLength(40, MinimumLength = 1)]
        public string Name { get; set; }
        public IFormFile Logo { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для ввода!")]
        [StringLength(40, MinimumLength = 1)]
        public string Category { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для ввода!")]
        [StringLength(40, MinimumLength = 1)]
        public string Subcategory { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для ввода!")]
        [StringLength(4000, MinimumLength = 5)]
        public string Description { get; set; }

        [Range(0, 100)]
        public decimal? BirthdayDiscount { get; set; }
        [Required]
       // public FilialDTO filial { get; set; }
       // [Required]
        public string PhoneNumber { get; set; }
        public string Site { get; set; }
    }
}
