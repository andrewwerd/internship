﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.DTO
{
    public class PartnerForUpdateDTO
    {
        [Required]
        [StringLength(40, MinimumLength = 1)]
        public string Name { get; set; }
        //public IFormFile Logo { get; set; }
        [Required]
        [StringLength(40, MinimumLength = 1)]
        public string Category { get; set; }
        [Required]
        [StringLength(4000, MinimumLength = 5)]
        public string Description { get; set; }
        [Required]
        [Range(0,100)]
        public decimal BirthdayDiscount { get; set; }
    }
}
