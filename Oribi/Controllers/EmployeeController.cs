using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oribi.Services;
using Oribi.Models;
using Oribi.Entity;

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

        [HttpGet]  // Render the view model to the View/UI
        public IActionResult Create()
        {
            var model = new EmployeeCreateViewModel();
            return View(model);
        }

        [HttpPost] // Send data to the server in order to create/obtain a resource
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if(ModelState.IsValid)
            {
                var employee = new Employee
                {
                    Id = model.Id,
                    EmployeeNo = model.EmployeeNo,
                    FirstName = model.FirstName,
                    Surname = model.Surname,
                    FullName = model.FullName,
                    Gender = model.Gender,
                    Email = model.Email,
                    DOB = model.DOB,
                    DateJoinded = model.DateJoinded,
                    InsuranceNo = model.InsuranceNo,
                    PaymentMethods = model.PaymentMethods,
                    StudentLoans = model.StudentLoans,
                    UnionMembers = model.UnionMembers,
                    Address = model.Address,
                    City = model.City,



                };
            }
        }
    }
}
