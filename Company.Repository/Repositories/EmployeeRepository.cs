using Company.Data.Context;
using Company.Data.Models;
using Company.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Repositories
{
    public class EmployeeRepository :  GenericRepository<Employee>,IEmployeeRepository
    {
        private readonly ComanyDBContext _context;

        public EmployeeRepository(ComanyDBContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetEmployeeByName(string name) => _context.Employee.Where(x => x.Name.Trim().ToLower().Contains(name.Trim().ToLower())).ToList();
        public IEnumerable<Employee> GetEmployeesByAddress(string address)
        {
            throw new NotImplementedException();
        }

     
    } 
}
