using Company.Data.Models;
using Company.Service.Interfaces.Department.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Interfaces
{
    public interface IDepartmentService
    {
        Department.Dto.DepartmentDto GetbyId(int? id);
        IEnumerable<Department.Dto.DepartmentDto> GetAll();
        void Add(Department.Dto.DepartmentDto department);
        void Update(Department.Dto.DepartmentDto department);
        void Delete(Department.Dto.DepartmentDto department);
    }
}
