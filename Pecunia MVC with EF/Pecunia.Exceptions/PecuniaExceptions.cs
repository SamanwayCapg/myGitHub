﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.Pecunia.Exceptions
{
    public class InvalidStringException : ApplicationException
    {
        public InvalidStringException(string msg) : base(msg)
        {

        }
    }

    public class EmployeeAddedException : ApplicationException
    {
        public EmployeeAddedException(string msg) : base(msg)
        {

        }
    }

    public class InvalidEmployeeException : ApplicationException
    {
        public InvalidEmployeeException(string msg) : base(msg)
        {

        }

    }

    public class EmployeeUpdateException : ApplicationException
    {
        public EmployeeUpdateException(string msg) : base(msg)
        {

        }
    }

    public class EmployeeDeletedException : ApplicationException
    {
        public EmployeeDeletedException(string msg) : base(msg)
        {

        }
    }

    public class EmployeeListException : ApplicationException
    {
        public EmployeeListException(string msg) : base(msg)
        {

        }
    }

    public class LoanListException : ApplicationException
    {
        public LoanListException(string msg) : base(msg)
        {

        }
    }

    public class InvalidAdminException : ApplicationException
    {
        public InvalidAdminException(string msg) : base(msg)
        {

        }

    }

    public class AdminUpdateException : ApplicationException
    {
        public AdminUpdateException(string msg) : base(msg)
        {

        }

    }


    public class InvalidAmountException : ApplicationException
    {
        public InvalidAmountException(string msg) : base(msg)
        {

        }
    }

    public class InvalidRangeException : ApplicationException
    {
        public InvalidRangeException(string msg) : base(msg)
        {

        }
    }

    public class InvalidEnumException : ApplicationException
    {
        public InvalidEnumException(string msg) : base(msg)
        {

        }
    }


    public class InitialAmountOfFDException : Exception
    {
        public InitialAmountOfFDException(String m) : base(m)
        {

        }
    }
    public class EnterValidCustomerIDException : Exception
    {
        public EnterValidCustomerIDException(String m) : base(m)
        {

        }
    }

    public class CustomerDoesNotExistException : Exception
    {
        public CustomerDoesNotExistException(String m) : base(m)
        {

        }
    }

    public class EnterValidAccountTypeException : Exception
    {
        public EnterValidAccountTypeException(String m) : base(m)
        {

        }
    }
    public class AccountDoesNotExistException : Exception
    {
        public AccountDoesNotExistException(String m) : base(m)
        {

        }
    }

    public class DebitSlipException : ApplicationException
    {
        public DebitSlipException(string message) : base(message)
        {

        }
    }
    public class CreditSlipException : ApplicationException
    {
        public CreditSlipException(string message) : base(message)
        {

        }
    }
    public class DebitChequeException : ApplicationException
    {
        public DebitChequeException(string message) : base(message)
        {

        }
    }
    public class CreditChequeException : ApplicationException
    {
        public CreditChequeException(string message) : base(message)
        {

        }
    }
    public class TransactionDisplayIDException : ApplicationException
    {
        public TransactionDisplayIDException(string message) : base(message)
        {

        }
    }
    public class TransactionDisplayAccountException : ApplicationException
    {
        public TransactionDisplayAccountException(string message) : base(message)
        {

        }
    }
    public class TransactionDetailsException : ApplicationException
    {
        public TransactionDetailsException(string message) : base(message)
        {

        }
    }

        public class TransactionIDExistsException : ApplicationException
    {
        public TransactionIDExistsException(string message) : base(message)
        {

        }
    }
    public class ValidateChequeNumberException : ApplicationException
    {
        public ValidateChequeNumberException(string message) : base(message)
        {

        }
    }

   

    public class GetAllTransactionException : ApplicationException
    {
        public GetAllTransactionException(string message) : base(message)
        {

        }
    }

    public class StoreTransactionException : ApplicationException
    {
        public StoreTransactionException(string message) : base(message)
        {

        }
    }

    public class InsufficientBalanceException : ApplicationException
    {
        public InsufficientBalanceException(string message) : base(message)
        {

        }
    }

    public class FDAccountCannotBeChangedException : ApplicationException
    {
        public FDAccountCannotBeChangedException(string msg) : base(msg)
        {

        }
    }

    public class EnterValidAccountIDException : ApplicationException
    {
        public EnterValidAccountIDException(string msg) : base(msg)
        {

        }
    }

    public class PecuniaException : ApplicationException
    {
        public PecuniaException()
            : base()
        {
        }

        public PecuniaException(string message)
                : base(message)
        {
        }
        public PecuniaException(string message, Exception innerException)
                : base(message, innerException)
        {
        }
    }
}
