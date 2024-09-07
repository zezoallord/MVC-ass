using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Company.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Company.Data.Context
{
    public class ComanyDBContext : DbContext
    {
        public ComanyDBContext() { 
        }
        public ComanyDBContext(DbContextOptions<ComanyDBContext> options): base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server=.; database=CompanyMVCG01; integrated security=true; trusted_connection=true;");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //modelBuilder.Entity<BaseEntity>().HasQueryFilter(x => !x.isDeleted);   
            base.OnModelCreating(modelBuilder);

        }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public object Employees { get; set; }
    }
}
