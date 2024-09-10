using AutoMapper;
using Company.Data.Models;
using Company.Repository.Interfaces;
using Company.Service.Interfaces;
using Company.Service.Interfaces.Department.Dto;

using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Add(DepartmentDto departmentDto)
        {
            Department department = _mapper.Map<Department>(departmentDto);
            _unitOfWork.DepartmentRepository.Add(department);
            _unitOfWork.complete();
        }

        public void Delete(DepartmentDto departmentDto)
        {
            Department department = _mapper.Map<Department>(departmentDto);
            _unitOfWork.DepartmentRepository.Delete(department);
            _unitOfWork.complete();
        }

        public IEnumerable<DepartmentDto> GetAll()
        {
           var departments = _unitOfWork.DepartmentRepository.GetAll();
            var mappeddepartments = _mapper.Map<IEnumerable<DepartmentDto>>(departments);

            return mappeddepartments;
        }

        public DepartmentDto GetbyId(int? id)
        {
            if(id == null)
                return null;

            var department = _unitOfWork.DepartmentRepository.GetById(id.Value);
            if(department == null)

                return null;
            DepartmentDto departmentdto = _mapper.Map<DepartmentDto>(department);


            return departmentdto;
        }

        public void Update(DepartmentDto departmentDto)
        {
            Department department = _mapper.Map<Department>(departmentDto);
            _unitOfWork.DepartmentRepository.Update(department);
            _unitOfWork.complete();
        }

    }


}
