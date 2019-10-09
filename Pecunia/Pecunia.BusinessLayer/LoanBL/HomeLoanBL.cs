using Capgemini.Pecunia.Contracts.BLContracts.ILoanBL;
using Capgemini.Pecunia.Contracts.DALcontracts.LoanDALBase;
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
                        homeLoan.InterestRate = 8.50;
                        homeLoan.EMI_Amount = BusinessLogicUtil.ComputeEMI(homeLoan.AmountApplied, homeLoan.RepaymentPeriod, homeLoan.InterestRate);
                        homeLoan.DateOfApplication = DateTime.Now;
                        homeLoan.Status = (LoanStatus)0; // APPLIED

                        HomeLoanDAL homeDAL = new HomeLoanDAL();
                        loanApplied =  homeDAL.ApplyLoanDAL(homeLoan);
                    });
                }
            }
            catch
            {
                return false;
            }
            return loanApplied;
        }

        /// <summary>
        /// For displaying loan status.
        /// </summary>
        /// <param name="loanID">Represents Loan ID.</param>
        /// <returns>Returns Loan Status for Loans.</returns>
        public async Task<LoanStatus> GetLoanStatusBL(string loanID)
        {
            //if (BusinessLogicUtil.validate(loanID) == false)
            //    throw new InvalidStringException("Invalid Loan ID");

            try
            {
                HomeLoanDAL homeLoanDAL = new HomeLoanDAL();

                await Task.Run(() =>
                {
                    if (homeLoanDAL.IsLoanIDExistDAL(loanID) == false)
                        throw new Exceptions.InvalidStringException("Loan ID not found");
                });

                return homeLoanDAL.GetLoanStatusDAL(loanID);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// For displaying loan for specific customer ID.
        /// </summary>
        /// <param name="customerID">Represents Customer ID.</param>
        /// <returns>Returns Home Loan for Customer.</returns>
        public async Task<HomeLoan> GetLoanByCustomerIDBL(string customerID)
        {
            //if (BusinessLogicUtil.validate(customerID) == false)
            //    throw new InvalidStringException("Invalid Customer ID");
            try
            {
                HomeLoanDAL homeLoanDAL = new HomeLoanDAL();
                CustomerBL customerBL = new CustomerBL();
                bool isExist = await customerBL.isCustomerIDExistBL(Guid.Parse(customerID));
                await Task.Run(() =>
                {
                    
                    if ( isExist == false)
                        throw new InvalidStringException("customer ID not found");
                });

                return homeLoanDAL.GetLoanByCustomerIDDAL(customerID);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// For approving loan.
        /// </summary>
        /// <param name="loanID">Represents Loan ID.</param>
        /// <param name="updatedStatus">Represents Updated Loan Status.</param>
        /// <returns>Returns Home loan object.</returns>
        public async Task<HomeLoan> ApproveLoanBL(string loanID, LoanStatus loanStatus)
        {
            //if (BusinessLogicUtil.validate(loanID) == false)
            //    throw new InvalidStringException("Invalid Loan ID");
            try
            {
                HomeLoanDAL homeLoanDAL = new HomeLoanDAL();
                await Task.Run(() =>
                {
                    if (homeLoanDAL.IsLoanIDExistDAL(loanID) == false)
                        throw new InvalidStringException("Loan ID not found");
                });

                return homeLoanDAL.ApproveLoanDAL(loanID, loanStatus);
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// Gets Loan by Loan ID.
        /// </summary>
        /// <param name="loanID">Represents Loan ID.</param>
        /// <returns>Returns Home loan object.</returns>
        public async Task<HomeLoan> GetLoanByLoanIDBL(string loanID)
        {
            //if (BusinessLogicUtil.validate(loanID) == false)
            //    throw new InvalidStringException("Invalid loan ID");
            try
            {
                HomeLoanDAL homeLoanDAL = new HomeLoanDAL();
                await Task.Run(() =>
                {
                    if (homeLoanDAL.IsLoanIDExistDAL(loanID) == false)
                        throw new InvalidStringException("Loan ID not found");
                });

                return homeLoanDAL.GetLoanByLoanIDDAL(loanID);
            }
            catch
            {
                return null;
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


        /// <summary>
        /// Lists all Loans.
        /// </summary>    
        /// <returns>Returns list of Home loan objects.</returns>
        public async Task<List<HomeLoan>> ListAllLoansBL()
        {
            List<HomeLoan> HomeLoansList = null;
            //HomeLoanDAL homeLoanDAL = new HomeLoanDAL();
            //return homeLoanDAL.ListAllLoans();
            try
            {
                await Task.Run(() =>
                {
                    HomeLoansList = homeLoanDAL.ListAllLoansDAL();
                });
            }
            catch (PecuniaException ex)
            {
                throw new LoanListException(ex.Message);
            }
            return HomeLoansList;
        }

        /// <summary>
        /// Checks if a particular loan ID exists.
        /// </summary>    
        /// <returns>Returns bool value to know if loan ID exists or not.</returns>
        public bool IsLoanIDExistBL(string loanID)
        {
            HomeLoanDAL homeLoanDAL = new HomeLoanDAL();
            return homeLoanDAL.IsLoanIDExistDAL(loanID);
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
