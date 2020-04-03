using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class Filial : Entity<long>
    {
        [Phone]
        public string PhoneNumber { get; set; }
        public bool IsMainOffice { get; set; }
        public long PartnerId { get; set; }
        public virtual Address Address { get; set; }
        public virtual Partner Partner { get; set; }
        public virtual List<Transaction> Transactions { get; set; }
    }
}