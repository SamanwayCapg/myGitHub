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
using System.Data.Entity;
using Capgemini.Pecunia.Helpers;

namespace Capgemini.Pecunia.DataAccessLayer
{
    /// <summary>
    /// Contains data access layer methods for inserting, updating, deleting Transaction from Transactions collection.
    /// </summary>
    [Serializable]
    public class TransactionDAL : TransactionDALBase, IDisposable
    {


        /// <summary>
        /// Stores all transaction records to Transactions collection.
        /// </summary>
        /// <param name="accountID">Uniquely generated account ID.</param>
        /// <param name="amount">Amount to be transacted.</param>
        /// <param name="type">Type of transaction such as credit, debit.</param>
        /// <param name="mode">Mode of transaction such as cheque or withdrawal slip.</param>
        /// <param name="chequeNumber">Cheque number if mode of transaction is cheque and null in case of withdrawal slip.</param>
        /// <returns>Determinates whether the transactions are stored.</returns>
        public override bool StoreTransactionRecord(Guid accountID, decimal amount, string typeOfTransaction, string mode, string chequeNumber)
        {
            bool storeTransaction = false;

            using (PecuniaEntities pe = new PecuniaEntities())
            {
                int n = pe.StoreTransactionRecords(accountID, typeOfTransaction, amount, mode, chequeNumber);
            }

            //SqlConnection conn = sqlCommonClass.getConnection("ndamssql\\sqlilearn", "13th Aug CLoud PT Immersive", "sqluser", "sqluser");
            ////SqlConnection conn = SQLServerUtil.getConnetion("Pecunia");
            //try
            //{
            //    conn.Open();
            //    Console.WriteLine("connected to the database");

            //    SqlCommand comm = new SqlCommand("TeamF.StoreTransactionRecords", conn);

            //    SqlParameter param1 = new SqlParameter("@accountID", accountID);
            //    param1.SqlDbType = SqlDbType.UniqueIdentifier;

            //    SqlParameter param2 = new SqlParameter("@type", type);
            //    param2.SqlDbType = SqlDbType.VarChar;

            //    SqlParameter param3 = new SqlParameter("@amount", amount);
            //    param3.SqlDbType = SqlDbType.Money;



            //    SqlParameter param6 = new SqlParameter("@mode", mode);
            //    param6.SqlDbType = SqlDbType.VarChar;

            //    SqlParameter param7 = new SqlParameter("@chequeNumber", chequeNumber);
            //    param7.SqlDbType = SqlDbType.VarChar;


            //    List<SqlParameter> Params = new List<SqlParameter>();
            //    Params.Add(param1);
            //    Params.Add(param2);
            //    Params.Add(param3);
            //    //Params.Add(param4);
            //    //Params.Add(param5);
            //    Params.Add(param6);
            //    Params.Add(param7);



            //    comm.Parameters.AddRange(Params.ToArray());
            //    comm.CommandType = CommandType.StoredProcedure;
            //    comm.ExecuteNonQuery();
            //    conn.Close();
            storeTransaction = true;
            return storeTransaction;

            //}

            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    Console.ReadKey();
            //    return false;
            //    //throw new StoreTransactionException("Transaction not stored.");
            //}
        }


        /// <summary>
        /// Debit type of transaction with mode of transaction as withdrawal slip.
        /// </summary>
        /// <param name="accountID">Uniquely generated account ID.</param>
        /// <param name="amount">Amount to be debited.</param>       
        /// <returns>Determinates whether the amount is debited by withdrawal slip.</returns>
        public override bool DebitTransactionByWithdrawalSlipDAL(Guid accountID, decimal amount)
        {

            bool transactionWithdrawal = false;
            using (PecuniaEntities pe = new PecuniaEntities())
            {
                int n = pe.DebitBalance(accountID, amount);
            }

            StoreTransactionRecord(accountID, amount, "Debit", "Slip", "000000");
            transactionWithdrawal = true;
            return transactionWithdrawal;






        }

        /// <summary>
        /// Credit type of transaction with mode of transaction as withdrawal slip.
        /// </summary>
        /// <param name="accountID">Uniquely generated account ID.</param>
        /// <param name="amount">Amount to be credited.</param>       
        /// <returns>Determinates whether the amount is credited by withdrawal slip.</returns>
        public override bool CreditTransactionByDepositSlipDAL(Guid accountID, decimal amount)
        {

            bool transactionDeposit = false;
            using (PecuniaEntities pe = new PecuniaEntities())
            {
                int n = pe.CreditBalance(accountID, amount);
            }

            StoreTransactionRecord(accountID, amount, "Credit", "Slip", "000000");
            transactionDeposit = true;
            return transactionDeposit;

        }


        /// <summary>
        /// Debit type of transaction with mode of transaction as cheque.
        /// </summary>
        /// <param name="accountID">Uniquely generated account ID.</param>
        /// <param name="amount">Amount to be debited.</param>       
        /// <param name="chequeNumber">Cheque Number.</param>       
        /// <returns>Determinates whether the amount is debited by withdrawal slip.</returns>
        public override bool DebitTransactionByChequeDAL(Guid accountID, decimal amount, string chequeNumber)
        {

            bool transactionDebited = false;
            using (PecuniaEntities pe = new PecuniaEntities())
            {
                int n = pe.DebitBalance(accountID, amount);
            }

            StoreTransactionRecord(accountID, amount, "Debit", "Cheque", chequeNumber);

            transactionDebited = true;
            return transactionDebited;

        }


        /// <summary>
        /// Credit type of transaction with mode of transaction as cheque.
        /// </summary>
        /// <param name="accountID">Uniquely generated account ID.</param>
        /// <param name="amount">Amount to be credited.</param>      
        /// <param name="chequeNumber">Cheque Number.</param>                
        /// <returns>Determinates whether the amount is credited by cheque.</returns>
        public override bool CreditTransactionByChequeDAL(Guid accountID, decimal amount, string chequeNumber)
        {
            bool transactionCredited = false;
            using (PecuniaEntities pe = new PecuniaEntities())
            {
                int n = pe.CreditBalance(accountID, amount);
            }

            StoreTransactionRecord(accountID, amount, "Debit", "Cheque", chequeNumber);

            transactionCredited = true;
            return transactionCredited;
        }

        /// <summary>
        /// Displays all transactions for a particular account ID.
        /// </summary>
        /// <param name="accountID">Uniquely generated account ID.</param>
        /// <returns>Provides a list of transactions for a particular account ID.</returns>
        public override List<Transaction> DisplayTransactionByAccountIDDAL(string accountID)
        {
            Guid accID = new Guid();
            Guid.TryParse(accountID, out accID);
            using (PecuniaEntities db = new PecuniaEntities())
            {
                List<Transaction> trans = db.Transactions.Where(e => e.AccountID == accID).ToList();
                return trans;
            }

        }


        public override async Task<List<Transaction>> GetAllTransactionsDAL()
        {
            List<Transaction> trans = new List<Transaction>();
            try
            {
                using (PecuniaEntities db = new PecuniaEntities())
                {
                    trans = await db.Transactions.ToListAsync();
                    return trans;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override async Task<List<Account>> GetAllAccountsDAL()
        {
            List<Account> trans = new List<Account>();
            try
            {
                using (PecuniaEntities db = new PecuniaEntities())
                {
                    trans = await db.Accounts.ToListAsync();
                    return trans;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }



        /// <summary>
        /// Clears unmanaged resources such as db connections or file streams.
        /// </summary>
        public void Dispose()
        {
            //No unmanaged resources currently
        }

    }
}
