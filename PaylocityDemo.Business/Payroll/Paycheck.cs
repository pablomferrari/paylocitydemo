using PaylocityDemo.Business.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaylocityDemo.Business.Payroll
{
    public class Paycheck
    {
        public Employee Employee { get; set; }
        public decimal BenefitCost { get; set; }
        public decimal Salary { get; set; }
        public decimal Total => Salary - BenefitCost;
    }
}
