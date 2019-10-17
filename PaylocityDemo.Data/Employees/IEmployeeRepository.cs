using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PaylocityDemo.Domain.Models;

namespace PaylocityDemo.Domain.Employees
{
    public interface IEmployeeRepository
    {
        Task<int> AddEmployeeAsync(Employee employee);

        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee> GetAsync(int id);
    }
}
