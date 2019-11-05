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
    public class CarLoanApproveController : Controller
    {
        // GET: ApproveLoan
        public async Task<ActionResult> ListAllCarLoans()
        {
            List<CarLoan> carLoans = new List<CarLoan>();
            
            List<CarLoanViewModel> carLoanViewModels = new List<CarLoanViewModel>();
            
            CarLoanBL carLoanBL = new CarLoanBL();
            
            carLoans = await carLoanBL.ListAllLoansBL();
            
            foreach(CarLoan car in carLoans)
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

            
            return View("ApproveCarLoan", carLoanViewModels);
        }


        
        // to update status of loans
        [HttpPost]
        public async Task<ActionResult> UpdateStatus(List<CarLoanViewModel> carLoanModels)
        {

            CarLoanBL carLoanBL = new CarLoanBL();
            List<CarLoan> carLoans = new List<CarLoan>();
            carLoans = await carLoanBL.ListAllLoansBL();
            
            for(int i=0; i<carLoans.Count; i++)
            {
                // status from database if different from the status received from view then update
                if (carLoanModels.ElementAt(i).Status.Equals("NotUpdated") == false)
                {
                    if (carLoans.ElementAt(i).LoanStatus.Equals(carLoanModels.ElementAt(i).Status) == false)
                        await carLoanBL.ApproveLoanBL(carLoans.ElementAt(i).LoanID.ToString(), carLoanModels.ElementAt(i).Status);
                }
            }
            
            return RedirectToAction("DisplayMessageForAdmin", "ShowMessage", new { Message = "Status updated successfully!" });
            
        }

        public async Task<ActionResult> ListAllCarLoansToCancel()
        {
            List<CarLoan> carLoans = new List<CarLoan>();

            List<CarLoanViewModel> carLoanViewModels = new List<CarLoanViewModel>();

            CarLoanBL carLoanBL = new CarLoanBL();

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


            return View("CancelCarLoan", carLoanViewModels);
        }

        public async Task<ActionResult> CancelCarLoan(string loanID)
        {

            CarLoanBL carLoanBL = new CarLoanBL();
            List<CarLoan> carLoans = new List<CarLoan>();
            bool isDeleted = await carLoanBL.DeleteLoanEntryBL(loanID);
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

        //[HttpPost]
        public ActionResult CancelBatchCarLoan(List<CarLoanViewModel> carLoanViewModels)
        {
            //List<CarLoanViewModel> carLoanViewModels = new List<CarLoanViewModel>();
            System.Diagnostics.Debug.WriteLine("dsf"+carLoanViewModels.Count);
            foreach (var car in carLoanViewModels)
            {
                System.Diagnostics.Debug.WriteLine(car.Occupation);
            }

            return RedirectToAction("DisplayMessage", "ShowMessage", new { Message = "Internal error occured! Request cant be processed now, try again later!" });
        }
    }
}