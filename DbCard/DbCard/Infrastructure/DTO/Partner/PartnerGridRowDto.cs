using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Infrastructure.DTO.Partner
{
    public class PartnerForGrid
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public IFormFile Logo { get; set; }
        public string Name { get; set; }
        public string Rating { get; set; }
        public string Subcategory { get; set; }
        public string CurrentBalance { get; set; }
        public bool IsPremium { get; set; }
    }
}
