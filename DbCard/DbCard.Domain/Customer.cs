using DbCard.Domain.Auth;
using System;
using System.Collections.Generic;

namespace DbCard.Domain
{
    public class Customer : Entity<long>
    {
        public byte[] Avatar { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Barcode { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public virtual User User { get; set; }
        public long UserId { get; set; }
        public virtual List<Transaction> Transactions { get; set; }
        public virtual List<CustomersBalance> CustomersBalances { get; set; }
        public virtual List<Review> Reviews { get; set; }
        public virtual List<FavoritePartners> FavoritePartners { get; set; }
    }
}