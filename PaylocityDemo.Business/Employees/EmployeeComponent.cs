using AutoMapper;
using PaylocityDemo.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaylocityDemo.Business.Employees
{
    public class EmployeeComponent : IEmployeeComponent
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeComponent(
            IMapper mapper,
            IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }
        public Task<Employee> AddAsync(Employee employee)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            var result = await _employeeRepository.GetAllAsync();
            return result.Select(x => _mapper.Map<Employee>(x));
        }

        public async Task<Employee> GetAsync(int id)
        {
            Domain.Models.Employee result = await _employeeRepository.GetAsync(id);
            return _mapper.Map<Employee>(result);
        }
    }
}
