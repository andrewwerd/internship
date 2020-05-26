using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Infrastructure.Dto.News
{
    public class News
    {
        public long Id { get; set; }
        public long PartnerId { get; set; }
        [Required]
        [MaxLength(40)]
        public string Title { get; set; }
        [Required]
        [StringLength(4000, MinimumLength = 100)]
        public string Body { get; set; }
        [Required]
        [StringLength(100)]
        public string Author { get; set; }
    }
}
