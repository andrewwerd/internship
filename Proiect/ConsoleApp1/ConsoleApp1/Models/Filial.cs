using System;

namespace Proiect.Models
{
    public class Filial
    {
        public Guid PartnerId { get; set; }
        public Guid Id { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}