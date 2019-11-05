using Pecunia.PresentationMVC.ServiceReference1;
using Capgemini.Pecunia.Entities;
using MvcTransaction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capgemini.Pecunia.BusinessLayer;
using System.Threading.Tasks;

namespace MvcTransaction.Controllers
{
    public class TransactionController : Controller
    {
        //URL: Transaction/ChequeTransactions
        public async Task<ActionResult> ChequeTransactions()
        {
            //Creating and initializing viewmodel object
            TransactionViewModel transactionViewModel = new TransactionViewModel()
            {
                TransactionID = Guid.NewGuid(),
                Mode = "Cheque"
            };
            TransactionBL transactionBL = new TransactionBL();

            //Getting list of accounts from TransactionBL
            List<Account> accounts = new List<Account>();
            accounts = await transactionBL.GetAllAccountsBL();

            //Add accounts to ViewBag
            ViewBag.AccountsList = new SelectList(accounts, "AccountID", "AccountID");

            return View(transactionViewModel);
        }


        //Saving the Cheque Transaction
        [HttpPost]
        public async Task<ActionResult> SaveCheque(TransactionViewModel transactionVM)
        {
            TransactionBL transactionBL = new TransactionBL();
            Transaction transaction = new Transaction();

            transaction.TransactionID = Guid.NewGuid();
            transaction.AccountID = (System.Guid)transactionVM.AccountID;
            transaction.TypeOfTransaction = transactionVM.TypeOfTransaction;
            transaction.Amount = (decimal)transactionVM.Amount;
            
            transaction.Mode = transactionVM.Mode;
            transaction.ChequeNumber = transactionVM.ChequeNumber;

            if(transaction.TypeOfTransaction == "Debit")
            {
                await transactionBL.DebitTransactionByChequeBL(transaction.AccountID, transaction.Amount, transaction.ChequeNumber);
                return RedirectToAction("Index", "Transaction");
            }
            else
            {
                await transactionBL.CreditTransactionByChequeBL(transaction.AccountID, transaction.Amount, transaction.ChequeNumber);
                return RedirectToAction("Index", "Transaction");
            }


        }

        //URL: Transaction/SlipTransactions
        public async Task<ActionResult> SlipTransactions()
        {
            //Creating and initializing viewmodel object
            TransactionViewModel transactionViewModel = new TransactionViewModel()
            {
                Mode = "Slip",
                TransactionID = Guid.NewGuid()
            };

            TransactionBL transactionBL = new TransactionBL();

            //Getting list of accounts from TransactionBL
            List<Account> accounts = new List<Account>();
            accounts = await transactionBL.GetAllAccountsBL();

            //Add accounts to ViewBag
            ViewBag.AccountsList = new SelectList(accounts, "AccountID", "AccountID");
            return View(transactionViewModel);
        }

        //Saving the Slip Transaction
        [HttpPost]
        public async Task<ActionResult> SaveSlip(TransactionViewModel transactionVM)
        {
            bool isAdded = true;
            TransactionBL transactionBL = new TransactionBL();
            Transaction transaction = new Transaction();

            transaction.TransactionID = Guid.NewGuid();
            transaction.AccountID = (System.Guid)transactionVM.AccountID;
            transaction.TypeOfTransaction = transactionVM.TypeOfTransaction;
            System.Diagnostics.Debug.WriteLine(transactionVM.TypeOfTransaction);
            transaction.Amount = (decimal)transactionVM.Amount;

            transaction.Mode = transactionVM.Mode;
            transaction.ChequeNumber = transactionVM.ChequeNumber;

            
            if (transaction.TypeOfTransaction == "Debit")
            {
                isAdded = await transactionBL.DebitTransactionByWithdrawalSlipBL(transaction.AccountID, transaction.Amount);
                
            }
            else
            {
                isAdded = await transactionBL.CreditTransactionByDepositSlipBL(transaction.AccountID, transaction.Amount);
                //return RedirectToAction("Index", "Transaction");
            }
            if (isAdded == true)
            {
                return RedirectToAction("Index", "Transaction");
            }
            return RedirectToAction("Index", "Transaction");
        }

       
        public ActionResult Index()
        {
            //Creating and initializing viewmodel object
            TransactionViewModel transactionViewModel = new TransactionViewModel();

            //Creating object of TransactionsBL
            TransactionBL transactionBL = new TransactionBL();

            // Proxy: used to call the service
           TransactionServiceClient transactionServiceClient = new TransactionServiceClient();

            //Getting list of transactions from TransactionBL
            TransactionDataContract[] transactionDataContracts = transactionServiceClient.GetAllTransactions();

            //Convert data from DataContract to ViewModel
            List<TransactionViewModel> transactionsVM = transactionDataContracts
                .Select
                    (temp => new TransactionViewModel()
                    {
                        AccountID = temp.AccountID,
                        TypeOfTransaction = temp.TypeOfTransaction,
                        Amount = temp.Amount,
                        DateOfTransaction = temp.DateOfTransaction,
                        Mode = temp.Mode,
                        ChequeNumber = temp.ChequeNumber

                    }
                ).ToList();

            //Calling view & passing viewmodel object to view
            return View(transactionsVM);

        }

    }
}