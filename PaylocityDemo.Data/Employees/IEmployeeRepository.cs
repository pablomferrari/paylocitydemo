using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PaylocityDemo.Domain.Models;

namespace PaylocityDemo.Domain.Employees
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee> GetAsync(int id);
        Task<Employee> AddAsync(Employee employee);
        Task<Employee> UpdateAsync(Employee employee);
    }
}
