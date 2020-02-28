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
        public List<decimal> Levels;
        public List<Discount> Discounts;
        public List<Filial> Filials;
        public List<News> News;
        public List<Review> Reviews;

        public (decimal,decimal) GetDiscount(decimal Balance)
        {
            int index = Levels.FindIndex(x => x < Balance);
            return (Discounts[index].AccumulationPercent,Discounts[index].DiscountPercent);
        }
    }
}