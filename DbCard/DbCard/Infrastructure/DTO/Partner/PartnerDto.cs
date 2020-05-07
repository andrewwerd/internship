using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Infrastructure.DTO.Partner
{
    public class PartnerDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Name { get; set; }
        public IFormFile Logo { get; set; }
        public string Subcategory { get; set; }
        public decimal Rating { get; set; }
        public string Description { get; set; }
    }
}
