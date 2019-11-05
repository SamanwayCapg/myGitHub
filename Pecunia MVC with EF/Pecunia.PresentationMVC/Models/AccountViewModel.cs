using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PecuniaMVC.Models
{
    public class AccountViewModel
    {
       [Required(ErrorMessage = "Person Name can't be blank")]
        public string HomeBranch { get; set; }


        [Required(ErrorMessage = "Account Type can't be blank")]
        public string AccountType { get; set; }

        [Required(ErrorMessage = "CustomerID can't be blank")]
        public Nullable<System.Guid> CustomerID { get; set; }

    }
}