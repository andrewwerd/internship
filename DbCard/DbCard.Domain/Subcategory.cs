using System;
using System.Collections.Generic;
using System.Text;

namespace DbCard.Domain
{
    public class Subcategory: Entity<long>
    {
        public string Name { get; set; }
        public long CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<Partner> Partners { get; set; }
        public virtual List<Transaction> Transactions { get; set; }
    }
}
