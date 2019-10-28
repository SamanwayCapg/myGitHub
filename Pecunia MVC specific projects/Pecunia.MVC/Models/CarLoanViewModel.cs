using Capgemini.Pecunia.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Pecunia.MVC.Models
{
    public class CarLoanViewModel
    {
        public Guid LoanID { get; set; } // system generated 

        [Required(ErrorMessage ="This field can't be blank")]
        [RegularExpression("^[0-9a-fA-F-]{36}$", ErrorMessage ="Customer Id not valid")]
        public Guid ?CustomerID { get; set; } //user input 

        [Required(ErrorMessage = "This field can't be blank")]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = " Invalid Amount")]
        public double ?AmountApplied { get; set; } // user input

        [Required(ErrorMessage = "This field can't be blank")]
        
        public int ?RepaymentPeriod { get; set; } //user input

        [Required(ErrorMessage = "This field can't be blank")]
        public ServiceType Occupation { get; set; } //user input

        [Required(ErrorMessage = "This field can't be blank")]
        public double ?GrossIncome { get; set; } //user input 

        [Required(ErrorMessage = "This field can't be blank")]
        public double ?SalaryDeductions { get; set; } //user input

        [Required(ErrorMessage = "This field can't be blank")]
        public VehicleType Vehicle { get; set; } //user input 

        public bool IsAccepted { get; set; }
        public DateTime DOB { get; set; }
    }
}