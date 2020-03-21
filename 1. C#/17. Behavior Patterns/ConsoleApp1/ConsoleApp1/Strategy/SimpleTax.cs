using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
   class SimpleTax : ITaxes
    {
        public double TaxCalculation(int salary)
        {
            int taxRate = 12;
            double tax = salary * taxRate / 100;
            return tax;
        }
    }
}
