using PaylocityDemo.Business.Dependents;
using PaylocityDemo.Business.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaylocityDemo.Business.Services
{
    public interface IPayrollService
    {
        decimal EvaluateEmployeeDiscountEligibility(Employee employee);
        decimal EvaluateDependentDiscountEligibility(Dependent dependent);
        decimal CalculatePaycheckBenefitCost(Employee employee);       
    }
}
