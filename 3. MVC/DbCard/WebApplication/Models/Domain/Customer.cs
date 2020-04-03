using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Models
{
    public class Customer : Entity<long>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public int Age
        {
            get => (int)((DateTime.Today - DateOfBirth).TotalDays / 365.2425);
        }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public long UserId { get; set; }
        public virtual User User { get; set; }
        public virtual List<Transaction> Transactions { get; set; }
        public virtual List<CustomersBalance> CustomersBalances { get; set; }
        public virtual List<Review> Reviews { get; set; }
        public virtual List<FavoritePartners> FavoritePartners { get; set; }
    }
}