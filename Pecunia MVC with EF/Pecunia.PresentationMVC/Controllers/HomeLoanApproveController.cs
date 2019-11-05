using Capgemini.Pecunia.BusinessLayer.LoanBL;
using Capgemini.Pecunia.Entities;
using Pecunia.PresentationMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace Pecunia.PresentationMVC.Controllers
{
    public class HomeLoanApproveController : Controller
    {
        // GET: HomeLoanApprove
        public async Task<ActionResult> ListAllHomeLoans()
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
            return View("ApproveHomeLoan", homeLoanViewModels);
        }

        // to update status of loans
        [HttpPost]
        public async Task<ActionResult> UpdateStatus(List<HomeLoanViewModel> homeLoanModels)
        {

            HomeLoanBL homeLoanBL = new HomeLoanBL();
            List<HomeLoan> homeLoans = new List<HomeLoan>();
            homeLoans = await homeLoanBL.ListAllLoansBL();

            for (int i = 0; i < homeLoans.Count; i++)
            {
                // status from database if different from the status received from view then update
                if (homeLoanModels.ElementAt(i).Status.Equals("NotUpdated") == false)
                {
                    if (homeLoans.ElementAt(i).LoanStatus.Equals(homeLoanModels.ElementAt(i).Status) == false)
                        await homeLoanBL.ApproveLoanBL(homeLoans.ElementAt(i).LoanID.ToString(), homeLoanModels.ElementAt(i).Status);
                }
            }

            return RedirectToAction("DisplayMessageForAdmin", "ShowMessage", new { Message = "Status updated successfully!" });

        }
        //////////

        public async Task<ActionResult> ListAllHomeLoansToCancel()
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
            return View("CancelHomeLoan", homeLoanViewModels);
        }


        public async Task<ActionResult> CancelHomeLoan(string loanID)
        {

            HomeLoanBL homeLoanBL = new HomeLoanBL();
            List<HomeLoan> homeLoans = new List<HomeLoan>();
            bool isDeleted = await homeLoanBL.DeleteLoanEntryBL(loanID);
            //System.Diagnostics.Debug.WriteLine($"loanID:{loanID}, status:{updatedStatus}");

            if (isDeleted == true)
            {
                return RedirectToAction("DisplayMessage", "ShowMessage", new { Message = "Loan Cancelled Successfully!" });
            }
            else
            {
                return RedirectToAction("DisplayMessage", "ShowMessage", new { Message = "Internal error occured! Request cant be processed now, try again later!" });
            }
        }
    }
}