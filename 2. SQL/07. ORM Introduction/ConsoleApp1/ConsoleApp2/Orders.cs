using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    public partial class Orders
    {
        public int OrderId { get; set; }
        public string OrderName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customers Customer { get; set; }
    }
}
