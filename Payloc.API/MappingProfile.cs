using AutoMapper;
using Payloc.Domain.Payroll;

namespace Payloc.API;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<PayCheck, PayCheckModel>();
        CreateMap<Domain.Employees.Employee, EmployeeModel>();
        CreateMap<Domain.Employees.DependentPerson, DependentModel>();
        CreateMap<(string Name,decimal Cost), BenefitModel>()
            .ForMember(x=>x.AnnualCost, x=>x.MapFrom(s=>s.Cost)
            ).ForMember(x=>x.Name, x=>x.MapFrom(s=>s.Name));
    }
}