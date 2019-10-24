using System;
using System.Collections.Generic;
using System.Text;

namespace PaylocityDemo.Business.Employees
{
    public class EmployeeLite
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
    }
}
