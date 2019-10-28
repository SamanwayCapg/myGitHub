using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capgemini.Pecunia.DataAccessLayer;
using System.IO;

using Capgemini.Pecunia.Exceptions;
using Capgemini.Pecunia.Entities;
using Capgemini.Pecunia.Contracts.DALContracts;
using System.Data.SqlClient;
using System.Data;

using Capgemini.Pecunia.Helpers;

namespace Capgemini.Pecunia.DataAccessLayer
{
    /// <summary>
    /// Contains data access layer methods for inserting, updating, deleting Transaction from Transactions collection.
    /// </summary>
    
    //public class TransactionDAL : TransactionDALBase, IDisposable
    //{

    //    //public static List<Transaction> Transactions = new List<Transaction>() { };
    //    //public List<Transaction> TransactionsToSerialize = new List<Transaction>() { };
    //    //private string filepath = "Transactions.txt";

    //    /// <summary>
    //    /// Stores all transaction records to Transactions collection.
    //    /// </summary>
    //    /// <param name="accountID">Uniquely generated account ID.</param>
    //    /// <param name="amount">Amount to be transacted.</param>
    //    /// <param name="type">Type of transaction such as credit, debit.</param>
    //    /// <param name="mode">Mode of transaction such as cheque or withdrawal slip.</param>
    //    /// <param name="chequeNumber">Cheque number if mode of transaction is cheque and null in case of withdrawal slip.</param>
    //    /// <returns>Determinates whether the transactions are stored.</returns>
    //    public override bool StoreTransactionRecord(Guid accountID, double amount, TypeOfTransaction type,
    //        ModeOfTransaction mode, string chequeNumber)
    //    {
    //        bool storeTransaction = false;
    //        SqlConnection conn = sqlCommonClass.getConnection("ndamssql\\sqlilearn", "13th Aug CLoud PT Immersive", "sqluser", "sqluser");
    //        //SqlConnection conn = SQLServerUtil.getConnetion("Pecunia");
    //        try
    //        {
    //            conn.Open();
    //            Console.WriteLine("connected to the database");

    //            SqlCommand comm = new SqlCommand("TeamF.StoreTransactionRecords", conn);

    //            SqlParameter param1 = new SqlParameter("@accountID", accountID);
    //            param1.SqlDbType = SqlDbType.UniqueIdentifier;

    //            SqlParameter param2 = new SqlParameter("@type", type);
    //            param2.SqlDbType = SqlDbType.VarChar;

    //            SqlParameter param3 = new SqlParameter("@amount", amount);
    //            param3.SqlDbType = SqlDbType.Money;

    //            //Guid transactionID = Guid.NewGuid(); Console.WriteLine(transactionID);
    //            //SqlParameter param4 = new SqlParameter("@transactionID", transactionID);
    //            //param4.SqlDbType = SqlDbType.UniqueIdentifier;

    //            //DateTime dateOfTransaction = DateTime.Now;
    //            //SqlParameter param5 = new SqlParameter("@dateOfTransaction", dateOfTransaction);
    //            //param5.SqlDbType = SqlDbType.DateTime;

    //            SqlParameter param6 = new SqlParameter("@mode", mode);
    //            param6.SqlDbType = SqlDbType.VarChar;

    //            SqlParameter param7 = new SqlParameter("@chequeNumber", chequeNumber);
    //            param7.SqlDbType = SqlDbType.VarChar;


    //            List<SqlParameter> Params = new List<SqlParameter>();
    //            Params.Add(param1);
    //            Params.Add(param2);
    //            Params.Add(param3);
    //            //Params.Add(param4);
    //            //Params.Add(param5);
    //            Params.Add(param6);
    //            Params.Add(param7);



    //            comm.Parameters.AddRange(Params.ToArray());
    //            comm.CommandType = CommandType.StoredProcedure;
    //            comm.ExecuteNonQuery();
    //            conn.Close();

    //            return storeTransaction;
    //            //    //// retrieving customerID based on account No
    //            //    AccountDAL accountDAL = new AccountDAL();
    //            //    List<Account> accounts = accountDAL.DeserializeFromJSON("AccountData.txt");
    //            //    string customerID = "00000000000000";// dummy initialization to avoid warnings
    //            //    foreach (Account account in accounts)
    //            //    {
    //            //        if (account.AccountID == accountID)
    //            //            customerID = account.CustomerID.ToString();
    //            //    }

    //            //    DateTime time = DateTime.Now;
    //            //    Guid TransactionID = Guid.NewGuid();

    //            //    Transaction transaction = new Transaction();
    //            //    transaction.AccountID = accountID;
    //            //    transaction.Type = type;
    //            //    transaction.Amount = amount;

    //            //    transaction.TransactionID = TransactionID;
    //            //    transaction.DateOfTransaction = time;
    //            //    transaction.Mode = mode;
    //            //    transaction.ChequeNumber = chequeNumber;

    //            //    List<Transaction> TransactionsRecords = DeserializeFromJSON(filepath);
    //            //    TransactionsRecords.Add(transaction);
    //            //    return SerializeIntoJSON(TransactionsRecords, filepath);
    //        }

    //        catch (Exception ex)
    //        {
    //            Console.WriteLine(ex.Message);
    //            Console.ReadKey();
    //            return false;
    //            //throw new StoreTransactionException("Transaction not stored.");
    //        }
    //    }

    //    /// <summary>
    //    /// Checks if a particular transaction ID exists in Transactions collection.
    //    /// </summary>
    //    /// <param name="transactionID">Uniquely generated transaction ID.</param>
    //    /// <returns>Determinates whether the transaction ID exists.</returns>
    //    //public override bool TransactionIDExistsDAL(Guid transactionID)
    //    //{
    //    //    bool transactionIDExists = false;
    //    //    try
    //    //    {



    //    //        List<Transaction> transactionsList = DeserializeFromJSON("Transactions.txt");

    //    //        foreach (Transaction transaction in transactionsList)
    //    //        {
    //    //            if (transaction.TransactionID == transactionID)
    //    //            {
    //    //                transactionIDExists = true;
    //    //            }

    //    //        }
    //    //        return transactionIDExists;
    //    //    }
    //    //    catch (PecuniaException)
    //    //    {
    //    //        throw new TransactionIDExistsException("Transaction ID does not exist.");
    //    //    }          
    //    //}


    //    /// <summary>
    //    /// Debit type of transaction with mode of transaction as withdrawal slip.
    //    /// </summary>
    //    /// <param name="accountID">Uniquely generated account ID.</param>
    //    /// <param name="amount">Amount to be debited.</param>       
    //    /// <returns>Determinates whether the amount is debited by withdrawal slip.</returns>
    //    public override bool DebitTransactionByWithdrawalSlipDAL(Guid accountID, double amount)
    //    {
    //        SqlConnection conn = sqlCommonClass.getConnection("ndamssql\\sqlilearn", "13th Aug CLoud PT Immersive", "sqluser", "sqluser");
    //        bool transactionWithdrawal = false;
    //        try
    //        {

    //            SqlCommand comm = new SqlCommand("TeamF.DebitBalance", conn);
    //            conn.Open();
    //            //Guid accID;
    //            //Guid.TryParse("bdc8e59d-f8ac-4cd6-92eb-4c3ed5baacf6", out accID);
    //            SqlParameter param1 = new SqlParameter("@accountID", accountID);
    //            param1.SqlDbType = SqlDbType.UniqueIdentifier;

    //            SqlParameter param3 = new SqlParameter("@amount", amount);
    //            param3.SqlDbType = SqlDbType.Money;

    //            //SqlParameter param3 = new SqlParameter("@amount", amount);
    //            //param3.SqlDbType = SqlDbType.Money;

    //            List<SqlParameter> Params = new List<SqlParameter>();
    //            Params.Add(param1);
    //            Params.Add(param3);

    //            comm.Parameters.AddRange(Params.ToArray());
    //            comm.CommandType = CommandType.StoredProcedure;
    //            comm.ExecuteNonQuery();
    //            conn.Close();
    //            Console.WriteLine("Transaction is donee");

    //            TypeOfTransaction typeOfTransaction;
    //            Enum.TryParse("Debit", out typeOfTransaction);
    //            ModeOfTransaction modeOfTransaction;
    //            Enum.TryParse("WithdrawalSlip", out modeOfTransaction);
    //            StoreTransactionRecord(accountID, amount, typeOfTransaction, modeOfTransaction, "000000");
    //            transactionWithdrawal = true;
    //            //accountDAL.SerialiazeIntoJSON(accounts, "AccountData.txt");


    //            return transactionWithdrawal;




    //        }
    //        catch (Exception e)
    //        {
    //            Console.WriteLine(e.Message);
    //            Console.ReadKey();
    //            return false;
    //            //throw new InsufficientBalanceException("Insufficient Balance");
    //        }

    //    }

    //    /// <summary>
    //    /// Credit type of transaction with mode of transaction as withdrawal slip.
    //    /// </summary>
    //    /// <param name="accountID">Uniquely generated account ID.</param>
    //    /// <param name="amount">Amount to be credited.</param>       
    //    /// <returns>Determinates whether the amount is credited by withdrawal slip.</returns>
    //    public override bool CreditTransactionByDepositSlipDAL(Guid accountID, double amount)
    //    {

    //        SqlConnection conn = sqlCommonClass.getConnection("ndamssql\\sqlilearn", "13th Aug CLoud PT Immersive", "sqluser", "sqluser");
    //        bool transactionDeposit = false;
    //        try
    //        {




    //            SqlCommand comm = new SqlCommand("TeamF.CreditBalance", conn);
    //            conn.Open();
    //            //Guid accID;
    //            //Guid.TryParse("bdc8e59d-f8ac-4cd6-92eb-4c3ed5baacf6", out accID);
    //            SqlParameter param1 = new SqlParameter("@accountID", accountID);
    //            param1.SqlDbType = SqlDbType.UniqueIdentifier;

    //            SqlParameter param3 = new SqlParameter("@amount", amount);
    //            param3.SqlDbType = SqlDbType.Money;

    //            //SqlParameter param3 = new SqlParameter("@amount", amount);
    //            //param3.SqlDbType = SqlDbType.Money;

    //            List<SqlParameter> Params = new List<SqlParameter>();
    //            Params.Add(param1);
    //            Params.Add(param3);

    //            comm.Parameters.AddRange(Params.ToArray());
    //            comm.CommandType = CommandType.StoredProcedure;
    //            comm.ExecuteNonQuery();
    //            conn.Close();



    //            TypeOfTransaction typeOfTranscation;
    //            Enum.TryParse("Credit", out typeOfTranscation);
    //            ModeOfTransaction modeOfTransaction;
    //            Enum.TryParse("WithdrawalSlip", out modeOfTransaction);
    //            StoreTransactionRecord(accountID, amount, typeOfTranscation, modeOfTransaction, "000000");

    //            transactionDeposit = true;

    //            return transactionDeposit;
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine(ex.Message);
    //            Console.ReadKey();
    //            return false;
    //        }
    //    }


    //    /// <summary>
    //    /// Debit type of transaction with mode of transaction as cheque.
    //    /// </summary>
    //    /// <param name="accountID">Uniquely generated account ID.</param>
    //    /// <param name="amount">Amount to be debited.</param>       
    //    /// <param name="chequeNumber">Cheque Number.</param>       
    //    /// <returns>Determinates whether the amount is debited by withdrawal slip.</returns>
    //    public override bool DebitTransactionByChequeDAL(Guid accountID, double amount, string chequeNumber)
    //    {
    //        SqlConnection conn = sqlCommonClass.getConnection("ndamssql\\sqlilearn", "13th Aug CLoud PT Immersive", "sqluser", "sqluser");
    //        bool transactionDebited = false;
    //        try


    //        {
    //            SqlCommand comm = new SqlCommand("TeamF.DebitBalance", conn);
    //            conn.Open();

    //            SqlParameter param1 = new SqlParameter("@accountID", accountID);
    //            param1.SqlDbType = SqlDbType.UniqueIdentifier;



    //            SqlParameter param2 = new SqlParameter("@amount", amount);
    //            param2.SqlDbType = SqlDbType.Money;



    //            List<SqlParameter> Params = new List<SqlParameter>();
    //            Params.Add(param1);
    //            Params.Add(param2);

    //            comm.Parameters.AddRange(Params.ToArray());
    //            comm.CommandType = CommandType.StoredProcedure;
    //            comm.ExecuteNonQuery();
    //            conn.Close();


    //            TypeOfTransaction typeOfTranscation;
    //            Enum.TryParse("Debit", out typeOfTranscation);
    //            ModeOfTransaction modeOfTransaction;
    //            Enum.TryParse("Cheque", out modeOfTransaction);
    //            StoreTransactionRecord(accountID, amount, typeOfTranscation, modeOfTransaction, chequeNumber);

    //            transactionDebited = true;

    //            return transactionDebited;
    //        }
    //        catch (Exception e)
    //        {
    //            Console.WriteLine(e.Message);
    //            Console.ReadKey();
    //            return false;

    //        }
    //    }


    //    /// <summary>
    //    /// Credit type of transaction with mode of transaction as cheque.
    //    /// </summary>
    //    /// <param name="accountID">Uniquely generated account ID.</param>
    //    /// <param name="amount">Amount to be credited.</param>      
    //    /// <param name="chequeNumber">Cheque Number.</param>                
    //    /// <returns>Determinates whether the amount is credited by cheque.</returns>
    //    public override bool CreditTransactionByChequeDAL(Guid accountID, double amount, string chequeNumber)
    //    {
    //        SqlConnection conn = sqlCommonClass.getConnection("ndamssql\\sqlilearn", "13th Aug CLoud PT Immersive", "sqluser", "sqluser");
    //        bool transactionCredited = false;
    //        try
    //        {
    //            SqlCommand comm = new SqlCommand("TeamF.CreditBalance", conn);
    //            conn.Open();

    //            SqlParameter param1 = new SqlParameter("@accountID", accountID);
    //            param1.SqlDbType = SqlDbType.UniqueIdentifier;


    //            SqlParameter param2 = new SqlParameter("@amount", amount);
    //            param2.SqlDbType = SqlDbType.Money;



    //            List<SqlParameter> Params = new List<SqlParameter>();
    //            Params.Add(param1);
    //            Params.Add(param2);


    //            comm.Parameters.AddRange(Params.ToArray());
    //            comm.CommandType = CommandType.StoredProcedure;
    //            comm.ExecuteNonQuery();
    //            conn.Close();
    //            TypeOfTransaction typeOfTranscation;
    //            Enum.TryParse("Credit", out typeOfTranscation);
    //            ModeOfTransaction modeOfTransaction;
    //            Enum.TryParse("Cheque", out modeOfTransaction);
    //            StoreTransactionRecord(accountID, amount, typeOfTranscation, modeOfTransaction, chequeNumber);
    //            transactionCredited = true;
    //            return transactionCredited;
    //        }

    //        catch (Exception e)
    //        {
    //            Console.WriteLine(e.Message);
    //            Console.ReadKey();
    //            return false;

    //        }
    //    }

    //    /// <summary>
    //    /// Displays all transactions for a particular account ID.
    //    /// </summary>
    //    /// <param name="accountID">Uniquely generated account ID.</param>
    //    /// <returns>Provides a list of transactions for a particular account ID.</returns>
    //    public override List<Transaction> DisplayTransactionByAccountIDDAL(Guid accountID)
    //    {

    //        List<Transaction> transactions = new List<Transaction>();
    //        SqlConnection conn = sqlCommonClass.getConnection("ndamssql\\sqlilearn", "13th Aug CLoud PT Immersive", "sqluser", "sqluser");


    //        try
    //        {

    //            SqlCommand comm = new SqlCommand("TeamF.GetTransactionsByAccountID", conn);
    //            conn.Open();


    //            SqlParameter param2 = new SqlParameter("@accountID", accountID);
    //            param2.SqlDbType = SqlDbType.UniqueIdentifier;

    //            List<SqlParameter> Params = new List<SqlParameter>();

    //            Params.Add(param2);

    //            comm.Parameters.AddRange(Params.ToArray());
    //            comm.CommandType = CommandType.StoredProcedure;
    //            comm.ExecuteNonQuery();


    //            SqlDataReader sql = comm.ExecuteReader();

    //            if (sql.HasRows)
    //            {
    //                while (sql.Read())
    //                {
    //                    Transaction objToReturn = new Transaction();
    //                    objToReturn = getNetDataTypes(sql, objToReturn);
    //                    transactions.Add(objToReturn);
    //                }
    //            }
    //            else
    //            {
    //                return transactions;
    //            }
    //            sql.Close();

    //            conn.Close();
    //            return transactions;

    //        }
    //        catch (Exception e)
    //        {
    //            Console.WriteLine(e.Message);
    //            Console.WriteLine(e.StackTrace);
    //            Console.ReadKey();
    //            return transactions;
    //        }
    //    }

    //    Transaction getNetDataTypes(SqlDataReader sql, Transaction objToReturn)
    //    {
    //        objToReturn.TransactionID = sql.GetGuid(0);
    //        objToReturn.AccountID = sql.GetGuid(1);

    //        TypeOfTransaction typeOfTransaction;
    //        Enum.TryParse(sql.GetString(2), out typeOfTransaction);
    //        objToReturn.Type = typeOfTransaction;

    //        objToReturn.Amount = Convert.ToDouble(sql.GetDecimal(3));
    //        objToReturn.DateOfTransaction = sql.GetDateTime(4);

    //        ModeOfTransaction modeOfTransaction;
    //        Enum.TryParse(sql.GetString(5), out modeOfTransaction);
    //        objToReturn.Mode = modeOfTransaction;

    //        objToReturn.ChequeNumber = sql.GetString(6);
    //        return objToReturn;


    //    }
    //    /// <summary>
    //    /// Displays transaction for a particular transaction ID.
    //    /// </summary>
    //    /// <param name="transactionID">Uniquely generated transaction ID.</param>
    //    /// <returns>Provides transaction details for a particular transaction ID.</returns>
    //    //public override Transaction DisplayTransactionByTransactionIDDAL(Guid transactionID)
    //    //{
    //    //    try
    //    //    {
    //    //        List<Transaction> transactions = DeserializeFromJSON("Transactions.txt");
    //    //        foreach (Transaction transaction in transactions)
    //    //        {
    //    //            if (transaction.TransactionID == transactionID)
    //    //            {
    //    //                return transaction;
    //    //            }
    //    //        }
    //    //        return null;
    //    //    }
    //    //    catch (PecuniaException)
    //    //    {

    //    //        throw new TransactionDisplayAccountException("Invalid Transaction ID");
    //    //    }            
    //    //}

    //    /// <summary>
    //    /// Gets all Transactions from the collection.
    //    /// </summary>
    //    /// <returns>Returns list of all Transactions.</returns>
    //    public override DataSet GetAllTransactionsDAL()
    //    {
    //        Transaction getAll = new Transaction();

    //        SqlConnection conn = sqlCommonClass.getConnection("ndamssql\\sqlilearn", "13th Aug CLoud PT Immersive", "sqluser", "sqluser");
    //        SqlDataAdapter dataAdapter = new SqlDataAdapter("select*from TeamF.GetAllTransactions", conn);
    //        DataSet ds = new DataSet();
    //        dataAdapter.Fill(ds);
    //        return ds;
    //    }

    //    /// <summary>
    //    /// Reads all Transactions from the file.
    //    /// </summary>
    //    /// <param name="fileName">Name of file where data is to be read.</param>
    //    /// <returns>Returns list of all Transactions.</returns>
    //    //public override List<Transaction> DeserializeFromJSON(string fileName)
    //    //{
    //    //    try
    //    //    {
    //    //        List<Transaction> transactionsList = JsonConvert.DeserializeObject<List<Transaction>>(File.ReadAllText(fileName));// Done to read data from file
    //    //        return transactionsList;
    //    //    }
    //    //    catch 
    //    //    {
    //    //        throw;
    //    //    }           
    //    //}

    //    ///// <summary>
    //    ///// Writes all Transactions to the file.
    //    ///// </summary>
    //    ///// <param name="transactions">List of transactions.</param>
    //    ///// <param name="fileName">Name of file where data is to be written.</param>
    //    ///// <returns>Determinates if the data is written in the file.</returns>
    //    //public override bool SerializeIntoJSON(List<Transaction> transactions, string fileName)
    //    //{
    //    //    try
    //    //    {
    //    //        JsonSerializer serializer = new JsonSerializer();
    //    //        using (FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
    //    //        using (StreamWriter streamWriter = new StreamWriter(fileStream))   //filename is used so that we can have access over our own file
    //    //        using (JsonWriter writer = new JsonTextWriter(streamWriter))
    //    //        {
    //    //            serializer.Serialize(writer, transactions);
    //    //            streamWriter.Close();
    //    //            fileStream.Close();
    //    //            return true;
    //    //        }
    //    //    }
    //    //    catch
    //    //    {
    //    //       throw;
    //    //    }
    //    //}

    //    /// <summary>
    //    /// Clears unmanaged resources such as db connections or file streams.
    //    /// </summary>
    //    public void Dispose()
    //    {
    //        //No unmanaged resources currently
    //    }

    //}
}
