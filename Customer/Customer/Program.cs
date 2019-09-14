using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Customer
{

    public interface ICustomer
    {
        string CustomerName { get; set; }
        string CustomerAddress { get; set; }
        int CustomerID { get; set; }
        string CustomerEmail { get; set; }
        string CustomerMobile { get; set; }
        string CustomerPAN { get; set; }

    }
    public class Customer: ICustomer
    {
        public string _customerName; //*
        public string _customerAddress;
        public int _customerID;
        public string _customerEmail; //* 
        public string _customerMobile;
        public string _customerPAN; //*

        public string CustomerName
        {
            set
            {
                if(Regex.IsMatch(value, @"^[a-zA-Z]+$")==true&& value.Length <= 15)
                {
                    _customerName = value;
                }
                else
                {
                    throw new Exception("Customer name should only contain letters and should be less than 15 characters long");
                }
            }
            get
            {
                return _customerName;
            }
        }
        public string CustomerAddress
        {
            set
            {
                if (value.Length <= 100)
                {
                    _customerAddress = value;
                }
                else
                {
                    throw new Exception("Customer Address should be less than 100 characters");
                }
            }
            get
            {
                return _customerAddress;
            }
        }
        public int CustomerID
        {
            set
            {

            }
            get
            {
                return _customerID;
            }
        }
        public string CustomerEmail
        {
            set
            {
                if (Regex.IsMatch(value, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")==true)
                {
                    value = _customerEmail;
                }
                else
                {
                    throw new Exception("Invalid Email ID");
                }
            }
            get
            {
                return _customerEmail;
            }
        } 
        public string CustomerMobile
        {
            set
            {
                if (Regex.IsMatch(value, @"^[0-9]+$")==true && value.Length==10)
                {
                    _customerMobile = value;
                }
                else
                {
                    throw new Exception("Invalid Mobile Number");
                }
            }
            get
            {
                return _customerMobile;
            }
        }
        public string CustomerPAN
        {
            set
            {
                if (Regex.IsMatch(value, @"^[a-zA-Z0-9]+$")==true && value.Length==10)
                {
                    _customerPAN = value;
                }
                else
                {
                    throw new Exception("Invalid Pan Number");
                }
            }
            get
            {
                return _customerPAN;
            }
        }
    }

    public interface ICustomerService
    {
        List<Customer> CustomerList { get; set; }
       


        List<Customer> AddCustomer();
        List<Customer> RemoveCustomer(int customerID);
        List<Customer> GetAllCustomerList();
        Customer GetCustomerByCustomerID(int customerID);
        Customer UpdateCustomer(int customerID);
    }

    public class CustomerService: ICustomerService
    {
        List<Customer> AddCustomer()
        {
            return ;
        }
        List<Customer> RemoveCustomer (int customerID)
        {
            return;
        }
        List<Customer> DisplayCustomerList()
        {
            return;
        }
        Customer SearchCustomer(int customerID)
        {
            return;
        }
        Customer UpdateCustomer(int customerID)
        {
            return;
        }

    }

    

    
}
