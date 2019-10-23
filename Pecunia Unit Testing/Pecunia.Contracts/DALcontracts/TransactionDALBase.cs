using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capgemini.Pecunia.Entities;


namespace Capgemini.Pecunia.Contracts.DALContracts
{
    public abstract class TransactionDALBase
    {
        public abstract bool StoreTransactionRecord(Guid accountID, double amount, TypeOfTranscation type, ModeOfTransaction mode, string chequeNumber);
        public abstract bool DebitTransactionByWithdrawalSlipDAL(Guid accountID, double amount);
        public abstract bool CreditTransactionByDepositSlipDAL(Guid accountID, double amount);
        public abstract bool DebitTransactionByChequeDAL(Guid accountID, double amount, string chequeNumber);
        public abstract bool CreditTransactionByChequeDAL(Guid accountID, double amount, string chequeNumber);
        public abstract List<Transaction> DisplayTransactionByAccountIDDAL(Guid accountID);
        public abstract Transaction DisplayTransactionByTransactionIDDAL(Guid transactionID);
        public abstract bool SerializeIntoJSON(List<Transaction> transactions, string filename);
        public abstract List<Transaction> DeserializeFromJSON(string filename);
        public abstract bool TransactionIDExistsDAL(Guid transactionID);
        public abstract List<Transaction> GetAllTransactionsDAL();

    }
}
