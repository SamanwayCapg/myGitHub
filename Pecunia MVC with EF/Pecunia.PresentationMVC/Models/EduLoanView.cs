using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pecunia.PresentationMVC.Models
{
    public class EduLoanViewModel
    {
        public Guid? LoanID { get; set; } // system generated 
        public decimal? AmountApplied { get; set; } //user input 
        public decimal? InterestRate { get; set; } //system fixed 
        public decimal? EMI_Amount { get; set; } //system computed 
        public int? RepaymentPeriod { get; set; } //user input 
        public DateTime? DateOfApplication { get; set; } //system generated 
        public string LoanStatus { get; set; } //system determined 
        public string Course { get; set; } //user input 

        public string InstituteName { get; set; } //user input 
        public string StudentID { get; set; } //user input 
        public int? RepaymentHoliday { get; set; } // system fixed 

    }
}