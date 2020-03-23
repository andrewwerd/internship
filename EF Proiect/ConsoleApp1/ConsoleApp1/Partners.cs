using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class Partners
    {
        public Partners()
        {
            CustomersBalance = new HashSet<CustomersBalance>();
            FavoritePartners = new HashSet<FavoritePartners>();
            Filials = new HashSet<Filials>();
            News = new HashSet<News>();
            PremiumDiscount = new HashSet<PremiumDiscount>();
            Reviews = new HashSet<Reviews>();
            StandartDiscount = new HashSet<StandartDiscount>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Rating { get; set; }
        public string Description { get; set; }
        public byte[] Logo { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public decimal? BirthdayDiscount { get; set; }
        public long UserId { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<CustomersBalance> CustomersBalance { get; set; }
        public virtual ICollection<FavoritePartners> FavoritePartners { get; set; }
        public virtual ICollection<Filials> Filials { get; set; }
        public virtual ICollection<News> News { get; set; }
        public virtual ICollection<PremiumDiscount> PremiumDiscount { get; set; }
        public virtual ICollection<Reviews> Reviews { get; set; }
        public virtual ICollection<StandartDiscount> StandartDiscount { get; set; }
    }
}
