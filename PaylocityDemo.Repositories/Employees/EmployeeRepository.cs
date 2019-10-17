using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PaylocityDemo.Domain.Models;

namespace PaylocityDemo.Repositories.Employees
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly PaylocityContext _context;

        public EmployeeRepository(PaylocityContext context)
        {
            _context = context;
        }
        public async Task<int> AddEmployeeAsync(Employee employee)
        {
            var result = await _context.AddAsync<Employee>(employee);
            await _context.SaveChangesAsync();
            return result.Entity.Id;
        }
    }
}
