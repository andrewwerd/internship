using System;
using System.Globalization;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region strategy
            var John = new Employee();
            John.Salary = 100000;
            John.SetCalculationMethod(new ProgressiveTax());
            Console.WriteLine($"{nameof(John)} has anual salary: {John.Salary.ToString("C")} \nIncome tax equals  {John.TaxCalculation().ToString("C")}");
            #endregion

            #region Template Method


            #endregion
        }
    }
}
