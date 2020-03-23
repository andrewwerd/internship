using System;
using System.Collections.Generic;
using System.Text;

namespace dbCard.Domain
{
    public abstract class Entity<T>
    {
        public T Id { get; set; }
    }
}
