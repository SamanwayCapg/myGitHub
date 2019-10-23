using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capgemini.Pecunia.Entities;
using Capgemini.Pecunia.Contracts.DALContracts;
using System.IO;
using Capgemini.Pecunia.Exceptions;
using Newtonsoft.Json;

namespace Capgemini.Pecunia.DataAccessLayer
{
    public class FixedDepositDAL : FixedDepositBase
    {
        public override bool AddFixedDepositDAL(FixedDeposit fixedDepositObject)
        {
            fixedDepositObject.IsActive = true;
           
            List<FixedDeposit> fixedDepositList = DeserializeFromJSON("FixedDepositdata.txt");
             //List<FixedDeposit> fixedDepositList = new List<FixedDeposit>();
            fixedDepositList.Add(fixedDepositObject);
            return SerialiazeIntoJSON(fixedDepositList, "FixedDepositdata.txt");


        }

        public override bool DeleteFixedDepositDAL(Guid accountID, string feedback)
        {
            bool result = false;
            bool validator = false;
            List<FixedDeposit> fixedDepositList = DeserializeFromJSON("FixedDepositdata.txt");

            foreach (FixedDeposit index in fixedDepositList)
            {
                if (accountID.Equals(index.AccountID))
                {
                    index.Feedback = feedback;
                    //SerialiazeIntoJSON(ListClosedAccounts, "ClosedAccountdata.txt");
                    //accountList.Remove(index);
                    index.IsActive = false;
                    SerialiazeIntoJSON(fixedDepositList, "FixedDepositdata.txt");

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


        public override List<FixedDeposit> GetFixedDepositByCustomerIDDAL(Guid customerID)
        {
            
            bool validator = false;
            List<FixedDeposit> fixedDepositTemporary = new List<FixedDeposit>();
            List<FixedDeposit> fixedDepositList = DeserializeFromJSON("FixedDepositdata.txt");
            foreach (FixedDeposit index in fixedDepositList)
            {
                if (index.CustomerID == customerID)
                {
                    validator = true;
                    fixedDepositTemporary.Add(index);

                }
            }
            if (validator != true)
            {
                throw new EnterValidCustomerIDException("Customer Does not have account(Customer wala)");
            }
            return fixedDepositTemporary;
        }

        public override List<FixedDeposit> GetAllFixedDepositsDAL()
        {
            List<FixedDeposit> fixedDepositList = DeserializeFromJSON("FixedDepositdata.txt");
            return fixedDepositList;
        }


        public override FixedDeposit GetFixedDepositByAccountIDDAL(Guid accountID)
        {

            bool validator = false;
            FixedDeposit fixedDepositTemporary = new FixedDeposit();
            List<FixedDeposit> FixedDepositList = DeserializeFromJSON("FixedDepositdata.txt");
            try
            {
                foreach (FixedDeposit index in FixedDepositList)
                {
                    if (accountID.Equals(index.AccountID))
                    {
                        validator = true;
                        fixedDepositTemporary = index;
                        break;
                    }
                }
                if (validator != true)
                {
                    throw new CustomerDoesNotExistException("Customer Does not have FixedDeposit");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            return fixedDepositTemporary;
        }


        public override bool SerialiazeIntoJSON(List<FixedDeposit> fixedDepositsList, string FileName)
        {
            try
            {
                JsonSerializer serializer = new JsonSerializer();
                using (StreamWriter sw = new StreamWriter(FileName))   //filename is used so that we can have access over our own file
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, fixedDepositsList); // Serialize customers in customer.json
                    return true;
                }
            }
            catch 
            {
                return false;
            }
        }



        public override void SerializeUpdated(FixedDeposit account)
        {
            List<FixedDeposit> fixedDepositList = new List<FixedDeposit>();
            fixedDepositList = DeserializeFromJSON("FixedDepositdata.txt");
            foreach (FixedDeposit index in fixedDepositList)
            {
                if (index.AccountNo == account.AccountNo)
                {
                    fixedDepositList.Remove(index);
                    fixedDepositList.Add(account);
                    break;


                }
            }
            SerialiazeIntoJSON(fixedDepositList, "FixedDepositdata.txt");



        }

        public override  List<FixedDeposit> DeserializeFromJSON(string FileName)
        {
            List<FixedDeposit> fixedDeposits = JsonConvert.DeserializeObject<List<FixedDeposit>>(File.ReadAllText(FileName));
            return fixedDeposits;
        }
        public override bool AccountIDExists(Guid accountID)
        {
            List<Account> accountList = JsonConvert.DeserializeObject<List<Account>>(File.ReadAllText("Accountdata.txt"));
            bool result = false;
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
