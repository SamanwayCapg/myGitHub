
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
    public class CarLoanApplyController : Controller
    {
        // URL: CarLoanApply/apply
        public ActionResult Apply()
        {
            CarLoanApplyModel carLoanApplyModel = new CarLoanApplyModel();
            //getting list of customers
            CustomerBL customerBL = new CustomerBL();
            List<DropDownListData> customers = new List<DropDownListData>();
            customers = GetDropDownListData();
            System.Diagnostics.Debug.WriteLine("loanID:" + carLoanApplyModel.LoanID);

            ViewBag.customers = new SelectList(customers, "ID", "NameMobile");
            return View(carLoanApplyModel);
        }


        [HttpPost]
        public async Task<ActionResult> Apply(CarLoanApplyModel carLoanModel)
        {
            CarLoanBL carLoanBL = new CarLoanBL();
            CarLoan carLoan = new CarLoan();

            carLoan.LoanID = Guid.NewGuid();
            carLoan.CustomerID = carLoanModel.CustomerID;
            carLoan.AmountApplied = carLoanModel.AmountApplied;
            carLoan.RepaymentPeriod = carLoanModel.RepaymentPeriod;
            carLoan.Occupation = carLoanModel.Occupation;
            carLoan.GrossIncome = carLoanModel.GrossIncome;
            carLoan.SalaryDeduction = carLoanModel.SalaryDeductions;
            carLoan.VehicleType = carLoanModel.Vehicle;
            
            bool isApplied = await carLoanBL.ApplyLoanBL(carLoan);
            if (isApplied == true)
                return RedirectToAction("ViewDetails", "CarLoanView", new { loanID = carLoan.LoanID });
            else
                return RedirectToAction("Apply", "HomeLoanApply");

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