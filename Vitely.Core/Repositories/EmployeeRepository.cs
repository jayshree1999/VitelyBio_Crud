using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vitely.Core.Data;
using Vitely.Core.Entities;
using Vitely.Core.Interfaces;

namespace Vitely.Core.Repositories
{
    public class EmployeeRepository:IEmployeeRepository
    {
        public readonly ApplicationDBContext _context;
        public EmployeeRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        /*public async Task<IEnumerable<Employee>> GetEmployeeList()
        {
            var EmployeeList = await _context.Employees.ToListAsync();

            return EmployeeList;
        }*/

        public async Task<IEnumerable<SP_EmpDeptInfo>> GetEmployeeList()
        {
            string sql = "exec GetEmployeeDetail";
            List<SqlParameter> parms = new List<SqlParameter>
            { 
                // Create parameters    
               // new SqlParameter { ParameterName = "@OrgId", Value = orgId }
            };
            return await _context.Set<SP_EmpDeptInfo>().FromSqlRaw(sql).ToListAsync();
        }

        public async Task<IEnumerable<SP_EmpDeptInfo>> SearchEmployeeRecords(string search)
        {
            
            string sql = "exec GetEmployeeDetail";
            
            var searchlist= await _context.Set<SP_EmpDeptInfo>().FromSqlRaw(sql).ToListAsync();
            
            
            var FilterSearch = searchlist.Where(x => x.DepartmentName.Contains(search)||x.FirstName.Contains(search)||x.LastName.Contains(search)).ToList();

            return FilterSearch;
        }

        public async Task<Employee> GetEmployeeById(int EmployeeId)
        {


            var empdetails = await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == EmployeeId);


            return empdetails;
        }


        public async Task AddEmpoyeeList(Employee employee)
        {
            if (employee.EmployeeId == 0)
            {
                Employee e = new Employee();
                e.FirstName = employee.FirstName;
                e.LastName = employee.LastName;
                e.Salary = employee.Salary;
                e.DepartmentId = employee.DepartmentId;
                e.JoinDate = DateTime.Now ;
                e.IsActive = employee.IsActive;
                _context.Employees.Add(e);
                _context.SaveChanges();
            }
            else
            {
                Employee e = await _context.Employees.FindAsync(employee.EmployeeId);

                if (employee != null)
                {

                    e.FirstName = employee.FirstName;
                    e.LastName = employee.LastName;
                    e.Salary = employee.Salary;
                    e.DepartmentId = employee.DepartmentId;
                    e.JoinDate = employee.JoinDate;
                    e.IsActive = employee.IsActive;

                    _context.Entry(e).State = EntityState.Detached;
                }
                _context.Entry(e).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteEmployee(int EmployeeId)
        {
            var delteemp = await _context.Employees.FindAsync(EmployeeId);

            if (delteemp != null)
            {
                _context.Employees.Remove(delteemp);
                await _context.SaveChangesAsync();
            }
        }

    }
}
