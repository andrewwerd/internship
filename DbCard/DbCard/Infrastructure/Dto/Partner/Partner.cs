using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Infrastructure.Dto.Partner
{
    public class Partner
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Name { get; set; }
        public string Rating { get; set; }
        public Category.Category Category { get; set; }
        public Category.Subcategory Subcategory { get; set; }
        public string Description { get; set; }
        public string Site { get; set; }
        public bool IsPremium { get; set; }
    }
}
