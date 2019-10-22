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
                EduLoan edu = new EduLoan();
                await Task.Run(() =>
                {
                    edu = EduLoanDALobj.ApproveLoanDAL(loanID, updatedStatus);
                });
                return edu;
            }
            catch
            {
                return default(EduLoan);
            }
        }

        /// <summary>
        /// For displaying loan for specific customer ID.
        /// </summary>
        /// <param name="customerID">Represents Customer ID.</param>
        /// <returns>Returns Home Loan for Customer.</returns>
        public async Task<EduLoan> GetLoanByCustomerIDBL(string customerID)
        {
            try
            {
                EduLoanDAL EduLoanDALobj = new EduLoanDAL();
                EduLoan edu = new EduLoan();
                await Task.Run(() =>
                {
                    edu = EduLoanDALobj.GetLoanByCustomerIDDAL(customerID);
                });

                return edu;
            }
            catch
            {
                return default(EduLoan);
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
            catch
            {
                return default(string);
            }
        }

        /// <summary>
        /// Gets Loan by Loan ID.
        /// </summary>
        /// <param name="loanID">Represents Loan ID.</param>
        /// <returns>Returns Home loan object.</returns>
        public async Task<EduLoan> GetLoanByLoanIDBL(string loanID)
        {
            try
            {
                EduLoanDAL EduLoanDALobj = new EduLoanDAL();
                EduLoan edu = new EduLoan();
                await Task.Run(() =>
                {
                    edu = EduLoanDALobj.GetLoanByLoanIDDAL(loanID);
                });

                return edu;
            }
            catch
            {
                //throw new PecuniaException("invalid details");
                return default(EduLoan);
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
        public async Task<DataSet> ListAllLoans()
        {
            EduLoanDAL loanDAL = new EduLoanDAL();
            DataSet eduLoans = new DataSet();
            try
            {
                await Task.Run(() =>
                {
                    eduLoans = loanDAL.ListAllLoansDAL();
                });
                return eduLoans;
            }
            catch
            {
                return default(DataSet);
            }
        }

        /// <summary>
        /// Checks if a particular loan ID exists.
        /// </summary>    
        /// <returns>Returns bool value to know if loan ID exists or not.</returns>
        
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
