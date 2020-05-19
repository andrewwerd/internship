using System;
using System.Collections.Generic;

namespace DbCard.Domain
{
    public class Filial : Entity<long>
    {
        public string PhoneNumber { get; set; }
        public long PartnerId { get; set; }
        public bool IsMainOffice { get; set; }
        public string HouseNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public virtual Partner Partner { get; set; }
        public virtual List<Transaction> Transactions { get; set; }
    }
}