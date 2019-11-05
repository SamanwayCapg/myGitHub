using Capgemini.Pecunia.BusinessLayer;
using Capgemini.Pecunia.BusinessLayer.LoanBL;
using Capgemini.Pecunia.Entities;
using Pecunia.PresentationMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Pecunia.PresentationMVC.Controllers
{
    public class HomeLoanApplyController : Controller
    {
        // GET: HomeLoanApply/apply
        public ActionResult Apply()
        {
            HomeLoanApplyModel homeLoanApplyModel = new HomeLoanApplyModel();
            //getting list of customers
            CustomerBL customerBL = new CustomerBL();
            List<DropDownListData> customers = new List<DropDownListData>();
            customers = GetDropDownListData();
            System.Diagnostics.Debug.WriteLine("loanID:" + homeLoanApplyModel.LoanID);

            ViewBag.customers = new SelectList(customers, "ID", "NameMobile");
            return View(homeLoanApplyModel);
        }

        [HttpPost]
        public async Task<ActionResult> Apply(HomeLoanApplyModel homeLoanModel)
        {
            HomeLoanBL homeLoanBL = new HomeLoanBL();
            HomeLoan homeLoan = new HomeLoan();

            homeLoan.LoanID = Guid.NewGuid();
            homeLoan.CustomerID = homeLoanModel.CustomerID;
            homeLoan.AmountApplied = homeLoanModel.AmountApplied;
            homeLoan.RepaymentPeriod = homeLoanModel.RepaymentPeriod;
            homeLoan.Occupation = homeLoanModel.Occupation;
            homeLoan.GrossIncome = homeLoanModel.GrossIncome;
            homeLoan.SalaryDeduction = homeLoanModel.SalaryDeductions;
            homeLoan.ServiceYears = homeLoanModel.ServiceYears;

            bool isApplied = await homeLoanBL.ApplyLoanBL(homeLoan);
            if (isApplied == true)
                return RedirectToAction("ViewDetails", "HomeLoanView", new { loanID = homeLoan.LoanID });
            else
                return RedirectToAction("DisplayMessage", "ShowMessage", new { Message = "Salary deductions must be less than Gross Income" });

        }

        List<DropDownListData> GetDropDownListData()
        {
            List<DropDownListData> list = new List<DropDownListData>();
            using (PecuniaEntities pecEnt = new PecuniaEntities())
            {
                list = (from cust
                        in pecEnt.Customers
                        select new DropDownListData
                        {
                            ID = cust.CustomerID,
                            NameMobile = "Name:" + cust.CustomerName + "|Mobile:" + cust.CustomerMobile
                        }).ToList();
            }
            return list;
        }
    }
}