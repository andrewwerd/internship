using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace ConsoleApp1
{
    static public class FileSynchronization
    {
        static private SHA256 Sha256 = SHA256.Create();

        // Compute the file's hash.
        static private byte[] GetHashSha256(string filename)
        {
            using (FileStream stream = File.OpenRead(filename))
            {
                return Sha256.ComputeHash(stream);
            }
        }
        static public void CopyFiles(DirectoryInfo DIR1, DirectoryInfo DIR2)
        {
            FileInfo[] FilesFromDIR1 = DIR1.GetFiles();
            foreach (var i in FilesFromDIR1)
                if (!File.Exists($"{DIR2.FullName}\\{i.Name}"))
                {
                    File.Copy($"{i.FullName}", $"{DIR2.FullName}\\{i.Name}");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("File: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(i.Name);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(" was copied to directory");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(DIR2.FullName);
                    Console.ResetColor();
                }
        }
        static public void DeleteFiles(DirectoryInfo DIR1, DirectoryInfo DIR2)
        {
            FileInfo[] FilesFromDIR2 = DIR2.GetFiles();
            foreach (var i in FilesFromDIR2)
                if (!File.Exists($"{DIR1.FullName}\\{i.Name}"))
                {
                    File.Delete($"{i.FullName}");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("File: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(i.Name);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(" was deleted from directory");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(DIR2.FullName);
                    Console.ResetColor();
                }
        }
        static public void CopyChanges(DirectoryInfo DIR1, DirectoryInfo DIR2)
        {
            FileInfo[] FilesFromDIR1 = DIR1.GetFiles();
            FileInfo[] FilesFromDIR2 = DIR2.GetFiles();
            var ChangedFiles = from file1 in FilesFromDIR1
                               from file2 in FilesFromDIR2
                               where file1.Name == file2.Name
                               where GetHashSha256(file1.FullName) != GetHashSha256(file2.FullName)
                               select file1;
            foreach (var i in ChangedFiles)
            {
                //File.Copy($"{i.FullName}", $"{DIR2.FullName}\\{i.Name}",true);
                Update(i.FullName, $"{DIR2.FullName}\\{i.Name}");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("File: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(i.Name);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" was copied to directory");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(DIR2.FullName);
                Console.ResetColor();
            }
                
        }
        static private void Update (string FirstPath, string SecondPath)
        {
            FileStream FirstStream = new FileStream(FirstPath, FileMode.Open, FileAccess.Read);
            FileStream SecondStream = new FileStream(SecondPath, FileMode.Open, FileAccess.Write);
            try
            {
                int length = (int)FirstStream.Length; 
                byte[] buffer = new byte[length];
                FirstStream.Read(buffer);
                SecondStream.Write(buffer);
            }
            finally { 
                FirstStream.Close();
                SecondStream.Close();
            }
        }
    }
}
