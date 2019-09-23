using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pecunia.Entities;
using Pecunia.Exceptions;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

namespace Pecunia.DataAccessLayer
{
    [Serializable]
    public class AccountDAL
    {
        public static List<Account> ListOfAccounts = new List<Account>();
        public static List<Account> ListClosedAccounts = new List<Account>();
        //----------------------------------------------------------------------------------------------1)
        public bool AddAccountDAL(Account accountObject)
        {

            List<Account> accountList = DeserializeFromJSON("Accountdata.txt");
           // List<Account> accountList = new List<Account>();
            accountList.Add(accountObject);
            return SerializeIntoJSON(accountList, "Accountdata.txt");


        }
        //---------------------------------------------------------------------------------------------2)
        public bool DeleteAccountDAL(long accountNumber, string feedback)
        {
            bool result = false;
            bool validator = false;
            List<Account> accountList = DeserializeFromJSON("Accountdata.txt");

            foreach (Account index in accountList)
            {
                if (index.AccountNo == accountNumber)
                {
                    index.Feedback = feedback;
                    ListClosedAccounts.Add(index);
                    accountList.Remove(index);
                    SerializeIntoJSON(accountList, "Accountdata.txt");
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
        public List<Account> GetAccountByCustomerIDDAL(String customerID)
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

        public List<Account> GetAllAccountsDAL()
        {
            List<Account> accountList = DeserializeFromJSON("Accountdata.txt");
            return accountList;
        }
        public Account GetAccountByAccountNoDAL(long accountNumber)
        {

            bool validator = false;
            Account accountTemporary = new Account();
            List<Account> accountList = DeserializeFromJSON("Accountdata.txt");
            try
            {
                foreach (Account index in accountList)
                {
                    if (index.AccountNo == accountNumber)
                    {
                        validator = true;
                        accountTemporary = index;
                        break;
                    }
                }
                if (validator != true)
                {
                    throw new CustomerDoesNotExistException("Customer Does not have account");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            return accountTemporary;
        }

        //----------------------------------------------------------------------------------------
        //===============================================================================================================


        public bool SerializeIntoJSON(List<Account> AccountsList, string FileName)
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
            catch (Exception e)
            {
                return false;
            }
        }
        public List<Account> DeserializeFromJSON(string FileName)
        {
            List<Account> customers = JsonConvert.DeserializeObject<List<Account>>(File.ReadAllText(FileName));// Done to read data from file
            using (StreamReader file = File.OpenText(FileName))
            {
                JsonSerializer serializer = new JsonSerializer();
                List<Account> accounts = (List<Account>)serializer.Deserialize(file, typeof(List<Account>));
                return accounts;
            }
        }

        public void SerializeUpdated(Account account)
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
            SerializeIntoJSON(accountList, "Accountdata.txt");

        }
        //===============================================================================================
        //public void DisplayAllAccounts()
        //{
        //    Account accountObj = new Account();
        //    string filePath = "Records.dot";
        //    FileStream fs2 = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        //    BinaryFormatter binaryFormatter = new BinaryFormatter();
        //    accountObj = (Account)binaryFormatter.Deserialize(fs2);
        //    for(Account index in)
        //    Console.WriteLine("Person name: " + person2.PersonName);
        //    Console.WriteLine("Age: " + person2.Age);
        //    Console.WriteLine("Gender: " + person2.Gender);
        //    Console.WriteLine("Is Registered: " + person2.IsRegistered);
        //}

        //public bool UpdateFDAmount_DAL(long AccountNo)
        //{
        //    bool res = false;
        //    int count = 0;
        //    foreach (Account a in ListOfAccounts)
        //    {
        //        if (a.AccountNo == AccountNo)
        //        {
        //            try
        //            {
        //                res = true;
        //                count++;
        //                Console.WriteLine("Enter New FD Amount");
        //                long temp = long.Parse(Console.ReadLine());
        //                if (temp < 20000)
        //                {
        //                    throw new InitialAmountOfFDException("Amount should be Atleast 20000");
        //                }
        //                else
        //                {
        //                    a.FdDeposit = temp;
        //                }

        //            }
        //            catch (Exception ex)
        //            {
        //                Console.WriteLine(ex.Message);
        //                throw;
        //            }
        //            break;
        //        }
        //    }
        //    if (count != 1)
        //    {
        //        Console.WriteLine("ENter Valid Account Number");
        //    }
        //    return res;
        //}
        //Account GetAccountByAccountNo_DAL(long AccountNo)
        //{
        //    Account a = new Account();
        //    int count = 0;
        //    foreach(Account i in ListOfAccounts)
        //    {
        //        if(i.AccountNo == AccountNo)
        //        {
        //            a = i;
        //            count++;
        //            break;
        //        }
        //    }
        //    if(count!=1)
        //    {
        //        throw new AccountDoesNotExistException("Account does not exist for ");
        //    }
        //    return a;
        //}

        //public Account GetAccountByCustomer_DAL(String CustomerID)
        //{

        //    int count = 0;
        //    Account a = new Account();
        //    try
        //    {
        //        foreach (Account i in ListOfAccounts)
        //        {
        //            if (i.CustomerID == CustomerID)
        //            {
        //                count++;
        //                a = i;
        //                break;
        //            }
        //        }
        //        if (count != 1)
        //        {
        //            throw new CustomerDoesNotExistException("Customer Does not have account");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        throw;
        //    }

        //    return a;
        //}
        //public bool ChangeAccountTypeDAL(long accountNuber)
        //{
        //    bool result = false;
        //    List<Account> accountList = DeserializeFromJSON("Accountdata.txt");
        //    try
        //    {
        //        foreach (Account index in accountList)
        //        {

        //            if (index.AccountNo == accountNuber)
        //            {
        //                Console.WriteLine("ENter Account Type");
        //                if ((Enum.TryParse(Console.ReadLine(), out index._accType)) == false)
        //                {
        //                    throw new EnterValidAccountTypeException("Enter Valid Account Type");
        //                }
        //                else
        //                {
        //                    result = true;
        //                }

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        throw;
        //    }

        //    return result;
        //}

        ////-----------------------------------------------------------------------------------------6)
        //public bool ChangeBranchDAL(String CustomerID)
        //{
        //    bool result = false;
        //    int count = 0;
        //    foreach (Account i in ListOfAccounts)
        //    {
        //        if (i.CustomerID == CustomerID)
        //        {
        //            Console.WriteLine("ENter Home Branch");
        //            i.HomeBranch = Console.ReadLine();
        //            result = true;
        //            count++;
        //            break;
        //        }
        //    }
        //    if (count != 1)
        //    {
        //        throw new AccountDoesNotExistException("Account does not exist for ");
        //    }
        //    return result;
        //}

        ////----------------------------------------------------------------------------------------7)
        //public List<Account> GetAllAccountsDAL()
        //{
        //    return ListOfAccounts;

        //}
        //==============================================================================================
    }
}
