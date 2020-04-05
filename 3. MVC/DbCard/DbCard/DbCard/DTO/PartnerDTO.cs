using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.DTO
{
    public class PartnerDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IFormFile Logo { get; set; }
        public string Category { get; set; }
        public decimal Rating { get; set; }
        public string Description { get; set; }
    }
}
