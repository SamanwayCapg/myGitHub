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
using Newtonsoft.Json;
using Capgemini.Pecunia.Contracts.DALContracts;
using Capgemini.Pecunia.Entities;

namespace Capgemini.Pecunia.DataAccessLayer
{
    
    public class CustomerDAL : CustomerDALBase, IDisposable
    {
        public static List<Customer> CustomersList = new List<Customer>(); // list of customers is created by passing CustomerEntities class as data type 
        public override bool AddCustomerDAL(Customer customer)
        {
            
            //string customerID = "CUST" + custID.ToString();
            try
            {
                List<Customer> customers = DeserializeFromJSON("Customerdata.txt");
                customers.Add(customer);  //Customer is added in the list        
                return SerialiazeIntoJSON(customers, "Customerdata.txt");
            }
            catch 
            {
                return false;
            }
            
        }

        public override bool RemoveCustomerDAL(Guid CustomerID)
        {
            try
            {
                List<Customer> customerlist = DeserializeFromJSON("Customerdata.txt");// deserialize because we have to search list

                foreach (Customer cust in customerlist)  //foreach(dataType variable in collectionName)
                {
                    if (cust.CustomerID == CustomerID)
                    {
                        customerlist.Remove(cust);
                        SerialiazeIntoJSON(customerlist, "Customerdata.txt");// we serialize because in our original database we have to make the above changes
                        break;
                    }
                }
                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }

        public override Customer GetCustomerByCustomerIDDAL(Guid CustomerID)
        {
            bool validate = false;
            try
            {
                Customer customerEntitiesTemporary = new Customer();

                List<Customer> custlist = DeserializeFromJSON("Customerdata.txt"); //we have to search customer through CustomerID

                foreach (Customer cust in custlist) //foreach will search the list
                {
                    if (cust.CustomerID.Equals(CustomerID) == true)
                    {
                        validate = true;
                        customerEntitiesTemporary = cust;
                        break;
                    }
                }
                if (validate != true)
                {
                    throw new CustomerDoesNotExistException("Customer Not available based on given CustomerID");
                }
                //if customerID not found

                return customerEntitiesTemporary;
            }
            catch (Exception)
            {
                Customer c = new Customer();
                return c;
            }
        }

        public override List<Customer> GetAllCustomersDAL()
        {
            List<Customer> custlist = DeserializeFromJSON("Customerdata.txt");
            return custlist;
        }


        public override bool UpdateCustomerByCustomerIDDAL(Customer sourceobject)
        {
            bool customerUpdated = false;

            try
            {
                List<Customer> custlist = DeserializeFromJSON("Customerdata.txt");

                foreach (Customer cust in custlist) //stores object not fields

                {
                    if (cust.CustomerID == sourceobject.CustomerID)
                    {
                        ReflectionHelper.CopyProperties( sourceobject,cust,new List<string>() { "CustomerName", "CustomerAddress ", "CustomerMobile", "CustomerEmail" } );
                        customerUpdated = true;
                        break;
                    }  
                }
                SerialiazeIntoJSON(custlist, "Customerdata.txt");
            }
            catch (Exception )
            {
                Console.WriteLine("cannot update");
            }
            return customerUpdated;
        }


        public  override bool isCustomerIDExistDAL(Guid customerID)
        {
            List<Customer> customers = DeserializeFromJSON("Customerdata.txt");
            foreach(var cust in customers)
            {
                if (cust.CustomerID == customerID)
                    return true;
            }
            return false;
        }


        public override bool SerialiazeIntoJSON(List<Customer> CustomersList, string FileName)
        {
            try
            {
                JsonSerializer serializer = new JsonSerializer();
                using (StreamWriter sw = new StreamWriter(FileName))   //filename is used so that we can have access over our own file
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, CustomersList); // Serialize customers in customer.json
                    return true;
                }
            }
            catch (Exception )
            {
                return false;
            }
        }

        public override List<Customer> DeserializeFromJSON(string FileName)
        {
            List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(File.ReadAllText(FileName));// Done to read data from file
            using (StreamReader file = File.OpenText(FileName))
            {
                JsonSerializer serializer = new JsonSerializer();
                List<Customer> customers1 = (List<Customer>)serializer.Deserialize(file, typeof(List<Customer>));
                return customers1;
            }


        }
      
        /// <summary>
        /// Clears unmanaged resources such as db connections or file streams.
        /// </summary>
        public void Dispose()
        {
            //No unmanaged resources currently
        }
    }
}