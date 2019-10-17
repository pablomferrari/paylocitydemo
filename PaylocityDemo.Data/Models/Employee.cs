using System;
using System.Collections.Generic;

namespace PaylocityDemo.Domain.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Dependent = new HashSet<Dependent>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal BenefitDiscount { get; set; }
        public decimal Salary { get; set; }
        public int? BenefitId { get; set; }

        public virtual Benefit Benefit { get; set; }
        public virtual ICollection<Dependent> Dependent { get; set; }
    }
}
