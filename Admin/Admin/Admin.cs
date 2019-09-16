using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AdminNamespace
{
    interface IAdmin
    {
        long AdminID { get; set; }
        string AdminName { get; set; }
        string AdminEmail { get; set; }
        string AdminPassword { get; set; }
        string AdminMobile { get; set; }

        long GenerateAdminID();

    }


    [Serializable]
    public class Admin :IAdmin
    {
        //fields
        private long _adminID;
        private string _adminName;
        private string _adminEmail;
        private string _adminPassword;
        private string _adminMobile;

        public static long AdminIDCount = 100000000000;

        //constructor parameterless
        public Admin()
        {

        }

        //constructor parameterized
        public Admin(long id, string password)
        {
            AdminID = id;
            AdminPassword = password;
        }

        //properties
        public long AdminID
        {
            set
            {
                GenerateAdminID();
            }
            get
            {
                return _adminID;
            }
        }

        public string AdminName
        {
            set
            {
                Regex regex = new Regex("^[a-zA-Z ]{2,30}*$");
                if (regex.IsMatch(value) == true && value!=null)
                    _adminName = value;
                else
                    throw new Exception("Name should contain alphabets only and should be between 2 to 30 characters!");
            }
            get
            {
                return _adminName;
            }
        }

        public string AdminEmail
        {
            set
            {
                Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
                if (regex.IsMatch(value) == true)
                {
                    _adminEmail = value;
                }
                else
                {
                    throw new Exception("Email should be valid!");
                }
            }
            get
            {
                return _adminEmail;
            }
        }

        public string AdminPassword
        {
            set
            {
                Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,10}$");
                if (regex.IsMatch(value) == true)
                    _adminPassword = value;
                else
                    throw new Exception("Password should be 8 to 10 characters long and should contain atleast one capital letter, number, and special character!");
            }
            get
            {
                return _adminPassword;
            }
        }
        public string AdminMobile
        {
            set
            {
                Regex regex = new Regex("^([9]{1})([234789]{1})([0-9]{8})$");              
                if (regex.IsMatch(value) == true)
                    _adminMobile = value;
                else
                    throw new Exception("Please enter valid mobile number, it must contain numbers only and should be of 10 digits.");
            }
            get
            {
                return _adminMobile;
            }
        }

        //method to generate AdminID
        public long GenerateAdminID()
        {
            AdminID = AdminIDCount++;            
            return AdminID;
        }
    }
}
