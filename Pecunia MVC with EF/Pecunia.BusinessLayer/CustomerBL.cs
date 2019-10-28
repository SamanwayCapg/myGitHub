using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Capgemini.Pecunia.Contracts.BLContracts;
using Capgemini.Pecunia.Contracts.DALContracts;
using Capgemini.Pecunia.Exceptions;
using Capgemini.Pecunia.Entities;
using Capgemini.Pecunia.DataAccessLayer;
using Capgemini.Pecunia.Helpers;

namespace Capgemini.Pecunia.BusinessLayer
{
    /// <summary>
    /// Contains data access layer methods for inserting, updating, deleting  customer from Customers collection.
    /// </summary>
    public class CustomerBL 
    {
        //    //fields
        //    CustomerDALBase customerDAL;

        //    /// <summary>
        //    /// Constructor.
        //    /// </summary>
        //    public CustomerBL()
        //    {
        //        this.customerDAL = new CustomerDAL();
        //    }

        //    /// <summary>
        //    /// Validations on data before adding or updating.
        //    /// </summary>
        //    /// <param name="entityObject">Represents object to be validated.</param>
        //    /// <returns>Returns a boolean value, that indicates whether the data is valid or not.</returns>
        //    public async override Task<bool> Validate(Customer entityObject)
        //    {
        //        //Create string builder
        //        StringBuilder sb = new StringBuilder();
        //        bool valid = await base.Validate(entityObject);

        //        if (valid == false)
        //            throw new PecuniaException(sb.ToString());
        //        return valid;
        //    }

        //    /// <summary>
        //    /// Adds new customer to Customers collection.
        //    /// </summary>
        //    /// <param name="newCustomer">Contains the customer details to be added.</param>
        //    /// <returns>Determinates whether the new customer is added.</returns>
        //    public async Task<bool> AddCustomerBL(Customer newCustomer)
        //    {
        //        bool customerAdded = false;
        //        try
        //        {
        //            //bool isValid = await Validate(newCustomer);
        //            //if (isValid == true)
        //            {
        //                CustomerDAL custDAL = new CustomerDAL();
        //                await Task.Run(() =>
        //                {
        //                    newCustomer.CustomerID = Guid.NewGuid();
        //                    customerAdded = custDAL.AddCustomerDAL(newCustomer);


        //                });
        //            }
        //            return customerAdded;
        //        }
        //        catch
        //        {
        //            // throw new PecuniaException(e.Message);
        //            // Console.WriteLine(e.Message);
        //            return customerAdded;
        //        }

        //    }

        //    /// <summary>
        //    /// Gets all customers from the collection.
        //    /// </summary>
        //    /// <returns>Returns list of all customer.</returns>
        public List<Customer> GetAllCustomerDetailsBL()
        {
            List<Customer> customerList = new List<Customer>();
            try
            {
                CustomerDAL customerDAL = new CustomerDAL();


                customerList = customerDAL.GetAllCustomersDAL();

            }
            catch(Exception e)
            {
                BusinessLogicUtil.logException(e.Message, e.StackTrace, "CustomerBL.ListAllCustomers");
                return default(List<Customer>);
            }
            return customerList;
        }

        //    /// <summary>
        //    /// Gets customer based on CustomerID.
        //    /// </summary>
        //    /// <param name="searchCustomerID">Represents CustomerID to search.</param>
        //    /// <returns>Returns Customer object.</returns>
        //    public async Task<Customer> GetCustomerByCustomerIDBL(Guid searchCustomerID)
        //    {
        //        CustomerDAL customerDAL = new CustomerDAL();
        //        Customer matchingCustomer = new Customer();

        //        try
        //        {
        //            await Task.Run(() =>
        //            {
        //                matchingCustomer = customerDAL.GetCustomerByCustomerIDDAL(searchCustomerID);
        //            });
        //        }
        //        catch (Exception)
        //        {
        //            return default(Customer);
        //        }
        //        return matchingCustomer;
        //    }

        //    public async Task<bool> isCustomerIDExistBL(Guid customerID)
        //    {
        //        bool isFound = false;
        //        await Task.Run(() =>
        //        {
        //            CustomerDAL customerDAL = new CustomerDAL();
        //            isFound = customerDAL.isCustomerIDExistDAL(customerID);
        //        });
        //        return isFound;
        //    }

        //    /// <summary>
        //    /// Updates supplier based on CustomerID.
        //    /// </summary>
        //    /// <param name="updateCustomer">Represents Customer details including CustomerID, CustomerName etc.</param>
        //    /// <returns>Determinates whether the existing customer is updated.</returns>
        //    public async Task<bool> UpdateCustomerByCustomerIDBL(Customer updateCustomer)
        //    {
        //        bool customerUpdated = false;
        //        try
        //        {
        //            await Task.Run(() =>
        //            {
        //                CustomerDAL custDAL = new CustomerDAL();

        //                customerUpdated = custDAL.UpdateCustomerByCustomerIDDAL(updateCustomer);



        //            });
        //        }
        //        catch
        //        {
        //            return customerUpdated;
        //        }
        //        return customerUpdated;
        //    }

        //    /// <summary>
        //    /// Deletes customer based on CustomerID.
        //    /// </summary>
        //    /// <param name="removeCustomerID">Represents CustomerID to remove.</param>
        //    /// <returns>Determinates whether the existing customer is updated.</returns>
        //    public async Task<bool> RemoveCustomerBL(Guid removeCustomerID)
        //    {
        //        CustomerDAL customerDAL = new CustomerDAL();
        //        bool customerRemoved = false;
        //        try
        //        {
        //            await Task.Run(() =>
        //            {
        //                CustomerDAL custDAL = new CustomerDAL();
        //                if (custDAL.isCustomerIDExistDAL(removeCustomerID) == true)
        //                {
        //                    customerRemoved = custDAL.RemoveCustomerDAL(removeCustomerID);
        //                    return customerRemoved;
        //                }
        //                else
        //                    return false;
        //            });
        //            return customerRemoved;
        //        }
        //        catch
        //        {

        //        }
        //        return true;
        //    }

        //    /// <summary>
        //    /// Disposes all object(s)
        //    /// </summary>
        //    public void Dispose()
        //    {
        //        ((CustomerDAL)customerDAL).Dispose();
        //    }
    }
}



