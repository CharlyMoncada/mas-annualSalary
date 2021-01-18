using AutoMapper;
using EmployeeAnnualSalary.Api.Business;
using EmployeeAnnualSalary.Api.Domain.DTOs;
using EmployeeAnnualSalary.Api.Domain.Enums;
using EmployeeAnnualSalary.Api.Domain.Models;
using System;

namespace EmployeeAnnualSalary.Api.Maps
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDTO>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, opts => opts.MapFrom(src => src.Person.FirstName))
                .ForMember(dest => dest.LastName, opts => opts.MapFrom(src => src.Person.LastName))
                .ForMember(dest => dest.AnnualSalary, opts => opts.MapFrom(src => new ContractFactory().Create(Enum.Parse<ContractTypes>(src.Contract.ContractType)).CalculateAnnualSalary(src.SalaryPerContract)));
        }
    }
}
