using System;
using System.IO;
namespace ConsoleApp2
{
    class Program
    {
        
        static void Main(string[] args)
        {
            FileSync Sync = new FileSync(@"C:\Users\andrei.tirsina\Documents\Internship\internship\13. FilesAndStreams\DIR1", @"C:\Users\andrei.tirsina\Documents\Internship\internship\13. FilesAndStreams\DIR2");
            Sync.SyncOn();
            Console.WriteLine(@"Press 'q' to quit app.");
            while (Console.Read() != 'q') ;
            Console.WriteLine("Hello World!");
        }
    }
}
