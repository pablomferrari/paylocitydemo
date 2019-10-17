using System;
using System.Collections.Generic;

namespace PaylocityDemo.Domain.Models
{
    public partial class Benefit
    {
        public Benefit()
        {
            Dependent = new HashSet<Dependent>();
            Employee = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public int BenefitType { get; set; }
        public decimal Cost { get; set; }

        public virtual ICollection<Dependent> Dependent { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
