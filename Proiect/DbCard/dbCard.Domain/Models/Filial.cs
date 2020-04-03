using System;
using System.Collections.Generic;

namespace dbCard.Domain.Models
{
    public class Filial : Entity<long>
    {
        public string PhoneNumber { get; set; }
        public long PartnerId { get; set; }
        public byte[] RowVersion { get; set; }
        public virtual Address Address { get; set; }
        public virtual Partner Partner { get; set; }
        public virtual List<Transaction> Transactions { get; set; }
    }
}