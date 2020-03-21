using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Owner : Entity
    {
        public string Name { get; set; }
        public char Gender { get; set; }
        public int Age { get; set; }
        public List<int>? CarsId;
        public Owner() { }
        public Owner(string name, char gender, int age)
        {
            Name = name;
            Gender = gender;
            Age = age;
            CarsId = new List<int>();
        }
        public override string ToString()
        {
            return $"Owner ID:{ID}\nName: {Name}, Gender: {(Gender == 'M' ? "Male" : "Female")}, Age: {Age} years";
        }
    }
}
