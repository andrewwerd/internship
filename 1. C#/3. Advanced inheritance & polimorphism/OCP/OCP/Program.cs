using System;

namespace OCP
{
    //не соотвествие принципу ОСР
     class Figure{
        public string FigureType { get; set; }
        public void Area()
        {
            if(FigureType == "rect")
            {
                //считает площадь для прямоугольника
            }
            if(FigureType == "circle")
            {
                //считает площадь для круга
            }
            
        }
        }
    // Соответствие принципу ОСР
    public abstract class Figure1
    {
        public abstract void area();
    }
    public class CircleArea : Figure1
    {
        public override void area()
        {
            //считает площадь для круга
        }
    }
    public class RectArea : Figure1
    {
        public override void area()
        {
            //считает площадь для прямоугольника
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
