using DbCard.Domain.Auth;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DbCard.Domain
{
    public class Partner : Entity<long>
    {
        public string Name { get; set; }
        public byte[] Logo { get; set; }
        public decimal Rating { get; set; }
        public string Description { get; set; }
        public decimal? BirthdayDiscount { get; set; }
        public string? Site { get; set; }
        public long SubcategoryId { get; set; }
        public long CategoryId { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public long UserId { get; set; }
        public virtual User User { get; set; }
        public virtual Subcategory Subcategory { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<StandartDiscount> StandartDiscounts { get; set; }
        public virtual List<CustomersBalance> CustomersBalances { get; set; }
        public virtual List<PremiumDiscount> PremiumDiscounts { get; set; }
        public virtual List<Filial> Filials { get; set; }
        public virtual List<News> News { get; set; }
        public virtual List<Review> Reviews { get; set; }
        public virtual List<FavoritePartners> MyCustomers { get; set; }
    }
}