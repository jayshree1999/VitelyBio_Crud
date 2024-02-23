using Microsoft.AspNetCore.Mvc;
using Vitely.Application.Models;
using Vitely.Core.Entities;
using Vitely.Core.Interfaces;
namespace Vitely.UI.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly  IDepartmentRepository _departmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository, IConfiguration config)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpPost]
        public async Task<IActionResult> DepartmentAddEdit(Department empObj)
        {
            
           await  _departmentRepository.AddDepartment(empObj);
            return View("Index");
        }
        [HttpGet]
        public async Task <IActionResult> DepartmentAddEdit(int DepartmentId)
        {
            var dept=await _departmentRepository.GetDeptId(DepartmentId);
                if (dept != null)
            {
                var departmentModel = new DepartmentModel()
                {
                    DepartmentName=dept.DepartmentName,
                    DepartmentId = dept.DepartmentId

                };
                return View(departmentModel);

            }

            return View();
        }

        public async Task <IActionResult> Index()
        {
            var department =await _departmentRepository.GetDepartmentList();

            if (department != null){

                List<DepartmentModel> departmentModels= new();
                foreach (var dept in department)
                {
                    var Department = new DepartmentModel()
                    {
                        DepartmentName = dept.DepartmentName,
                        DepartmentId = dept.DepartmentId

                    };
                    departmentModels.Add(Department);
                }
                return View(departmentModels);


            }



            return View();

        }
    }
}
