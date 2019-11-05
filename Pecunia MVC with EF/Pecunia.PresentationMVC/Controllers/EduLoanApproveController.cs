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
    public class EduLoanApproveController : Controller
    {
        // GET: EduLoanApprove
        public async Task<ActionResult> ListAllEduLoans()
        {
            List<EduLoan> eduLoans = new List<EduLoan>();
            List<EduLoanViewModel> eduLoanViewModels = new List<EduLoanViewModel>();
            EduLoanBL eduLoanBL = new EduLoanBL();
            eduLoans = await eduLoanBL.ListAllLoans();

            foreach (EduLoan edu in eduLoans)
            {
                EduLoanViewModel eduLoanViewModel = new EduLoanViewModel()
                {
                    LoanID = edu.LoanID,
                    AmountApplied = edu.AmountApplied,
                    InterestRate = edu.InterestRate,
                    EMI_Amount = edu.EMI_amount,
                    RepaymentPeriod = edu.RepaymentPeriod,
                    DateOfApplication = edu.DateOfApplication,
                    LoanStatus = edu.LoanStatus,
                    Course = edu.Course,
                    InstituteName = edu.InstituteName,
                    StudentID = edu.StudentID,
                    RepaymentHoliday = edu.RepaymentHoliday
                };
                eduLoanViewModels.Add(eduLoanViewModel);
            }

            return View("ApproveEduLoan", eduLoanViewModels);
        }


        // to update status of loans
        [HttpPost]
        public async Task<ActionResult> UpdateStatus(List<EduLoanViewModel> eduLoanModels)
        {

            EduLoanBL eduLoanBL = new EduLoanBL();
            List<EduLoan> eduLoans = new List<EduLoan>();
            eduLoans = await eduLoanBL.ListAllLoans();

            for (int i = 0; i < eduLoans.Count; i++)
            {
                // status from database if different from the status received from view then update
                if (eduLoanModels.ElementAt(i).LoanStatus.Equals("NotUpdated") == false)
                {
                    if (eduLoans.ElementAt(i).LoanStatus.Equals(eduLoanModels.ElementAt(i).LoanStatus) == false)
                        await eduLoanBL.ApproveLoanBL(eduLoans.ElementAt(i).LoanID.ToString(), eduLoanModels.ElementAt(i).LoanStatus);
                }
            }

            return RedirectToAction("DisplayMessageForAdmin", "ShowMessage", new { Message = "Status updated successfully!" });

        }


        ///////////////////////////////////////////////
        public async Task<ActionResult> ListAllEduLoansToCancel()
        {
            List<EduLoan> eduLoans = new List<EduLoan>();
            List<EduLoanViewModel> eduLoanViewModels = new List<EduLoanViewModel>();
            EduLoanBL eduLoanBL = new EduLoanBL();
            eduLoans = await eduLoanBL.ListAllLoans();

            foreach (EduLoan edu in eduLoans)
            {
                EduLoanViewModel eduLoanViewModel = new EduLoanViewModel()
                {
                    LoanID = edu.LoanID,
                    AmountApplied = edu.AmountApplied,
                    InterestRate = edu.InterestRate,
                    EMI_Amount = edu.EMI_amount,
                    RepaymentPeriod = edu.RepaymentPeriod,
                    DateOfApplication = edu.DateOfApplication,
                    LoanStatus = edu.LoanStatus,
                    Course = edu.Course,
                    InstituteName = edu.InstituteName,
                    StudentID = edu.StudentID,
                    RepaymentHoliday = edu.RepaymentHoliday
                };
                eduLoanViewModels.Add(eduLoanViewModel);
            }

            return View("CancelEduLoan",eduLoanViewModels);
        }


        public async Task<ActionResult> CancelEduLoan(string loanID)
        {

            EduLoanBL eduLoanBL = new EduLoanBL();
            List<EduLoan> eduLoans = new List<EduLoan>();
            bool isDeleted = await eduLoanBL.DeleteLoanEntryBL(loanID);
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