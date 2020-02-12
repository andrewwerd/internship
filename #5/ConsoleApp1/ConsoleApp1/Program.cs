using System;

namespace LSP
{
    abstract class figure
    {
        public abstract int area();
    }

    class rectangle : figure
    {
        public int _heigth { get; set; }
        public int _width { get; set; }
        public override int area() { return _heigth * _width; }
    }
    class square : figure
    {
        public int _side { get; set; }
        public override int area() { return _side * _side; }
    }
    class Program
    {
        static int someMethod(figure fig)
        {
            return fig.area();
        }
        static void Main(string[] args)
        {
            square square = new square();
            square._side = 5;
            Console.WriteLine(someMethod(square));
        }
    }
}
