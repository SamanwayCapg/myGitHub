using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capgemini.Pecunia.Entities;
using Capgemini.Pecunia.Exceptions;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using Capgemini.Pecunia.Contracts.DALContracts;
using Pecunia.Contracts.DALContracts;

namespace Capgemini.Pecunia.DataAccessLayer
{
    [Serializable]
    public class AccountDAL : AccountDALBase
    {
        
        
        //----------------------------------------------------------------------------------------------1)
        public override bool AddAccountDAL(Account accountObject)
        {
            accountObject.IsActive = true;
            List<Account >accountList = DeserializeFromJSON("Accountdata.txt");
           //List<Account> accountList = new List<Account>();
            accountList.Add(accountObject);
            return SerialiazeIntoJSON(accountList, "Accountdata.txt");


        }
        //---------------------------------------------------------------------------------------------2)
        public override bool DeleteAccountDAL(Guid accountID, string feedback)
        {
            bool result = false;
            bool validator = false;
            List<Account> accountList = DeserializeFromJSON("Accountdata.txt");

            foreach (Account index in accountList)
            {
                if (accountID.Equals(index.AccountID))
                {
                    index.Feedback = feedback;
                    //SerialiazeIntoJSON(ListClosedAccounts, "ClosedAccountdata.txt");
                    //accountList.Remove(index);
                    index.IsActive = false;
                    SerialiazeIntoJSON(accountList, "Accountdata.txt");
                    
                    result = true;
                    validator = true;
                    break;
                }
            }
            if (validator != true)
            {
                Console.WriteLine("Enter Valid Account Number");
            }
            return result;
        }
        //-------------------------------------------------------------------------------3)
        public override List<Account> GetAccountByCustomerIDDAL(Guid customerID)
        {

            bool validator = false;
            List<Account> accountTemporary = new List<Account>();
            List<Account> accountList = DeserializeFromJSON("Accountdata.txt");
            foreach (Account index in accountList)
            {
                if (index.CustomerID == customerID)
                {
                    validator = true;
                    accountTemporary.Add(index);
                    
                }
            }
            if (validator != true)
            {
                throw new CustomerDoesNotExistException("Customer Does not have account(Customer wala)");
            }
            return accountTemporary;
        }
        //----------------------------------------------------------------------------------------4)

        public override List<Account> GetAllAccountsDAL()
        {
            List<Account> accountList = DeserializeFromJSON("Accountdata.txt");
            return accountList;
        }
        public override Account GetAccountByAccountIDDAL(Guid accountID)
        {

            bool validator = false;
            Account accountTemporary = new Account();
            List<Account> accountList = DeserializeFromJSON("Accountdata.txt");
            try
            {
                foreach (Account index in accountList)
                {
                    if (accountID==index.AccountID)
                    {
                        validator = true;
                        accountTemporary = index;
                        break;
                    }
                }
                if (validator != true)
                {
                    throw new CustomerDoesNotExistException("Customer Does not have account from here");
                    
                }
            }
            catch(Exception)
            {

            }


            return accountTemporary;
        }

        //----------------------------------------------------------------------------------------
        //===============================================================================================================


        public override bool SerialiazeIntoJSON(List<Account> AccountsList, string FileName)
        {
            try
            {
                JsonSerializer serializer = new JsonSerializer();
                using (StreamWriter sw = new StreamWriter(FileName))   //filename is used so that we can have access over our own file
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, AccountsList); // Serialize customers in customer.json
                    return true;
                }
            }
            catch 
            {
                return false;
            }
        }
        //public override List<Account> DeserializeFromJSON(string FileName)
        //{
        //    List<Account> customers = JsonConvert.DeserializeObject<List<Account>>(File.ReadAllText(FileName));// Done to read data from file
        //    using (StreamReader file = File.OpenText(FileName))
        //    {
        //        JsonSerializer serializer = new JsonSerializer();
        //        List<Account> accounts = (List<Account>)serializer.Deserialize(file, typeof(List<Account>));
        //        return accounts;
        //    }
        //}
        public override List<Account> DeserializeFromJSON(string FileName)
        {
            List<Account> accountLists = JsonConvert.DeserializeObject<List<Account>>(File.ReadAllText(FileName));
            return accountLists;
        }

        public override void SerializeUpdated(Account account)
        {
            List<Account> accountList = new List<Account>();
            accountList = DeserializeFromJSON("Accountdata.txt");
            foreach (Account index in accountList)
            {
                if (index.AccountNo == account.AccountNo)
                {
                    accountList.Remove(index);
                    accountList.Add(account);
                    break;
                   

                }
            }
            SerialiazeIntoJSON(accountList, "Accountdata.txt");

        }

        public override bool AccountIDExists(Guid accountID)
        {
            bool result = false;
         
            
                List<Account> accountList = JsonConvert.DeserializeObject<List<Account>>(File.ReadAllText("Accountdata.txt"));
                
                foreach (Account account in accountList)
                {
                    if (accountID.Equals(account.AccountID))
                    {
                        result = true;
                        break;
                    }
                }
            

            
            
                List<FixedDeposit> fixedDepositList = JsonConvert.DeserializeObject<List<FixedDeposit>>(File.ReadAllText("FixedDepositdata.txt"));
                foreach (FixedDeposit fixedDeposit in fixedDepositList)
                {
                    if (accountID.Equals(fixedDeposit.AccountID))
                    {
                        result = true;
                        break;
                    }
                }
            
            return result;
        }
       
       
    }
}
