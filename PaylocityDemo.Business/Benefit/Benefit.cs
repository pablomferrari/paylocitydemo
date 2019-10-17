using System;
using System.Collections.Generic;
using System.Text;

namespace PaylocityDemo.Business.Benefit
{
    public class Benefit
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int BenefitType { get; set; }
        public decimal Cost { get; set; }
    }
}
