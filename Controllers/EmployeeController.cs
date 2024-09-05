
using Company.Data.Models;
using Company.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace company.Web.Controllers
{
    public class EmployeeController : Controller
    {
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
        {
            try
            {
                if (ModelState.IsValid)
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
