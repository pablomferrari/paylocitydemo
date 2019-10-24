using System;
using System.Collections.Generic;
using System.Text;
using PaylocityDemo.Business.Employees;

namespace PaylocityDemo.Business.Services
{
    public interface IBenefitEvaluator
    {
        decimal GetDefaultBenefitCost<T>(T entity);
        decimal CalculateBenefitCost(Employee employee);
    }
}
