using System;
using System.Collections.Generic;

namespace DbCard.Domain
{
    public class Filial : Entity<long>
    {
        public string PhoneNumber { get; set; }
        public long PartnerId { get; set; }
        public bool IsMainOffice { get; set; }
        public virtual Schedule Schedule { get; set; }
        public virtual Address Address { get; set; }
        public virtual Partner Partner { get; set; }
        public virtual List<Transaction> Transactions { get; set; }
    }
}