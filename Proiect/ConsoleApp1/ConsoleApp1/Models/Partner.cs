using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Proiect.Models
{
    public class Partner : User
    {
        public string Logo { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public decimal Rating { get; set; }
        public string Description { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public List<decimal> Levels { get; set; }
        public List<Discount> Discounts { get; set; }
        public List<Filial> Filials { get; set; }
        public List<News> News { get; set; }
        public List<Review> Reviews { get; set; }
    }
}