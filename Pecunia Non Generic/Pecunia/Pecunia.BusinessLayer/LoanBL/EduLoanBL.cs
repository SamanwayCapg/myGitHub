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
    public class EduLoanBL : BLbase<EduLoan>
    {
        public async Task<bool> ApplyLoanBL(EduLoan edu)
        {
            //EduLoan edu = (EduLoan)(Object)obj;
            bool isValid, isApplied = false;
            try
            {
                isValid = await Validate(edu);
                if (isValid == true)
                {
                    await Task.Run(() =>
                    {
                        //Guid guid = Guid.NewGuid();
                        edu.LoanID = Guid.NewGuid(); //"EDU" + guid.ToString();
                        edu.InterestRate = 10.65;
                        edu.EMI_Amount = BusinessLogicUtil.ComputeEMI(edu.AmountApplied, edu.RepaymentPeriod, edu.InterestRate);
                        edu.DateOfApplication = DateTime.Now;
                        edu.Status = (LoanStatus)0;
                        edu.RepaymentHoliday = 1;

                        EduLoanDAL eduDAL = new EduLoanDAL();
                        isApplied = eduDAL.ApplyLoanDAL(edu);
                    });
                }
            }
            catch
            {
                return false;
            }
            return isApplied;
        }


        public async Task<EduLoan> ApproveLoanBL(string loanID, LoanStatus updatedStatus)
        {
            try
            {
                EduLoanDAL EduLoanDALobj = new EduLoanDAL();
                await Task.Run(() =>
                {
                    if (EduLoanDALobj.isLoanIDExistDAL(loanID) == false)
                        throw new InvalidStringException("Loan ID not found");
                });
                return EduLoanDALobj.ApproveLoanDAL(loanID, updatedStatus);
            }
            catch
            {
                return null;
            }
        }

        public async Task<EduLoan> GetLoanByCustomerID_BL(string customerID)
        {
            //if (BusinessLogicUtil.validate(customerID) == false)
            //    throw new InvalidStringException("Invalid customer ID");

            try
            {
                EduLoanDAL EduLoanDALobj = new EduLoanDAL();

                await Task.Run(() =>
                {
                    CustomerBL custBL = new CustomerBL();
                    if (custBL.isCustomerIDExistBL(Guid.Parse(customerID)) == false)
                        throw new InvalidStringException("Customer ID not found");
                });

                return EduLoanDALobj.GetLoanByCustomerID_DAL(customerID);
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
                EduLoanDAL EduLoanDALobj = new EduLoanDAL();

                await Task.Run(() =>
                {
                    if (EduLoanDALobj.isLoanIDExistDAL(loanID) == false)
                        throw new InvalidStringException("Loan ID not found");
                });

                return EduLoanDALobj.GetLoanStatusDAL(loanID);
            }
            catch
            {
                return 0;
            }
        }

        public async Task<EduLoan> GetLoanByLoanID_BL(string loanID)
        {
            //if (BusinessLogicUtil.validate(loanID) == false)
            //    throw new InvalidStringException("Invalid loan ID");

            try
            {
                EduLoanDAL EduLoanDALobj = new EduLoanDAL();

                await Task.Run(() =>
                {
                    if (EduLoanDALobj.isLoanIDExistDAL(loanID) == false)
                        throw new InvalidStringException("Loan ID not found");
                });

                return EduLoanDALobj.GetLoanByLoanID_DAL(loanID);
            }
            catch
            {
                return null;
            }
        }


        protected async override Task<bool> Validate(EduLoan eduLoan)
        {
            bool valid = await base.Validate(eduLoan);

            if (valid == false)
                return valid;

            if (eduLoan.AmountApplied > 2000000)
                throw new InvalidAmountException("Amount must be less than Rs. 20 Lakh");

            if (eduLoan.RepaymentPeriod > 96)
                throw new InvalidRangeException("Maximum Repayment period is 96 months");

            return valid;
        }

        public List<EduLoan> ListAllLoans()
        {
            EduLoanDAL loanDAL = new EduLoanDAL();
            return loanDAL.ListAllLoans();
        }

        public bool isLoanIDExistBL(string loanID)
        {
            EduLoanDAL loanDAL = new EduLoanDAL();
            return loanDAL.isLoanIDExistDAL(loanID);
        }

    }
}
