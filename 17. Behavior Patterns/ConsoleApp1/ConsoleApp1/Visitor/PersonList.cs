using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Visitor
{
    public class PersonList
    {
        private readonly Person _objectStructure;

        public PersonList()
        {
            _objectStructure =
                new Person("John",
                    new Person("Megane",
                        new Child("Kate",
                            new Person("Vanea",
                                    new Child("Vitea",
                                        new Person("Jenea",
                                        new Person("Objects", null)))))));
        }

        public Person ObjectStructure
        {
            get { return _objectStructure; }
        }
    }
}
