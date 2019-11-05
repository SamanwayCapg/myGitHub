using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capgemini.Pecunia.Entities;


namespace Capgemini.Pecunia.Contracts.DALContracts
{
    public abstract class TransactionDALBase
    {
        public abstract bool StoreTransactionRecord(Guid accountID, decimal amount, string typeOfTransaction, string mode, string chequeNumber);
        public abstract bool DebitTransactionByWithdrawalSlipDAL(Guid accountID, decimal amount);
        public abstract bool CreditTransactionByDepositSlipDAL(Guid accountID, decimal amount);
        public abstract bool DebitTransactionByChequeDAL(Guid accountID, decimal amount, string chequeNumber);
        public abstract bool CreditTransactionByChequeDAL(Guid accountID, decimal amount, string chequeNumber);
        public abstract List<Transaction> DisplayTransactionByAccountIDDAL(string accountID);
        //public abstract Transaction DisplayTransactionByTransactionIDDAL(Guid transactionID);
        //public abstract bool SerializeIntoJSON(List<Transaction> transactions,  string filename);
        //public abstract List<Transaction> DeserializeFromJSON(string filename);
        //public abstract bool TransactionIDExistsDAL(Guid transactionID);
        public abstract Task<List<Transaction>> GetAllTransactionsDAL();
        public abstract Task<List<Account>> GetAllAccountsDAL();

    }
}
