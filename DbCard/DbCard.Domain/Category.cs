using System;
using System.Collections.Generic;
using System.Text;

namespace DbCard.Domain
{
    public class Category : Entity<long>
    {
        public string Name { get; set; }
        public virtual List<Partner> Partners { get; set; }
        public virtual List<Subcategory> Subcategories { get; set; }
        public virtual List<Transaction> Transactions{ get; set; }
    }
}
