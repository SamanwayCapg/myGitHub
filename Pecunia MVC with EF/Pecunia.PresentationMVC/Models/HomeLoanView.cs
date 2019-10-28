using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pecunia.PresentationMVC.Models
{
    public class HomeLoanViewModel
    {
        public Guid LoanID { get; set; } // system generated 
        public Guid CustomerID { get; set; } //user input 
        public decimal? AmountApplied { get; set; } // user input 
        public decimal? InterestRate { get; set; } // system fixed 
        public decimal? EMI_Amount { get; set; } // system computed 
        public byte? RepaymentPeriod { get; set; } //user input 
        public DateTime? DateOfApplication { get; set; } //system generated 
        public string Status { get; set; } // system determined 

        public string Occupation { get; set; } //user input 
        public decimal? GrossIncome { get; set; } //user input 
        public decimal? SalaryDeductions { get; set; } //user input 
        public byte? ServiceYears { get; set; }
    }
}