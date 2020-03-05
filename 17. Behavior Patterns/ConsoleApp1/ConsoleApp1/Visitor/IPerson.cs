using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Visitor
{
    public abstract class IPerson
    {
         public abstract void Accept(IVisitor visitor);
    }
}
