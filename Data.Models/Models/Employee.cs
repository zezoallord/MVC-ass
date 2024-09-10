using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Models
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public int age { get; set; }
        public string Address { get; set; }
        public decimal salary { get; set; }
        public string Email { get; set; }
        public string phoneNumber { get; set; }
        public DateTime Hiringdate { get; set; }
        public string ImageUrl { get; set; }
        public Department Department { get; set; }
        public int? DepartmentId { get; set; }

    }
}
