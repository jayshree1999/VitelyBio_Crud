using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vitely.Core.Entities;

namespace Vitely.Core.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<SP_EmpDeptInfo> sP_EmpDeptInfos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                 .ToTable("Department");

            modelBuilder.Entity<Employee>()
                 .ToTable("Employee");

            modelBuilder.Entity<SP_EmpDeptInfo>(entity =>
            {
                entity.HasNoKey();
            });

        }


    }

}
