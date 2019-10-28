using System.Collections.Generic;
using Capgemini.Pecunia.Entities;

using System.IO;
using System;
using Capgemini.Pecunia.Contracts.DALcontracts.LoanDALBase;
using System.Data.SqlClient;
using System.Data;
using Capgemini.Pecunia.Helpers;
using System.Linq;

namespace Capgemini.Pecunia.DataAccessLayer.LoanDAL
{
    /// <summary>
    /// Contains data access layer methods for validating, inserting, updating, deleting Home Loan from Home Loans collection.
    /// </summary>
    public class HomeLoanDAL : HomeLoanDALBase, IDisposable
    {
        public static List<HomeLoan> HomeLoans = new List<HomeLoan>();

        /// <summary>
        /// Validation before applying a new loan.
        /// </summary>
        /// <param name="HomeLoan">Represents home loan object that contains details of home loan.</param>
        /// <returns>Returns a boolean value, that indicates whether loan is applied or not.</returns>
        public override bool ApplyLoanDAL(HomeLoan home)
        {
            int rowsAffected = 0;
            try
            {
                using (PecuniaEntities pecEnt = new PecuniaEntities())
                {
                    rowsAffected = pecEnt.applyHomeLoan(home.LoanID,
                                        home.CustomerID,
                                        home.AmountApplied,
                                        home.InterestRate,
                                        home.EMI_amount,
                                        home.RepaymentPeriod,
                                        home.DateOfApplication,
                                        home.LoanStatus,
                                        home.Occupation,
                                        home.ServiceYears,
                                        home.GrossIncome,
                                        home.SalaryDeduction
                                        );
                }
                if (rowsAffected == 1)
                    return true;
                else
                {
                    BusinessLogicUtil.logException("rowsAffected != 1", "no stacktrace", "carLoanBL.ApplyCarLoan");
                    return false;
                }
            }
            catch (Exception e)
            {
                BusinessLogicUtil.logException(e.Message, e.StackTrace, "homeLoanDAL.ApplyHomeLoan");
                return false;
            }
        }

        /// <summary>
        /// For approving loan.
        /// </summary>
        /// <param name="loanID">Represents Loan ID.</param>
        /// <param name="updatedStatus">Represents Updated Loan Status.</param>
        /// <returns>Returns Home loan object.</returns>
        public override List<HomeLoan> ApproveLoanDAL(string loanID, string updatedStatus)
        {
            try
            {
                List<HomeLoan> homeLoan = new List<HomeLoan>();
                int rowsAffected = 0;
                using (PecuniaEntities pecEnt = new PecuniaEntities())
                {
                    Guid guid;
                    Guid.TryParse(loanID, out guid);

                    var loanEntry = pecEnt.HomeLoans.SingleOrDefault(t => t.LoanID == guid);
                    if (loanEntry != null)
                    {
                        loanEntry.LoanStatus = updatedStatus;
                        pecEnt.SaveChanges();
                    }
                    else
                    {
                        BusinessLogicUtil.logException("entry not found in database", "no stacktrace", "homeloanDaL.approveLoanDAL");
                        return default(List<HomeLoan>);
                    }
                    homeLoan = pecEnt.HomeLoans.Where(t => t.LoanID == guid).ToList();
                }
                return homeLoan;
            }
            catch (Exception e)
            {
                BusinessLogicUtil.logException(e.Message, e.StackTrace, "HomeLoanDAL.ApproveLoanDAL");
                return default(List<HomeLoan>);
            }
        }

        /// <summary>
        /// For displaying loan for specific customer ID.
        /// </summary>
        /// <param name="customerID">Represents Customer ID.</param>
        /// <returns>Returns Home Loan for Customer.</returns>
        public override List<HomeLoan> GetLoanByCustomerIDDAL(string customerID)
        {
            try
            {
                List<HomeLoan> homeLoans = new List<HomeLoan>();
                Guid guid;
                Guid.TryParse(customerID, out guid);
                using (PecuniaEntities pecEnt = new PecuniaEntities())
                {
                    homeLoans = pecEnt.HomeLoans.Where(t => t.CustomerID == guid).ToList();
                }
                return homeLoans;
            }
            catch (Exception e)
            {
                BusinessLogicUtil.logException(e.Message, e.StackTrace, "HomeLoanDAL.getLoanByCustomerID");
                return default(List<HomeLoan>);
            }
        }

        /// <summary>
        /// Gets Loan by Loan ID.
        /// </summary>
        /// <param name="loanID">Represents Loan ID.</param>
        /// <returns>Returns Home loan object.</returns>
        public override List<HomeLoan> GetLoanByLoanIDDAL(string loanID)
        {
            try
            {
                List<HomeLoan> homeLoans = new List<HomeLoan>();
                Guid guid;
                Guid.TryParse(loanID, out guid);
                using (PecuniaEntities pecEnt = new PecuniaEntities())
                {
                    homeLoans = pecEnt.HomeLoans.Where(t => t.LoanID == guid).ToList();
                }
                return homeLoans;
            }
            catch (Exception e)
            {
                BusinessLogicUtil.logException(e.Message, e.StackTrace, "HomeLoanDAL.getLoanByLoanID");
                return default(List<HomeLoan>);
            }
        }

        /// <summary>
        /// For displaying loan status.
        /// </summary>
        /// <param name="loanID">Represents Loan ID.</param>
        /// <returns>Returns Loan Status for Loans.</returns>
        public override string GetLoanStatusDAL(string loanID)
        {
            try
            {
                List<HomeLoan> homeLoans = new List<HomeLoan>();
                Guid guid;
                Guid.TryParse(loanID, out guid);
                using (PecuniaEntities pecEnt = new PecuniaEntities())
                {
                    homeLoans = pecEnt.HomeLoans.Where(t => t.LoanID == guid).ToList();
                }
                return homeLoans.ElementAt(0).LoanStatus;
            }
            catch (Exception e)
            {
                BusinessLogicUtil.logException(e.Message, e.StackTrace, "HomeLoanDAL.getLoanStatus");
                return default(string);
            }
            
        }

        

        /// <summary>
        /// Lists all Loans.
        /// </summary>    
        /// <returns>Returns list of Home loan objects.</returns>
        public override List<HomeLoan> ListAllLoansDAL()
        {
            try
            {
                List<HomeLoan> homeLoans = new List<HomeLoan>();
                using (PecuniaEntities pecEnt = new PecuniaEntities())
                {
                    homeLoans = pecEnt.HomeLoans.ToList();
                }
                return homeLoans;
            }
            catch (Exception e)
            {
                BusinessLogicUtil.logException(e.Message, e.StackTrace, "HomeLoanDAL.ListAllLoans");
                return default(List<HomeLoan>);
            }
        }

        public bool DeleteLoanEntryDAL(string loanID)
        {
            Guid loanIDguid;
            Guid.TryParse(loanID, out loanIDguid);
            using (PecuniaEntities pecEnt = new PecuniaEntities())
            {
                var loanToDelete = pecEnt.HomeLoans.SingleOrDefault(t => t.LoanID == loanIDguid);
                if (loanToDelete != null)
                {
                    pecEnt.HomeLoans.Remove(loanToDelete);
                    pecEnt.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
        }

        /// <summary>
        /// Clears unmanaged resources such as db connections or file streams.
        /// </summary>
        public void Dispose()
        {
            //No unmanaged resources currently
        }
    }
}
