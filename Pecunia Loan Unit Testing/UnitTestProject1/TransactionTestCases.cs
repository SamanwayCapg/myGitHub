using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Capgemini.Pecunia.BusinessLayer.LoanBL;
using Capgemini.Pecunia.BusinessLayer;
using Capgemini.Pecunia.Entities;
using Capgemini.Pecunia.Exceptions;
using System.Collections.Generic;
using Capgemini.Pecunia.DataAccessLayer;


namespace Capgemini.Pecunia.UnitTest
{
    [TestClass]
    public class CreditTransactionChequeBLTest
    {
        /// <summary>
        /// Credit Transaction if it is valid.
        /// </summary>
        [TestMethod]
        public async Task CreditTransactionByCheque()
        {
            //Arrange
            TransactionBL transactionBL = new TransactionBL();
            Transaction transaction = new Transaction() { AccountID = Guid.Parse("bdc8e59d-f8ac-4cd6-92eb-4c3ed5baacf7"), Amount = 30000.00, ChequeNumber = "123456" };

            bool isCredited = false;
            string errorMessage = null;

            //Act
            try
            {
                isCredited = await transactionBL.CreditTransactionByChequeBL(transaction.AccountID, transaction.Amount, transaction.ChequeNumber);
            }
            catch (CreditChequeException ex)
            {
                isCredited = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsTrue(isCredited, errorMessage);
            }
        }

        /// <summary>
        /// Account ID can't be null
        /// </summary>
        [TestMethod]
        public async Task AccountIDCantBeNull()
        {
            //Arrange
            TransactionBL transactionBL = new TransactionBL();
            Transaction transaction = new Transaction() { AccountID = Guid.Parse(""), Amount = 30000.00, ChequeNumber = "123456" };
            bool isCredited = false;
            string errorMessage = null;

            //Act
            try
            {
                isCredited = await transactionBL.CreditTransactionByChequeBL(transaction.AccountID, transaction.Amount, transaction.ChequeNumber);
            }
            catch (CreditChequeException ex)
            {
                isCredited = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isCredited, errorMessage);
            }
        }

        /// <summary>
        /// Amount can't be null
        /// </summary>
        [TestMethod]
        public async Task AmountCantBeNull()
        {

            //Arrange
            TransactionBL transactionBL = new TransactionBL();
            Transaction transaction = new Transaction() { AccountID = Guid.Parse("bdc8e59d-f8ac-4cd6-92eb-4c3ed5baacf7"), Amount = 0, ChequeNumber = "123456" };
            bool isCredited = false;
            string errorMessage = null;

            //Act
            try
            {
                isCredited = await transactionBL.CreditTransactionByChequeBL(transaction.AccountID, transaction.Amount, transaction.ChequeNumber);
            }
            catch (CreditChequeException ex)
            {
                isCredited = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isCredited, errorMessage);
            }
        }

        /// <summary>
        /// Cheque Number can't be null
        /// </summary>
        [TestMethod]
        public async Task ChequeNumberCantBeNull()
        {
            //Arrange
            TransactionBL transactionBL = new TransactionBL();
            Transaction transaction = new Transaction() { AccountID = Guid.Parse("bdc8e59d-f8ac-4cd6-92eb-4c3ed5baacf7"), Amount = 30000.00, ChequeNumber = "" };
            bool isCredited = false;
            string errorMessage = null;

            //Act
            try
            {
                isCredited = await transactionBL.CreditTransactionByChequeBL(transaction.AccountID, transaction.Amount, transaction.ChequeNumber);
            }
            catch (CreditChequeException ex)
            {
                isCredited = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isCredited, errorMessage);
            }
        }

        /// <summary>
        /// Amount should be positive and less than 50000
        /// </summary>
        [TestMethod]
        public async Task Amountshouldbepositiveandlessthan50000()
        {
            //Arrange
            TransactionBL transactionBL = new TransactionBL();
            Transaction transaction = new Transaction() { AccountID = Guid.Parse("bdc8e59d-f8ac-4cd6-92eb-4c3ed5baacf7"), Amount = -8, ChequeNumber = "123456" };
            bool isCredited = false;
            string errorMessage = null;

            //Act
            try
            {
                isCredited = await transactionBL.CreditTransactionByChequeBL(transaction.AccountID, transaction.Amount, transaction.ChequeNumber);
            }
            catch (CreditChequeException ex)
            {
                isCredited = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isCredited, errorMessage);
            }
        }

        /// <summary>
        /// Cheque Number should be of 6 digits
        /// </summary>
        [TestMethod]
        public async Task ChequeNumbershouldbeof6digits()
        {
            //Arrange
            TransactionBL transactionBL = new TransactionBL();
            Transaction transaction = new Transaction() { AccountID = Guid.Parse("bdc8e59d-f8ac-4cd6-92eb-4c3ed5baacf7"), Amount = 34534.00, ChequeNumber = "456" };
            bool isCredited = false;
            string errorMessage = null;

            //Act
            try
            {
                isCredited = await transactionBL.CreditTransactionByChequeBL(transaction.AccountID, transaction.Amount, transaction.ChequeNumber);
            }
            catch (CreditChequeException ex)
            {
                isCredited = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isCredited, errorMessage);
            }
        }

    }
    [TestClass]
    public class DebitTransactionByChequeBLTest
    {
        /// <summary>
        /// Debit Transaction if it is valid.
        /// </summary>
        [TestMethod]
        public async Task DebitTransactionByCheque()
        {
            //Arrange
            TransactionBL transactionBL = new TransactionBL();
            Transaction transaction = new Transaction() { AccountID = Guid.Parse("bdc8e59d-f8ac-4cd6-92eb-4c3ed5baacf7"), Amount = 30000.00, ChequeNumber = "123456" };
            bool isDebited = false;
            string errorMessage = null;

            //Act
            try
            {
                isDebited = await transactionBL.DebitTransactionByChequeBL(transaction.AccountID, transaction.Amount, transaction.ChequeNumber);
            }
            catch (DebitChequeException ex)
            {
                isDebited = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsTrue(isDebited, errorMessage);
            }
        }

        /// <summary>
        /// Account ID can't be null
        /// </summary>
        [TestMethod]
        public async Task AccountIDCantBeNull()
        {
            //Arrange
            TransactionBL transactionBL = new TransactionBL();
            Transaction transaction = new Transaction() { AccountID = Guid.Parse(""), Amount = 30000.00, ChequeNumber = "123456" };
            bool isDebited = false;
            string errorMessage = null;

            //Act
            try
            {
                isDebited = await transactionBL.DebitTransactionByChequeBL(transaction.AccountID, transaction.Amount, transaction.ChequeNumber);
            }
            catch (DebitChequeException ex)
            {
                isDebited = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isDebited, errorMessage);
            }
        }

        /// <summary>
        /// Amount can't be null
        /// </summary>
        [TestMethod]
        public async Task AmountCantBeNull()
        {
            //Arrange
            TransactionBL transactionBL = new TransactionBL();
            Transaction transaction = new Transaction() { AccountID = Guid.Parse("bdc8e59d-f8ac-4cd6-92eb-4c3ed5baacf7"), Amount = 0, ChequeNumber = "123456" };
            bool isDebited = false;
            string errorMessage = null;

            //Act
            try
            {
                isDebited = await transactionBL.DebitTransactionByChequeBL(transaction.AccountID, transaction.Amount, transaction.ChequeNumber);
            }
            catch (DebitChequeException ex)
            {
                isDebited = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isDebited, errorMessage);
            }
        }

        /// <summary>
        /// Cheque Number can't be null
        /// </summary>
        [TestMethod]
        public async Task ChequeNumberCantBeNull()
        {
            //Arrange
            TransactionBL transactionBL = new TransactionBL();
            Transaction transaction = new Transaction() { AccountID = Guid.Parse("bdc8e59d-f8ac-4cd6-92eb-4c3ed5baacf7"), Amount = 30000.00, ChequeNumber = "" };
            bool isDebited = false;
            string errorMessage = null;

            //Act
            try
            {
                isDebited = await transactionBL.DebitTransactionByChequeBL(transaction.AccountID, transaction.Amount, transaction.ChequeNumber);
            }
            catch (DebitChequeException ex)
            {
                isDebited = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isDebited, errorMessage);
            }
        }

        /// <summary>
        /// Amount should be positive and less than 50000
        /// </summary>
        [TestMethod]
        public async Task Amountshouldbepositiveandlessthan50000()
        {
            //Arrange
            TransactionBL transactionBL = new TransactionBL();
            Transaction transaction = new Transaction() { AccountID = Guid.Parse("bdc8e59d-f8ac-4cd6-92eb-4c3ed5baacf7"), Amount = -8, ChequeNumber = "123456" };
            bool isDebited = false;
            string errorMessage = null;

            //Act
            try
            {
                isDebited = await transactionBL.DebitTransactionByChequeBL(transaction.AccountID, transaction.Amount, transaction.ChequeNumber);
            }
            catch (DebitChequeException ex)
            {
                isDebited = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isDebited, errorMessage);
            }
        }

        /// <summary>
        /// Cheque Number should be of 6 digits
        /// </summary>
        [TestMethod]
        public async Task ChequeNumbershouldbeof6digits()
        {
            //Arrange
            TransactionBL transactionBL = new TransactionBL();
            Transaction transaction = new Transaction() { AccountID = Guid.Parse("bdc8e59d-f8ac-4cd6-92eb-4c3ed5baacf7"), Amount = 34534.00, ChequeNumber = "456" };
            bool isDebited = false;
            string errorMessage = null;

            //Act
            try
            {
                isDebited = await transactionBL.DebitTransactionByChequeBL(transaction.AccountID, transaction.Amount, transaction.ChequeNumber);
            }
            catch (DebitChequeException ex)
            {
                isDebited = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isDebited, errorMessage);
            }
        }

    }

    [TestClass]
    public class CreditTransactionSlipBLTest
    {
        /// <summary>
        /// Credit Transaction if it is valid.
        /// </summary>
        [TestMethod]
        public async Task CreditTransactionBySlip()
        {
            //Arrange
            TransactionBL transactionBL = new TransactionBL();
            Transaction transaction = new Transaction() { AccountID = Guid.Parse("bdc8e59d-f8ac-4cd6-92eb-4c3ed5baacf7"), Amount = 30000.00 };
            bool isCredited = false;
            string errorMessage = null;

            //Act
            try
            {
                isCredited = await transactionBL.CreditTransactionByDepositSlipBL(transaction.AccountID, transaction.Amount);
            }
            catch (CreditSlipException ex)
            {
                isCredited = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsTrue(isCredited, errorMessage);
            }
        }

        /// <summary>
        /// Account ID can't be null
        /// </summary>
        [TestMethod]
        public async Task AccountIDCantBeNull()
        {
            //Arrange
            TransactionBL transactionBL = new TransactionBL();
            Transaction transaction = new Transaction() { AccountID = Guid.Parse(""), Amount = 30000.00 };
            bool isCredited = false;
            string errorMessage = null;

            //Act
            try
            {
                isCredited = await transactionBL.CreditTransactionByDepositSlipBL(transaction.AccountID, transaction.Amount);
            }
            catch (CreditSlipException ex)
            {
                isCredited = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isCredited, errorMessage);
            }
        }

        /// <summary>
        /// Amount can't be null
        /// </summary>
        [TestMethod]
        public async Task AmountCantBeNull()
        {
            //Arrange
            TransactionBL transactionBL = new TransactionBL();
            Transaction transaction = new Transaction() { AccountID = Guid.Parse("bdc8e59d-f8ac-4cd6-92eb-4c3ed5baacf7"), Amount = 0 };
            bool isCredited = false;
            string errorMessage = null;

            //Act
            try
            {
                isCredited = await transactionBL.CreditTransactionByDepositSlipBL(transaction.AccountID, transaction.Amount);
            }
            catch (CreditSlipException ex)
            {
                isCredited = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isCredited, errorMessage);
            }
        }

        /// <summary>
        /// Amount should be positive and less than 50000
        /// </summary>
        [TestMethod]
        public async Task Amountshouldbepositiveandlessthan50000()
        {
            //Arrange
            TransactionBL transactionBL = new TransactionBL();
            Transaction transaction = new Transaction() { AccountID = Guid.Parse("bdc8e59d-f8ac-4cd6-92eb-4c3ed5baacf7"), Amount = -8 };
            bool isCredited = false;
            string errorMessage = null;

            //Act
            try
            {
                isCredited = await transactionBL.CreditTransactionByDepositSlipBL(transaction.AccountID, transaction.Amount);
            }
            catch (CreditSlipException ex)
            {
                isCredited = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isCredited, errorMessage);
            }
        }
    }
    [TestClass]
    public class DebitTransactionSlipBLTest
    {
        /// <summary>
        /// Debit Transaction if it is valid.
        /// </summary>
        [TestMethod]
        public async Task DebitTransactionByWithdrawalSlip()
        {
            //Arrange
            TransactionBL transactionBL = new TransactionBL();
            Transaction transaction = new Transaction() { AccountID = Guid.Parse("bdc8e59d-f8ac-4cd6-92eb-4c3ed5baacf7"), Amount = 30000.00 };
            bool isDebited = false;
            string errorMessage = null;

            //Act
            try
            {
                isDebited = await transactionBL.DebitTransactionByWithdrawalSlipBL(transaction.AccountID, transaction.Amount);
            }
            catch (DebitSlipException ex)
            {
                isDebited = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsTrue(isDebited, errorMessage);
            }
        }

        /// <summary>
        /// Account ID can't be null
        /// </summary>
        [TestMethod]
        public async Task AccountIDCantBeNull()
        {
            //Arrange
            TransactionBL transactionBL = new TransactionBL();
            Transaction transaction = new Transaction() { AccountID = Guid.Parse(""), Amount = 30000.00 };
            bool isDebited = false;
            string errorMessage = null;

            //Act
            try
            {
                isDebited = await transactionBL.DebitTransactionByWithdrawalSlipBL(transaction.AccountID, transaction.Amount);
            }
            catch (DebitSlipException ex)
            {
                isDebited = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isDebited, errorMessage);
            }
        }

        /// <summary>
        /// Amount can't be null
        /// </summary>
        [TestMethod]
        public async Task AmountCantBeNull()
        {
            //Arrange
            TransactionBL transactionBL = new TransactionBL();
            Transaction transaction = new Transaction() { AccountID = Guid.Parse("bdc8e59d-f8ac-4cd6-92eb-4c3ed5baacf7"), Amount = 0 };
            bool isDebited = false;
            string errorMessage = null;

            //Act
            try
            {
                isDebited = await transactionBL.DebitTransactionByWithdrawalSlipBL(transaction.AccountID, transaction.Amount);
            }
            catch (DebitSlipException ex)
            {
                isDebited = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isDebited, errorMessage);
            }
        }

        /// <summary>
        /// Amount should be positive and less than 50000
        /// </summary>
        [TestMethod]
        public async Task Amountshouldbepositiveandlessthan50000()
        {
            //Arrange
            TransactionBL transactionBL = new TransactionBL();
            Transaction transaction = new Transaction() { AccountID = Guid.Parse("bdc8e59d-f8ac-4cd6-92eb-4c3ed5baacf7"), Amount = -8 };
            bool isDebited = false;
            string errorMessage = null;

            //Act
            try
            {
                isDebited = await transactionBL.DebitTransactionByWithdrawalSlipBL(transaction.AccountID, transaction.Amount);
            }
            catch (DebitSlipException ex)
            {
                isDebited = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isDebited, errorMessage);
            }
        }
    }
    [TestClass]
    public class GetAllTransactionsBLTest
    {
        [TestMethod]
        public void GetAllTransactionsTest()
        {
            //Arrange

            bool isAdded = false;
            bool isAddedToList = false;
            Transaction transaction1 = new Transaction() { AccountID = Guid.Parse("bdc8e59d-f8ac-4cd6-92eb-4c3ed5baacf7"), Type = TypeOfTranscation.Credit, Amount = 40000, Mode = ModeOfTransaction.Cheque, ChequeNumber = "123456" };
            TransactionDAL transactionDAL = new TransactionDAL();
            List<Transaction> transactionList = transactionDAL.GetAllTransactionsDAL();
            int count1 = transactionList.Count;

            isAdded = transactionDAL.StoreTransactionRecord(Guid.Parse("bdc8e59d-f8ac-4cd6-92eb-4c3ed5baacf7"), 40000, TypeOfTranscation.Credit, ModeOfTransaction.Cheque, "123456");
            transactionList = transactionDAL.GetAllTransactionsDAL();
            int count2 = transactionList.Count;
            string errorMessage = null;

            //Act
            try
            {
                if (count2 == count1 + 1)
                    isAddedToList = true;
            }
            catch (GetAllTransactionException ex)
            {
                isAddedToList = false;
                errorMessage = ex.Message;
            }
            finally
            {
                Assert.IsTrue(isAddedToList, errorMessage);
            }
        }
    }
}
