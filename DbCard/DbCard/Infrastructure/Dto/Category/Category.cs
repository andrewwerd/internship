using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Infrastructure.Dto.Category
{
    public class Category
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
