using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class Filials
    {
        public Filials()
        {
            TransactionHistory = new HashSet<TransactionHistory>();
        }

        public long Id { get; set; }
        public long PartnerId { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public virtual Partners Partner { get; set; }
        public virtual ICollection<TransactionHistory> TransactionHistory { get; set; }
    }
}
