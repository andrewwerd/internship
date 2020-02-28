using System;
using System.Collections.Generic;
using System.Text;

namespace Proiect.Models
{
    public class News : Entity
    {
        public Guid PartnerId { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}