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
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ComanyDBContext _context;
        public GenericRepository(ComanyDBContext context)
        {
            _context = context;
        }

        public T GetById(int id)
        {
            return _context.Set<T>().FirstOrDefault(x => x.id == id);
        }

        public IEnumerable<T> GetAll() => _context.Set<T>().Where(x => x.isDeleted == false).ToList();

        public void Add(T entity) =>
            _context.Set<T>().Add(entity); 
        



        public void Update(T entity) =>
            _context.Set<T>().Update(entity); 
        

        public void Delete(T entity) =>
            _context.Set<T>().Remove(entity); 
        
    }
}
