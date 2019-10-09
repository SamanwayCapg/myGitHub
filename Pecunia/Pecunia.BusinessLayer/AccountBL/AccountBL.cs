using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capgemini.Pecunia.Entities;
using Capgemini.Pecunia.Exceptions;
using Capgemini.Pecunia.DataAccessLayer;
using System.Text.RegularExpressions;
using static System.Console;
using  System.IO;
using Capgemini.Pecunia.Contracts.BLContracts;

using Capgemini.Pecunia.Helpers;
using Capgemini.Pecunia.BusinessLayer;
using Pecunia.Contracts.DALContracts;

namespace Capgemini.Pecunia.BusinessLayer
{

    /// <summary>
    /// Contains business layer methods for validating, inserting, updating, deleting Account from Accounts collection.
    /// </summary>
    public class AccountBL :BLbase<Account>, IAccountBL, IDisposable
    {
        //fields
        AccountDALBase accountDAL;

        /// <summary>
        /// Constructor.
        /// </summary>
        public AccountBL()
        {
            this.accountDAL = new AccountDAL();
        }

        static List<long> SavingsAccountListGenerator = new List<long>();
        static List<long> CurrentAccountListGenerator = new List<long>();

        /// <summary>
        /// Validates Account type of Customer.
        /// </summary>
        /// <param name="accountType">Type of Account of Customer.</param>
        /// <param name="accountObject">Contains Account object details.</param>
        /// <returns>Returns bool value to tell whether account type are valid or not.</returns>
        public bool ValidateAccountType(string accountType, Account accountObject)    // Validate if account Type is one which is listed in Enum
        {
            bool result = false;
            

            if ((Enum.TryParse(accountType, out accountObject._accType) == true))
            {
         
                result = true;
            }
            else
            {
                throw new EnterValidAccountTypeException("Enter Valid Account Type");
            }
            return result;
        }

        /// <summary>
        /// Validates Account details of Customer.
        /// </summary>
        /// <param name="account">Type of Account of Customer.</param>        
        /// <returns>Returns bool value to tell whether account object details are valid or not.</returns>
        public override async Task<bool> Validate(Account account)
        {
            
            bool valid = true;
            valid = await base.Validate(account);
            return valid;
        }


        /// <summary>
        /// Adds new Account to Accounts collection.
        /// </summary>
        /// <param name="account">Contains the Account details to be added.</param>
        /// <param name="customerID">Uniquely generated customerID.</param>
        /// <param name="accountType">Type of account to be added.</param>
        /// <returns>Determinates whether the new Account is added.</returns>
        public async Task<bool> AddAccountBL(Account account,Guid customerID,string accountType)
        {
            account.Balance = 0;
           
            bool result = false;
            CustomerDAL customerDAL = new CustomerDAL();

            if (customerDAL.isCustomerIDExistDAL(customerID))
            {
                account.CustomerID = customerID;
            }
            
            AccountDAL accountDAL = new AccountDAL();
            ValidateAccountType(accountType, account);
            if (await Validate(account))
            {
                await Task.Run(() =>
                {

                    if ((int)account._accType == 0)
                    {
                        Guid AccountIDGenerator = Guid.NewGuid();
                        account.AccountID = AccountIDGenerator;

                        if (SavingsAccountListGenerator.Count == 0)
                        {
                            account.AccountNo = 500001;
                            SavingsAccountListGenerator.Add(account.AccountNo);
                        }
                        else
                        {
                            int index = SavingsAccountListGenerator.Count;
                            account.AccountNo = (SavingsAccountListGenerator[index - 1]) + 1;
                            SavingsAccountListGenerator.Add(account.AccountNo);
                        }
                    }

                    else if ((int)account._accType == 1)
                    {

                        Guid AccountIDGenerator = Guid.NewGuid();
                        account.AccountID = AccountIDGenerator;
                        if (CurrentAccountListGenerator.Count == 0)
                        {
                            account.AccountNo = 400001;   // FD Account Begin with 400001
                            CurrentAccountListGenerator.Add(account.AccountNo);

                        }
                        else
                        {
                            int index = SavingsAccountListGenerator.Count;
                            account.AccountNo = (CurrentAccountListGenerator[index - 1]) + 1;
                            CurrentAccountListGenerator.Add(account.AccountNo);
                        }
                    }

                    result = accountDAL.AddAccountDAL(account); // Calling Method of DAL to add the object
                });
            }
            return result;

        }

        /// <summary>
        /// Deletes Employee based on EmployeeID.
        /// </summary>
        /// <param name="accountID">Represents accountID to delete.</param>
        /// <param name="feedback">Represents feedback of the customer.</param>      
        /// <returns>Determinates whether the existing Account is deleted.</returns>
        public async Task<bool> DeleteAccount(Guid accountID, string feedback)
        {
            bool result = false;
            AccountDAL accountDAL = new AccountDAL();
            await Task.Run(() =>
            {
                if (accountDAL.AccountIDExists(accountID))
                {

                    result = accountDAL.DeleteAccountDAL(accountID, feedback);         // Calling DAL Method of Delete Account
                }
                else
                {
                    throw new AccountDoesNotExistException("Enter Valid CustomerID");

                }

            });

            return result;
        }

        /// <summary>
        /// Gets Account based on Customer ID.
        /// </summary>
        /// <param name="customerID">Represents CustomerID to search.</param>
        /// <returns>Returns Account object.</returns>
        public List<Account> GetAccountByCustomerIDBL(Guid customerID)
        {
            CustomerDAL customerDAL = new CustomerDAL();
            List<Account> accountList = null;
           
            
                if (customerDAL.isCustomerIDExistDAL(customerID))
                {
                    AccountDAL accountDAL = new AccountDAL();
                    accountList = accountDAL.GetAccountByCustomerIDDAL(customerID);
                }
                else
                {
                    throw new EnterValidCustomerIDException("ENter Valid Customer ID");

                }
           

            return accountList;

        }

        /// <summary>
        /// Gets Account based on Account ID.
        /// </summary>
        /// <param name="accountID">Represents Account ID to search.</param>
        /// <returns>Returns Account object.</returns>
        public async Task<Account> GetAccountByAccountIDBL(Guid accountID)
        {
            AccountDAL accountDAL = new AccountDAL();
            Account account = new Account();
            await Task.Run(() =>
            {
                if (accountDAL.AccountIDExists(accountID))
                {

                    account = accountDAL.GetAccountByAccountIDDAL(accountID);
                }
                else
                {
                    throw new EnterValidCustomerIDException("ENter Valid AccountNumber"); // Account Number Kar Hyala


                }
            });

            return account;

        }

        /// <summary>
        /// Changes Account type of Customer.
        /// </summary>
        /// <param name="accountID">Represents Account ID of account.</param>
        /// <param name="accountType">Represents type of account to change.</param>
        /// <returns>Returns bool value to determine whether account type is changed or not.</returns>
        public async Task<bool> ChangeAccountTypeBL(Guid accountID, string accountType) // Change Account Type
        {
           
            bool result = false;

            Account temporaryObject = new Account();
            AccountDAL accountDAL = new AccountDAL();

            await Task.Run(() =>
            {
                temporaryObject = accountDAL.GetAccountByAccountIDDAL(accountID);  // Getting Account Object having that particular account Number

                if(!(accountDAL.AccountIDExists(accountID)))
                {
                    throw new AccountDoesNotExistException("Enter Valid Account ID");
                }
                if (ValidateAccountType(accountType, temporaryObject))
                {
                    accountDAL.SerializeUpdated(temporaryObject);
                    result = true;
                }
            });
         
            return result;
        }

        /// <summary>
        /// Changes Branch of Account.
        /// </summary>
        /// <param name="accountID">Represents Account ID of account.</param>
        /// <param name="homeBranch">Represents home branch to change.</param>
        /// <returns>Returns bool value to determine whether home branch is changed or not.</returns>
        public async Task<bool> ChangeBranchBL(Guid accountID, string homeBranch)     // Change Branch
        {

            Account temporaryObject = new Account();
            AccountDAL accountDAL = new AccountDAL();
            bool res = false;
            await Task.Run(() =>
            { 

             if (accountDAL.AccountIDExists(accountID))
            {
                temporaryObject = accountDAL.GetAccountByAccountIDDAL(accountID);
            }
                else
                {
                    throw new AccountDoesNotExistException("Enter Valid Account ID");
                }
            temporaryObject.HomeBranch = homeBranch;
                res = true;
            accountDAL.SerializeUpdated(temporaryObject);
        });
           
            return res;
        }

        //--------------------------------------------------------------------------------------6)

        public List<Account> GetAllAccountsBL()
        {
            AccountDAL accountDAL = new AccountDAL();
           
           
            
                

            return accountDAL.GetAllAccountsDAL();

           
        }

        public bool AccountIDExists(Guid accountID)
        {
            AccountDAL acc = new AccountDAL();
            return acc.AccountIDExists(accountID);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        //-------------------------------------------------------------------------------------7)





    }



}

