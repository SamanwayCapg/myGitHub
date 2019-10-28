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
        public decimal? AmountApplied { get; set; } // user input

        [Required(ErrorMessage = "This field can't be blank")]

        public byte? RepaymentPeriod { get; set; } //user input

        [Required(ErrorMessage = "This field can't be blank")]
        public string Occupation { get; set; } //user input

        [Required(ErrorMessage = "This field can't be blank")]
        public decimal? GrossIncome { get; set; } //user input 

        [Required(ErrorMessage = "This field can't be blank")]
        public decimal? SalaryDeductions { get; set; } //user input

        [Required(ErrorMessage = "This field can't be blank")]
        public string Vehicle { get; set; } //user input 

        [Required(ErrorMessage = "Please accepts the terms and conditions")]
        public bool IsAccepted { get; set; }

    }
}