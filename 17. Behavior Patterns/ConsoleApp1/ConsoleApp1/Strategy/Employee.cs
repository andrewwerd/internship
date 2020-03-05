using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Employee
    {
        public int Salary { get; set; }
        private ITaxes _taxCalculationMethod;
        public void SetCalculationMethod(ITaxes method)
        {
            _taxCalculationMethod = method;
        }
        public double TaxCalculation()
        {
            return _taxCalculationMethod.TaxCalculation(Salary);
        }
    }
}
