using System;
using System.Collections.Generic;

namespace PaylocityDemo.Domain.Models
{
    public partial class Dependent
    {
        public int Id { get; set; }
        public string DependentName { get; set; }
        public int? EmployeeId { get; set; }
        public decimal? BenefitDiscount { get; set; }
        public int BenefitId { get; set; }

        public virtual Benefit Benefit { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
