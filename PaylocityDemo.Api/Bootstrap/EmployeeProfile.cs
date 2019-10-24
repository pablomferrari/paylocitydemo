using AutoMapper;
using PaylocityDemo.Api.ViewModels;
using PaylocityDemo.Business.Employees;

namespace PaylocityDemo.Api.Bootstrap
{
    internal class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeViewModel>();
        }
    }
}