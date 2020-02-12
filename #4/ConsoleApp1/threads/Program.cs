using System;
using System.Threading;
namespace threads
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(() =>
            {
                for (int i = 0; i < 10; i++) {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("New thread");
                    Thread.Sleep(600);
                }
                
            

            });
            thread.Start();
            for (int i = 0; i < 10; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Main thread!");
                Thread.Sleep(1000);
            }
                
        }
    }
}
