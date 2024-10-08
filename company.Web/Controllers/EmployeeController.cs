﻿using Company.Service.Interfaces;
using Company.Service.Interfaces.Employee.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers
{
    [Authorize]

    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;

        public EmployeeController(IEmployeeService employeeService, IDepartmentService departmentService)
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
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeDto employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _employeeService.Add(employee);
                    return RedirectToAction(nameof(Index));
                }

                return View(employee);
            }
            catch (Exception ex)
            {
                return View(employee);
            }
        }

    }
}