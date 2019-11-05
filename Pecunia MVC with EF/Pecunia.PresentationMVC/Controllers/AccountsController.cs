using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capgemini.Pecunia.Entities;
using PecuniaMVC.Models;
using Capgemini.Pecunia.BusinessLayer;
using System.Threading.Tasks;
using Pecunia.PresentationMVC.ServiceReference1;
using TeamF.WCF;

namespace PecuniaMVC.Controllers
{
    public class AccountsController : Controller
    {
        // URL: Accounts/Create
        public ActionResult Create()
        {
            //Creating View Modal Object
            AccountViewModel accountViewModel = new AccountViewModel();


            //Creating object of CustomerBL
            CustomerBL customerBL = new CustomerBL();

            List<Customer> customers = customerBL.GetAllCustomerDetailsBL();

            ViewBag.CustomersList = new SelectList(customers, "CustomerID", "CustomerName");
            return View(accountViewModel);

        }

        // URL: Accounts/Create
        [HttpPost]
        public async Task<ActionResult> Create(AccountViewModel accountVM)
        {
            //Create object of PersonsBL
            AccountBL accountBL = new AccountBL();

            //Creating object of Person EntityModel
            Account account = new Account();
            System.Diagnostics.Debug.WriteLine(accountVM.CustomerID);
            Guid cust = (Guid)accountVM.CustomerID;
            account.CustomerID = accountVM.CustomerID;
            account.AccountType = accountVM.AccountType;
            account.HomeBranch = accountVM.HomeBranch;

            //Invoke the AddPerson method BL
            bool isAdded = await accountBL.AddAccountBL(account, cust, account.AccountType);
            if (isAdded)
            {
                //Go to Index action method of Persons Controller
                return RedirectToAction("AccountAdded");
            }
            else
            {
                //Return plain html / plain string
                return Content("Account not added");
            }
        }

        public  ActionResult ShowAllAccount()
        {
            List<AccountViewModelDisplay> accountViewModelList = new List<AccountViewModelDisplay>();

            using (TransactionServiceClient accountServiceClient = new TransactionServiceClient())
            {
                AccountBL accountBL = new AccountBL();
                List<Account> accountsList = accountBL.GetAllAccountsBL();

                foreach (var acc in accountsList)
                {
                    AccountViewModelDisplay accountView = new AccountViewModelDisplay()
                    {
                        AccountID = acc.AccountID,
                        CustomerID = acc.CustomerID,
                        HomeBranch = acc.HomeBranch,
                        AccountType = acc.AccountType,
                        AccountNumber=acc.AccountNumber

                    };
                    accountViewModelList.Add(accountView);
                }

                if (accountViewModelList.Count == 0)
                {
                    return RedirectToAction("Create", "Accounts");
                }

            }
            return View(accountViewModelList);
        }

        public ActionResult AccountAdded()
        {
            return View();
        }
        public async  Task<ActionResult> EditAccount(Guid id)
        {
            AccountBL accountBL = new AccountBL();
           
            Account account = await accountBL.GetAccountByAccountIDBL(id);
            
            AccountViewModelDisplay accountViewModel = new AccountViewModelDisplay();
            accountViewModel.CustomerID = account.CustomerID;
            accountViewModel.AccountType = account.AccountType;
            accountViewModel.HomeBranch = account.HomeBranch;
            accountViewModel.AccountID = account.AccountID;
            System.Diagnostics.Debug.WriteLine(id);

            TempData["Avm"] = accountViewModel;
            return View(accountViewModel); // Object is of Type AccountViewModalDisplay
        }

        public ActionResult EditingAccountMenu()
        {
            AccountBL accountBL = new AccountBL();
            List<Account> accountList = new List<Account>();
            accountList = accountBL.GetAllAccountsBL();

            List<AccountViewModelDisplay> accountVMList = new List<AccountViewModelDisplay>();
            foreach (var temp in accountList)
            {
                AccountViewModelDisplay accountVM = new AccountViewModelDisplay()
                {
                    CustomerID = temp.CustomerID,
                    AccountType = temp.AccountType,
                    AccountBalance = temp.AccountBalance,
                    AccountNumber = temp.AccountNumber,
                    HomeBranch = temp.HomeBranch,
                    AccountID =temp.AccountID
                };
                accountVMList.Add(accountVM);

               
            }
           
            return View(accountVMList);
        }

        // URL: Accounts/EditedAccountAdd
        [HttpPost]
        public async Task<ActionResult> EditedAccountAdd(FormCollection collection)
        {
            //Create object of PersonsBL
            AccountBL accountBL = new AccountBL();

            //Creating object of Person EntityModel
            Account account = new Account();

            Guid.TryParse(collection["AccountID"], out Guid tp);

            //Invoke the AddPerson method BL
            var obj = (AccountViewModelDisplay)TempData["Avm"];
            account.AccountType = obj.AccountType;
            account.HomeBranch = obj.HomeBranch;

            System.Diagnostics.Debug.WriteLine(obj.AccountID);
        
            bool isAdded = await accountBL.ChangeAccountTypeBL(tp,collection["AccountType"]);
            
            bool second = await accountBL.ChangeBranchBL(tp,collection["HomeBranch"]);
            if (isAdded)
            {
                //Go to Index action method of Persons Controller
                return RedirectToAction("AccountEdited");
            }
            else
            {
                //Return plain html / plain string
                return Content("Person not added");
            }
        }
        public async Task<ActionResult> DeleteAccount(Guid id)
        {
            Account account = new Account();
            AccountBL accountBL = new AccountBL();
            account = await accountBL.GetAccountByAccountIDBL(id);
            AccountViewModelDisplay avmd = new AccountViewModelDisplay();
            avmd.AccountID = account.AccountID;
            avmd.CustomerID = account.CustomerID;
            TempData["AVM"] = avmd;
            return View(avmd);
        }

        public ActionResult AccountEdited()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> DeleteAccountDeleted(FormCollection collection)
        {
            var obj = (AccountViewModelDisplay)TempData["AVM"];
            AccountBL accountBL = new AccountBL();
            Guid.TryParse(collection["AccountID"], out Guid tp);
            bool isDeleted = await accountBL.DeleteAccount(tp,collection["Feedback"]);
            if(isDeleted)
            {
                return RedirectToAction("AccountDeleted");
            }
            else
            {
                return Content("Person not added");

            }

        }

        public ActionResult AccountDeleted()
        {
            return View();
        }

    }
}