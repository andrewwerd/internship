using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class FavoritePartners
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public long? PartnerId { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual Partners Partner { get; set; }
    }
}
