using System;
using System.Collections.Generic;
using System.Text;

namespace DbCard.Domain
{
    public class Address: Entity<long>
    {
        public string HouseNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public long FilialId { get; set; }
        public virtual Filial Filial { get; set; }
        
        public override string ToString()
        {
            return $"Country: {Country}, City: {City}, Street: {$"{Street} {HouseNumber}"}";
        }
    }
}
