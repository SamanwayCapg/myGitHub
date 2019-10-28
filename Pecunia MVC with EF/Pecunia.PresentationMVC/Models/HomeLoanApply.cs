using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pecunia.PresentationMVC.Models
{
    public class HomeLoanApplyModel
    {
        public Guid? LoanID { get; set; } // system generated 

        [Required(ErrorMessage = "You must select a customer")]
        [RegularExpression("^[0-9a-fA-F-]{36}$", ErrorMessage = "Customer Id not valid")]
        public Guid? CustomerID { get; set; } //user input 

        [Required(ErrorMessage = "Amount applied can't be blank")]
        public decimal? AmountApplied { get; set; } // user input

        [Required(ErrorMessage = "Repayment period can't be blank")]
        public byte? RepaymentPeriod { get; set; } //user input

        [Required(ErrorMessage = "Occupation can't be blank")]
        public string Occupation { get; set; } //user input

        [Required(ErrorMessage = "Gross income can't be blank")]
        public decimal? GrossIncome { get; set; } //user input 

        [Required(ErrorMessage = "Salary deductions can't be blank")]
        public decimal? SalaryDeductions { get; set; } //user input

        [Required(ErrorMessage = "Serice Years can't be blank")]
        public byte? ServiceYears { get; set; } //user input 

        [Required(ErrorMessage = "Please accepts the terms and conditions")]
        public bool IsAccepted { get; set; }
    }
}