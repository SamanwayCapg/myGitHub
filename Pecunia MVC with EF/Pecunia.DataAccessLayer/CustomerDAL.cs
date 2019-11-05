using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;
using Capgemini.Pecunia.Exceptions;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Capgemini.Pecunia.Helper;

using Capgemini.Pecunia.Contracts.DALContracts;
using Capgemini.Pecunia.Entities;
using System.Data.SqlClient;
using System.Data;

namespace Capgemini.Pecunia.DataAccessLayer
{

    public class CustomerDAL : CustomerDALBase, IDisposable
    {
        public static List<Customer> CustomersList = new List<Customer>(); // list of customers is created by passing CustomerEntities class as data type 

        //Adding Customer
        public override bool AddCustomerDAL(Customer customer)
        {


            try
            {
                using (PecuniaEntities db = new PecuniaEntities())
                {
                    customer.CustomerID = Guid.NewGuid();

                    db.AddCustomerDAL(customer.CustomerID, customer.CustomerName, customer.CustomerAddress, customer.CustomerMobile, customer.CustomerEmail, customer.CustomerPan, customer.CustomerAadhaarNumber, customer.DOB, customer.CustomerGender);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }

            return true;
        }

        public override bool RemoveCustomerDAL(Guid CustomerID)
        {
            using (PecuniaEntities db = new PecuniaEntities())
            {
                var customerToRemove = db.Customers.SingleOrDefault(t => t.CustomerID == CustomerID);
                try
                {
                    if (customerToRemove != null)
                    {
                        db.Customers.Remove(customerToRemove);
                        db.SaveChanges();
                    }
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                    return false;
                }
            }
        }


        public override Customer GetCustomerByCustomerIDDAL(Guid CustomerID)
        {

            using (PecuniaEntities db = new PecuniaEntities())
            {
                Customer customer = db.Customers.Where(c => c.CustomerID == CustomerID).FirstOrDefault();
                return customer;
            }
        }

        public override List<Customer> GetAllCustomersDAL()

        {
            using (PecuniaEntities db = new PecuniaEntities())
            {
                List<Customer> customers = db.Customers.ToList();
                return customers;
            }
        }


        public override bool UpdateCustomerByCustomerIDDAL(Customer customer)
        {
            using (PecuniaEntities db = new PecuniaEntities())
            {
                Customer existingCustomer = db.Customers.Where(temp => temp.CustomerID == customer.CustomerID).FirstOrDefault();

                if (existingCustomer == null)
                {
                    return false;
                }
                else
                {
                    existingCustomer.CustomerName = customer.CustomerName;
                    existingCustomer.CustomerAddress = customer.CustomerAddress;
                    existingCustomer.CustomerMobile = customer.CustomerMobile;
                    existingCustomer.CustomerEmail = customer.CustomerEmail;
                    existingCustomer.CustomerPan = customer.CustomerPan;
                    existingCustomer.CustomerAadhaarNumber = customer.CustomerAadhaarNumber;
                    existingCustomer.DOB = customer.DOB;
                    existingCustomer.CustomerGender = customer.CustomerGender;


                    db.SaveChanges();
                    return true;
                }
            }

        }


        public override bool isCustomerIDExistDAL(Guid customerID)
        {
            return true;
        }


        

        


        /// <summary>
        /// Clears unmanaged resources such as db connections or file streams.
        /// </summary>
        public void Dispose()
        {
            //No unmanaged resources currently
        }

        public override bool SerialiazeIntoJSON(List<Customer> CustomersList, string FileName)
        {
            throw new NotImplementedException();
        }

        public override List<Customer> DeserializeFromJSON(string FileName)
        {
            throw new NotImplementedException();
        }
    }
}