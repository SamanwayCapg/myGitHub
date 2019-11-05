using Capgemini.Pecunia.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Pecunia.PresentationMVC.Models
{
    public class CarLoanApplyModel
    {
        public Guid? LoanID { get; set; } // system generated 

        [Required(ErrorMessage = "This field can't be blank")]
        [RegularExpression("^[0-9a-fA-F-]{36}$", ErrorMessage = "Customer Id not valid")]
        public Guid? CustomerID { get; set; } //user input 

        [Required(ErrorMessage = "This field can't be blank")]
        [Range(100000, 2000000, ErrorMessage = "Minimum Amount Rs.1 lakh and Maximum amount Rs.20 lakh")]
        public decimal? AmountApplied { get; set; } // user input

        [Required(ErrorMessage = "This field can't be blank")]
        [Range(1,120, ErrorMessage = "Minimum Repayment Period one month and maximum Repayment Period 180 months")]
        public byte? RepaymentPeriod { get; set; } //user input

        [Required(ErrorMessage = "This field can't be blank")]
        public string Occupation { get; set; } //user input

        [Required(ErrorMessage = "This field can't be blank")]
        [Range(10000, 10000000, ErrorMessage = "Minimum income Rs.10000/month and Maximum income Rs.1cr/month")]
        public decimal? GrossIncome { get; set; } //user input 

        [Required(ErrorMessage = "This field can't be blank")]
        [Range(1, 9999999, ErrorMessage = "Deductions can not be negative")]
        public decimal? SalaryDeductions { get; set; } //user input

        [Required(ErrorMessage = "This field can't be blank")]
        public string Vehicle { get; set; } //user input 

        [Required(ErrorMessage = "Please accepts the terms and conditions")]
        public bool IsAccepted { get; set; }

    }
}