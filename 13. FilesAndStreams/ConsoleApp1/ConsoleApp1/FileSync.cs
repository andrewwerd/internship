using System;
using System.IO;

namespace ConsoleApp1
{
    class FileSync
    {
        static DirectoryInfo DIR1;
        static DirectoryInfo DIR2;
        public FileSync(string dir1, string dir2)
        {
            DIR1 = new DirectoryInfo(dir1);
            DIR2 = new DirectoryInfo(dir2);
        }
        public void Sync()
        {
            FileSynchronization.CopyFiles(DIR1, DIR2);
            FileSynchronization.DeleteFiles(DIR1, DIR2);
            FileSynchronization.CopyChanges(DIR1, DIR2);
            DirectorySynchronization.Copy(DIR1, DIR2);
            DirectorySynchronization.Delete(DIR1, DIR2);
            DirectorySynchronization.CopyChanges(DIR1, DIR2);
        }
        public void SyncRealTime()
        {
            FileSystemWatcher DirectoryWatcher = new FileSystemWatcher();
            DirectoryWatcher.Path = DIR1.FullName;
            DirectoryWatcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                            | NotifyFilters.DirectoryName;
            DirectoryWatcher.Created += new FileSystemEventHandler(OnCreatedDirectory);
            DirectoryWatcher.Renamed += new RenamedEventHandler(OnRenamedDirectory);
            DirectoryWatcher.Deleted += new FileSystemEventHandler(OnDeltedDirectory);
            DirectoryWatcher.EnableRaisingEvents = true;
            FileSystemWatcher FileWatcher = new FileSystemWatcher();
            FileWatcher.Path = DIR1.FullName;
            FileWatcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                            | NotifyFilters.FileName;
            FileWatcher.IncludeSubdirectories = false;
            FileWatcher.Created += new FileSystemEventHandler(OnCreated);
            FileWatcher.Changed += new FileSystemEventHandler(OnChanged);
            FileWatcher.Renamed += new RenamedEventHandler(OnRenamed);
            FileWatcher.Deleted += new FileSystemEventHandler(OnDelted);
            FileWatcher.EnableRaisingEvents = true;

        }
        private static void SyncRealTimeDirectories(string path)
        {
            FileSystemWatcher FileWatcher = new FileSystemWatcher();
            FileSystemWatcher DirectoryWatcher = new FileSystemWatcher();
            FileWatcher.Path = DirectoryWatcher.Path = path;
            FileWatcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                            | NotifyFilters.FileName;
            DirectoryWatcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                            | NotifyFilters.DirectoryName;
            FileWatcher.EnableRaisingEvents = true;
            DirectoryWatcher.EnableRaisingEvents = true;
            FileWatcher.Filter = "*.*";
            FileWatcher.Created += new FileSystemEventHandler(OnCreated);
            FileWatcher.Changed += new FileSystemEventHandler(OnChanged);
            FileWatcher.Deleted += new FileSystemEventHandler(OnDelted);
            FileWatcher.Renamed += new RenamedEventHandler(OnRenamed);
            DirectoryWatcher.Created += new FileSystemEventHandler(OnCreatedDirectory);
            DirectoryWatcher.Deleted += new FileSystemEventHandler(OnDeltedDirectory);
            DirectoryWatcher.Renamed += new RenamedEventHandler(OnRenamedDirectory);

        }
        #region FilesVents
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            string NewPath = e.FullPath.Replace($"{DIR1.FullName}", $"{DIR2.FullName}");
            if (e.Name.Contains('.'))
            {
                File.Copy($"{e.FullPath}", $"{NewPath}", true);
                OutputChangesInFile(e.Name, NewPath.Remove(NewPath.IndexOf(e.Name)), "copy to");
            }
        }
        private static void OnCreated(object source, FileSystemEventArgs e)
        {
            string NewPath = e.FullPath.Replace($"{DIR1.FullName}", $"{DIR2.FullName}");
            File.Copy($"{e.FullPath}", $"{NewPath}");
            OutputChangesInFile(e.Name, NewPath.Remove(NewPath.IndexOf(e.Name)), "created on");
        }
        private static void OnDelted(object source, FileSystemEventArgs e)
        {
            string NewPath = e.FullPath.Replace($"{DIR1.FullName}", $"{DIR2.FullName}");
            File.Delete(NewPath);
            OutputChangesInFile(e.Name, NewPath.Remove(NewPath.IndexOf(e.Name)), "deleted from");
        }
        private static void OnRenamed(object source, RenamedEventArgs e)
        {

            string NewPath = e.FullPath.Replace($"{DIR1.FullName}", $"{DIR2.FullName}");
            string OldPath = e.OldFullPath.Replace($"{DIR1.FullName}", $"{DIR2.FullName}");
            File.Move(OldPath, NewPath);
            OutputChangesInFile(e.Name, NewPath.Remove(NewPath.IndexOf(e.Name)), "renamed in");
        }
        #endregion
        #region DirectoryEvents
        private static void OnCreatedDirectory(object sender, FileSystemEventArgs e)
        {
            string NewPath = e.FullPath.Replace($"{DIR1.FullName}", $"{DIR2.FullName}");
            Directory.CreateDirectory(NewPath);
            OutputChangesInDirectory(e.Name, "created");
        }
        private static void OnRenamedDirectory(object sender, RenamedEventArgs e)
        {
            string NewPath = e.FullPath.Replace($"{DIR1.FullName}", $"{DIR2.FullName}");
            string OldPath = e.OldFullPath.Replace($"{DIR1.FullName}", $"{DIR2.FullName}");
            Directory.Move(OldPath, NewPath);
            OutputChangesInDirectory(e.OldName, "renamed"); 
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("to");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e.Name);
            Console.ResetColor();

        }
        private static void OnDeltedDirectory(object sender, FileSystemEventArgs e)
        {
            string NewPath = e.FullPath.Replace($"{DIR1.FullName}", $"{DIR2.FullName}");
            bool flag = false;
            try
            {
                Directory.Delete(NewPath);
            }
            catch (IOException)
            {
                FileInfo[] Files = new DirectoryInfo(NewPath).GetFiles();
                DirectoryInfo[] SubDirectories = new DirectoryInfo(NewPath).GetDirectories();
                if (Files.Length != 0)
                {
                    foreach (var i in Files)
                        i.Delete();
                    flag = true;
                }
                else if (SubDirectories.Length != 0)
                {
                    foreach (var i in SubDirectories)
                        DeleteDirectory(i.FullName);
                    flag = true;
                }
            }
            finally
            {
                Directory.Delete(NewPath);
            }
            OutputChangesInDirectory(e.Name, "deleted");
            if (flag)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Along with all files and subdirectories");
                Console.ResetColor();
            }
        }
        #endregion
        private static void DeleteDirectory(string Path)
        {
            try
            {
                Directory.Delete(Path);
            }
            catch (IOException)
            {
                FileInfo[] Files = new DirectoryInfo(Path).GetFiles();
                DirectoryInfo[] SubDirectories = new DirectoryInfo(Path).GetDirectories();
                if (Files.Length != 0)
                {
                    foreach (var i in Files)
                        i.Delete();
                }
                else if (SubDirectories.Length != 0)
                {
                    foreach (var i in SubDirectories)
                        DeleteDirectory(i.FullName);
                }
            }
            finally
            {
                Directory.Delete(Path);
            }
        }
        private static void OutputChangesInFile(string FileName, string DirectoryName, string operation)
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
        private static void OutputChangesInDirectory(string DirectoryName, string operation)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Directory: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(DirectoryName);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($" was {operation}");
            Console.ResetColor();
        }
    }

}
