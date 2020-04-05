using System;
using System.Collections.Generic;
using System.Text;

namespace DbCard.Domain
{
    public abstract class Entity<T>
    {
        public T Id { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
