using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pecunia.Entities;
using Pecunia.Exceptions;
using Pecunia.DataAccessLayer;
using System.Text.RegularExpressions;
using static System.Console;
using  System.IO;
namespace Pecunia.BusinessLayer
{

    interface IAccountBL
    {
        bool ValidateAccountType(string accountType, Account accountObject);
        bool ValidateInitialAmount(double initialAmount, Account accountObject);
        bool AddAccountBL(string accountType, double initialAmount, string homeBranch,string customerID);
        bool ValidateAccountNumber(long accountNumber);
        bool DeleteAccount(long accountNo, string feedback);
        bool ValidateCustomerID(string customerID);

        List<Account> GetAccountByCustomerIDBL(string customerID);

        Account GetAccountByAccountNoBL(long accountNumber);
        bool ChangeAccountTypeBL(long accountNumber, string accountType);
        bool ChangeBranchBL(long accountNumber, string homeBranch);
        List<Account> GetAllAccountsBL();
        bool UpdateFDAmountBL(long accountNumber, double newAmount);




    }

    public class AccountBL : IAccountBL
    {
        //static List<long> AccountNumberGeneratorSavings = new List<long>();  // Lists to generate Account Number

        //static List<long> AccountNumberGeneratorCurrent = new List<long>();         // Lists to generate Account Number


        //static List<long> AccountNumberGeneratorFD = new List<long>();          // Lists to generate Account Number
        
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

        public bool ValidateInitialAmount(double initialAmount, Account accountObject)         // Validate if FD amount is atleast 20,000
        {
            bool result = false;
            if ((int)accountObject._accType == 2 && initialAmount < 20000)
            {
                throw new InitialAmountOfFDException("Amount should be Atleast 20000");
            }
            else if ((int)accountObject._accType == 2 && initialAmount > 20000)
            {
                accountObject.FdDeposit = initialAmount;
                result = true;
            }
            else
            {
                accountObject.InitialAmount = initialAmount;
                accountObject.Balance = accountObject.Balance + accountObject.InitialAmount;
                result = true;

            }
            return result;
        }
        //---------------------------------------------------------------------------------------------------------------------1)
        public bool AddAccountBL(string accountType, double initialAmount, string homeBranch,string customerID)
        {
            bool result = false;
            Account account = new Account();
            if(ValidateCustomerID(customerID))
            {
                account.CustomerID = customerID;
            }
         



            if (ValidateAccountType(accountType, account))
            {
                account.HomeBranch = homeBranch;

            }




            ValidateInitialAmount(initialAmount, account);

            if ((int)account._accType == 0)
            {
                account.InterestRate = 5;
                /* if (AccountNumberGeneratorSavings.Count == 0)  */          // If list empty then only

                //{
                //    account.AccountNo = 500001;            // Account Number of Savings Account Starts with 5 series and add First Account Number
                //    AccountNumberGeneratorSavings.Add(account.AccountNo);
                //}
                //else
                //{
                //    int index = AccountNumberGeneratorSavings.Count;
                //    Console.WriteLine(AccountNumberGeneratorSavings[index - 1]);
                //    account.AccountNo = (AccountNumberGeneratorSavings[index - 1] + 1);
                //    AccountNumberGeneratorSavings.Add(account.AccountNo);// Add the existing list number + 1 (eg 500001 +1)
                //}
                StreamReader sr = new StreamReader("AccountNumberSavings.txt");
                //string data = File.ReadAllText("AccountNumberSavings.txt");
                string data = sr.ReadToEnd();
                sr.Close();
                long temporary = long.Parse(data);
                account.AccountNo = temporary + 1;
                temporary = temporary + 1;
                //data = temporary.ToString();
                StreamWriter sw = new StreamWriter("AccountNumberSavings.txt");
                sw.WriteLine(temporary);
                sw.Close();
                


            }

            else if ((int)account._accType == 1)
            {

                //account.InterestRate = 0;
                //if (AccountNumberGeneratorCurrent.Count == 0)

                //{
                //    account.AccountNo = 400001;                 // Account Number of Current Account Starts with 4 series
                //    AccountNumberGeneratorCurrent.Add(account.AccountNo);
                //}

                //else
                //{
                //    int index = AccountNumberGeneratorCurrent.Count;
                //    account.AccountNo = (AccountNumberGeneratorCurrent[index - 1] + 1);
                //    AccountNumberGeneratorCurrent.Add(account.AccountNo);// Add the existing list number + 1 (eg 400001 +1)
                //}
                StreamReader sr = new StreamReader("AccountNumberCurrent.txt");
           
                string data = sr.ReadToEnd();
                sr.Close();
                long temporary = long.Parse(data);
                account.AccountNo = temporary + 1;
                temporary = temporary + 1;
                //data = temporary.ToString();
                StreamWriter sw = new StreamWriter("AccountNumberCurrent.txt");
                sw.WriteLine(temporary);
                sw.Close();
            }

            else
            {
                //if (account.InitialAmount > 100000)
                //{
                //    account.InterestRate = 5.5;
                //}

                //if (account.InitialAmount < 100000)
                //{
                //    account.InterestRate = 6;
                //}


                //if (AccountNumberGeneratorFD.Count == 0)

                //{
                //    account.AccountNo = 300001;                      // Account No of FD Account Starts with 3 series
                //    AccountNumberGeneratorFD.Add(account.AccountNo);
                //}

                //else
                //{
                //    int index = AccountNumberGeneratorFD.Count;
                //    account.AccountNo = (AccountNumberGeneratorFD[index - 1] + 1);
                //    AccountNumberGeneratorFD.Add(account.AccountNo);
                //    // Add the existing list number + 1 (eg 300001 +1)
                //}
                StreamReader sr = new StreamReader("AccountNumberFD.txt");

                string data = sr.ReadToEnd();
                sr.Close();
                long temporary = long.Parse(data);
                account.AccountNo = temporary + 1;
                temporary = temporary + 1;
                //data = temporary.ToString();
                StreamWriter sw = new StreamWriter("AccountNumberFD.txt");
                sw.WriteLine(temporary);
                sw.Close();


            }

            AccountDAL accountDAL = new AccountDAL();
            result = accountDAL.AddAccountDAL(account); // Calling Method of DAL to add the object


            return result;

        }
        //----------------------------------------------------------------------------------------
        public bool ValidateAccountNumber(long accountNumber)
        {
            bool result = false;
            if ((accountNumber > 500000 && accountNumber < 599999) || (accountNumber > 400000 && accountNumber < 499999) || (accountNumber > 300000 && accountNumber < 399999))
            {
                result = true;
            }
            else
            {
                throw new AccountDoesNotExistException("Enter Valid Account Number");
            }
            return result;
        }
        //------------------------------------------------------------------------------------------2)
        public bool DeleteAccount(long accountNo, string feedback)
        {
            bool result = false;
            if (ValidateAccountNumber(accountNo))
            {
                AccountDAL accountDAL = new AccountDAL();
                result = accountDAL.DeleteAccountDAL(accountNo, feedback);         // Calling DAL Method of Delete Account
            }



            return result;
        }
        //----------------------------------------------------------------------------------------
        public bool ValidateCustomerID(string customerID)
        {
            bool result = false;
            if (Regex.IsMatch(customerID, "[0-9]{14}$") == false)  // The CustomerID must be 14 Digits long
            {
                throw new InvalidStringException("Customer ID must be of 14 Digits");
            }


            else
            {
                result = true;
            }
            return result;
        }
        //----------------------------------------------------------------------------------------3)
        public List<Account> GetAccountByCustomerIDBL(string customerID)
        {
            if (ValidateCustomerID(customerID))
            {
                AccountDAL accountDAL = new AccountDAL();
                return accountDAL.GetAccountByCustomerIDDAL(customerID);
            }
            else
            {
                throw new EnterValidCustomerIDException("ENter Valid Customer ID");

            }


        }
        //-----------------------------------------------------------------------------------------
        public Account GetAccountByAccountNoBL(long accountNumber)
        {
            if (ValidateAccountNumber(accountNumber))
            {
                AccountDAL a = new AccountDAL();
                return a.GetAccountByAccountNoDAL(accountNumber);
            }
            else
            {
                throw new EnterValidCustomerIDException("ENter Valid AccountNumber"); // Account Number Kar Hyala


            }


        }

        //----------------------------------------------------------------------------------------4)
        public bool ChangeAccountTypeBL(long accountNumber, string accountType) // Change Account Type
        {
            //--------------------------------

            //===========
            bool result = false;

            Account temporaryObject = new Account();
            AccountDAL accountDAL = new AccountDAL();


            temporaryObject = accountDAL.GetAccountByAccountNoDAL(accountNumber);  // Getting Account Object having that particular account Number
            if ((int)temporaryObject._accType == 2)
            {

                //Raise excpetion
                throw new FDAccountCannotBeChangedException("Cannot change from FD account");
            }
            if (ValidateAccountType(accountType, temporaryObject))
            {
                accountDAL.SerializeUpdated(temporaryObject);
                result = true;
            }



            return result;
        }
        //-----------------------


        //---------------------------------------------------------------------------------------5)
        public bool ChangeBranchBL(long accountNumber, string homeBranch)     // Change Branch
        {

            Account temporaryObject = new Account();
            AccountDAL accountDAL = new AccountDAL();
            bool res = false;
            if (ValidateAccountNumber(accountNumber))
            {
               

                temporaryObject = accountDAL.GetAccountByAccountNoDAL(accountNumber);
            }
            temporaryObject.HomeBranch = homeBranch;
            accountDAL.SerializeUpdated(temporaryObject);
            return res;
        }

        //--------------------------------------------------------------------------------------6)

        public List<Account> GetAllAccountsBL()
        {
            AccountDAL accountDAL = new AccountDAL();
            return accountDAL.GetAllAccountsDAL();
        }

        //-------------------------------------------------------------------------------------7)

        public bool ValidateNewAount(double newAmount)
        {
            bool result = true;
            if (newAmount < 20000)
            {
                result = false;
                throw new InitialAmountOfFDException("Amount should be Atleast 20000");

            }
            return result;

        }
        public bool UpdateFDAmountBL(long accountNumber, double newAmount)
        {
            bool result = false;
            if (ValidateAccountNumber(accountNumber) && ValidateNewAount(newAmount))
            {

                AccountDAL accountDAL = new AccountDAL();
                Account accountTemporary = accountDAL.GetAccountByAccountNoDAL(accountNumber);
                accountTemporary.FdDeposit = newAmount;
                if (newAmount > 100000)
                {
                    accountTemporary.InterestRate = 5;
                    result = true;
                }
                else
                {
                    accountTemporary.InterestRate = 6;
                    result = true;
                }
                accountDAL.SerializeUpdated(accountTemporary);

            }
            return result;
        }

    }


}

