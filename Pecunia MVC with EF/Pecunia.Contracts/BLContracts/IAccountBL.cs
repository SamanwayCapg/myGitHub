using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capgemini.Pecunia.Entities;

namespace Capgemini.Pecunia.Contracts.BLContracts
{

    public interface IAccountBL
    {

        Task<bool> AddAccountBL(Account account, Guid customerID, string accountType);
        Task<bool> DeleteAccount(Guid accountID, string feedback);
        List<Account> GetAccountByCustomerIDBL(Guid customerID);
        Task<Account> GetAccountByAccountIDBL(Guid accountID);
        Task<bool> ChangeAccountTypeBL(Guid accountID, string accountType);
        Task<bool> ChangeBranchBL(Guid accountID, string homeBranch);
        List<Account> GetAllAccountsBL();

    }

}
