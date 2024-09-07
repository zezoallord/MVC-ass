using AutoMapper;
using Company.Data.Models;
using Company.Service.Interfaces.Employee.Dto;


namespace Company.Service.Mapping
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
        }
    }
}
