using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oribi.Services;
using Oribi.Models;
using Oribi.Entity;
using System.IO;
using Microsoft.AspNetCore.Hosting;



namespace Oribi.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;
        private readonly IWebHostEnvironment hostingEnvironment;


        public EmployeeController(IEmployeeService _employeeService, IWebHostEnvironment _hostingEnvironment)
        {
            employeeService = _employeeService;
            hostingEnvironment = _hostingEnvironment;
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
        [ValidateAntiForgeryToken]      // Prevent Cross-site Request Forgery Attacks
        public async Task<IActionResult> Create(EmployeeCreateViewModel model)
        {
            if(ModelState.IsValid)
            {
                var employee = new Employee
                {
                    Id = model.Id,
                    EmployeeNo = model.EmployeeNo,
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
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
                    Phone = model.Phone,
                    PostalCode = model.PostalCode,
                };

                if(model.ImageURL != null && model.ImageURL.Length > 0)
                {
                    var uploadDir = @"images/employee";
                    var fileName = Path.GetFileNameWithoutExtension(model.ImageURL.FileName);
                    var fileExtension = Path.GetExtension(model.ImageURL.FileName);
                    var webRootPath = hostingEnvironment.WebRootPath;
                    fileName = DateTime.Now.ToString("yyymmssfff") + fileName + fileExtension;      // override the first 'var fileName'
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.ImageURL.CopyToAsync(new FileStream(path, FileMode.Create));
                    employee.ImageURL = "/" + uploadDir + "/" + fileName;
                }
                await employeeService.CreateAsync(employee);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


        [HttpGet]       // You don't have to put it, as per default it's a HTTP GET
        public IActionResult Edit(int id)
        {
            var employee = employeeService.GetById(id);
            if(employee == null)
            {
                return NotFound();
            }

            var model = new EmployeeEditViewModel()
            {
                Id = employee.Id,
                EmployeeNo = employee.EmployeeNo,
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName,
                Surname = employee.Surname,
                Gender = employee.Gender,
                Email = employee.Email,
                DOB = employee.DOB,
                DateJoinded = employee.DateJoinded,
                InsuranceNo = employee.InsuranceNo,
                PaymentMethods = employee.PaymentMethods,
                StudentLoans = employee.StudentLoans,
                UnionMembers = employee.UnionMembers,
                Address = employee.Address,
                City = employee.City,
                Phone = employee.Phone,
                PostalCode = employee.PostalCode,
            };

            return View(model);
        }


        [HttpPost]
        public IActionResult Edit(EmployeeEditViewModel model)
        {
            if(ModelState.IsValid)
            {
                var employee = employeeService.GetById(model.Id);
                if(employee == null)
                {
                    return NotFound();
                }
                employee.EmployeeNo = model.EmployeeNo;
                employee.FirstName = model.FirstName;
                employee.MiddleName = model.MiddleName;
                employee.Surname = model.Surname;
                employee.Gender = model.Gender;
                employee.Email = model.Email;
                employee.DOB = model.DOB;
                employee.DateJoinded = model.DateJoinded;
                employee.InsuranceNo = model.InsuranceNo;
                employee.PaymentMethods = model.PaymentMethods;
                employee.StudentLoans = model.StudentLoans;
                employee.UnionMembers = model.UnionMembers;
                employee.Address = model.Address;
                employee.City = model.City;
                employee.Phone = model.Phone;
                employee.PostalCode = model.PostalCode;
            }

            return View();
        }

    }
}
