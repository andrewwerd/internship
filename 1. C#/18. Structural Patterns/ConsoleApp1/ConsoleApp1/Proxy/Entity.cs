using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Proxy
{
    public abstract class Entity : IComparable
    {
        public int ID { get; set; }
        public int CompareTo(object obj)
        {
            if (obj != null)
            {
                Entity a = (Entity)obj;
                return this.ID.CompareTo(a.ID);
            }
            else
                throw new NotImplementedException();
        }
    }
}
