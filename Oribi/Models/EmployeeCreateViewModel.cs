using Microsoft.AspNetCore.Http;
using Oribi.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Oribi.Models
{
    public class EmployeeCreateViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Employee Number is required"),
            RegularExpressionAttribute(@"^[A-Z]{3,3}[0-9]{3}$")]
        public string EmployeeNo { get; set; }
        //[Required, MaxLength(50)]
        [Required(ErrorMessage = "Firstname is required"), StringLength(50, MinimumLength = 2)]
        [RegularExpressionAttribute(@"^[A-Z][a-zA-Z""'\s-]*$"), Display(Name = "First Name")]
        public string FirstName { get; set; }
        [StringLength(50), Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Surname is required"), StringLength(50, MinimumLength = 2)]
        [RegularExpressionAttribute(@"^[A-Z][a-zA-Z""'\s-]*$"), Display(Name = "Surname")]
        public string Surname { get; set; }
        public string FullName { 
            get {
                return FirstName + (string.IsNullOrEmpty(MiddleName) ? " " : (" " + (char?)MiddleName[0] + ".").ToUpper()) + Surname;
            }
        }
        public string Gender { get; set; }
        [Display(Name = "Photo")]
        public IFormFile ImageURL { get; set; }                         // The IFormFile interface is used for uploading Files in ASP.Net Core MVC
        [DataType(DataType.Date), Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }
        [DataType(DataType.Date), Display(Name = "Date Joined")]
        public DateTime DateJoinded { get; set; } = DateTime.Now;
        [Display(Name = "Phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage ="Job Role is required"), StringLength(100)]
        public string Designation { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, StringLength(50), Display(Name = "Insurance No.")]
        public string InsuranceNo { get; set; }
        [Display(Name = "Payment Method")]
        public PaymentMethod PaymentMethods { get; set; }
        [Display(Name = "Student Loan")]
        public StudentLoan StudentLoans { get; set; }
        [Display(Name = "Union Member")]
        public UnionMember UnionMembers { get; set; }
        [Required, StringLength(150)]
        public string Address { get; set; }
        [Required, StringLength(50)]
        public string City { get; set; }
        [Required, StringLength(50), Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        // 1 to Many relationship
        //public IEnumerable<PaymentRecord> PaymentRecords { get; set; }
    }
}
