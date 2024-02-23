using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vitely.Core.Entities;

namespace Vitely.Core.Interfaces
{
    public interface IEmployeeRepository
    {
        public Task<IEnumerable<SP_EmpDeptInfo>> GetEmployeeList();
        public Task<IEnumerable<SP_EmpDeptInfo>> SearchEmployeeRecords(string search);
        Task AddEmpoyeeList(Employee employee);
        public Task<Employee> GetEmployeeById(int EmployeeId);
        Task DeleteEmployee(int EmployeeId);



    }
}
