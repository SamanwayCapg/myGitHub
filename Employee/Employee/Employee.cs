using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace EmployeeNamespace
{
    interface IEmployee
    {
        long EmployeeID { get; set; }
        string EmployeeName { get; set; }
        string EmployeeCode { get; set; }
        string EmployeeEmail { get; set; }
        string EmployeePassword { get; set; }
        string EmployeeMobile { get; set; }
      
    }

    [Serializable]
    public class Employee
    {
        //fields
        private long _employeeID;
        private string _employeeName;
        private string _employeeCode;
        private string _employeeEmail;
        private string _employeePassword;
        private string _employeeMobile;
       

        //constructor parameterless
        public Employee() { }

        //constructor parameterized
        public Employee(string name, string code, string email, string password, string mobile)
        {
            EmployeeName = name;
            EmployeeCode = code;
            EmployeeEmail = email;
            EmployeePassword = password;
            EmployeeMobile = mobile;
        }

        //properties
        public long EmployeeID
        {
            set
            {
                _employeeID = value;
            }
            get
            {
                return _employeeID;
            }
        }
        public string EmployeeName
        {
            set
            {
                Regex regex = new Regex("^[a-zA-Z ]{2,30}*$");
                if (regex.IsMatch(value) == true && value!=null)
                    _employeeName = value;
                else
                    throw new Exception("Name should contain alphabets only and should be between 2 to 30 characters!");
            }
            get
            {
                return _employeeName;
            }
        }
        public string EmployeeCode
        {
            set
            {
                Regex regex = new Regex("^[a-zA-Z0-9]+$"); //no spaces allowed
                if (regex.IsMatch(value) == true)
                    _employeeCode = value;
                else
                    throw new Exception("Please enter valid code.");
            }
            get
            {
                return _employeeCode;
            }
        }
        public string EmployeeEmail
        {
            set
            {
                Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
                if (regex.IsMatch(value) == true)
                {
                    _employeeEmail = value;
                }
                else
                {
                    throw new Exception("Email should be valid!");
                }
            }
            get
            {
                return _employeeEmail;
            }
        }
        public string EmployeePassword
        {
            set
            {
                Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,10}$");
                if (regex.IsMatch(value) == true)
                    _employeePassword = value;
                else
                    throw new Exception("Password should be 8 to 10 characters long and should contain atleast one capital letter, number, and special character!");
            }
            get
            {
                return _employeePassword;
            }
        }
        public string EmployeeMobile
        {
            set
            {
                Regex regex = new Regex("^([9]{1})([234789]{1})([0-9]{8})$");
                if (regex.IsMatch(value) == true)
                    _employeeMobile = value;
                else
                    throw new Exception("Please enter valid mobile number, it must contain numbers only and should be of 10 digits.");
            }
            get
            {
                return _employeeMobile;
            }
        }
    }
}
