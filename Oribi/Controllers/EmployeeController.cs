using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oribi.Services;
using Oribi.Models;

namespace Oribi.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService _employeeService)
        {
            employeeService = _employeeService;
        }

        public IActionResult Index()
        {
            var employees = employeeService.GetAll().Select(employee => new EmployeeIndexViewModel
            {
                Id = employee.Id,
                EmployeeNo = employee.EmployeeNo,
                FullName = employee.FullName,
                Gender = employee.Gender,
                ImageURL = employee.ImageURL,
                DateJoinded = employee.DateJoinded,
                Designation = employee.Designation,
                City = employee.City
            }).ToList();

            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
