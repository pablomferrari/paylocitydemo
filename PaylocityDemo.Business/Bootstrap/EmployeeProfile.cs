using AutoMapper;
using PaylocityDemo.Business.Employees;

namespace PaylocityDemo.Business.Bootstrap
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, Domain.Models.Employee>()                
                .ReverseMap();
        }
    }
}
