using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PaylocityDemo.Api.ViewModels;
using PaylocityDemo.Business.Employees;
using PaylocityDemo.Business.Payroll;
using PaylocityDemo.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee = PaylocityDemo.Business.Employees.Employee;

namespace PaylocityDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class EmployeesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeComponent _employeeComponent;
        private readonly IPayrollService _payrollService;

        public EmployeesController(
            IMapper mapper,
            IEmployeeComponent employeeComponent, 
            IPayrollService payrollService
        )
        {
            _mapper = mapper;
            _employeeComponent = employeeComponent;
            _payrollService = payrollService;
        }

        // GET: api/Employees
        // get all employees
        // eventualy could be parameterized to allow for paging
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeLite>>> GetEmployee()
        {
            try
            {
                var employees = await _employeeComponent.GetAllAsync();
                var vm = employees.Select(x =>  _mapper.Map<EmployeeLite>(x));
                return Ok(vm);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // GET: api/Employees/5        
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _employeeComponent.GetAsync(id);


            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            var result = await _employeeComponent.UpdateAsync(employee);
            return Ok(result);
        }

        // POST: api/Employees
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            var result = await _employeeComponent.AddAsync(employee);
            return Ok(result);
        }

        [HttpGet("paycheck/{id}")]
        public async Task<ActionResult<Employee>> GetPaycheck(int id)
        {
            var employee = await _employeeComponent.GetAsync(id);  

            var paycheck = _employeeComponent.GetPayCheck(employee);

            var vm = new PaycheckViewModel
            {
                FullName = $"{employee.FirstName} {employee.LastName}",
                BenefitCost = paycheck.BenefitCost,
                Salary = paycheck.Salary  ,
                Total = paycheck.Total
            };

            return Ok(vm);

        }


    }
}
