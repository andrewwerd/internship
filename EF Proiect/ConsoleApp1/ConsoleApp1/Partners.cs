using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class Partners
    {
        public Partners()
        {
            BirthdayDiscount = new HashSet<BirthdayDiscount>();
            FavoritePartners = new HashSet<FavoritePartners>();
            Filials = new HashSet<Filials>();
            News = new HashSet<News>();
            PremiumCustomers = new HashSet<PremiumCustomers>();
            PremiumDiscount = new HashSet<PremiumDiscount>();
            Rewiews = new HashSet<Rewiews>();
            StandartDiscount = new HashSet<StandartDiscount>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Rating { get; set; }
        public string Description { get; set; }
        public byte[] Logo { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public int UserId { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<BirthdayDiscount> BirthdayDiscount { get; set; }
        public virtual ICollection<FavoritePartners> FavoritePartners { get; set; }
        public virtual ICollection<Filials> Filials { get; set; }
        public virtual ICollection<News> News { get; set; }
        public virtual ICollection<PremiumCustomers> PremiumCustomers { get; set; }
        public virtual ICollection<PremiumDiscount> PremiumDiscount { get; set; }
        public virtual ICollection<Rewiews> Rewiews { get; set; }
        public virtual ICollection<StandartDiscount> StandartDiscount { get; set; }
    }
}
