using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Template
{
    class EmployeeFromMoldova : Employee
    {
        public string Name { get; set; }
        public int Childrens { get; set; }
        public int PersonalExemption { get; set; } = 24000;
        public int  ChildrenExemption { get; set; } = 3000;
        public override double CalculationOfExemption()
        {
            return PersonalExemption + Childrens * ChildrenExemption;
        }

        public override double IncomeTax(double salary)
        {
            return salary * 12 / 100;
        }

        public override double SocialTaxes(double salary)
        {
            return salary*10.5/100;
        }
    }
}
