using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace Oribi.Entity
{
    public class PaymentRecord
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string FullName { get; set; }
        public string InsuranceNo { get; set; }
        public DateTime PayDate { get; set; }
        public string PayMonth { get; set; }
        public string TaxCode { get; set; }
        [Column(TypeName = "money")]
        public decimal HourlyRate { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal HoursWorked { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ContractualHours { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal OvertimeHours { get; set; }
        [Column(TypeName = "money")]
        public decimal ContractualEarnings { get; set; }
        [Column(TypeName = "money")]
        public decimal OvertimeEarnings { get; set; }
        [Column(TypeName = "money")]
        public decimal Tax { get; set; }
        [Column(TypeName = "money")]
        public decimal NIC { get; set; }
        [Column(TypeName = "money")]
        public decimal? UnionFee { get; set; }

        //This field is optional that why there's ? or Nullable<decimal>
        [Column(TypeName = "money")]
        public Nullable<decimal> StudentLoanCompany { get; set; }
        [Column(TypeName = "money")]
        public decimal TotalEarnings { get; set; }
        [Column(TypeName = "money")]
        public decimal TotalDeduction { get; set; }
        [Column(TypeName="money")]
        public decimal NetPayment { get; set; }




        // 1 to Many relationship

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }


        public int TaxYearId { get; set; }
        public TaxYear TaxYear { get; set; }

    }
}
