using Company.Data.Models;
using Company.Repository.Interfaces;
using Company.Service.Interfaces;
<<<<<<< HEAD
using Company.Service.Interfaces.Department.Dto;
=======
>>>>>>> 4e7271227ef2f56002153a674b19f1451a9818c9
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

<<<<<<< HEAD
        //public IDepartmentService Departmentservice { get; }
=======
        public IDepartmentService Departmentservice { get; }
>>>>>>> 4e7271227ef2f56002153a674b19f1451a9818c9

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
<<<<<<< HEAD
        public IActionResult Create(DepartmentDto department)
=======
        public IActionResult Create(Department department)
>>>>>>> 4e7271227ef2f56002153a674b19f1451a9818c9
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
<<<<<<< HEAD
        public IActionResult Update(int? id, DepartmentDto department)
        {
            if (department.Id != id.Value)
=======
        public IActionResult Update(int? id, Department department)
        {
            if (department.id != id.Value)
>>>>>>> 4e7271227ef2f56002153a674b19f1451a9818c9
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
