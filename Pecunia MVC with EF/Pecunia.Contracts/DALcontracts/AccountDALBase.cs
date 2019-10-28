using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capgemini.Pecunia.Entities;

namespace Pecunia.Contracts.DALContracts
{
    public abstract class AccountDALBase
    {
        public abstract bool AddAccountDAL(Account accountObject);
        public abstract bool DeleteAccountDAL(Guid accountID, string feedback);
        public abstract List<Account> GetAccountByCustomerIDDAL(Guid customerID);
        public abstract List<Account> GetAllAccountsDAL();
        public abstract Account GetAccountByAccountIDDAL(Guid accountID);


        public abstract bool AccountIDExistsAccount(Guid accountID);

        static List<Account> accountList = new List<Account>();

        public abstract bool ChangeBranchOfAccount(Guid accountID, string homebranch);

    }
}
