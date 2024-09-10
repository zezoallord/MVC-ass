﻿using AutoMapper;
using Company.Data.Models;
using Company.Repository.Interfaces;
using Company.Service.Helper;
using Company.Service.Interfaces;
using Company.Service.Interfaces.Employee.Dto;
using System.Reflection.Metadata;


namespace Company.Service.Services
{
    public class EmployeeService : IEmployeeService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
           _mapper = mapper;
        }
        public void Add(EmployeeDto employeeDto)
        {
            employeeDto.ImageUrl = DocumentSettings.UplodeFile(employeeDto.Image,"Images");
            Employee employee = _mapper.Map<Employee>(employeeDto);
 _unitOfWork.EmployeeRepository.Add(employee);
            _unitOfWork.complete();
        }

        public void Delete(EmployeeDto employeeDto)
        {
            Employee employee = _mapper.Map<Employee>(employeeDto);
            _unitOfWork.EmployeeRepository.Delete(employee);
            _unitOfWork.complete();
        }

        public IEnumerable<EmployeeDto> GetAll()
        {
            var employees = _unitOfWork.EmployeeRepository.GetAll();
            IEnumerable<EmployeeDto> mappedemployee = _mapper.Map<IEnumerable<EmployeeDto>>(employees);

            return mappedemployee;
        }

        public EmployeeDto GetById(int? id)
        {
            if (id is null)
                return null;

            var employee = _unitOfWork.EmployeeRepository.GetById(id.Value);
            if (employee is null)
                return null;
          


            EmployeeDto employeeDto = _mapper.Map<EmployeeDto>(employee);

            return employeeDto;
        }

        public IEnumerable<EmployeeDto> GetEmployeeByName(string name)
        { 
          var employees =  _unitOfWork.EmployeeRepository.GetEmployeeByName(name);
            IEnumerable<EmployeeDto> mappedemployee = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return mappedemployee;
        }

        public void Update(EmployeeDto employeeDto)
        {
            Employee employee = _mapper.Map<Employee>(employeeDto);
            _unitOfWork.EmployeeRepository.Update(employee);
            _unitOfWork.complete();
        }
    }

}

