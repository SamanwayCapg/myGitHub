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

            return View(homeLoanViewModel);
        }
    }
}