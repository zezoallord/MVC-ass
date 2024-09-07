using Company.Service.Interfaces.Department.Dto;
using Microsoft.AspNetCore.Http;

namespace Company.Service.Interfaces.Employee.Dto
{
    public class EmployeeDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int age { get; set; }
        public string Address { get; set; }
        public decimal salary { get; set; }
        public string Email { get; set; }
        public string phoneNumber { get; set; }
        public DateTime Hiringdate { get; set; }
        public IFormFile Image { get; set; }
        public string? ImageUrl { get; set; }
        public DepartmentDto? Department { get; set; }
        public int? DepartmentId { get; set; }
        public DateTime CreateAT { get; set; }
    }
}
