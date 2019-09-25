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
    public class HomeLoanBL : BLbase<HomeLoan>//, ILoanBL
    {
        public async Task<bool> ApplyLoanBL(HomeLoan home)
        {
            //HomeLoan home = (HomeLoan)(Object)obj;
            bool loanApplied = false;
            try
            {
                bool isValid = await Validate(home);
                if (isValid == true)
                {
                    await Task.Run(() =>
                    {
                        //Guid guid = Guid.NewGuid();
                        home.LoanID = Guid.NewGuid(); // "HOME" + guid.ToString();
                        home.InterestRate = 8.50;
                        home.EMI_Amount = BusinessLogicUtil.ComputeEMI(home.AmountApplied, home.RepaymentPeriod, home.InterestRate);
                        home.DateOfApplication = DateTime.Now;
                        home.Status = (LoanStatus)0; // APPLIED

                        HomeLoanDAL homeDAL = new HomeLoanDAL();
                        loanApplied =  homeDAL.ApplyLoanDAL(home);
                    });
                }
            }
            catch
            {
                return false;
            }
            return loanApplied;
        }

        public async Task<LoanStatus> GetLoanStatusBL(string loanID)
        {
            //if (BusinessLogicUtil.validate(loanID) == false)
            //    throw new InvalidStringException("Invalid Loan ID");

            try
            {
                HomeLoanDAL homeloanDALobj = new HomeLoanDAL();

                await Task.Run(() =>
                {
                    if (homeloanDALobj.IsLoanIDExistDAL(loanID) == false)
                        throw new Exceptions.InvalidStringException("Loan ID not found");
                });

                return homeloanDALobj.GetLoanStatusDAL(loanID);
            }
            catch
            {
                return 0;
            }
        }

        public async Task<HomeLoan> GetLoanByCustomerID_BL(string customerID)
        {
            //if (BusinessLogicUtil.validate(customerID) == false)
            //    throw new InvalidStringException("Invalid Customer ID");
            try
            {
                HomeLoanDAL homeloanDALobj = new HomeLoanDAL();

                await Task.Run(() =>
                {
                    CustomerBL custBL = new CustomerBL();
                    if (custBL.isCustomerIDExistBL(Guid.Parse(customerID)) == false)
                        throw new InvalidStringException("customer ID not found");
                });

                return homeloanDALobj.GetLoanByCustomerID_DAL(customerID);
            }
            catch
            {
                return null;
            }
        }

        public async Task<HomeLoan> ApproveLoanBL(string loanID, LoanStatus updatedStatus)
        {
            //if (BusinessLogicUtil.validate(loanID) == false)
            //    throw new InvalidStringException("Invalid Loan ID");
            try
            {
                HomeLoanDAL homeloanDALobj = new HomeLoanDAL();
                await Task.Run(() =>
                {
                    if (homeloanDALobj.IsLoanIDExistDAL(loanID) == false)
                        throw new InvalidStringException("Loan ID not found");
                });

                return homeloanDALobj.ApproveLoanDAL(loanID, updatedStatus);
            }
            catch
            {
                return null;
            }
        }

        public async Task<HomeLoan> GetLoanByLoanID_BL(string loanID)
        {
            //if (BusinessLogicUtil.validate(loanID) == false)
            //    throw new InvalidStringException("Invalid loan ID");
            try
            {
                HomeLoanDAL LoanDALobj = new HomeLoanDAL();
                await Task.Run(() =>
                {
                    if (LoanDALobj.IsLoanIDExistDAL(loanID) == false)
                        throw new InvalidStringException("Loan ID not found");
                });

                return LoanDALobj.GetLoanByLoanID_DAL(loanID);
            }
            catch
            {
                return null;
            }
        }

        protected async override Task<bool> Validate(HomeLoan homeLoan)
        {
            bool valid = await base.Validate(homeLoan);
            if (valid == false)
                return valid;

            if (homeLoan.AmountApplied > 2000000)
                throw new InvalidAmountException("Maximum loan amount is Rs.20 lakh");

            if (homeLoan.RepaymentPeriod > 180)
                throw new InvalidRangeException("Repayment period can be maximum of 180 months");

            if (homeLoan.SalaryDeductions >= homeLoan.GrossIncome)
                throw new InvalidAmountException("Salary deduction can't be greater than or equal to Gross salary");

            if (homeLoan.ServiceYears < 5)
                throw new InvalidRangeException("Service experience must be minimum of 5 years");

            return valid;
        }



        public List<HomeLoan> ListAllLoans()
        {
            HomeLoanDAL loanDAL = new HomeLoanDAL();
            return loanDAL.ListAllLoans();
        }

        public bool IsLoanIDExistBL(string loanID)
        {
            HomeLoanDAL loanDAL = new HomeLoanDAL();
            return loanDAL.IsLoanIDExistDAL(loanID);
        }

    }
}
