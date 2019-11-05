using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pecunia.Mvc.Models
{
    public class AdminHomeModel
    {
        public Guid AdminID { get; set; }

        [Required(ErrorMessage = "Admin Name cannot be empty")]
        [RegularExpression("^[a-zA-Z ]{2,40}$", ErrorMessage = "Admin Name should contain alphabets only")]
        public string AdminName { get; set; }

        [Required(ErrorMessage = "Email cannot be empty!")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email is invalid.")]
        public string AdminEmail { get; set; }

        [Required(ErrorMessage = "Password cannot be empty!")]
        [RegularExpression(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,15})", ErrorMessage = "Password should be 6 to 15 characters with at least one digit, one uppercase letter, one lower case letter.")]
        public string AdminPassword { get; set; }

        [Required(ErrorMessage = "Password cannot be empty!")]
        [RegularExpression(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,15})", ErrorMessage = "Password should be 6 to 15 characters with at least one digit, one uppercase letter, one lower case letter.")]
        public string ChangePassword { get; set; }

        [Compare("ChangePassword", ErrorMessage ="Password does not match!")]
        public string ConfirmPassword { get; set; }


        public DateTime? LastModifiedDate { get; set; }
    }
}