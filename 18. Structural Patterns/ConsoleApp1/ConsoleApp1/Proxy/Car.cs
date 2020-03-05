using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Proxy
{
    public class Car : Entity
    {
        public Owner Owner { get; set; }
        public string Name { get; set; }
        private string _category;
        public string Category
        {
            get => _category;
            set
            {
                _category = value;
                switch (Category)
                {
                    case "SimpleCar":
                        {
                            MaxSpeed = 120;
                            Power = 500;
                            break;
                        }
                    case "SportCar":
                        {
                            MaxSpeed = 250;
                            Power = 250;
                            break;
                        }
                    case "SUV":
                        {
                            MaxSpeed = 100;
                            Power = 1000;
                            break;
                        }
                }
            }
        }
        public int MaxSpeed { get; set; }
        public int Power { get; set; }
        public int Age;
        public int Price { get; set; }
        public Car() { }
        public Car(string name, string category, int age, int price, Owner owner)
        {
            Name = name;
            Age = age;
            Price = price;
            Category = category;
            Owner = owner;
        }
        public Car(string name, string category, int age)
        {
            Name = name;
            Age = age;
            Category = category;
        }
        public override string ToString()
        {
            return $"Car ID:{ID}\n\tName: {Name}, Category: {Category}, Age: {Age} years, Max Speed: {MaxSpeed}, Power: {Power}";
        }
    }
