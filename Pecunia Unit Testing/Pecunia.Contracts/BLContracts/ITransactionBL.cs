using Capgemini.Pecunia.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.Pecunia.Contracts.BLContracts
{
    public interface ITransactionBL : IDisposable
    {
        Task<bool> DebitTransactionByWithdrawalSlipBL(Guid accountID, double amount);
        Task<bool> CreditTransactionByDepositSlipBL(Guid accountID, double amount);
        Task<bool> DebitTransactionByChequeBL(Guid accountID, double amount, string chequeNumber);
        Task<bool> CreditTransactionByChequeBL(Guid AccountID, double Amount, string ChequeNumber);
        Task DisplayTransactionByAccountIDBL(Guid AccountID);
        Task<bool> TransactionIDExistsBL(Guid transactionID);
        Task<Transaction> DisplayTransactionByTransactionIDBL(Guid transactionID);
        Task<bool> ValidateChequeNumber(string chequeNumber);
        Task<List<Transaction>> GetAllTransactionBL();
    }
}
