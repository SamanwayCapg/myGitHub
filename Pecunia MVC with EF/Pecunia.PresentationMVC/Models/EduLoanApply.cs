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
        [Range(100000, 2000000, ErrorMessage ="Amount must be betwen Rs.1 lakh to Rs.20 lakh")]
        public decimal? AmountApplied { get; set; } // user input

        [Required(ErrorMessage = "Repayment period can't be blank")]
        [Range(1, 96, ErrorMessage ="Repayment period must be between one months to 96 months")]
        public byte? RepaymentPeriod { get; set; } //user input

        [Required(ErrorMessage = "Course field can't be blank")]
        public string Course { get; set; }

        [Required(ErrorMessage ="Institute name can't be blank")]
        [RegularExpression("[a-zA-Z]*", ErrorMessage="Only alphabets are allowed")]
        public string InstituteName { get; set; }

        [Required(ErrorMessage = "Plase provide your student ID")]
        [RegularExpression("[a-zA-Z0-9]*", ErrorMessage = "Only alphabets and numerics are allowed")]
        public string StudentID { get; set; }



        [Required(ErrorMessage = "Please accepts the terms and conditions")]
        public bool IsAccepted { get; set; }

        public string button { get; set; }
    }
}