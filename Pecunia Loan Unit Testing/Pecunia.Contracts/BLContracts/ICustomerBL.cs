using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capgemini.Pecunia.Entities;



namespace Capgemini.Pecunia.Contracts.BLContracts
{
    public interface ICustomerBL
    {
    
        Task<bool> AddCustomerBL(Customer customer);  
        Task<bool> RemoveCustomerBL(Guid customerID);
        Task<Customer> GetCustomerByCustomerIDBL(Guid customerID);
        List<Customer> GetAllCustomerDetailsBL();
        Task<bool> UpdateCustomerByCustomerIDBL(Customer customer);



    }
}
