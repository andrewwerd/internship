using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class ProgressiveTax : ITaxes
    {

        public double TaxCalculation(int salary)
        {
            double tax = 0;

            if (salary <= 33000)
                tax = salary * 0.08;
            else if (salary > 33000)
                tax = 33000 * 0.08 + (salary - 33000) * 0.12;

            return tax;
        }
    }
}
