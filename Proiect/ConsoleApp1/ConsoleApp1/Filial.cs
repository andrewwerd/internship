using System;
using System.Collections.Generic;
using System.Text;

namespace Proiect
{
    public class Filial
    {
       public Guid PartnerId { get; set; }
        public Guid Id { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public Filial( Guid partnerId, string address, int phoneNumber)
        {
            Address = address;
            PartnerId = partnerId;
            PhoneNumber = phoneNumber;
            Id = Guid.NewGuid();
        }
    }
}