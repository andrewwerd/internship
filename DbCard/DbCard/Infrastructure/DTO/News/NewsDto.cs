using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Infrastructure.DTO.News
{
    public class NewsDTO
    {
        public long Id { get; set; }
        public long PartnerId { get; set; }
        public IFormFile Image { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public string Author { get; set; }
    }
}
