using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using PaylocityDemo.Business.Dependents;
using PaylocityDemo.Business.Employees;

namespace PaylocityDemo.Business.Services
{
    public class PayrollService : IPayrollService
    {
        const decimal DEFAULT_DISCOUNT = (decimal)0.1;
        private readonly IConfiguration _configuration;
        const string DEFAULT_EMPLOYEE_BENEFIT_COST = "PayrollConstants:DefaultEmployeeBenefitCost";
        const string DEFAULT_DEPEDENT_BENEFIT_COST = "PayrollConstants:DefaultDependentBenefitCost";
        const string CHECK_COUNT_PER_YEAR = "PayrollConstants:YearlyPaycheckCount";

        public PayrollService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public decimal EvaluateDependentDiscountEligibility(Dependent dependent)
        {
            if (dependent.DependentName.StartsWith("A", StringComparison.OrdinalIgnoreCase))
                return DEFAULT_DISCOUNT;
            else return 0;
        }

        public decimal EvaluateEmployeeDiscountEligibility(Employee employee)
        {
            if (employee.FirstName.StartsWith("A", StringComparison.OrdinalIgnoreCase)
                || employee.LastName.StartsWith("A", StringComparison.OrdinalIgnoreCase))
                return DEFAULT_DISCOUNT;
            else return 0;
        }

        public decimal CalculatePaycheckBenefitCost(Employee employee)
        {
            var dependentCost = _configuration.GetValue<decimal>(DEFAULT_DEPEDENT_BENEFIT_COST);
            var employeeCost = _configuration.GetValue<decimal>(DEFAULT_EMPLOYEE_BENEFIT_COST);          
            var total = employeeCost - (employeeCost * employee.BenefitDiscount);
            foreach (var dependent in employee.Dependents)
            {
                total += dependentCost - (dependentCost - (dependent.BenefitDiscount ?? 0));
            }
            var checkCountPerYear = _configuration.GetValue<int>(CHECK_COUNT_PER_YEAR);
            return total / checkCountPerYear;
        }

        public decimal CalculatePaycheckSalary(decimal salary)
        {
            var checkCountPerYear = _configuration.GetValue<int>(CHECK_COUNT_PER_YEAR);
            return salary / checkCountPerYear;
        }
    }
}
