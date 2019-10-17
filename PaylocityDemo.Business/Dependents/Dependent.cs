using System;
using System.Collections.Generic;
using System.Text;

namespace PaylocityDemo.Business.Dependents
{
    public class Dependent
    {
        public int Id { get; set; }
        public string DependentName { get; set; }
        public int? EmployeeId { get; set; }
        public decimal? BenefitDiscount { get; set; }
        public int BenefitId { get; set; }
    }
}
