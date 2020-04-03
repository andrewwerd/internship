using System;
using System.Collections.Generic;
using System.Text;

namespace dbCard.Domain.Models
{
    public abstract class Entity<T>
    {
        public T Id { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
