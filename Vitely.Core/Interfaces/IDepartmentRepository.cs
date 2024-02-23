
using Vitely.Core.Entities;

namespace Vitely.Core.Interfaces
{
    public interface  IDepartmentRepository 
    {
       public Task<IEnumerable<Department>> GetDepartmentList();
        Task AddDepartment(Department department);

        public Task<Department> GetDeptId(int EmployeeId);


    }
}
