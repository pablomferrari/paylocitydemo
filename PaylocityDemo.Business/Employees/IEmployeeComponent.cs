using System.Collections.Generic;
using System.Threading.Tasks;
using PaylocityDemo.Business.Payroll;

namespace PaylocityDemo.Business.Employees
{
    public interface IEmployeeComponent
    {
        Task<IEnumerable<EmployeeLite>> GetAllAsync();
        Task<Employee> GetAsync(int id);
        Task<Employee> AddAsync(Employee employee);
        Task<Employee> UpdateAsync(Employee employee);
        decimal CalculateBenefitCost(Employee employee);        
        Paycheck GetPayCheck(Employee employee);
    }
}
