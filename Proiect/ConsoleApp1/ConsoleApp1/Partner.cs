using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Proiect
{
    public class Partner : User
    {
        public string Logo;
        public string Category;
        public string Name;
        public decimal Rating;
        public string Description;
        public List<decimal> Levels;
        public List<Discount> Discounts;
        public List<Filial> Filials;
        public List<News> News;
        public List<Review> Reviews;
        public Partner(string name, string category, string address, int phoneNumber)
        {
            Name = name;
            Category = category;
            Filials = new List<Filial>();
            Filials.Add(new Filial(Id, address, phoneNumber));
        }
        public void SetLevels()
        {

        }
        public (decimal,decimal) GetDiscount(decimal Balance)
        {
            int index = Levels.FindIndex(x => x < Balance);
            return (Discounts[index].AccumulationPercent,Discounts[index].DiscountPercent);
        }
    }
}