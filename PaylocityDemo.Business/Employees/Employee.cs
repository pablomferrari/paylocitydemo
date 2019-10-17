using System;
using System.Collections.Generic;
using System.Text;

namespace PaylocityDemo.Business.Employees
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal BenefitDiscount { get; set; }
        public decimal Salary { get; set; }
        public int? BenefitId { get; set; }
    }
}
