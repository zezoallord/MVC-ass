using Company.Service.Interfaces.Employee.Dto;

namespace Company.Service.Interfaces.Department.Dto
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime CreateAt { get; set; }
        public ICollection<EmployeeDto> Employees { get; set; } = new List<EmployeeDto>();
    }
}
