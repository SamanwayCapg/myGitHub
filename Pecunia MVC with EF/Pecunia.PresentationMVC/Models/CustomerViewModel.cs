using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace Pecunia.Mvc.Models
{
    public class CustomerViewModel
    {
        public System.Guid CustomerID { get; set; }

        [Required(ErrorMessage ="Customer Name cannot be blank")]
        [RegularExpression("^[A-Za-z]*$",ErrorMessage =" Name should contain alphabets only ")]
        public string CustomerName { get; set; }

        [RegularExpression("^[A-Za-z0-9/]$")]
        [Required(ErrorMessage = " Address cannot be blank")]
        public string CustomerAddress { get; set; }

        [Required(ErrorMessage = " Mobile cannot be blank")]
        [RegularExpression( "^[0-9]{10}$",ErrorMessage ="Mobile must contain 10 digits")]
        public string CustomerMobile { get; set; }

        [Required(ErrorMessage = " Email cannot be blank")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email is invalid")]
        public string CustomerEmail { get; set; }

        [Required(ErrorMessage = " Pan Number cannot be blank")]
        [RegularExpression("^[A-Z]{5}[0-9]{4}[A-Z]{1}$", ErrorMessage = " Pan must be in correct format ")]
        public  string CustomerPan { get; set; }

        [Required(ErrorMessage = " Aadhar cannot be blank")]
        [RegularExpression("^[0-9]{12}$", ErrorMessage = "Aadhar number contain 12 digits")]
        public   string CustomerAadhaarNumber { get; set; }

        public DateTime DOB { get; set; }
        

        public  string CustomGender { get; set; }

    }
   

}