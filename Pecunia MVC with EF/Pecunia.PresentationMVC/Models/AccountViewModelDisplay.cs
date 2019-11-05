using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PecuniaMVC.Models
{
    public class AccountViewModelDisplay
    {
        public System.Guid AccountID { get; set; }
        public Nullable<long> AccountNumber { get; set; }
        public string HomeBranch { get; set; }
        [Required(ErrorMessage="This field cant be blank")]
        public string Feedback { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> DateOfCreation { get; set; }
        public string AccountType { get; set; }
        public Nullable<decimal> AccountBalance { get; set; }
        public Nullable<System.Guid> CustomerID { get; set; }

    }
}