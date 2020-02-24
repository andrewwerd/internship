using System;
using System.Collections.Generic;
using System.Text;

namespace Proiect
{
    public class Partner : User
    {
        public string Logo;
        public string Category;
        public string Name;
        public decimal Rating;
        public string Description;
        public List<Discount> Discounts;
        public List<Filial> Filials;
        public List<News> News;
        public List<Review> Reviews;
    }
}