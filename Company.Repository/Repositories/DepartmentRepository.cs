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
    public class DepartmentRepository : GenericRepository<Department> ,IDepartmentRepository
    {
        private readonly ComanyDBContext _context;

        public DepartmentRepository(ComanyDBContext context) : base(context)
        {
            _context = context;
        }
        
    }

}

