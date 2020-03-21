using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Visitor
{
    class CalculateChildrens : IVisitor
    {
        public int Count { get; set; }

        public void CountChildrens(Person person)
        {
            person.Accept(this);
            if (person != null)
            {
                CountChildrens(person.Child);
            }
        }

        public void Visit(Child person)
        {
            Count++;
        }
        public void Visit(Person element)
        {
        }
    }
}
