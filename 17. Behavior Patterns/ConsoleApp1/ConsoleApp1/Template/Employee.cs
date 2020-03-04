using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Template
{
    abstract class Employee
    {
        public double SalaryPayable(double salary) 
        {
            double exemption = CalculationOfExemption();
            double socialTaxes = SocialTaxes(salary-exemption);
            double incomeTax = IncomeTax(salary - (exemption + socialTaxes));
            return salary - (socialTaxes + incomeTax);
        }
        public abstract double CalculationOfExemption();
        public abstract double SocialTaxes(double salary);
        public abstract double IncomeTax(double salary);
    }
}
