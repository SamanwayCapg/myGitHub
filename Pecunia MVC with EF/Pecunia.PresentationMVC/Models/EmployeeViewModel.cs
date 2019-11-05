using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Pecunia.Mvc.Models
{
    public class EmployeeViewModel
    {

        public Guid EmployeeID { get; set; }

        [Required(ErrorMessage = "Employee Name cannot be empty")]
        [RegularExpression("^[a-zA-Z ]{2,40}$", ErrorMessage = "Employee Name should contain alphabets only")]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Email cannot be empty!")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email is invalid.")]
        public string EmployeeEmail { get; set; }

        [Required(ErrorMessage = "Mobile number can't be blank.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Mobile number should be of 10 digits.")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Password cannot be empty!")]
        [RegularExpression(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,15})", ErrorMessage = "Password should be 6 to 15 characters with at least one digit, one uppercase letter, one lower case letter.")]
        public string EmployeePassword { get; set; }

        [Compare("EmployeePassword", ErrorMessage = "Password does not match!")]
        public string ConfirmPassword { get; set; }

    }
}