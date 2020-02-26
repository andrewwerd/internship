using System;
using System.Collections.Generic;
using System.Text;

namespace Proiect
{
    public class Filial
    {
        public Guid PartnerId;
        public Guid Id;
        public string Address;
        public int PhoneNumber;
        public Filial( Guid partnerId, string address, int phoneNumber)
        {
            Address = address;
            PartnerId = partnerId;
            PhoneNumber = phoneNumber;
            Id = Guid.NewGuid();
        }
    }
}