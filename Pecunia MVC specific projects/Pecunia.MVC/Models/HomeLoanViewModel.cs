using Capgemini.Pecunia.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Pecunia.MVC.Models
{
    public class HomeLoanViewModel
    {
        public Guid ?LoanID { get; set; } // system generated 

        [Required(ErrorMessage ="This field can't be blank")]
        public Guid ?CustomerID { get; set; } //user input 

        [Required(ErrorMessage = "This field can't be blank")]
        public double ?AmountApplied { get; set; } // user input 

        [Required(ErrorMessage = "This field can't be blank")]
        public int ?RepaymentPeriod { get; set; } //user input

        [Required(ErrorMessage = "This field can't be blank")]
        public ServiceType Occupation { get; set; } //user input 

        [Required(ErrorMessage = "This field can't be blank")]
        public int ?ServiceYears { get; set; } //user input 

        [Required(ErrorMessage = "This field can't be blank")]
        public double ?GrossIncome { get; set; } // user input

        [Required(ErrorMessage = "This field can't be blank")]
        public double ?SalaryDeductions { get; set; } //user input
    }
}