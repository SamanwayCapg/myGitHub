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
    public class EduLoanViewController : Controller
    {
        // URL: EduLoanView/Viewdetails
        public async Task<ActionResult> ViewDetails(Guid loanID)
        {
            
            EduLoanBL eduLoanBL = new EduLoanBL();
            List<EduLoan> eduLoans = new List<EduLoan>();
            eduLoans = await eduLoanBL.GetLoanByLoanIDBL(Convert.ToString(loanID));

            EduLoanViewModel eduLoanViewModel = new EduLoanViewModel()
            {
                LoanID = eduLoans.ElementAt(0).LoanID,
                AmountApplied = eduLoans.ElementAt(0).AmountApplied,
                InterestRate = eduLoans.ElementAt(0).InterestRate,
                EMI_Amount = eduLoans.ElementAt(0).EMI_amount,
                RepaymentPeriod = eduLoans.ElementAt(0).RepaymentPeriod,
                DateOfApplication = eduLoans.ElementAt(0).DateOfApplication,
                LoanStatus = eduLoans.ElementAt(0).LoanStatus,
                Course = eduLoans.ElementAt(0).Course,
                InstituteName = eduLoans.ElementAt(0).InstituteName,
                StudentID = eduLoans.ElementAt(0).StudentID,
                RepaymentHoliday = eduLoans.ElementAt(0).RepaymentHoliday
            };

            TempData["loanID"] = eduLoans.ElementAt(0).LoanID;
            return View("ConfirmApplication", eduLoanViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> ViewDetails(string button, EduLoanViewModel carLoanModel)
        {
            bool isDeleted = false;
            switch (button)
            {
                case "apply":
                    return RedirectToAction("DisplayMessage", "ShowMessage", new { Message = "Loan Applied Successfully" });

                case "cancel":
                    EduLoanBL eduLoan = new EduLoanBL();
                    isDeleted = await eduLoan.DeleteLoanEntryBL(Convert.ToString(TempData["loanID"]));
                    System.Diagnostics.Debug.WriteLine(isDeleted);
                    if (isDeleted == true)
                        return RedirectToAction("DisplayMessage", "ShowMessage", new { Message = "Loan ID:" + TempData["loanID"] + "\nHey! Loan Application Cancelled" });
                    else
                        return RedirectToAction("DisplayMessage", "ShowMessage", new { Message = "Loan ID:" + TempData["loanID"] + "\nSorry! Request can't be processed now, come back later " });

                default:
                    return RedirectToAction("DisplayMessage", "ShowMessage", new { Message = "Loan Applied Successfully" });
            }
        }


        public async Task<ActionResult> ViewEduLoanDetails()
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

            return View("ShowEduLoanDetails", eduLoanViewModels);
        }
    }
}