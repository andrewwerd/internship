using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Proiect
{
    public class Partner : User
    {
        public string Logo { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public decimal Rating { get; set; }
        public string Description { get; set; }

        private List<decimal> Levels;
        private List<Discount> Discounts;
        public List<Filial> Filials;
        private  List<News> News;
        private List<Review> Reviews;


        public Partner () { }

        public Partner (string userName, string password, string email):base(userName,password,email) { }

        public Partner(string name, string category, string address, int phoneNumber)
        {
            Name = name;
            Category = category;
            Filials = new List<Filial>();
            Filials.Add(new Filial(Id, address, phoneNumber));
        }
        public (decimal,decimal) GetDiscount(decimal Balance)
        {
            int index = Levels.FindIndex(x => x < Balance);
            return (Discounts[index].AccumulationPercent,Discounts[index].DiscountPercent);
        }
    }
}