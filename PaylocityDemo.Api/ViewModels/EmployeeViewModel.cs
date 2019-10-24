using PaylocityDemo.Business.Dependents;
using PaylocityDemo.Business.Employees;
using System.Collections.Generic;

namespace PaylocityDemo.Api.ViewModels
{
    internal class EmployeeViewModel : EmployeeLite
    {
        public IEnumerable<Dependent> Dependents { get; set; }
    }
}
