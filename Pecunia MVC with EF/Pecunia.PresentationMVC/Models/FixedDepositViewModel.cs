using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PecuniaMVC.Models
{
    public class FixedDepositViewModel
    {
        [Required(ErrorMessage = "FdDeposoit can't be blank")]
        [Range(20000,1000000)]
        public Nullable<long> FdDeposit { get; set; }

        [Required(ErrorMessage = "Tenure can't be blank")]
        public Nullable<int> Tenure { get; set; }

        [Required(ErrorMessage = "HomeBranch can't be blank")]
        public string HomeBranch { get; set; }

        [Required(ErrorMessage = "CustomerID can't be blank")]
        public Nullable<System.Guid> CustomerID { get; set; }
    }
}