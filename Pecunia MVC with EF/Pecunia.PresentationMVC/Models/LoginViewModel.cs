using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Pecunia.Mvc.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email cannot be empty!")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage ="Invalid email!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password cannot be empty!")]
        [RegularExpression(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,15})", ErrorMessage = "Invalid password!")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Please select user type to login")]
        public string UserType { get; set; }
    }
}