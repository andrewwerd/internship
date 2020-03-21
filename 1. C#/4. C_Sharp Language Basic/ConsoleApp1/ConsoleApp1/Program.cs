using System;

namespace ConsoleApp1
{
    public class Point
    {
        public int x { get; set; }
        public int y { get; set; }

    }
    class Program
    {
        public static void multiply_by_ref(ref int a)
        {
            a *= 1000;
        }
        int multiply_by_val(int a)
        {
            return a *= 1000;
        }
        public static object newPoint (object p){
            Point p1 = (Point)p;
            p1 = new Point();
            object obj = p1;
            return obj;
            }
        static void Main(string[] args)
        {
            int a = 10;
            Console.WriteLine("a=" + a);
            multiply_by_ref(ref a);
            Console.WriteLine(" Multiply by reference :a=" + a);
            multiply_by_val(a);
            Console.WriteLine(" Multiply by value :a=" + a);
            Console.WriteLine();
            Point p = new Point();
            p.x = 5;
            p.y = 6;
            object obj = p;
            Console.WriteLine("Point before boxing \n\t X=" + p.x + " Y=" + p.y);
            p = (Point)newPoint(obj);
            Console.WriteLine("Point after boxing \n\t X=" + p.x + " Y=" + p.y);
        }
    }
}
