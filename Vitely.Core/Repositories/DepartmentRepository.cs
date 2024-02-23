using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vitely.Core.Data;
using Vitely.Core.Entities;
using Vitely.Core.Interfaces;

namespace Vitely.Core.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public readonly ApplicationDBContext _context;
       public  DepartmentRepository(ApplicationDBContext context) 
        {
            _context = context;
        }
        public async Task<IEnumerable<Department>> GetDepartmentList()
        {
            var DepartmentList = await _context.Departments.Where(x=>x.IsActive==true).ToListAsync();
            
            return DepartmentList;
        }

        public async Task AddDepartment(Department department)
        {
            if (department.DepartmentId == 0)
            {
                Department d = new Department();
                 d.DepartmentName=department.DepartmentName;
                d.IsActive = department.IsActive;
                 _context.Departments.Add(d);
                _context.SaveChanges();
            }
            else
            {
                Department d = await _context.Departments.FindAsync(department.DepartmentId);
                
                if (department != null)
                {
                    d.DepartmentName = department.DepartmentName;

                    _context.Entry(d).State = EntityState.Detached;
                }
                _context.Entry(d).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }


        public async Task<Department> GetDeptId(int DepartmentId)
        {


            var department = await _context.Departments.FirstOrDefaultAsync(x => x.DepartmentId == DepartmentId);


            return department;
        }
    }
}
