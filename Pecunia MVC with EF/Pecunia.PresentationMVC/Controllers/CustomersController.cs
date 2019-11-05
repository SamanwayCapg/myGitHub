using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pecunia.Mvc.Models;
using Capgemini.Pecunia.BusinessLayer;
using System.Threading.Tasks;
using Capgemini.Pecunia.Entities;
using Pecunia.PresentationMVC.ServiceReference1;

namespace Pecunia.Mvc.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult AddCustomers()
        {
            //Creating and initializing viewmodel object

            CustomerViewModel customerViewModel = new CustomerViewModel();

            //calling view and passing viewmodel object to view
            return View(customerViewModel);
        }

        public ActionResult UpdateCustomers()
        {
            //Creating and initializing viewmodel object

            CustomerViewModel customerViewModel = new CustomerViewModel();

            //calling view and passing viewmodel object to view
            return View(customerViewModel);
        }

        public ActionResult CustomersMenu()
        {
            //Creating and initializing viewmodel object
            //Pecunia.Entities.Customer cus = new Entities.Customer;

            CustomerViewModel customerViewModel = new CustomerViewModel();

            //calling view and passing viewmodel object to view
            return View(customerViewModel);
        }

        public ActionResult SearchCustomer()
        {
            //Creating and initializing viewmodel object
            //Pecunia.Entities.Customer cus = new Entities.Customer;

            CustomerViewModel customerViewModel = new CustomerViewModel();

            //calling view and passing viewmodel object to view
            return View(customerViewModel);
        }

        public ActionResult GetAllCustomers()

        {

            //creating and initializing viewmodel object
            List<CustomerViewModel> customerViewModellist = new List<CustomerViewModel>();

            using (TransactionServiceClient customerServiceClient = new TransactionServiceClient())
            {
                CustomerBL customerBL = new CustomerBL();
                List<Customer> customerList = customerBL.GetAllCustomerDetailsBL();

                foreach (var item in customerList)
                {
                    CustomerViewModel customerView = new CustomerViewModel()
                    {
                        CustomerID = item.CustomerID,
                        CustomerName = item.CustomerName,
                        CustomerAddress = item.CustomerAddress,
                        CustomerMobile = item.CustomerMobile,
                        CustomerEmail = item.CustomerEmail,
                        CustomerPan = item.CustomerPan,
                        CustomerAadhaarNumber = item.CustomerAadhaarNumber,
                        CustomGender = item.CustomerGender,
                        DOB = (DateTime)item.DOB
                    };
                    customerViewModellist.Add(customerView);
                }

               
            }



            //calling view and passing viewmodel object to view
            return View(customerViewModellist);
        }

       


        [HttpPost]
        public async Task<ActionResult> Create(CustomerViewModel customerVM)
        {
            //Create object of PersonsBL
            CustomerBL customerBL = new CustomerBL();

            //Creating object of Person EntityModel
            Customer customer = new Customer();
            customer.CustomerName = customerVM.CustomerName;
            customer.CustomerAddress = customerVM.CustomerAddress;
            customer.CustomerMobile = customerVM.CustomerMobile;
            customer.CustomerEmail = customerVM.CustomerEmail;
            customer.CustomerPan = customerVM.CustomerPan;
            customer.CustomerAadhaarNumber = customerVM.CustomerAadhaarNumber;
            customer.DOB = customerVM.DOB;
            customer.CustomerGender = customerVM.CustomGender;


            //Invoke the AddCustomer method BL
             bool isAdded = await customerBL.AddCustomerBL(customer);
            if (isAdded == true)
            {
             
                return Content("Customer added");
            }
            else
            {
              
                return Content("Customer not added");
            }
        }

        public async Task<ActionResult> Update(Guid id)
        {
            Customer customer = new Customer();
            CustomerViewModel cvm = new CustomerViewModel();
            CustomerBL cuBL = new CustomerBL();
            customer = await cuBL.GetCustomerByCustomerIDBL(id);
            cvm.CustomerName = customer.CustomerName;
            cvm.CustomerAddress = customer.CustomerAddress;
            cvm.CustomerMobile = customer.CustomerMobile;
            cvm.CustomerEmail = customer.CustomerEmail;
            cvm.CustomerID = customer.CustomerID;
            cvm.CustomerPan = customer.CustomerPan;
            cvm.CustomerAadhaarNumber = customer.CustomerAadhaarNumber;
            cvm.DOB = Convert.ToDateTime(customer.DOB);
            cvm.CustomGender = customer.CustomerGender;

            return View("UpdateCustomers",cvm);

        }

        [HttpPost]
        public async Task<ActionResult> Update1(FormCollection customerVM)
        {
           
            CustomerBL customerBL = new CustomerBL();

            System.Diagnostics.Debug.WriteLine(customerVM["CustomerID"]);
        

            //Creating object of Person EntityModel
            Customer customer = new Customer();
            Guid.TryParse(customerVM["CustomerID"], out Guid cust);
            customer.CustomerID = cust;

            customer.CustomerName = customerVM["CustomerName"];
            customer.CustomerAddress = customerVM["CustomerAddress"];
            customer.CustomerMobile = customerVM["CustomerMobile"];
            customer.CustomerEmail = customerVM["CustomerEmail"];
            customer.CustomerPan = customerVM["customerPan"];
            customer.CustomerAadhaarNumber = customerVM["CustomerAadhaarNumber"];
            customer.DOB = Convert.ToDateTime(customerVM["DOB"]);
            customer.CustomerGender= customerVM["CustomGender"];
            


            bool isupdated = await customerBL.UpdateCustomerByCustomerIDBL(customer);
            if (isupdated == true)
            {

                return Content("Customer updated");
            }
            else
            {

                return Content("Customer not updated");
            }

        }


    }
}