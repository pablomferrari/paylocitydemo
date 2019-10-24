using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<Employee> AddAsync(Employee employee)
        {
            var result = await _context.AddAsync<Employee>(employee);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            employee.Dependents = await _context.Dependents.Where(x => x.EmployeeId == id).ToListAsync();
            return employee;
        }

        public async Task<Employee> UpdateAsync(Employee employee)
        {
            var result = _context.Update<Employee>(employee);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}
