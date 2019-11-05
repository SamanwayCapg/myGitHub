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
    public class HomeLoanViewController : Controller
    {
        // URL: HomeLoanView/Viewdetails
        public async Task<ActionResult> ViewDetails(Guid loanID)
        {

            HomeLoanBL homeLoanBL = new HomeLoanBL();
            List<HomeLoan> homeLoans = new List<HomeLoan>();
            homeLoans = await homeLoanBL.GetLoanByLoanIDBL(Convert.ToString(loanID));

            HomeLoanViewModel homeLoanViewModel = new HomeLoanViewModel()
            {
                LoanID = homeLoans.ElementAt(0).LoanID,
                AmountApplied = homeLoans.ElementAt(0).AmountApplied,
                InterestRate = homeLoans.ElementAt(0).InterestRate,
                EMI_Amount = homeLoans.ElementAt(0).EMI_amount,
                RepaymentPeriod = homeLoans.ElementAt(0).RepaymentPeriod,
                DateOfApplication = homeLoans.ElementAt(0).DateOfApplication,
                Status = homeLoans.ElementAt(0).LoanStatus,
                Occupation = homeLoans.ElementAt(0).Occupation,
                GrossIncome = homeLoans.ElementAt(0).GrossIncome,
                SalaryDeductions = homeLoans.ElementAt(0).SalaryDeduction,
                ServiceYears = homeLoans.ElementAt(0).ServiceYears
            };

            //to pass value from one action to another action
            TempData["loanID"] = Convert.ToString(homeLoans.ElementAt(0).LoanID);

            return View("ConfirmApplication", homeLoanViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> ViewDetails(string button, CarLoanViewModel carLoanModel)
        {
            bool isDeleted = false;
            switch (button)
            {
                case "apply":
                    return RedirectToAction("DisplayMessage", "ShowMessage", new { Message = "Loan Applied Successfully" });

                case "cancel":
                    HomeLoanBL homeLoan = new HomeLoanBL();
                    isDeleted = await homeLoan.DeleteLoanEntryBL(Convert.ToString(TempData["loanID"]));
                    System.Diagnostics.Debug.WriteLine(isDeleted);
                    if (isDeleted == true)
                        return RedirectToAction("DisplayMessage", "ShowMessage", new {Message = "Loan ID:" +  TempData["loanID"] + "\nHey! Loan Application Cancelled" });
                    else
                        return RedirectToAction("DisplayMessage", "ShowMessage", new { Message = "Loan ID:" + TempData["loanID"] + "\nSorry! Request can't be processed now, come back later " });

                default:
                    return RedirectToAction("DisplayMessage", "ShowMessage", new { Message = "Loan Applied Successfully" });
            }
        }


        public async Task<ActionResult> ViewHomeLoanDetails()
        {
            List<HomeLoan> homeLoans = new List<HomeLoan>();

            List<HomeLoanViewModel> homeLoanViewModels = new List<HomeLoanViewModel>();

            HomeLoanBL homeLoanBL = new HomeLoanBL();

            homeLoans = await homeLoanBL.ListAllLoansBL();

            foreach (HomeLoan loan in homeLoans)
            {
                HomeLoanViewModel homeLoanViewModel = new HomeLoanViewModel()
                {
                    LoanID = loan.LoanID,
                    AmountApplied = loan.AmountApplied,
                    InterestRate = loan.InterestRate,
                    EMI_Amount = loan.EMI_amount,
                    RepaymentPeriod = loan.RepaymentPeriod,
                    DateOfApplication = loan.DateOfApplication,
                    Status = loan.LoanStatus,
                    Occupation = loan.Occupation,
                    GrossIncome = loan.GrossIncome,
                    SalaryDeductions = loan.SalaryDeduction,
                    ServiceYears = loan.ServiceYears
                };
                homeLoanViewModels.Add(homeLoanViewModel);
            }
            return View("ShowHomeLoanDetails", homeLoanViewModels);
        }
    }
}