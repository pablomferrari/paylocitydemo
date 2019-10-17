using System;
using AutoMapper;
using PaylocityDemo.Business.Dependents;

namespace PaylocityDemo.Business.Bootstrap
{
    public class DependentProfile : Profile
    {
        public DependentProfile()
        {

            CreateMap<Dependent, Domain.Models.Dependent>()
                .ReverseMap();
        }
    }
}
