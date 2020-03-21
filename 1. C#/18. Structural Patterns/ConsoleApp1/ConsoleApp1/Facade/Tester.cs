using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Facade
{
    class Tester
    {
        public void CreateTest()
        {
            Console.WriteLine("Test Created");
        }
        public void TestProduct()
        {
            Console.WriteLine("Product Checked");
        }  
        public void ResultOfTesting()
        {
            CreateTest();
            TestProduct();
            Console.WriteLine("Product without bugs");
        }
    }
}
