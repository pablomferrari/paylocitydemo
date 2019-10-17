using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PaylocityDemo.Domain.Models;

namespace PaylocityDemo.Repositories.Employees
{
    public interface IEmployeeRepository
    {
        Task<int> AddEmployeeAsync(Employee employee);
    }
}
