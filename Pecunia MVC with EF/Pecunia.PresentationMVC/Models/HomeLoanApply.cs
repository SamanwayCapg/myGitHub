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
        [Range(100000, 2000000, ErrorMessage ="Minimum Amount Rs.1 lakh and Maximum amount Rs.20 lakh")]
        public decimal? AmountApplied { get; set; } // user input

        [Required(ErrorMessage = "Repayment period can't be blank")]
        [Range(1, 180, ErrorMessage ="Minimum Repayment Period one month and maximum Repayment Period 180 months")]
        public byte? RepaymentPeriod { get; set; } //user input

        [Required(ErrorMessage = "Occupation can't be blank")]
        public string Occupation { get; set; } //user input

        [Required(ErrorMessage = "Gross income can't be blank")]
        [Range(10000, 10000000, ErrorMessage = "Minimum income Rs.10000/month and Maximum income Rs.1cr/month")]
        public decimal? GrossIncome { get; set; } //user input 

        [Required(ErrorMessage = "Salary deductions can't be blank")]
        [Range(1, 9999999, ErrorMessage ="Deductions can not be negative")]
        public decimal? SalaryDeductions { get; set; } //user input

        [Required(ErrorMessage = "Serice Years can't be blank")]
        [Range(5,50, ErrorMessage ="Minimum service experience 5 years and maximum service experience 50 years")]
        public byte? ServiceYears { get; set; } //user input 

        [Required(ErrorMessage = "Please accepts the terms and conditions")]
        public bool IsAccepted { get; set; }
    }
}