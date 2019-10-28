using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pecunia.PresentationMVC.Models
{
    public class EduLoanApplyModel
    {
        public Guid? LoanID { get; set; } // system generated 

        [Required(ErrorMessage = "You must select a customer")]
        [RegularExpression("^[0-9a-fA-F-]{36}$", ErrorMessage = "Customer Id not valid")]
        public Guid? CustomerID { get; set; } //user input 

        [Required(ErrorMessage = "Amount applied can't be blank")]
        public decimal? AmountApplied { get; set; } // user input

        [Required(ErrorMessage = "Repayment period can't be blank")]
        public byte? RepaymentPeriod { get; set; } //user input

        [Required(ErrorMessage = "Course field can't be blank")]
        public string Course { get; set; }

        [Required(ErrorMessage ="Institute name can't be blank")]
        public string InstituteName { get; set; }

        [Required(ErrorMessage = "Plase provide your student ID")]
        public string StudentID { get; set; }



        [Required(ErrorMessage = "Please accepts the terms and conditions")]
        public bool IsAccepted { get; set; }

        public string button { get; set; }
    }
}