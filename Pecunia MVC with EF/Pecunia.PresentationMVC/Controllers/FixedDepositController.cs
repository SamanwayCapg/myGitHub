using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PecuniaMVC.Models;

using Capgemini.Pecunia.Entities;
using Capgemini.Pecunia.BusinessLayer;
using System.Threading.Tasks;


namespace PecuniaMVC.Controllers
{
    public class FixedDepositController : Controller
    {
        // GET: FixedDeposit
        public ActionResult Create()
        {
            FixedDepositViewModel fixedDepositViewModel = new FixedDepositViewModel();

            CustomerBL customerBL = new CustomerBL();

            List<Customer> customers = customerBL.GetAllCustomerDetailsBL();

            ViewBag.CustomersList = new SelectList(customers, "CustomerID", "CustomerName");

            return View(fixedDepositViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Create(FixedDepositViewModel fdVM)
        {
            //Create object of PersonsBL
            FixedDepositBL fdBL = new FixedDepositBL();

            //Creating object of Person EntityModel
            FixedDeposit fd = new FixedDeposit();
            System.Diagnostics.Debug.WriteLine(fdVM.CustomerID);
            Guid cust = (Guid)fdVM.CustomerID;
            fd.CustomerID = fdVM.CustomerID;
            fd.HomeBranch = fdVM.HomeBranch;
            fd.Tenure = fdVM.Tenure;
            fd.FdDeposit = fdVM.FdDeposit;

            //Invoke the AddPerson method BL
            try
            {
                bool isAdded = await fdBL.AddFixedDepositBL(fd, cust);
                if (isAdded)
                {
                    //Go to Index action method of Persons Controller
                    return RedirectToAction("FixedDepositAdded");
                }
                else
                {
                    //Return plain html / plain string
                    return Content("FixedDeposit not added");
                }
            }
            catch(Exception ex)
            {
                return Content(ex.Message);
            }
           

        }

        public ActionResult FixedDepositAdded()
        {
            return View();
        }

        public ActionResult ShowAllFixedDeposit()
        {
            FixedDepositBL fixedDepositBL = new FixedDepositBL();
            List<FixedDeposit> fixedDepositList = new List<FixedDeposit>();
            fixedDepositList = fixedDepositBL.GetAllFixedDepositBL();

            List<FixedDepositViewModelDisplay> fixedDepositListVM = new List<FixedDepositViewModelDisplay>();
            foreach (var temp in fixedDepositList)
            {
                FixedDepositViewModelDisplay fixedDepositVM = new FixedDepositViewModelDisplay()
                {
                    CustomerID = temp.CustomerID,
                    FdDeposit = temp.FdDeposit,
                    AccountNumber = temp.AccountNumber,
                    HomeBranch = temp.HomeBranch,
                    Tenure=temp.Tenure
                };
                fixedDepositListVM.Add(fixedDepositVM);
            }
            return View(fixedDepositListVM);
        }

        public async Task<ActionResult> EditFixedDeposit(Guid id)
        {
            FixedDepositBL fixedDepositBL = new FixedDepositBL();

            System.Diagnostics.Debug.WriteLine(id);
            FixedDeposit fixedDeposit = await fixedDepositBL.GetFixedDepositByAccountIDBL(id);
      
            FixedDepositViewModelDisplay fixedDepositViewModelDisplay = new FixedDepositViewModelDisplay();
            fixedDepositViewModelDisplay.CustomerID = fixedDeposit.CustomerID;
            fixedDepositViewModelDisplay.FdDeposit = fixedDeposit.FdDeposit;
            fixedDepositViewModelDisplay.HomeBranch = fixedDeposit.HomeBranch;
            fixedDepositViewModelDisplay.AccountID = fixedDeposit.AccountID;
            fixedDepositViewModelDisplay.Tenure = fixedDeposit.Tenure;
            System.Diagnostics.Debug.WriteLine(id);

            TempData["Avm"] = fixedDepositViewModelDisplay;
            return View(fixedDepositViewModelDisplay); 
        }

        [HttpPost]
        public async Task<ActionResult> EditFixedDepositEdited(FormCollection collection)
        {
            //Create object of PersonsBL
            FixedDepositBL fixedDepositBL = new FixedDepositBL();

            //Creating object of Person EntityModel
            FixedDeposit fixedDeposit = new FixedDeposit();

            Guid.TryParse(collection["AccountID"], out Guid tp);
            System.Diagnostics.Debug.WriteLine(tp);

            //Invoke the AddPerson method BL


            try
            {
                bool isAdded = fixedDepositBL.UpdateFDAmountBL(tp, Convert.ToDouble(collection["FdDeposit"]));

                bool second = await fixedDepositBL.ChangeBranchBL(tp, collection["HomeBranch"]);
                if (isAdded)
                {
                    //Go to Index action method of Persons Controller
                    return RedirectToAction("FixedDepositEdited");
                }
                else
                {
                    //Return plain html / plain string
                    return Content("FIxedDeposit not added");
                }
            }
            catch(Exception ex)
            {
                return Content(ex.Message);
            }
           

        }

        public ActionResult EditingFixedDepositMenu()
        {
            FixedDepositBL fixedDepositBL = new FixedDepositBL();
            List<FixedDeposit> fixedDepositList = new List<FixedDeposit>();
            fixedDepositList = fixedDepositBL.GetAllFixedDepositBL();

            List<FixedDepositViewModelDisplay> fixedDepositListVM = new List<FixedDepositViewModelDisplay>();
            foreach (var temp in fixedDepositList)
            {
                FixedDepositViewModelDisplay fixedDepositVM = new FixedDepositViewModelDisplay()
                {
                    CustomerID = temp.CustomerID,
                    FdDeposit = temp.FdDeposit,
                    AccountNumber = temp.AccountNumber,
                    HomeBranch = temp.HomeBranch,
                    Tenure = temp.Tenure,
                    AccountID=temp.AccountID
                    
                };
                fixedDepositListVM.Add(fixedDepositVM);
            }
            return View(fixedDepositListVM);
        }

        public ActionResult FixedDepositEdited()
        {
            return View();
        }


        public async Task<ActionResult> DeleteFixedDeposit(Guid id)
        {
            FixedDeposit fixedDeposit = new FixedDeposit();
            FixedDepositBL fixedDepositBL = new FixedDepositBL();
            fixedDeposit = await fixedDepositBL.GetFixedDepositByAccountIDBL(id);
            FixedDepositViewModelDisplay fdvmd = new FixedDepositViewModelDisplay();
            fdvmd.AccountID = fixedDeposit.AccountID;
            fdvmd.CustomerID = fixedDeposit.CustomerID;
            return View(fdvmd);

        }


        [HttpPost]
        public async Task<ActionResult> DeleteFixedDepositDeleted(FormCollection collection)
        {
            FixedDepositBL fixedDepositBL = new FixedDepositBL();
            Guid.TryParse(collection["AccountID"], out Guid tp);
            bool isDeleted = await fixedDepositBL.DeleteFixedDeposit(tp, collection["Feedback"]);
            if (isDeleted)
            {
                return RedirectToAction("FixedDepositDeleted");
            }
            else
            {
                return Content("FixedDeposit not added");

            }
        }

        public ActionResult FixedDepositDeleted()
        {
            return View();
        }

    }

   


}