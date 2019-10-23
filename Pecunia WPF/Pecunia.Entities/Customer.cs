using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capgemini.Pecunia.Helper;



namespace Capgemini.Pecunia.Entities
{
    public interface ICustomer
    {
        Guid CustomerID { get; set; }
        string CustomerName { get; set; }
        string CustomerAddress { get; set; }
        string CustomerMobile { get; set; }
        string CustomerEmail { get; set; }
        string CustomerPan { get; set; }
        string CustomerAadhaarNumber { get; set; }
        string DOB { get; set; }
        Gender CustomGender { get; set; }

    }



    public class Customer : ICustomer
    {
        [Required("CustomerID cannot be blank")]
        public Guid CustomerID { get; set; }

        [Required("CustomerName cannot be blank")]
        [RegExp("[a-zA-Z]$", "name format wrong")]
        public string CustomerName { get; set; }

        [Required("CustomerAddress cannot be blank")]
        [RegExp(@"([a-zA-Z]+|[a-zA-Z]+\s[a-zA-Z]+)$", "address format wrong")]
        public string CustomerAddress { get; set; }

        [Required("CustomerMobile cannot be blank")]
        [RegExp(@"\+?[0-9]{10}", "mobile format wrong")]
        public string CustomerMobile { get; set; }

        [Required("CustomerEmail cannot be blank")]
        [RegExp(@"([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", "email format wrong")]
        public string CustomerEmail { get; set; }

        [Required("CustomerPAN cannot be blank")]
        [RegExp(@"([A-Z]{5}\d{4}[A-Z]{1})$", "PAN format wrong")]
        public string CustomerPan { get; set; }

        [Required("CustomerAadhaarNumber cannot be blank")]
        [RegExp(@"^\d{4}\s\d{4}\s\d{4}$", "AADHAR format wrong")]
        public string CustomerAadhaarNumber { get; set; }

        [Required("Customer DateOfBirth cannot be blank")]
        [RegExp(@"^([012]\d|30|31)/(0\d|10|11|12)/\d{4}$", "date of birth format wrong")]
        public string DOB { get; set; }


        [Required("Customer Gender cannot be blank")]
        public Gender CustomGender { get; set; }



    }
}
