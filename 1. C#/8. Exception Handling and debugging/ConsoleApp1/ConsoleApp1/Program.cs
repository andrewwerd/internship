using System;
using System.Text;
using System.Collections.Generic;
namespace ConsoleApp1
{
    class NotSuchItemException : SystemException
    {
        public NotSuchItemException()
        {
            Console.WriteLine("Not such branch");
        }
    }
    class SuchItemExistException : SystemException
    {
        public SuchItemExistException()
        {
            Console.WriteLine("Such branch exist in programm");
        }
    }
    class InitException : SystemException
    {
        public InitException()
        {
            Console.WriteLine("Such branch already exists");
        }
    }
    class MergeException: Exception
    {
        public MergeException()
        {
            Console.WriteLine("Failed to merge branches, use MergeTool ");
        }
    }
    class Branch
    {
        private string _name;
        private StringBuilder _content;
        private DateTime _changeTime;

        public Branch()
        {
            _name = "\0";
            _content = new StringBuilder();
            _changeTime = new DateTime();
            _changeTime = DateTime.Now;

        }
        public Branch(string name)
        {
            _name = name;
            _content = new StringBuilder();
            _changeTime = new DateTime();
            _changeTime = DateTime.Now;
        }
        public Branch(string name, Branch current)
        {
            _name = name;
            _content = new StringBuilder();
            _content = current._content;
            _changeTime = new DateTime();
            _changeTime = DateTime.Now; 
        }
        public static int IndexByName(string name, List<Branch> branches)
        {
            for (int i = 0; i < branches.Count; i++)
            {
                if (name == branches[i]._name)
                {
                    return i;
                }
            }
            throw new NotSuchItemException();
        }
        static public void BranchInit(ref List<Branch> branches)
        {
            if (branches.Count == 0)
            {
                branches.Add(new Branch("master"));
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\tStart work\nCurrent branch is");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("    master");
                Console.ResetColor();
            }
            else throw new InitException();
        }
        static public Branch CreateBranch(string name, Branch current, ref List<Branch> branches)
        {
            int i;
            bool flag = true;
            for (i = 0; i < branches.Count; i++)
            {
                if (name == branches[i]._name)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
                branches.Add(new Branch(name, current)); 
            else 
                throw new InitException();
            return branches[i];
        }
        static public void Save(Branch current, ref List<Branch> branches)
        {
            current._changeTime = DateTime.Now;
           branches[Branch.IndexByName(current._name, branches)] = current;   
        }
        public void WriteContent()
        {
            string s;
            s = Console.ReadLine();
            do
            { 
                _content.AppendLine(s);
                s = Console.ReadLine();

            } while (s != "\\stop");
        }
        public void ReadContent()
        {
            Console.WriteLine(_content);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Date of latest changes:");
            Console.ResetColor();Console.WriteLine($" {_changeTime}");
        }
        static public void Merge(Branch current, Branch other)
        {
            if(DateTime.Compare(current._changeTime, other._changeTime) == 1)
            {
                throw new MergeException();
            }
            else
            {
                current._content = other._content;
            }
        }
        static public void MergeTool(Branch current, Branch other)
        {
            Console.WriteLine("Confirm [c], abort [a], merge[m]");
            char s = (char)Console.Read();
            switch (s)
            {
                case 'c':
                    {
                        current._content = other._content;
                        break;
                    }
                case 'a':
                    {
                        return;
                    }
                case 'm':
                    {
                        current._content.Append(other._content);
                        break;
                    }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("" +
                "Start [Start] \n " +
                "Write some content [Write] \n " +
                "Read some content [Read] \n " +
                "Save changes[Save] \n " +
                "Switch branches [Switch {name_of_branch}] \n " +
                "Create new branch [Create {name_of_branch}] \n " +
                "Merge branches [merge {name of branch} \n" +
                "Exit");
            List<Branch> branches = new List<Branch>();
            Branch current = new Branch();
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                string choice = Console.ReadLine();
                Console.ResetColor();
                string[] command = choice.Split(' ');
                choice = command[0];
                int i = 0;
                switch (choice.ToLower())
                {
                    case "start":
                        {
                            try
                            {
                                Branch.BranchInit(ref branches);
                                current = branches[0];
                            }
                            catch (InitException ex)
                            {
                                Console.WriteLine(ex.StackTrace);
                                throw new Exception("some message", ex);
                            }
                            break;
                        }
                    case "read":
                        {
                            current.ReadContent();
                            break;
                        }
                    case "save":
                        {
                            Branch.Save(current,ref branches);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Saved succes");
                            Console.ResetColor();
                            break;
                        }
                    case "write":
                        {
                            current.WriteContent();
                            break;
                        }
                    case "switch":
                        {
                            try 
                            {
                                
                                string s = command[1];
                                current = branches[Branch.IndexByName(s, branches)];
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("Current branch is");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine(s.PadLeft(40, ' '));
                                Console.ResetColor();
                            }
                            catch (NotSuchItemException ex) when (i > 3)
                            {
                                Console.WriteLine("You were thrown to the main menu ");
                            }
                            catch (NotSuchItemException ex)  
                            {
                                i++;
                                Console.WriteLine("Enter exist name:");
                                command[1] = Console.ReadLine();
                                goto case "switch";
                            }
                            catch (IndexOutOfRangeException)
                            {
                                Console.WriteLine("Branch name not entered");
                            }
                            break;
                        }
                    case "create":
                        {
                            try
                            {
                                string s = command[1];
                                current = Branch.CreateBranch(s,current, ref branches);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("Current branch is");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine(s.PadLeft(40, ' '));
                                Console.ResetColor();
                            }
                            catch (InitException ex)
                            {
                                Console.WriteLine(ex.StackTrace);
                            }
                            catch (IndexOutOfRangeException)
                            {
                                Console.WriteLine("Branch name not entered");
                            }
                            break;
                        }
                    case "merge":
                        {
                            string s = command[1];
                            try {
                                Branch.Merge(current, branches[Branch.IndexByName(s, branches)]);
                            }
                            catch(NotSuchItemException)
                            {

                            }
                            catch (MergeException)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Failed to merge branches, use MergeTool ");
                                Console.ResetColor();
                                Branch.MergeTool(current, branches[Branch.IndexByName(s, branches)]);
                            }
                            break;
                        }
                    case "exit":
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("GoodBye!");
                            Console.ResetColor();
                            return;
                        }
                }
            }
        }
    }
}
