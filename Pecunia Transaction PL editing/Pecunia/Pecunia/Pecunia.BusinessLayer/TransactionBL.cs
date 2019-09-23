using System;
using Pecunia.Exceptions;
using Pecunia.DataAccessLayer;
using System.Text.RegularExpressions;
using Pecunia.Entities;
using System.Collections.Generic;

namespace Pecunia.BusinessLayer
{
    public class TransactionsBL
    {
        public bool DebitTransactionByWithdrawalSlipBL(long AccountNo, double Amount)
        {
            // FD accountNo ranges from 30000 - 39999, Current accountNo ranges from 40000-49999, savings accountNo ranges from 50000-59999
            if (BusinessLogicUtil.validateAccountNo(Convert.ToString(AccountNo)) && Amount <= 50000)
            {
                TransactionDAL debit = new TransactionDAL();
                return debit.DebitTransactionByWithdrawalSlipDAL(AccountNo, Amount);
            }
            else
            {
                throw new DebitSlipException("Invalid Account No or Amount");
            }
        }
        public bool CreditTransactionByDepositSlipBL(long AccountNo, Double Amount)
        {

            if (BusinessLogicUtil.validateAccountNo(Convert.ToString(AccountNo)) && Amount <= 50000)
            {
                TransactionDAL credit = new TransactionDAL();
                return credit.CreditTransactionByDepositSlipDAL(AccountNo, Amount);
            }
            else
            {
                throw new CreditSlipException("Invalid Account No or Amount");
            }
        }
        public bool DebitTransactionByChequeBL(long AccountNo, double Amount, string ChequeNo)
        {

            if (BusinessLogicUtil.validateAccountNo(Convert.ToString(AccountNo)) && Amount <= 50000 && ChequeNo.Length == 10 && (Regex.IsMatch(ChequeNo, "[A-Z0-9]$") == true))
            {
                TransactionDAL Cheque = new TransactionDAL();
                return Cheque.DebitTransactionByChequeDAL(AccountNo, Amount, ChequeNo);
            }
            else
            {
                throw new DebitChequeException("Invalid Account Credentials or Amount");
            }

        }
        public bool CreditTransactionByChequeBL(long AccountNo, double Amount, string ChequeNo)
        {
            if ( BusinessLogicUtil.validateAccountNo(Convert.ToString(AccountNo)) && ValidateCheque(ChequeNo) == true && Amount <= 50000)
            {
                TransactionDAL Cheque = new TransactionDAL();
                return Cheque.CreditTransactionByChequeDAL(AccountNo, Amount, ChequeNo);
            }
            else
            {
                throw new CreditChequeException("Invalid Account Credentials or Amount");
            }
        }
        public void DisplayTransactionByCustomerID_BL(string CustomerID)
        {
            if (Regex.IsMatch(CustomerID, "[0-9]{14}$") == true)
            {
                TransactionDAL trans = new TransactionDAL();
                trans.DisplayTransactionByCustomerID_DAL(CustomerID);
            }
            else
            {
                throw new TransactionDisplayIDException("Invalid ID");
            }
        }
        public void DisplayTransactionByAccountNoBL(long AccountNo)
        {
            if (BusinessLogicUtil.validateAccountNo(Convert.ToString(AccountNo)))
            {
                TransactionDAL acc = new TransactionDAL();
                acc.DisplayTransactionByAccountNo_DAL(AccountNo);
            }
            else
            {
                throw new TransactionDisplayAccountException("Invalid AccountNo");
            }
        }
        public TransactionEntities DisplayTransactionByTransactionID_BL(string transactionID)
        {
            if (Regex.IsMatch(transactionID, "[TRANS][0-9]{14}$") == true)
            {
                TransactionDAL transDAL = new TransactionDAL();
                return transDAL.DisplayTransactionByTransactionID_DAL(transactionID);
            }
            else
            {
                throw new TransactionDetailsException("Invalid Transaction ID");
            }
            
        }
        public bool ValidateCheque(string ChequeNo)
        {
            if (Regex.IsMatch(ChequeNo, "[0-9]{10}$")==true)
            {
                return true;
            }
            return false;
        }

        public List<TransactionEntities> GetAllTransactionBL()
        {
            TransactionDAL transDAL = new TransactionDAL();
            return transDAL.GetAllTransactionsDAL();
        }

    }
}
