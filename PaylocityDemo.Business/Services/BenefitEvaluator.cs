using Microsoft.Extensions.Configuration;
using PaylocityDemo.Business.Dependents;
using PaylocityDemo.Business.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaylocityDemo.Business.Services
{
    public class BenefitEvaluator : IBenefitEvaluator
    {
        private readonly IConfiguration _configuration;
        const string DEFAULT_EMPLOYEE_BENEFIT_COST = "PayrollConstants:DefaultEmployeeBenefitCost";
        const string DEFAULT_DEPEDENT_BENEFIT_COST = "PayrollConstants:DefaultDependentBenefitCost";
        const string CHECK_COUNT_PER_YEAR = "PayrollConstants:YearlyPaycheckCount";
        public BenefitEvaluator(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public decimal GetDefaultBenefitCost<T>(T entity)
        {
            if (entity is Employee)
            {
                return _configuration.GetValue<decimal>(DEFAULT_EMPLOYEE_BENEFIT_COST);
            } 
            else if(entity is Dependent)
            {
                return _configuration.GetValue<decimal>(DEFAULT_DEPEDENT_BENEFIT_COST);
            }

            return default(decimal);
        }

        public decimal CalculateBenefitCost(Employee employee)
        {            
            var dependentCost = _configuration.GetValue<decimal>(DEFAULT_DEPEDENT_BENEFIT_COST);
            var employeeCost = _configuration.GetValue<decimal>(DEFAULT_EMPLOYEE_BENEFIT_COST);
            var checkCountPerYear = _configuration.GetValue<int>(CHECK_COUNT_PER_YEAR);
            var total = employeeCost - (employeeCost * employee.BenefitDiscount);
            foreach (var dependent in employee.Dependents)
            {
                total += dependentCost - (dependentCost * (dependent.BenefitDiscount ?? 0));
            }

            return total / checkCountPerYear;
        }
    }
}
