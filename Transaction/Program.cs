using System;
using System.Collections.Generic;

namespace PecuniaF
{
    interface ITransaction
    {
        long TransactionID { get; set;}
        long AccountNumber { get; set;}
        double Amount { get; set;}
        DateTime DateOfTransaction { get; set;}
        string Type { get; set;}

    }

    class Transaction : ITransaction
    {
        private long _transactionID;
        private long _accountNumber;
        private double _amount;
        private  DateTime _dateOfTransaction = DateTime.Now;
        private string _type;

        public long TransactionID
        {
            set
            {
                _transactionID = value;
            }
            get
            {
                return _transactionID;
            }
        }

        public long AccountNumber
        {
            set
            {
                _accountNumber = value;
            }
            get
            {
                return _accountNumber;
            }
        }

        public double Amount
        {
            set
            {
                _amount = value;
            }
            get
            {
                return _amount;
            }
        }
        public string Type
        {
            set
            {
                _type = value;
            }
            get
            {
                return _type;
            }
        }

        public DateTime DateOfTransaction
        {
            set
            {
                _dateOfTransaction = DateTime.Now;
            }
            get
            {
                return _dateOfTransaction;
            }
    }


        interface ITransactionService
        {
            List<Transaction> Transactions { get; set;}
             void Debit();
            void Credit();
            void getSummaryByAccount(long accountnumber);
            void getSummaryByDate(DateTime date);

        }

        class TransactionService : ITransactionService
        {
            public List<Transaction> Transactions { get => Transactions; set => Transactions = value;
            }

            public void Credit()
            {
               /* Transaction t = new Transaction();

                Transactions.Add(t);*/
            }

            public void Debit()
            {
                
            }

            public void getSummaryByAccount(long accountnumber)
            {
               
            }

            public void getSummaryByDate(DateTime date)
            {
                throw new NotImplementedException();
            }
        }






        class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
}