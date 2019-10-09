using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capgemini.Pecunia.Entities;


namespace Capgemini.Pecunia.Contracts.DALContracts
{
    public abstract class CustomerDALBase
    {
        public abstract bool AddCustomerDAL(Customer newCustomer);
        public abstract bool RemoveCustomerDAL(Guid CustomerID);
        public abstract Customer GetCustomerByCustomerIDDAL(Guid CustomerID);
        public abstract List<Customer> GetAllCustomersDAL();
        public abstract bool UpdateCustomerByCustomerIDDAL(Customer sourceobject);
        public abstract bool isCustomerIDExistDAL(Guid customerID);
        public abstract bool SerialiazeIntoJSON(List<Customer> CustomersList, string FileName);
        public abstract List<Customer> DeserializeFromJSON(string FileName);
    }
}
