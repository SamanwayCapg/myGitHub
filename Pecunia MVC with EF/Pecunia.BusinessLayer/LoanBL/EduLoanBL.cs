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
    public class EduLoanBL : BLbase<EduLoan>, IEduLoanBL, IDisposable
    {
        //fields
        EduLoanDALBase eduLoanDAL;

        /// <summary>
        /// Constructor.
        /// </summary>
        public EduLoanBL()
        {
            this.eduLoanDAL = new EduLoanDAL();
        }

        /// <summary>
        /// Validation before applying a new loan.
        /// </summary>
        /// <param name="eduLoan">Represents education loan object that contains details of education loan.</param>
        /// <returns>Returns a boolean value, that indicates whether loan is applied or not.</returns>
        public async Task<bool> ApplyLoanBL(EduLoan eduLoan)
        {
            //EduLoan edu = (EduLoan)(Object)obj;
            bool isValid, isApplied = false;
            try
            {
                isValid = await Validate(eduLoan);
                if (isValid == true)
                {
                    await Task.Run(() =>
                    {
                        //Guid guid = Guid.NewGuid();
                        //eduLoan.LoanID = Guid.NewGuid(); //"EDU" + guid.ToString();
                        eduLoan.InterestRate = (decimal)10.65;
                        eduLoan.EMI_amount = BusinessLogicUtil.ComputeEMI(eduLoan.AmountApplied, eduLoan.RepaymentPeriod, eduLoan.InterestRate);
                        eduLoan.DateOfApplication = DateTime.Now;
                        eduLoan.LoanStatus = "APPLIED";
                        eduLoan.RepaymentHoliday = 1;

                        EduLoanDAL eduDAL = new EduLoanDAL();
                        isApplied = eduDAL.ApplyLoanDAL(eduLoan);
                    });
                }
            }
            catch(Exception e)
            {
                BusinessLogicUtil.logException(e.Message, e.StackTrace, "eduLoanBL.ApplyEduLoan");
                return false;
            }
            return isApplied;
        }

        /// <summary>
        /// For approving loan.
        /// </summary>
        /// <param name="loanID">Represents Loan ID.</param>
        /// <param name="updatedStatus">Represents Updated Loan Status.</param>
        /// <returns>Returns Home loan object.</returns>
        public async Task<List<EduLoan>> ApproveLoanBL(string loanID, string updatedStatus)
        {
            try
            {
                EduLoanDAL EduLoanDALobj = new EduLoanDAL();
                List<EduLoan> edus = new List<EduLoan>();
                await Task.Run(() =>
                {
                    edus = EduLoanDALobj.ApproveLoanDAL(loanID, updatedStatus);
                });
                return edus;
            }
            catch(Exception e)
            {
                BusinessLogicUtil.logException(e.Message, e.StackTrace, "eduLoanBL.ApproeLoanBL");
                return default(List<EduLoan>);
            }
        }

        /// <summary>
        /// For displaying loan for specific customer ID.
        /// </summary>
        /// <param name="customerID">Represents Customer ID.</param>
        /// <returns>Returns Home Loan for Customer.</returns>
        public async Task<List<EduLoan>> GetLoanByCustomerIDBL(string customerID)
        {
            try
            {
                EduLoanDAL EduLoanDALobj = new EduLoanDAL();
                List<EduLoan> edus = new List<EduLoan>();
                await Task.Run(() =>
                {
                    edus = EduLoanDALobj.GetLoanByCustomerIDDAL(customerID);
                });

                return edus;
            }
            catch(Exception e)
            {
                BusinessLogicUtil.logException(e.Message, e.StackTrace, "eduLoanBL.GetLoanByCustomerIDBL");
                return default(List<EduLoan>);
            }
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
                EduLoanDAL EduLoanDALobj = new EduLoanDAL();
                
                await Task.Run(() =>
                {
                    status = EduLoanDALobj.GetLoanStatusDAL(loanID);
                });

                return status;
            }
            catch(Exception e)
            {
                BusinessLogicUtil.logException(e.Message, e.StackTrace, "eduLoanBL.GetLoanStatusBL");
                return default(string);
            }
        }

        /// <summary>
        /// Gets Loan by Loan ID.
        /// </summary>
        /// <param name="loanID">Represents Loan ID.</param>
        /// <returns>Returns Home loan object.</returns>
        public async Task<List<EduLoan>> GetLoanByLoanIDBL(string loanID)
        {
            try
            {
                EduLoanDAL EduLoanDALobj = new EduLoanDAL();
                List<EduLoan> edus = new List<EduLoan>();
                await Task.Run(() =>
                {
                    edus = EduLoanDALobj.GetLoanByLoanIDDAL(loanID);
                });

                return edus;
            }
            catch(Exception e)
            {
                BusinessLogicUtil.logException(e.Message, e.StackTrace, "eduLoanBL.GetLoanbyLoanIDBL");
                return default(List<EduLoan>);
            }
        }

        /// <summary>
        /// Validates Education Loan Object.
        /// </summary>
        /// <param name="eduLoan">Contains Education Loan details.</param>
        /// <returns>Returns bool value to tell whether education loan object details are valid or not.</returns>
        public async override Task<bool> Validate(EduLoan eduLoan)
        {
            bool valid = await base.Validate(eduLoan);

            if (valid == false)
                return valid;

            if (eduLoan.AmountApplied > 2000000 || eduLoan.AmountApplied<=0)
                throw new InvalidAmountException("Amount must be less than Rs. 20 Lakh and cant be negative or zero");

            if (eduLoan.RepaymentPeriod > 96 || eduLoan.RepaymentPeriod<=0)
                throw new InvalidRangeException("Maximum Repayment period is 96 months and cant be negative or zero");

            return valid;
        }

        /// <summary>
        /// Lists all Loans.
        /// </summary>    
        /// <returns>Returns list of Education loan objects.</returns>
        public async Task<List<EduLoan>> ListAllLoans()
        {
            EduLoanDAL loanDAL = new EduLoanDAL();
            List<EduLoan> eduLoans = new List<EduLoan>();
            try
            {
                await Task.Run(() =>
                {
                    eduLoans = loanDAL.ListAllLoansDAL();
                });
                return eduLoans;
            }
            catch(Exception e)
            {
                BusinessLogicUtil.logException(e.Message, e.StackTrace, "eduLoanBL.ListAllLoans");
                return default(List<EduLoan>);
            }
        }

        
        public async Task<bool> DeleteLoanEntryBL(string loanID)
        {
            EduLoanDAL eduLoanDAL = new EduLoanDAL();
            bool isDeleted = false;
            try
            {
                await Task.Run(() =>
                {
                    isDeleted = eduLoanDAL.DeleteLoanEntryDAL(loanID);
                });
                return isDeleted;
            }
            catch(Exception e)
            {
                BusinessLogicUtil.logException(e.Message, e.StackTrace, "eduLoanBL.deleteLoanEntry");
                return isDeleted;
            }
        }
        
        /// <summary>
        /// Disposes DAL object(s).
        /// </summary>
        public void Dispose()
        {
            ((EduLoanDAL)eduLoanDAL).Dispose();
        }

        
        public bool isLoanIDExistBL(string loanID)
        {
            throw new NotImplementedException();
        }
    }
}
