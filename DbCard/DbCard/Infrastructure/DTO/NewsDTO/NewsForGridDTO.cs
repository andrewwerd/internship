using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Infrastructure.DTO.NewsDTO
{
    public class NewsForGridDTO
    {
        public long Id { get; set; }
        public long PartnerId { get; set; }
        public IFormFile Image { get; set; }
        public string Title { get; set; }
        public string ShortBody { get; set; }
        public DateTime Date { get; set; }
        public string Author { get; set; }
    }
}
