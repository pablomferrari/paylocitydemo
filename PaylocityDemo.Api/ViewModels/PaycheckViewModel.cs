using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaylocityDemo.Api.ViewModels
{
    public class PaycheckViewModel
    {
        public string FullName { get; set; }
        public decimal Salary { get; set; }
        public decimal BenefitCost { get; set; }
        public decimal Total { get; set; }
    }
}
