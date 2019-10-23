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
                        eduLoan.LoanID = Guid.NewGuid(); //"EDU" + guid.ToString();
                        eduLoan.InterestRate = 10.65;
                        eduLoan.EMI_Amount = BusinessLogicUtil.ComputeEMI(eduLoan.AmountApplied, eduLoan.RepaymentPeriod, eduLoan.InterestRate);
                        eduLoan.DateOfApplication = DateTime.Now;
                        eduLoan.Status = (LoanStatus)0;
                        eduLoan.RepaymentHoliday = 1;

                        EduLoanDAL eduDAL = new EduLoanDAL();
                        isApplied = eduDAL.ApplyLoanDAL(eduLoan);
                    });
                }
            }
            catch
            {
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
        public async Task<EduLoan> ApproveLoanBL(string loanID, LoanStatus updatedStatus)
        {
            try
            {
                EduLoanDAL EduLoanDALobj = new EduLoanDAL();
                await Task.Run(() =>
                {
                    if (EduLoanDALobj.IsLoanIDExistDAL(loanID) == false)
                        throw new InvalidStringException("Loan ID not found");
                });
                return EduLoanDALobj.ApproveLoanDAL(loanID, updatedStatus);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// For displaying loan for specific customer ID.
        /// </summary>
        /// <param name="customerID">Represents Customer ID.</param>
        /// <returns>Returns Home Loan for Customer.</returns>
        public async Task<EduLoan> GetLoanByCustomerIDBL(string customerID)
        {
            //if (BusinessLogicUtil.validate(customerID) == false)
            //    throw new InvalidStringException("Invalid customer ID");

            try
            {
                EduLoanDAL EduLoanDALobj = new EduLoanDAL();
                CustomerBL custBL = new CustomerBL();
                bool isExist = await custBL.isCustomerIDExistBL(Guid.Parse(customerID));
                await Task.Run(() =>
                {
                    
                    if ( isExist == false)
                        throw new InvalidStringException("Customer ID not found");
                });

                return EduLoanDALobj.GetLoanByCustomerIDDAL(customerID);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// For displaying loan status.
        /// </summary>
        /// <param name="loanID">Represents Loan ID.</param>
        /// <returns>Returns Loan Status for Loans.</returns>
        public async Task<LoanStatus> GetLoanStatusBL(string loanID)
        {
            //if (BusinessLogicUtil.validate(loanID) == false)
            //    throw new InvalidStringException("Invalid loan ID");

            try
            {
                EduLoanDAL EduLoanDALobj = new EduLoanDAL();

                await Task.Run(() =>
                {
                    if (EduLoanDALobj.IsLoanIDExistDAL(loanID) == false)
                        throw new InvalidStringException("Loan ID not found");
                });

                return EduLoanDALobj.GetLoanStatusDAL(loanID);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets Loan by Loan ID.
        /// </summary>
        /// <param name="loanID">Represents Loan ID.</param>
        /// <returns>Returns Home loan object.</returns>
        public async Task<EduLoan> GetLoanByLoanIDBL(string loanID)
        {
            //if (BusinessLogicUtil.validate(loanID) == false)
            //    throw new InvalidStringException("Invalid loan ID");

            try
            {
                EduLoanDAL EduLoanDALobj = new EduLoanDAL();

                await Task.Run(() =>
                {
                    if (EduLoanDALobj.IsLoanIDExistDAL(loanID) == false)
                        throw new InvalidStringException("Loan ID not found");
                });

                return EduLoanDALobj.GetLoanByLoanIDDAL(loanID);
            }
            catch
            {
                return null;
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
        public List<EduLoan> ListAllLoans()
        {
            EduLoanDAL loanDAL = new EduLoanDAL();
            return loanDAL.ListAllLoansDAL();
        }

        /// <summary>
        /// Checks if a particular loan ID exists.
        /// </summary>    
        /// <returns>Returns bool value to know if loan ID exists or not.</returns>
        public bool isLoanIDExistBL(string loanID)
        {
            EduLoanDAL loanDAL = new EduLoanDAL();
            return loanDAL.IsLoanIDExistDAL(loanID);
        }
        /// <summary>
        /// Disposes DAL object(s).
        /// </summary>
        public void Dispose()
        {
            ((EduLoanDAL)eduLoanDAL).Dispose();
        }

    }
}
