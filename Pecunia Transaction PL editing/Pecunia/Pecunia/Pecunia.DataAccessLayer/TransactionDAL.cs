using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pecunia.Entities;
using Pecunia.DataAccessLayer;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Newtonsoft.Json;
using Pecunia.Exceptions;


namespace Pecunia.DataAccessLayer
{
    public abstract class TransactionDALAbstract
    {
        public abstract bool StoreTransactionRecord(long accountNo, double Amount, TypeOfTranscation type, string mode, string chequeNo);
        public abstract bool DebitTransactionByWithdrawalSlipDAL(long AccountNo, double Amount);
        public abstract bool CreditTransactionByDepositSlipDAL(long AccountNo, double Amount);
        public abstract bool DebitTransactionByChequeDAL(long AccountNo, double Amount, string ChequeNo);
        public abstract bool CreditTransactionByChequeDAL(long AccountNo, double Amount, string ChequeNo);
        public abstract List<TransactionEntities> DisplayTransactionByCustomerID_DAL(string CustomerID);
        public abstract List<TransactionEntities> DisplayTransactionByAccountNo_DAL(long AccountNo);
        public abstract TransactionEntities DisplayTransactionByTransactionID_DAL(string TransactionID);
        public abstract bool SerializeIntoJSON(List<TransactionEntities> transactions, string filename);
        public abstract List<TransactionEntities> DeserializeFromJSON(string filename);

    }
    [Serializable]
    public class TransactionDAL: TransactionDALAbstract
    {
        
        public static List<TransactionEntities> Transactions = new List<TransactionEntities>() { };
        public List<TransactionEntities> TransactionsToSerialize = new List<TransactionEntities>() { };
        private string filepath = "Transactions.txt";
        public override bool StoreTransactionRecord(long accountNo, double Amount, TypeOfTranscation type, string mode, string chequeNo)
        {
            //// retrieving customerID based on account No
            AccountDAL accDAL = new AccountDAL();
            List<Account> accounts = accDAL.DeserializeFromJSON("AccountData.txt");
            string customerID = "00000000000000";// dummy initialization to avoid warnings
            foreach(Account acc in accounts)
            {
                    if (acc.AccountNo == accountNo)
                        customerID = acc.CustomerID;
            }

            DateTime time = DateTime.Now;
            string transactionID = "TRANS" + time.ToString("yyyyMMddhhmmss");//sample transactionID : TRANS20190921154525

            TransactionEntities trans = new TransactionEntities();
            trans.AccountNo = accountNo;
            trans.CustomerID = customerID;
            trans.Type = type;
            trans.Amount = Amount;
            trans.TransactionID = transactionID;
            trans.DateOfTransaction = time;
            trans.Mode = mode;
            trans.ChequeNo = chequeNo;

            List<TransactionEntities> TransactionsRecords = DeserializeFromJSON(filepath);
            TransactionsRecords.Add(trans);
            return SerializeIntoJSON(TransactionsRecords, filepath);
        }

        public override bool DebitTransactionByWithdrawalSlipDAL(long AccountNo, double Amount)
        {
            bool res = false;
            AccountDAL accDAL = new AccountDAL();
            List<Account> accounts = accDAL.DeserializeFromJSON("AccountData.txt");
            foreach (Account acc in accounts)
            {
                if (acc.AccountNo == AccountNo)
                {
                    if (acc.Balance >= Amount)
                    {
                        acc.Balance = acc.Balance - Amount;
                        TypeOfTranscation transEnum;
                        Enum.TryParse("Debit", out transEnum);
                        StoreTransactionRecord(AccountNo, Amount, transEnum, "WithdrawalSlip", null);
                        res = true;
                        accDAL.SerializeIntoJSON(accounts, "AccountData.txt");
                        break;
                    }
                    else
                        throw new InsufficientBalanceException($"You must have a account balance of {Amount}\nCurrent Account Balance is Rs.{acc.Balance}");


                }

            }
            if (res == true)
            {
                Console.WriteLine($"Succesfully Debited Rs.{Amount} from account no. {AccountNo}");
                Console.WriteLine("Press any key -> Previous Menu");
                Console.ReadKey();
                return true;
            }
            else
            {
                Console.WriteLine("Invalid Account Number\nPress any key -> Try Again");
                Console.ReadKey();
                return false;
            }
        }

        public override bool CreditTransactionByDepositSlipDAL(long AccountNo, double Amount)
        {
            bool res = false;
            AccountDAL accDAL = new AccountDAL();
            List<Account> accounts = accDAL.DeserializeFromJSON("AccountData.txt");
            foreach (Account acc in accounts)
            {
                if (acc.AccountNo == AccountNo)
                {
                    acc.Balance = acc.Balance + Amount;
                    TypeOfTranscation transEnum;
                    Enum.TryParse("Credit", out transEnum);
                    StoreTransactionRecord(AccountNo, Amount, transEnum, "WithdrawalSlip", null);
                    accDAL.SerializeIntoJSON(accounts, "AccountData.txt");
                    res=true;
                    break;
                }

            }
            if (res == true)
            {
                Console.WriteLine($"Succesfully Credited Rs.{Amount} to account no. {AccountNo}");
                Console.WriteLine("Press any key -> Previous Menu");
                Console.ReadKey();
                return true;
            }
            else
            {
                Console.WriteLine("Invalid Account Number\nPress any key -> Try Again");
                Console.ReadKey();
                return false;
            }
        }

        public override bool DebitTransactionByChequeDAL(long AccountNo, double Amount, string ChequeNo)
        {
            bool res = false;
            AccountDAL accDAL = new AccountDAL();
            List<Account> accounts = accDAL.DeserializeFromJSON("AccountData.txt");

            foreach (Account acc in accounts)
            {
                if (acc.AccountNo == AccountNo)
                {
                    if (acc.Balance >= Amount)
                    {
                        acc.Balance = acc.Balance - Amount;
                        TypeOfTranscation transEnum;
                        Enum.TryParse("Debit", out transEnum);
                        StoreTransactionRecord(AccountNo, Amount, transEnum, "Cheque", ChequeNo);
                        accDAL.SerializeIntoJSON(accounts, "AccountData.txt");
                        res = true;
                        break;
                    }
                    else
                        throw new InsufficientBalanceException($"You must have a account balance of {Amount}\nCurrent Account Balance is Rs.{acc.Balance}");
                }

            }
            if (res == true)
            {
                Console.WriteLine($"Succesfully Debited Rs.{Amount} from account no. {AccountNo}");
                Console.WriteLine("Press any key -> Previous Menu");
                Console.ReadKey();
                return true;
            }
            else
            {
                Console.WriteLine("Invalid Account No. or Cheque No.\nPress any key -> Try Again");
                Console.ReadKey();
                return false;
            }
        }

        public override bool CreditTransactionByChequeDAL(long AccountNo, double Amount, string ChequeNo)
        {
            
            bool res = false;
            AccountDAL accDAL = new AccountDAL();
            List<Account> accounts = accDAL.DeserializeFromJSON("AccountData.txt");

            foreach (Account acc in accounts)
            {
                if (acc.AccountNo == AccountNo)
                {
                    acc.Balance = acc.Balance + Amount;
                    TypeOfTranscation transEnum;
                    Enum.TryParse("Credit", out transEnum);
                    StoreTransactionRecord(AccountNo, Amount, transEnum, "Cheque", ChequeNo);
                    accDAL.SerializeIntoJSON(accounts, "AccountData.txt");
                    res = true;
                    break;
                }

            }
            if (res == true)
            {
                Console.WriteLine($"Succesfully Credited Rs.{Amount} in account {AccountNo}\nPress Any Key -> Previous Menu");
                Console.ReadKey();
                return true;
            }
            else
            {
                Console.WriteLine("Invalid Account Number or Cheque\nPress Any Key -> Try Again");
                Console.ReadKey();
                return false;
            }
        }

        public override List<TransactionEntities> DisplayTransactionByCustomerID_DAL(string CustomerID)
        {
            List<TransactionEntities> transactions = DeserializeFromJSON("Transactions.txt");
            List<TransactionEntities> transactionsOfCustomerID = new List<TransactionEntities>();
            foreach (TransactionEntities trans in transactions)
            {
                if (trans.CustomerID == CustomerID)
                {
                    transactionsOfCustomerID.Add(trans);
                }
            }
            return transactionsOfCustomerID;
        }

        public override List<TransactionEntities> DisplayTransactionByAccountNo_DAL(long AccountNo)
        {
            List<TransactionEntities> transactions = DeserializeFromJSON("Transactions.txt");
            List<TransactionEntities> transactionsOfAccountNo = new List<TransactionEntities>();
            foreach (TransactionEntities trans in transactions)
            {
                if (trans.AccountNo == AccountNo)
                {
                    transactionsOfAccountNo.Add(trans);
                }
                
            }
            return transactionsOfAccountNo;
        }

        public override TransactionEntities DisplayTransactionByTransactionID_DAL(string TransactionID)
        {
            List<TransactionEntities> transactions = DeserializeFromJSON("Transactions.txt");
            foreach (TransactionEntities trans in transactions)
            {
                if (trans.TransactionID == TransactionID)
                {
                    return trans;
                }
            }
            return null;
        }

        public List<TransactionEntities> GetAllTransactionsDAL()
        {
            List<TransactionEntities> transactions = DeserializeFromJSON("Transactions.txt");
            return transactions;

        }
        public override List<TransactionEntities> DeserializeFromJSON(string FileName)
        {
            List<TransactionEntities> transactions = JsonConvert.DeserializeObject<List<TransactionEntities>>(File.ReadAllText(FileName));// Done to read data from file
            return transactions;
        }

        public override bool SerializeIntoJSON(List<TransactionEntities> transactions, string fileName)
        {
            try
            {
                JsonSerializer serializer = new JsonSerializer();
                using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs))   //filename is used so that we can have access over our own file
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, transactions);
                    sw.Close();
                    fs.Close();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

    }
}
