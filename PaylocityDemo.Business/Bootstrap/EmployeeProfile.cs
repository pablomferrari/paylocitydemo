using AutoMapper;
using PaylocityDemo.Business.Employees;

namespace PaylocityDemo.Business.Bootstrap
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Domain.Models.Employee, Employee>().ReverseMap();
            CreateMap<Domain.Models.Employee, EmployeeLite>();
        }
    }
}
