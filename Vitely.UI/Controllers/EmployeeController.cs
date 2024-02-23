using Microsoft.AspNetCore.Mvc;
using Vitely.Application.Models;
using Vitely.Core.Entities;
using Vitely.Core.Interfaces;
using Vitely.Core.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Vitely.UI.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public EmployeeController(IEmployeeRepository employeeRepository,IDepartmentRepository departmentRepository)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
        }
        [HttpGet]
        public async Task<IActionResult> EmployeeAddEdit(int Id)
        {
            var emp =await _employeeRepository.GetEmployeeById(Id);

            var deptlist = await _departmentRepository.GetDepartmentList();
            ViewBag.Departments = deptlist;


            if (emp != null)
            {
                var empmodel = new EmployeeModel()
                {
                    EmployeeId = emp.EmployeeId,
                    FirstName = emp.FirstName,
                    LastName= emp.LastName,
                    JoinDate=emp.JoinDate,
                    Salary=emp.Salary,
                    IsActive=emp.IsActive,
                    DepartmentId=emp.DepartmentId

                };

              //  empmodel.Departments = dept;
                return View(empmodel);
                

            }
            ViewBag.Departments = deptlist;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EmployeeAddEdit(Employee empObj)
        {
            var dept = await _departmentRepository.GetDepartmentList();

            ViewBag.Departments = dept;

            await _employeeRepository.AddEmpoyeeList(empObj);
            return View("EmployeeList");

        }
        [HttpGet]
        public async Task<IActionResult> EmployeeDelete(int Id)
        {
            await _employeeRepository.DeleteEmployee(Id);
            return RedirectToAction("EmployeeList");
        }

        public async Task<IActionResult> EmployeeList(string search,int pg=1)
        {
            const int pageSize = 10;
            if (pg < 1)
            {
                pg = 1;

            }
            if (search!=null)
            {
                var employees = await _employeeRepository.SearchEmployeeRecords(search);
                if(employees!=null)
                {
                    List<EmpDeptModel> employeeModels = new();
                    foreach (var emp in employees)
                    {
                        var employee = new EmpDeptModel()
                        {
                            FirstName = emp.FirstName,
                            LastName = emp.LastName,
                            Salary = emp.Salary,
                            // DepartmentId=emp.DepartmentId,
                            JoinDate = emp.JoinDate,
                            DepartmentName = emp.DepartmentName,
                            IsActive = emp.IsActive


                        };
                        employeeModels.Add(employee);
                    }
                    int resCount = employeeModels.Count();
                    var pager = new Pager(resCount, pg, pageSize);

                    int recSkip = (pg - 1) * pageSize;
                    var  employeedetail = employeeModels.Skip(recSkip).Take(pageSize).ToList();

                    this.ViewBag.Pager = pager;


                    return View(employeedetail);



                }
                return View();


            }
            else
            {
                var employees = await _employeeRepository.GetEmployeeList();

                if (employees != null)
                {

                    List<EmpDeptModel> employeeModels = new();
                    foreach (var emp in employees)
                    {
                        var employee = new EmpDeptModel()
                        {
                            FirstName = emp.FirstName,
                            LastName = emp.LastName,
                            Salary = emp.Salary,
                             EmployeeId=emp.EmployeeId,
                             DepartmentId=emp.DepartmentId,
                            JoinDate = emp.JoinDate,
                            DepartmentName = emp.DepartmentName,
                            IsActive = emp.IsActive


                        };
                        employeeModels.Add(employee);
                    }


                    return View(employeeModels);


                }


            }



            return View();

        }
    }
}
