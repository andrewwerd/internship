using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Visitor
{
    public class Person: IPerson
    {
        public string Name { get; set; }
        public Person Child { get; set; }
        static Person()
        {
        }
        public Person(string name, Person child)
        {
            Name = name;
            Child = child;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
