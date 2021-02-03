using Oribi.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Oribi.Models
{
    public class EmployeeDetailViewModel
    {
        public int Id { get; set; }
        public string EmployeeNo { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string ImageURL { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DateJoinded { get; set; }
        public string Phone { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }
        [Required, MaxLength(50)]
        public string InsuranceNo { get; set; }
        public PaymentMethod PaymentMethods { get; set; }
        public StudentLoan StudentLoans { get; set; }
        public UnionMember UnionMembers { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }
}
