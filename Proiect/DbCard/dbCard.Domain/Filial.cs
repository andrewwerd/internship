using System;
using System.Collections.Generic;

namespace dbCard.Domain
{
    public class Filial : Entity<long>
    {
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public long PartnerId { get; set; }
        public virtual Partner Partner { get; set; }
        public virtual List<Transaction> Transactions { get; set; }
    }
}