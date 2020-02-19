using System;

namespace LSP
{
    abstract class figure
    {
       public abstract int area();
    }

     class rectangle : figure
    {
        private int _heigth;
        private int _width;

        public void setHeight(int height) { _heigth = height; }
        public void setWidth(int width) { _width = width; }
        public int getHeigth () { return _heigth; }
        public int getWidth() { return _width; }
        public override int area() { return _heigth * _width; }
    }
    class square : figure
    {
        private int _side;

        public void setSide(int side) { _side = side; }
        public int getSide() { return _side; }
        public override int area() { return _side * _side; }
    }
    class Program
    {
        static int someMethod (figure fig)
        {
            return fig.area();
        }
        static void Main(string[] args)
        {
            square square = new square();
            square.setSide(5);
            Console.WriteLine(someMethod(square));
        }          
    }
}
