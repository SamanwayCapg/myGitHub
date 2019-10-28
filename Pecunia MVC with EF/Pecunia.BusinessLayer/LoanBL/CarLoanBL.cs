using Capgemini.Pecunia.DataAccessLayer.LoanDAL;
using Capgemini.Pecunia.Entities;
using Capgemini.Pecunia.Exceptions;
using Capgemini.Pecunia.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pecunia.Contracts.BLContracts.ILoanBL;

namespace Capgemini.Pecunia.BusinessLayer.LoanBL
{
    public class CarLoanBL : BLbase<CarLoan> , ICarLoanBL
    {
        public async Task<bool> ApplyLoanBL(CarLoan car)
        {
            bool isApplied = false;
            //CarLoan car = (CarLoan)(Object)obj;
            try
            {
                if (await Validate(car))
                {
                    await Task.Run(() =>
                    {
                        //Guid guid = Guid.NewGuid();
                        car.LoanID = Guid.NewGuid(); //"CAR" + guid.ToString();
                        car.InterestRate = (decimal)10.65;
                        car.EMI_amount = BusinessLogicUtil.ComputeEMI(car.AmountApplied, car.RepaymentPeriod, car.InterestRate);
                        car.DateOfApplication = DateTime.Now;
                        car.LoanStatus = "APPLIED";

                        CarLoanDAL carDAL = new CarLoanDAL();
                        isApplied = carDAL.ApplyLoanDAL(car);
                    });
                }
            }
            catch(Exception e)
            {
                BusinessLogicUtil.logException(e.Message, e.StackTrace, "carLoanBL.ApplyCarLoan");
                return false;
            }
            return isApplied;
        }

        public async Task<List<CarLoan>> ApproveLoanBL(string loanID, string updatedStatus)
        {
            
            try
            {
                CarLoanDAL carDAL = new CarLoanDAL();
                List<CarLoan> carLoans = new List<CarLoan>();
                await Task.Run(() =>
                {
                    carLoans = carDAL.ApproveLoanDAL(loanID, updatedStatus);
                });

                return carLoans;
            }
            catch(Exception e)
            {
                BusinessLogicUtil.logException(e.Message, e.StackTrace, "carLoanBL.AppLoanBL");
                return default(List<CarLoan>);
            }
        }

        

        public async Task<List<CarLoan>> GetLoanByCustomerIDBL(string customerID)
        {
            try
            {
                CarLoanDAL carDAL = new CarLoanDAL();
                List<CarLoan> carLoans = new List<CarLoan>();

                await Task.Run(() =>
                {
                    carLoans = carDAL.GetLoanByCustomerIDDAL(customerID); 
                });

                return carLoans;
            }
            catch(Exception e)
            {
                BusinessLogicUtil.logException(e.Message, e.StackTrace, "carLoanBL.GetLoanByCustomerIDBL");
                return default(List<CarLoan>);
            }
        }

        public async Task<List<CarLoan>> GetLoanByLoanIDBL(string loanID)
        {
            try
            {
                CarLoanDAL carDAL = new CarLoanDAL();
                List<CarLoan> carLoans = new List<CarLoan>();
                await Task.Run(() =>
                {
                    carLoans = carDAL.GetLoanByLoanIDDAL(loanID);
                });

                return carLoans;
            }
            catch(Exception e)
            {
                BusinessLogicUtil.logException(e.Message, e.StackTrace, "carLoanBL.GetLoanByLoanIDBL");
                return default(List<CarLoan>);
            }
        }

        public async Task<string> GetLoanStatusBL(string loanID)
        {
            string status = "";
            try
            {
                CarLoanDAL carDAL = new CarLoanDAL();
                
                await Task.Run(() =>
                {
                    status = carDAL.GetLoanStatusDAL(loanID);
                });

                return status;
            }
            catch(Exception e)
            {
                BusinessLogicUtil.logException(e.Message, e.StackTrace, "carLoanBL.GetLoanStatusBL");
                return default(string);
            }

        }

        public async override Task<bool> Validate(CarLoan carLoan)
        {
            bool valid = await base.Validate(carLoan);
            if (valid == false)
                return valid;

            if (carLoan.AmountApplied > 2000000 || carLoan.AmountApplied<=0)
                throw new InvalidAmountException("Maximum loan amount is Rs.20 lakh and Amount cant be negative or zero");

            if (carLoan.RepaymentPeriod > 120 || carLoan.RepaymentPeriod<=0)
                throw new InvalidRangeException("Repayment period can be maximum of 120 months and cant be negative or zero");

            if (carLoan.SalaryDeduction >= carLoan.GrossIncome)
                throw new InvalidAmountException("Salary deduction can't be greater than or equal to Gross salary");

            return valid;
        }


        public async Task<List<CarLoan>> ListAllLoansBL()
        {
            CarLoanDAL loanDAL = new CarLoanDAL();
            List<CarLoan> carLoans = new List<CarLoan>();
            try
            {
                await Task.Run(() =>
                {
                    carLoans = loanDAL.ListAllLoansDAL();
                });
            }
            catch(Exception e)
            {
                BusinessLogicUtil.logException(e.Message, e.StackTrace, "carLoanBL.ListAllLoansBL");
                return default(List<CarLoan>);
            }
            return carLoans;
        }

        public async Task<bool> DeleteLoanEntryBL(string loanID)
        {
            CarLoanDAL carLoanDAL = new CarLoanDAL();
            bool isDeleted = false;
            try
            {
                await Task.Run(() =>
                {
                    isDeleted = carLoanDAL.DeleteLoanEntryDAL(loanID);
                });
                return isDeleted;
            }
            catch (Exception e)
            {
                BusinessLogicUtil.logException(e.Message, e.StackTrace, "carLoanBL.deleteLoanEntry");
                return isDeleted;
            }
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
