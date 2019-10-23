using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using Capgemini.Pecunia.BusinessLayer;
using Capgemini.Pecunia.Entities;
using Capgemini.Pecunia.Exceptions;
using Capgemini.Pecunia.Helper;

namespace Capgemini.Pecunia.PresentationLayer
  
{
   /* public class MainClass
    {
        [STAThread]
        public static void Main()
        {
            CustomerPresentation.DisplayMenu().Wait();
        }
    }*/
    public static class CustomerPresentation
    {
        public static async Task DisplayMenu()
        {
               int choice;

                do
                {
                    Console.WriteLine("1.Add Customer\n" +
                                      "2.Remove Customer\n" +
                                      "3.Update Customer By CustomerID \n" +
                                      "4.Get Customer By CustomerID\n" +
                                      "5.Get All Customer Details \n" +
                                      "6. Back");

                    CustomerBL customerBL = new CustomerBL();
                    //CustomerPresentation cp = new CustomerPresentation();

                    choice = int.Parse(ReadLine());
                    if (choice != 6)
                    {
                        switch (choice)
                        {
                            case 1:
                                await CustomerPresentation.AddCustomer();
                                break;

                            case 2:
                                await CustomerPresentation.RemoveCustomer();
                                break;

                            case 3:
                                await CustomerPresentation.UpdateCustomer();
                                break;

                            case 4:
                                await CustomerPresentation.GetCustomerByCustomerID();
                                break;

                            case 5:
                                 CustomerPresentation.GetAllCustomerDetails();
                                break;


                            default:
                                Console.WriteLine("Invalid Choice");
                                break;
                        }
                    }
                } while (choice != 6);

        }

        public static bool GetAllCustomerDetails_PL()
        {
            CustomerBL custs = new CustomerBL();
            List<Customer> customers = custs.GetAllCustomerDetailsBL();

            foreach (var customer in customers)
            {
                Console.WriteLine($"Customer ID: {customer.CustomerID}");
                Console.WriteLine($"Customer Name: {customer.CustomerName}");
                Console.WriteLine($"Customer Address: {customer.CustomerAddress}");
                Console.WriteLine($"Customer Mobile: {customer.CustomerMobile}");
                Console.WriteLine($"Customer Email: {customer.CustomerEmail}");
                Console.WriteLine($"Customer PAN: {customer.CustomerPan}");
                Console.WriteLine($"Customer AadhaarNumber: {customer.CustomerAadhaarNumber}");
                Console.WriteLine($"Customer DOB: {customer.DOB}");
                Console.WriteLine($"Customer Gender: {customer.CustomGender}");


            }

            return true;
        }

        public static async Task<bool> AddCustomer()
        {
            bool isAdded = false;
            try
            {
                Customer customer = new Customer();
                CustomerBL customerBL = new CustomerBL();
                Console.Write("Enter Name:");
                customer.CustomerName = ReadLine();

                Console.Write("Enter Address:");
                customer.CustomerAddress = ReadLine();

                Console.Write("Enter Mobile:");
                customer.CustomerMobile = ReadLine();

                Console.Write("Enter Email:");
                customer.CustomerEmail = ReadLine();

                Console.Write("Enter PAN:");
                customer.CustomerPan = ReadLine();

                Console.Write("Enter AadhaarNumber:");
                customer.CustomerAadhaarNumber = ReadLine();

                Console.Write("Enter Date Of Birth:");
                customer.DOB = ReadLine();


                Console.Write("Enter Gender:");
                string gen = ReadLine();
                if (gen.Equals("Male", StringComparison.OrdinalIgnoreCase))
                {
                    customer.CustomGender = Gender.Male;
                }
                else if (gen.Equals("Female", StringComparison.OrdinalIgnoreCase))
                {
                    customer.CustomGender = Gender.Female;
                }
                else
                {
                    customer.CustomGender = Gender.TransGender;
                }

                isAdded = await customerBL.AddCustomerBL(customer);
                if (isAdded == true)
                {
                    Console.WriteLine("Customer added successfully\nPress any key -> Previous menu");
                    Console.ReadKey();
                }
                //else
                //    Console.WriteLine("Customer could not be adeed");

                Console.ReadKey();
                return isAdded;
            }
            catch(PecuniaException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }


            Console.WriteLine($"{isAdded}Press any key -> Previous menu");
            Console.ReadKey();
            return false;
        }

        public static async Task<bool> RemoveCustomer()
        {
            try
            {
                bool isRemoved = true;
                CustomerBL cust = new CustomerBL();
                Console.WriteLine("Enter Customer ID Which you want to remove");
                bool isGuid = Guid.TryParse(ReadLine(), out Guid customerID);
                if (isGuid == false)
                {
                    Console.WriteLine("Not a valid customer ID\nPress any key -> previous Menu");
                    Console.ReadKey();
                    return false;
                }

                isRemoved = await cust.RemoveCustomerBL(customerID);
                if (isRemoved == false)
                {
                    Console.WriteLine("customerID not found\nPress any key -> Previous Menu");
                    Console.ReadKey();
                    return false;
                }
                
            }
            catch
            {

            }

            Console.WriteLine("customer removed successfully\nPress any key -> Previous Menu");
            Console.ReadKey();
            return true;
        }

        public static async Task<bool> UpdateCustomer()
        {
            bool isUpdated = false;
            try
            {
                Customer customer = new Customer();
                CustomerBL customerBL = new CustomerBL();
                Console.Write("Enter Name");
                customer.CustomerName = ReadLine();

                Console.Write("Enter Address");
                customer.CustomerAddress = ReadLine();

                Console.Write("Enter Mobile");
                customer.CustomerMobile = ReadLine();

                Console.Write("Enter Email");
                customer.CustomerEmail = ReadLine();

                Console.Write("Enter PAN");
                customer.CustomerPan = ReadLine();

                Console.Write("Enter Email");
                customer.CustomerEmail = ReadLine();

                Console.Write("Enter AadhaarNumber");
                customer.CustomerAadhaarNumber = ReadLine();

                Console.Write("Enter Date Of Birth");
                customer.DOB = ReadLine();


                Console.WriteLine("Enter Gender");
                string gen = ReadLine();
                if (gen.Equals("Male", StringComparison.OrdinalIgnoreCase))
                {
                    customer.CustomGender = Gender.Male;
                }
                else if (gen.Equals("Female", StringComparison.OrdinalIgnoreCase))
                {
                    customer.CustomGender = Gender.Female;
                }
                else
                {
                    customer.CustomGender = Gender.TransGender;
                }
                Console.Write("Enter Customer ID ");
                bool isGuid = Guid.TryParse(ReadLine(), out Guid customerID);
                if (isGuid == false)
                {
                    Console.WriteLine("Enter Valid Guid\nPress any key -> Previous Menu");
                    Console.ReadKey();
                    return false;
                }
                customer.CustomerID = customerID;

                isUpdated = await customerBL.UpdateCustomerByCustomerIDBL(customer);
                if(isUpdated == false)
                {
                    Console.WriteLine("could not update customer details\npress any key -> previous menu");
                    Console.ReadKey();
                    return false;
                }
            }
            catch
            {

            }

            Console.WriteLine("customer updated successfully\n press any key -> previous menu");
            Console.ReadKey();
            return true;
        }
        
        public static async Task<bool> GetCustomerByCustomerID()
        {
            Customer customer = new Customer();
            CustomerBL customerBL = new CustomerBL();
            Console.WriteLine("Enter CustomerID");
            bool isGuid = Guid.TryParse(ReadLine(), out Guid customerID);
            if (isGuid == false)
            {
                Console.WriteLine("Enter Valid Guid");
                return false;
            }

            if(await customerBL.isCustomerIDExistBL(customerID) == false)
            {
                Console.WriteLine("customer id not found in records\npress any key -> Try again");
                Console.ReadKey();
                return false;
            }

            customer.CustomerID = customerID;
            Customer temp = new Customer();
            temp = await customerBL.GetCustomerByCustomerIDBL(customer.CustomerID);

            Console.WriteLine("Customer Name "+temp.CustomerName);
            Console.WriteLine("Customer Email " + temp.CustomerEmail);
            Console.WriteLine("Customer Address" + temp.CustomerAddress);
            Console.WriteLine("Customer PAN " + temp.CustomerPan);
            Console.WriteLine("Customer Adhaar Number"+temp.CustomerAadhaarNumber);
            Console.WriteLine("Customer Gender" + temp.CustomGender);
            Console.WriteLine("Customer Date of Birthd" + temp.DOB);
            return true;
        }

        public static void GetAllCustomerDetails()
        {
            List<Customer> customerList = new List<Customer>();
            CustomerBL customerBL = new CustomerBL();
            customerList =  customerBL.GetAllCustomerDetailsBL();
            foreach(Customer index in customerList)
            {
                Console.WriteLine("Customer Name " + index.CustomerName);
                Console.WriteLine("Customer Email " + index.CustomerEmail);
                Console.WriteLine("Customer Address" + index.CustomerAddress);
                Console.WriteLine("Customer PAN " + index.CustomerPan);
                Console.WriteLine("Customer Adhaar Number" + index.CustomerAadhaarNumber);
                Console.WriteLine("Customer Gender" + index.CustomGender);
                Console.WriteLine("Customer Date of Birthd" + index.DOB);
                Console.WriteLine("==================================================================");

            }
        }

    }

    

}
