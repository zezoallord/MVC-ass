
using Company.Data.Models;
using Company.Service.Interfaces;
<<<<<<< HEAD
using Company.Service.Interfaces.Department.Dto;
using Company.Service.Interfaces.Employee.Dto;
using Company.Service.Services;
=======
>>>>>>> 4e7271227ef2f56002153a674b19f1451a9818c9
using Microsoft.AspNetCore.Mvc;
namespace company.Web.Controllers
{
    public class EmployeeController : Controller
    {
<<<<<<< HEAD
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;

        public EmployeeController(IEmployeeService employeeService,  IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
        }

        public ActionResult Index(string searchInp)
        {
            // ViewBag.Message = "Hello From Employee Index (ViewBag)";
            //
            // ViewData["TextMessage"] = "Hello From Employee Index (ViewData)";


            IEnumerable<EmployeeDto> employees = new List<EmployeeDto>();
            if (string.IsNullOrEmpty(searchInp))
                employees = _employeeService.GetAll();
            else
                employees = _employeeService.GetEmployeeByName(searchInp);
            return View(employees);
        }
        public IActionResult Delete(int? id)
        {
            var employee = _employeeService.GetById(id);
            if (employee is null)
                return RedirectToAction("NotFoundPage", null, "Home");

            _employeeService.Delete(employee);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Create()
        {
            var departments = _departmentService.GetAll();
            ViewBag.Departments = departments;
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeDto employee)
=======
        private readonly IEmployeeService _employeeservice;

        public EmployeeController(IEmployeeService employeeservice)
        {

            _employeeservice = employeeservice;
        }

        public IEmployeeService employeeservice { get; }

        public IActionResult Index()
        {
            var employees = _employeeservice.GetAll();
            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
>>>>>>> 4e7271227ef2f56002153a674b19f1451a9818c9
        {
            try
            {
                if (ModelState.IsValid)
<<<<<<< HEAD
                {
                    _employeeService.Add(employee);
                    return RedirectToAction(nameof(Index));
                }
                var departments = _departmentService.GetAll();
                ViewBag.Departments = departments;
                return View(employee);
            }
            catch (Exception ex)
            {
                var departments = _departmentService.GetAll();
                ViewBag.Departments = departments;
                return View(employee);
            }
        }

    }
}
=======
            {
                _employeeservice.Add(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);

            }
            catch (Exception ex)
            {


                return View(employee);
            }
            

        }
        public IActionResult details(int? id)
        {
            var employee = _employeeservice.GetbyId(id);
            return View(employee);
        }

    }


}
>>>>>>> 4e7271227ef2f56002153a674b19f1451a9818c9
