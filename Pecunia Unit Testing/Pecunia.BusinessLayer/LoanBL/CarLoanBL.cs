using Capgemini.Pecunia.DataAccessLayer.LoanDAL;
using Capgemini.Pecunia.Entities;
using Capgemini.Pecunia.Exceptions;
using Capgemini.Pecunia.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.Pecunia.BusinessLayer.LoanBL
{
    public class CarLoanBL : BLbase<CarLoan> //, ILoanBL
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
                        car.InterestRate = 10.65;
                        car.EMI_Amount = BusinessLogicUtil.ComputeEMI(car.AmountApplied, car.RepaymentPeriod, car.InterestRate);
                        car.DateOfApplication = DateTime.Now;
                        car.Status = (LoanStatus)0;

                        CarLoanDAL carDAL = new CarLoanDAL();
                        isApplied = carDAL.ApplyLoanDAL(car);
                    });
                }
            }
            catch
            {
                return false;
            }
            return isApplied;
        }

        public async Task<CarLoan> ApproveLoanBL(string loanID, LoanStatus updatedStatus)
        {
            //if (BusinessLogicUtil.validate(loanID) == false)
            //    throw new InvalidStringException("Invalid loan ID");

            try
            {
                CarLoanDAL carDAL = new CarLoanDAL();

                await Task.Run(() =>
                {
                    if (carDAL.IsLoanIDExistDAL(loanID) == false)
                        throw new InvalidStringException("Loan ID not found");
                });

                return carDAL.ApproveLoanDAL(loanID, updatedStatus);
            }
            catch
            {
                return null;
            }
        }

        public async Task<CarLoan> GetLoanByCustomerID_BL(string customerID)
        {
            //if (BusinessLogicUtil.validate(customerID) == false)
            //    throw new InvalidStringException("Invalid customer ID");
            try
            {
                CarLoanDAL carDAL = new CarLoanDAL();
                CustomerBL custBL = new CustomerBL();
                bool isExist = await custBL.isCustomerIDExistBL(Guid.Parse(customerID));

                await Task.Run(() =>
                {
                    if ( isExist == false)
                        throw new InvalidStringException("Customer ID not found");
                });

                return carDAL.GetLoanByCustomerIDDAL(customerID);
            }
            catch
            {
                return null;
            }
        }

        public async Task<CarLoan> GetLoanByLoanID_BL(string loanID)
        {
            //if (BusinessLogicUtil.validate(loanID) == false)
            //    throw new InvalidStringException("Invalid loan ID");
            try
            {
                CarLoanDAL carDAL = new CarLoanDAL();

                await Task.Run(() =>
                {
                    if (carDAL.IsLoanIDExistDAL(loanID) == false)
                        throw new InvalidStringException("Loan ID not found");
                });

                return carDAL.GetLoanByLoanIDDAL(loanID);
            }
            catch
            {
                return null;
            }
        }

        public async Task<LoanStatus> GetLoanStatusBL(string loanID)
        {
            //if (BusinessLogicUtil.validate(loanID) == false)
            //    throw new InvalidStringException("Invalid loan ID");
            try
            {
                CarLoanDAL carDAL = new CarLoanDAL();

                await Task.Run(() =>
                {
                    if (carDAL.IsLoanIDExistDAL(loanID) == false)
                        throw new InvalidStringException("Loan ID not found");
                });

                return carDAL.GetLoanStatusDAL(loanID);
            }
            catch
            {
                return 0;
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

            if (carLoan.SalaryDeductions >= carLoan.GrossIncome)
                throw new InvalidAmountException("Salary deduction can't be greater than or equal to Gross salary");

            return valid;
        }


        public List<CarLoan> ListAllLoans()
        {
            CarLoanDAL loanDAL = new CarLoanDAL();
            return loanDAL.ListAllLoansDAL();
        }

        public bool isLoanIDExistBL(string loanID)
        {
            CarLoanDAL loanDAL = new CarLoanDAL();
            return loanDAL.IsLoanIDExistDAL(loanID);
        }


    }
}
