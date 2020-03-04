using System;
using System.Collections.Generic;
using System.Text;

namespace Proiect.Models
{
    public class Discount: Entity
    {
        public Guid PartnerId;
        public double AccumulationPercent;
        public double DiscountPercent;
    }
}