using Capgemini.Pecunia.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace Capgemini.Pecunia.Contracts.BLContracts
{
    public interface ITransactionBL : IDisposable
    {
        Task<bool> DebitTransactionByWithdrawalSlipBL(Guid accountID, decimal amount);
        Task<bool> CreditTransactionByDepositSlipBL(Guid accountID, decimal amount);
        Task<bool> DebitTransactionByChequeBL(Guid accountID, decimal amount, string chequeNumber);
        Task<bool> CreditTransactionByChequeBL(Guid AccountID, decimal Amount, string ChequeNumber);
        Task<List<Transaction>> DisplayTransactionByAccountIDBL(string AccountID);
        //Task<bool> TransactionIDExistsBL(Guid transactionID);
        //Task<Transaction> DisplayTransactionByTransactionIDBL(Guid transactionID);
        Task<bool> ValidateChequeNumber(string chequeNumber);
        Task<List<Transaction>> GetAllTransactionBL();
        Task<List<Account>> GetAllAccountsBL();
    }
}
