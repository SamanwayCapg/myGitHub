using Capgemini.Pecunia.BusinessLayer.LoanBL;
using Capgemini.Pecunia.Entities;
using Pecunia.PresentationMVC.Models;
using Pecunia.PresentationMVC.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Pecunia.PresentationMVC.Controllers
{
    public class CarLoanViewController : Controller
    {
        // URL: CarLoanView/Viewdetails
       
        public async Task<ActionResult> ViewDetails(Guid loanID)
        {

            CarLoanBL carLoanBL = new CarLoanBL();
            List<CarLoan> carLoans = new List<CarLoan>();
            carLoans = await carLoanBL.GetLoanByLoanIDBL(Convert.ToString(loanID));

            CarLoanViewModel carLoanViewModel = new CarLoanViewModel()
            {
                LoanID = carLoans.ElementAt(0).LoanID,
                AmountApplied = carLoans.ElementAt(0).AmountApplied,
                InterestRate = carLoans.ElementAt(0).InterestRate,
                EMI_Amount = carLoans.ElementAt(0).EMI_amount,
                RepaymentPeriod = carLoans.ElementAt(0).RepaymentPeriod,
                DateOfApplication = carLoans.ElementAt(0).DateOfApplication,
                Status = carLoans.ElementAt(0).LoanStatus,
                Occupation = carLoans.ElementAt(0).Occupation,
                GrossIncome = carLoans.ElementAt(0).GrossIncome,
                SalaryDeductions = carLoans.ElementAt(0).SalaryDeduction,
                Vehicle = carLoans.ElementAt(0).VehicleType
            };

            //to pass value from one action to another action
            TempData["loanID"] = Convert.ToString(carLoans.ElementAt(0).LoanID);

            return View("ConfirmApplication", carLoanViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> ViewDetails(string button, CarLoanViewModel carLoanModel)
        {
            bool isDeleted = false;
            switch (button)
            {
                case "apply":
                    return RedirectToAction("DisplayMessage", "ShowMessage", new {Message="Loan Applied Successfully"});

                case "cancel":
                    CarLoanBL carLoan = new CarLoanBL();
                    isDeleted = await carLoan.DeleteLoanEntryBL(Convert.ToString(TempData["loanID"]));
                    System.Diagnostics.Debug.WriteLine(isDeleted);
                    if (isDeleted == true)
                        return RedirectToAction("DisplayMessage", "ShowMessage", new { Message = "Loan ID:" + TempData["loanID"] + "\nHey! Loan Application Cancelled" });
                    else
                        return RedirectToAction("DisplayMessage", "ShowMessage", new { Message = "Loan ID:" + TempData["loanID"] + "\nSorry! Request can't be processed now, come back later " });

                default:
                    return RedirectToAction("DisplayMessage", "ShowMessage", new { Message = "Loan Applied Successfully" });
            }
        }


        public async Task<ActionResult> ViewCarLoanDetails()
        {
            List<CarLoanViewModel> carLoanViewModels = new List<CarLoanViewModel>();

            using (TransactionServiceClient carLoanServiceClient = new TransactionServiceClient())
            {
                CarLoanBL carLoanBL = new CarLoanBL();

                List<CarLoan> carLoans = new List<CarLoan>();
                carLoans = await carLoanBL.ListAllLoansBL();

                foreach (CarLoan car in carLoans)
                {
                    CarLoanViewModel carLoanViewModel = new CarLoanViewModel()
                    {
                        LoanID = car.LoanID,
                        AmountApplied = car.AmountApplied,
                        InterestRate = car.InterestRate,
                        EMI_Amount = car.EMI_amount,
                        RepaymentPeriod = car.RepaymentPeriod,
                        DateOfApplication = car.DateOfApplication,
                        Status = car.LoanStatus,
                        Occupation = car.Occupation,
                        GrossIncome = car.GrossIncome,
                        SalaryDeductions = car.SalaryDeduction,
                        Vehicle = car.VehicleType
                    };
                    carLoanViewModels.Add(carLoanViewModel);
                }
            }

            return View("ShowCarLoanDetails", carLoanViewModels);
        }

    }
}