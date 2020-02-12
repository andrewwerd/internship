using System;

namespace ConsoleApp1
{
    class Program
    {
        static int[] evenLast(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
                for (int j = i; j < a.Length - 1; j++)
                    if (a[i] % 2 == 0)
                    {
                        int temp = a[i];
                        a[i] = a[j + 1];
                        a[j + 1] = temp;
                    }
            return a;
        }
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Console.Write("Array before sort A[]={");
            foreach (int i in array)
                Console.Write("{0} ", i);
            Console.WriteLine("}");
            Console.WriteLine();
            Console.Write("Array before sort A[]={");
            array = evenLast(array);
            foreach (int i in array)
                Console.Write("{0} ", i);
            Console.WriteLine("}");
        }
    }
}