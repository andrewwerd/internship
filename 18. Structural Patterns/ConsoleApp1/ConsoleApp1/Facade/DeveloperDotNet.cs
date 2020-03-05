using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Facade
{
    class DeveloperDotNet
    {
        public void TurnOnVisual()
        {
            Console.WriteLine("Visual is turned on");
        }
        public void SetAssigment()
        {
            Console.WriteLine("Begin work");
        }
        public void SearchInGoogle()
        {
            Console.WriteLine("Searching in google");
        }
        public void WriteCode()
        {
            Console.WriteLine("Visual is turned on");
        }
        public void WorkIsDone()
        {
            SetAssigment();
            TurnOnVisual();
            SearchInGoogle();
            WriteCode();
            SearchInGoogle();
            WriteCode();
            Console.WriteLine("Assigment is done");
        }
    }
}
