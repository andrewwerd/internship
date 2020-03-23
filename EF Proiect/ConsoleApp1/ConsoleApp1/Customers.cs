using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class Customers
    {
        public Customers()
        {
            CustomersBalance = new HashSet<CustomersBalance>();
            FavoritePartners = new HashSet<FavoritePartners>();
            Reviews = new HashSet<Reviews>();
            TransactionHistory = new HashSet<TransactionHistory>();
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public byte[] Foto { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public long UserId { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<CustomersBalance> CustomersBalance { get; set; }
        public virtual ICollection<FavoritePartners> FavoritePartners { get; set; }
        public virtual ICollection<Reviews> Reviews { get; set; }
        public virtual ICollection<TransactionHistory> TransactionHistory { get; set; }
    }
}
