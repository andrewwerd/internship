using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Owner : Entity
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public List<Car> Cars { get; set; }
        public Owner() { }
        public Owner(string name, string gender, int age)
        {
            Name = name;
            Gender = gender;
            Age = age;
            Cars = new List<Car>();
        }
        public override string ToString()
        {
            return $"Owner ID:{ID}\nName: {Name}, Gender: {Gender}, Age: {Age} years";
        }
    }
}
