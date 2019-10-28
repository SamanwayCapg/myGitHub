using Capgemini.Pecunia.Contracts.BLContracts.ILoanBL;
using Capgemini.Pecunia.Contracts.DALcontracts.LoanDALBase;
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

namespace Capgemini.Pecunia.BusinessLayer.LoanBL
{
    /// <summary>
    /// Contains business layer methods for validating, inserting, updating, deleting Home Loan from Home Loans collection.
    /// </summary>
    public class HomeLoanBL : BLbase<HomeLoan>, IHomeLoanBL, IDisposable
    {
        //fields
        HomeLoanDALBase homeLoanDAL;

        /// <summary>
        /// Constructor.
        /// </summary>
        public HomeLoanBL()
        {
            this.homeLoanDAL = new HomeLoanDAL();
        }

        /// <summary>
        /// Validation before applying a new loan.
        /// </summary>
        /// <param name="homeLoan">Represents home loan object that contains details of home loan.</param>
        /// <returns>Returns a boolean value, that indicates whether loan is applied or not.</returns>
        public async Task<bool> ApplyLoanBL(HomeLoan homeLoan)
        {
            //HomeLoan home = (HomeLoan)(Object)obj;
            bool loanApplied = false;
            try
            {
                bool isValid = await Validate(homeLoan);
                if (isValid == true)
                {
                    await Task.Run(() =>
                    {
                        //Guid guid = Guid.NewGuid();
                        homeLoan.LoanID = Guid.NewGuid(); // "HOME" + guid.ToString();
                        homeLoan.InterestRate = (decimal)8.50;
                        homeLoan.EMI_amount = BusinessLogicUtil.ComputeEMI(homeLoan.AmountApplied, homeLoan.RepaymentPeriod, homeLoan.InterestRate);
                        homeLoan.DateOfApplication = DateTime.Now;
                        homeLoan.LoanStatus = "APPLIED";

                        HomeLoanDAL homeDAL = new HomeLoanDAL();
                        loanApplied =  homeDAL.ApplyLoanDAL(homeLoan);
                    });
                }
            }
            catch(Exception e)
            {
                BusinessLogicUtil.logException(e.Message, e.StackTrace, "homeLoanBL.ApplyHomeLoan");
                return false;
            }
            return loanApplied;
        }

        

        /// <summary>
        /// For displaying loan status.
        /// </summary>
        /// <param name="loanID">Represents Loan ID.</param>
        /// <returns>Returns Loan Status for Loans.</returns>
        public async Task<string> GetLoanStatusBL(string loanID)
        {
            string status = "";
            try
            {
                HomeLoanDAL homeLoanDAL = new HomeLoanDAL();
                await Task.Run(() =>
                {
                    status = homeLoanDAL.GetLoanStatusDAL(loanID);
                });

                return status;
            }
            catch(Exception e)
            {
                BusinessLogicUtil.logException(e.Message, e.StackTrace, "homeLoanBL.GetLoanStatusBL");
                return default(string);
            }
        }

        /// <summary>
        /// For displaying loan for specific customer ID.
        /// </summary>
        /// <param name="customerID">Represents Customer ID.</param>
        /// <returns>Returns Home Loan for Customer.</returns>
        public async Task<List<HomeLoan>> GetLoanByCustomerIDBL(string customerID)
        {
            //if (BusinessLogicUtil.validate(customerID) == false)
            //    throw new InvalidStringException("Invalid Customer ID");
            try
            {
                HomeLoanDAL homeLoanDAL = new HomeLoanDAL();
                List<HomeLoan> homes = new List<HomeLoan>();
                await Task.Run(() =>
                {
                   homes = homeLoanDAL.GetLoanByCustomerIDDAL(customerID);
                });

                return homes;
            }
            catch(Exception e)
            {
                BusinessLogicUtil.logException(e.Message, e.StackTrace, "homeLoanBL.GetLoanByCustomerIDBL");
                return default(List<HomeLoan>);
            }
        }

        /// <summary>
        /// For approving loan.
        /// </summary>
        /// <param name="loanID">Represents Loan ID.</param>
        /// <param name="updatedStatus">Represents Updated Loan Status.</param>
        /// <returns>Returns Home loan object.</returns>
        public async Task<List<HomeLoan>> ApproveLoanBL(string loanID, string loanStatus)
        {
            try
            {
                HomeLoanDAL homeLoanDAL = new HomeLoanDAL();
                List<HomeLoan> homes = new List<HomeLoan>();
                await Task.Run(() =>
                {
                    homes = homeLoanDAL.ApproveLoanDAL(loanID, loanStatus); 
                });

                return homes;
            }
            catch(Exception e)
            {
                BusinessLogicUtil.logException(e.Message, e.StackTrace, "homeLoanBL.ApproveLoanBL");
                return default(List<HomeLoan>);
            }
        }


        /// <summary>
        /// Gets Loan by Loan ID.
        /// </summary>
        /// <param name="loanID">Represents Loan ID.</param>
        /// <returns>Returns Home loan object.</returns>
        public async Task<List<HomeLoan>> GetLoanByLoanIDBL(string loanID)
        {
            try
            {
                HomeLoanDAL homeLoanDAL = new HomeLoanDAL();
                List<HomeLoan> homes = new List<HomeLoan>();
                await Task.Run(() =>
                {
                    homes = homeLoanDAL.GetLoanByLoanIDDAL(loanID);
                });

                return homes;
            }
            catch(Exception e)
            {
                BusinessLogicUtil.logException(e.Message, e.StackTrace, "homeLoanBL.GetLoanByLoanIDBL");
                return default(List<HomeLoan>);
            }
        }

        /// <summary>
        /// Validates Home Loan Object.
        /// </summary>
        /// <param name="homeLoan">Contains Home Loan details.</param>
        /// <returns>Returns bool value to tell whether home loan object details are valid or not.</returns>
        public async override Task<bool> Validate(HomeLoan homeLoan)
        {
            bool valid = await base.Validate(homeLoan);
            if (valid == false)
                return valid;

            if (homeLoan.AmountApplied > 2000000 || homeLoan.AmountApplied<=0)
                throw new InvalidAmountException("Maximum loan amount is Rs.20 lakh and cant be negative or zero");

            if (homeLoan.RepaymentPeriod > 180 || homeLoan.RepaymentPeriod<=0)
                throw new InvalidRangeException("Repayment period can be maximum of 180 months and cant be negative or zero");

            if (homeLoan.SalaryDeduction >= homeLoan.GrossIncome)
                throw new InvalidAmountException("Salary deduction can't be greater than or equal to Gross salary");

            if (homeLoan.ServiceYears < 5 || homeLoan.ServiceYears<0)
                throw new InvalidRangeException("Service experience must be minimum of 5 years and cant be negative");

            return valid;
        }


        /// <summary>
        /// Lists all Loans.
        /// </summary>    
        /// <returns>Returns list of Home loan objects.</returns>
        public async Task<List<HomeLoan>> ListAllLoansBL()
        {
            List<HomeLoan> HomeLoansList = new List<HomeLoan>();
            try
            {
                await Task.Run(() =>
                {
                    HomeLoansList = homeLoanDAL.ListAllLoansDAL();
                });
            }
            catch(Exception e)
            {
                BusinessLogicUtil.logException(e.Message, e.StackTrace, "homeLoanBL.ListAllLoansBL");
                return default(List<HomeLoan>);
            }
            return HomeLoansList;
        }

        public async Task<bool> DeleteLoanEntryBL(string loanID)
        {
            HomeLoanDAL homeLoanDAL = new HomeLoanDAL();
            bool isDeleted = false;
            try
            {
                await Task.Run(() =>
                {
                    isDeleted = homeLoanDAL.DeleteLoanEntryDAL(loanID);
                });
                return isDeleted;
            }
            catch (Exception e)
            {
                BusinessLogicUtil.logException(e.Message, e.StackTrace, "homeLoanBL.deleteLoanEntry");
                return isDeleted;
            }
        }

        /// <summary>
        /// Checks if a particular loan ID exists.
        /// </summary>    
        /// <returns>Returns bool value to know if loan ID exists or not.</returns>
        public bool IsLoanIDExistBL(string loanID)
        {
            return true;
        }

        /// <summary>
        /// Disposes DAL object(s).
        /// </summary>
        public void Dispose()
        {
            ((HomeLoanDAL)homeLoanDAL).Dispose();
        }

    }
}
