using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PecuniaMVC.Models
{
    public class FixedDepositViewModelDisplay
    {
        public System.Guid AccountID { get; set; }
        [Range(20000, 1000000)]
        public Nullable<long> FdDeposit { get; set; }
        public Nullable<double> InterestRate { get; set; }
        public Nullable<int> Tenure { get; set; }
        public Nullable<long> AccountNumber { get; set; }
        public string HomeBranch { get; set; }
        public Nullable<System.Guid> CustomerID { get; set; }

        [Required(ErrorMessage = "Feedback can't be blank")]
        public string Feedback { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> DateOfCreation { get; set; }

        //public virtual Customer Customer { get; set; }
    }
}