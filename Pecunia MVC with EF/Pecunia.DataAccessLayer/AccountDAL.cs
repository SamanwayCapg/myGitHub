using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capgemini.Pecunia.Entities;
using Capgemini.Pecunia.Exceptions;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Capgemini.Pecunia.Contracts.DALContracts;
using Pecunia.Contracts.DALContracts;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Windows.Input;

namespace Capgemini.Pecunia.DataAccessLayer
{
    [Serializable]
    public class AccountDAL : AccountDALBase
    {


        //----------------------------------------------------------------------------------------------1)
        public override bool AddAccountDAL(Account accountObject)
        {


            using (PecuniaEntities db = new PecuniaEntities())
            {

                //db.Employees.Add(emp);
                //db.SaveChanges();
                db.AddAccountDAL(accountObject.AccountType, accountObject.AccountNumber, accountObject.AccountID, accountObject.CustomerID,
                    accountObject.HomeBranch, accountObject.IsActive);
            }


            return true;




        }
        //---------------------------------------------------------------------------------------------2)
        public override bool DeleteAccountDAL(Guid accountID, string feedback)
        {
            using (PecuniaEntities db = new PecuniaEntities())
            {

                //db.Employees.Add(emp);
                //db.SaveChanges();
                db.DeleteAccountDAL1(accountID, feedback);
                db.SaveChanges();
            }
            return true;
        }
        //-------------------------------------------------------------------------------3)
        public override List<Account> GetAccountByCustomerIDDAL(Guid customerID)
        {


            List<Account> accounts = new List<Account>();

            using (PecuniaEntities db = new PecuniaEntities())
            {
                accounts = db.Accounts.Where(temp => temp.CustomerID == customerID).ToList();

            }


            return accounts;
        }
        //----------------------------------------------------------------------------------------4)

        public override List<Account> GetAllAccountsDAL()
        {
            List<Account> accounts = new List<Account>();

            using (PecuniaEntities db = new PecuniaEntities())
            {
                accounts = db.Accounts.Where(temp => temp.IsActive == true).ToList();

            }
            return accounts;
        }
        public override Account GetAccountByAccountIDDAL(Guid accountID)
        {
            Account account = new Account();

            using (PecuniaEntities db = new PecuniaEntities())
            {
                account = db.Accounts.Where(temp => temp.AccountID == accountID).FirstOrDefault();

            }


            return account;
        }


        public override bool AccountIDExistsAccount(Guid accountID)
        {
            using (PecuniaEntities db = new PecuniaEntities())
            {
                Account account = db.Accounts.Where(temp => temp.AccountID == accountID).FirstOrDefault();

                if (account == null)
                {
                    return false;
                }
                else
                    return true;
            }

        }

        public override bool ChangeBranchOfAccount(Guid accountID, string homebranch)
        {
            using (PecuniaEntities db = new PecuniaEntities())
            {
                db.ChangeBranchofAccount1(accountID, homebranch);
            }
            return true;
        }

        public bool ChangeAccountType(Guid accountID, string accountType)
        {
            using (PecuniaEntities db = new PecuniaEntities())
            {
                db.ChangeAccountType1(accountID, accountType);
            }
            return true;

        }

    }
}
