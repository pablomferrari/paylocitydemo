using AutoMapper;
using Microsoft.Extensions.Configuration;
using PaylocityDemo.Business.Dependents;
using PaylocityDemo.Business.Payroll;
using PaylocityDemo.Business.Services;
using PaylocityDemo.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaylocityDemo.Business.Employees
{
    public class EmployeeComponent : IEmployeeComponent
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IBenefitEvaluator _benefitEvaluator;
        private readonly IPayrollService _payrollService;


        const string APP_SETTINGS_DEFAULT_SALARY = "PayrollConstants:DefaultSalary";

        public EmployeeComponent(
            IConfiguration configuration,
            IMapper mapper,
            IEmployeeRepository employeeRepository,
            IBenefitEvaluator benefitEvaluator,
            IPayrollService payrollService          
        )
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
            _configuration = configuration;
            _benefitEvaluator = benefitEvaluator;
            _payrollService = payrollService;
        }

        public async Task<IEnumerable<EmployeeLite>> GetAllAsync()
        {
            var result = await _employeeRepository.GetAllAsync();
            return result.Select(x => _mapper.Map<EmployeeLite>(x));
        }

        public async Task<Employee> GetAsync(int id)
        {
            var result = await _employeeRepository.GetAsync(id);
            return _mapper.Map<Employee>(result);
        }
        public async Task<Employee> AddAsync(Employee employee)
        {
            employee.Salary = GetDefaultSalary(employee);
            SetDiscounts(employee);

            var domain = _mapper.Map<Domain.Models.Employee>(employee);

            var result = await _employeeRepository.AddAsync(domain);
            return _mapper.Map<Employee>(result);
        }

        public async Task<Employee> UpdateAsync(Employee employee)
        {
            SetDiscounts(employee);
            var domain = _mapper.Map<Domain.Models.Employee>(employee);
            var result = await _employeeRepository.UpdateAsync(domain);
            return _mapper.Map<Employee>(result);
        }

        private decimal GetDefaultSalary(Employee employee)
        {
            return _configuration.GetValue<decimal>(APP_SETTINGS_DEFAULT_SALARY);
        }

        public decimal CalculateBenefitCost(Employee employee)
        {
            return _benefitEvaluator.CalculateBenefitCost(employee);
        }

        public Paycheck GetPayCheck(Employee employee)
        {
            var benefitCost = CalculateBenefitCost(employee);
            var salary = employee.Salary;
            return new Paycheck
            {
                Employee = employee,
                BenefitCost = benefitCost,
                Salary = salary
            };
        }

        private void SetDiscounts(Employee employee)
        {
            employee.BenefitDiscount = _payrollService.EvaluateEmployeeDiscountEligibility(employee);

            foreach (var dependent in employee.Dependents)
            {
                dependent.BenefitDiscount = _payrollService.EvaluateDependentDiscountEligibility(dependent);
            }
        }
    }
}
