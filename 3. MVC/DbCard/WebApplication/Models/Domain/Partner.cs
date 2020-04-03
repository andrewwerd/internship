using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class Partner : Entity<long>
    {
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Category { get; set; }
        [Range(0,10)]
        public decimal Rating { get; set; }
        public string Description { get; set; }
        [Range(0,100)]
        public decimal BirthdayDiscount { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public long UserId { get; set; }
        public virtual User User { get; set; }
        public virtual List<StandartDiscount> StandartDiscounts { get; set; }
        public virtual List<CustomersBalance> CustomersBalances { get; set; }
        public virtual List<PremiumDiscount> PremiumDiscount { get; set; }
        public virtual List<Filial> Filials { get; set; }
        public virtual List<News> News { get; set; }
        public virtual List<Review> Reviews { get; set; }
        public virtual List<FavoritePartners> MyCustomers { get; set; }
    }
}