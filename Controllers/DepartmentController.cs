using Company.Data.Models;
using Company.Repository.Interfaces;
using Company.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace company.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentservice;

        public DepartmentController(IDepartmentService departmentservice)
        {

            _departmentservice = departmentservice;
        }

        public IDepartmentService Departmentservice { get; }

        public IActionResult Index()
        {
            var departments = _departmentservice.GetAll();
            return View(departments);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            try
            {

                if (ModelState.IsValid)
                {

                    _departmentservice.Add(department);

                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("DepartmentError", "Validation Error");
                return View(department);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("DepartmentError", ex.Message);
                return View(department);

            }
        }
        public IActionResult Details(int? id, string viewName = "Details")
        {
            var department = _departmentservice.GetbyId(id);

            if (department == null)
            {
                return RedirectToAction("notfound", null, "Home");
            }

            return View(viewName, department);
        }
        [HttpGet]
        public IActionResult Update(int? id)
        {

            return Details(id, "Update");
        }
        [HttpPost]
        public IActionResult Update(int? id, Department department)
        {
            if (department.id != id.Value)
                return RedirectToAction("notfound", null, "Home");
            _departmentservice.Update(department);

            return RedirectToAction(nameof(Index));
        }
        
        public IActionResult Delete(int id)
        {
            var department = _departmentservice.GetbyId(id);
            if (department == null)
                return RedirectToAction("notfound", null, "Home");
            _departmentservice.Delete(department);
            return RedirectToAction(nameof(Index));
        }


    }   
}
