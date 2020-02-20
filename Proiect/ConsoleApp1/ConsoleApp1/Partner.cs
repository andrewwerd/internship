using System;
using System.Collections.Generic;
using System.Text;

namespace Proiect
{
    public class Partner : User
    {
        public string Logo;
        public string Category;
        public decimal Rating;
        public StringBuilder Description;
        public Discount Discount;
        public List<Filial> Filials;
        public List<News> News;
        public List<Review> Reviews;

        public Filial Filial
        {
            get => default;
            set
            {
            }
        }

        public Review Review
        {
            get => default;
            set
            {
            }
        }

        public News News1
        {
            get => default;
            set
            {
            }
        }
    }
}