using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Visitor
{
    public interface IVisitor
    {
        void Visit(Person person);
        void Visit(Child person);
    }
}
