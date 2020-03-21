using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ConsoleApp2
{
    class FileSync
    {
        static DirectoryInfo DIR1;
        static DirectoryInfo DIR2;
        public FileSync(string dir1 ,string dir2)
        {
            DIR1 = new DirectoryInfo(dir1);
            DIR2 = new DirectoryInfo(dir2);
        }
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
        }
        private static void OnCreated(object source, FileSystemEventArgs e)
        {
            string NewPath = e.FullPath.Replace($"{DIR1.FullName}", $"{DIR2.FullName}");
            File.Copy($"{e.FullPath}", $"{NewPath}");
            OutputChanges(e.Name, NewPath, "created on");
        }
        private static void OnDelted(object source, FileSystemEventArgs e)
        {
            Console.WriteLine("File: {0} {1}!", e.FullPath, e.ChangeType);
        }
        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            Console.WriteLine("File: {0} {1}!", e.FullPath, e.ChangeType);
        }
        private static void OutputChanges(string FileName, string DirectoryName, string operation)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("File: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(FileName);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($" was {operation} directory");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(DirectoryName);
            Console.ResetColor();
        }
        public void SyncOn()
        {
            FileSystemWatcher watcherDIR1 = new FileSystemWatcher();
            FileSystemWatcher watcherDIR2 = new FileSystemWatcher();
            watcherDIR1.Path = DIR1.FullName;
            watcherDIR2.Path = DIR2.FullName;
            watcherDIR1.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                            | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            watcherDIR2.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                            | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            watcherDIR1.EnableRaisingEvents = true;
            watcherDIR1.Created += new FileSystemEventHandler(OnCreated);
            watcherDIR1.Changed += new FileSystemEventHandler(OnChanged);
            watcherDIR1.Renamed += new RenamedEventHandler(OnRenamed);
            watcherDIR2.Deleted += new FileSystemEventHandler(OnDelted);
        }
       
    }
}
