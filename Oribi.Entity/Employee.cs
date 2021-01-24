using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Oribi.Entity
{

    // Employee Domain Model
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string EmployeeNo { get; set; }
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string MiddleName { get; set; }
        [Required, MaxLength(50)]
        public string Surname { get; set; }
        public string FullName { get; set; }
        public string  Gender { get; set; }
        public string ImageURL { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DateJoinded { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }
        [Required, MaxLength(50)]
        public string InsuranceNo { get; set; }
        public PaymentMethod PaymentMethods { get; set; }
        public StudentLoan StudentLoans { get; set; }
        public UnionMember UnionMembers { get; set; }
        [Required, MaxLength(150)]
        public string Address { get; set; }
        [Required, MaxLength(50)]
        public string City { get; set; }
        [Required, MaxLength(50)]
        public string PostalCode { get; set; }

        // 1 to Many relationship
        public IEnumerable<PaymentRecord> PaymentRecords { get; set; }
    }
}
