using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string DIR1Path = @"C:\Users\andrei.tirsina\Documents\Internship\internship\13. FilesAndStreams\DIR1";
            string DIR2Path = @"C:\Users\andrei.tirsina\Documents\Internship\internship\13. FilesAndStreams\DIR2";
            FileSync SyncDIR = new FileSync(DIR1Path, DIR2Path);
            Console.WriteLine("1. Sync\n2. Sync in real time\n 0.Exit");
            int i;
            int.TryParse(Console.ReadLine(), out i);
            switch (i)
            {
                case 1:
                    {
                        while (true)
                        {
                            SyncDIR.Sync();
                            if (Console.ReadLine() == "0") break;
                        }
                        break;
                    }
                case 2:
                    {
                        SyncDIR.SyncRealTime();
                        Console.WriteLine(@"Press 'q' to quit app.");
                        while (Console.Read() != 'q') ;
                        break;
                    }
                case 0:
                    {
                        return;
                    }

            }
        }
    }
}
