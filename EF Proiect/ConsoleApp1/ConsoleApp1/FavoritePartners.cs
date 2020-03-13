using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class FavoritePartners
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int PartnerId { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual Partners Partner { get; set; }
    }
}
