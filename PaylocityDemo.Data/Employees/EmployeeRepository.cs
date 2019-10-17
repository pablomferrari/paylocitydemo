using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PaylocityDemo.Domain.Models;

namespace PaylocityDemo.Domain.Employees
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

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }
    }
}
