using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Visitor
{
    public class Child : Person
    {
        public Child(string name, Person child):base(name, child){}
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

}
