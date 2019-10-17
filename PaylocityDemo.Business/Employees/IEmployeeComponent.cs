using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaylocityDemo.Business.Employees
{
    public interface IEmployeeComponent
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee> GetAsync(int id);
        Task<Employee> AddAsync(Employee employee);

    }
}
