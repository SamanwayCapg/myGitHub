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

            return View(eduLoanViewModel);
        }
    }
}