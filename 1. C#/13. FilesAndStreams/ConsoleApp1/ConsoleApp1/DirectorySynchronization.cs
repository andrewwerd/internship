using System;
using System.IO;

namespace ConsoleApp1
{
    static public class DirectorySynchronization
    {
        static public void Copy(DirectoryInfo DIR1, DirectoryInfo DIR2)
        {
            DirectoryInfo[] SubDIR1 = DIR1.GetDirectories();
            foreach (var i in SubDIR1)
            {
                if (!Directory.Exists($"{DIR2.FullName}\\{i.Name}"))
                {
                    Directory.CreateDirectory($"{DIR2.FullName}\\{i.Name}");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Directory: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(i.Name);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(" was created to directory");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(DIR2.FullName);
                    Console.ResetColor();
                }
                DirectoryInfo SubDIRi = new DirectoryInfo($"{DIR2.FullName}\\{i.Name}");
                Copy(i, SubDIRi);
                FileSynchronization.CopyFiles(i, SubDIRi);
            }
        }
        static public void Delete(DirectoryInfo DIR1, DirectoryInfo DIR2)
        {
            DirectoryInfo[] SubDIR2 = DIR2.GetDirectories();
            foreach (var i in SubDIR2)
            {
                DirectoryInfo SubDIRi = new DirectoryInfo($"{DIR1.FullName}\\{i.Name}");
                Delete(SubDIRi, i);
                FileSynchronization.DeleteFiles(SubDIRi, i);
                if (!Directory.Exists(SubDIRi.FullName))
                {
                    Directory.Delete(i.FullName);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Directory: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(i.Name);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(" was deleted from directory");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(DIR2.FullName);
                    Console.ResetColor();
                }

            }

        }
        static public void CopyChanges(DirectoryInfo DIR1, DirectoryInfo DIR2)
        {
            DirectoryInfo[] SubDIR1 = DIR1.GetDirectories();
            foreach (var i in SubDIR1)
            {
                CopyChanges(i, new DirectoryInfo($"{DIR2.FullName}//{i.Name}"));
                FileSynchronization.CopyChanges(i, new DirectoryInfo($"{DIR2.FullName}//{i.Name}"));
            }
        }
    }
}
