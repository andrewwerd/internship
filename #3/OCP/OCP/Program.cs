using System;

namespace OCP
{
    //не соотвествие принципу ОСР
     class figureArea{
        public string FigureType { get; set; }
        public void area()
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
    public abstract class figureArea1
    {
        public abstract void area();
    }
    public class CircleArea : figureArea1
    {
        public override void area()
        {
            //считает площадь для круга
        }
    }
    public class RectArea : figureArea1
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
