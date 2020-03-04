using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Template
{
    class EmployeeFromUK:Employee
    {
        public string Name { get; set; }
        public int Childrens { get; set; }
        public int PersonalExemption { get; set; } = 30000;
        public int ChildrenExemption { get; set; } = 4500;
        public override double CalculationOfExemption()
        {
            return PersonalExemption + Childrens * ChildrenExemption;
        }

        public override double IncomeTax(double salary)
        {
            double tax = 0;
                if (salary <= 33000)
                    tax = salary * 0.1;
                else if (salary > 33000)
                    tax = 33000 * 0.1 + (salary - 33000) * 0.22;
                return tax;
        }

        public override double SocialTaxes(double salary)
        {
            return salary * 22.5 / 100;
        }
    }
}
