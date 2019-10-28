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
    public class EduLoanDAL : EduLoanDALBase, IDisposable
    {
        public static List<EduLoan> EduLoans;

        public override bool ApplyLoanDAL(EduLoan edu)
        {
            int rowsAffected = 0;
            try
            {
                using (PecuniaEntities pecEnt = new PecuniaEntities())
                {
                    rowsAffected = pecEnt.applyEduLoan(edu.LoanID,
                                        edu.CustomerID,
                                        edu.AmountApplied,
                                        edu.InterestRate,
                                        edu.EMI_amount,
                                        edu.RepaymentPeriod,
                                        edu.DateOfApplication,
                                        edu.LoanStatus,
                                        edu.Course,
                                        edu.InstituteName,
                                        edu.StudentID,
                                        edu.RepaymentHoliday
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
                BusinessLogicUtil.logException(e.Message, e.StackTrace, "EduLoanDAL.ApplyEduLoan");
                return false;
            }

        }

        public override List<EduLoan> ApproveLoanDAL(string loanID, string updatedStatus)
        {
            try
            {
                List<EduLoan> eduLoan = new List<EduLoan>();
                Guid guid;
                Guid.TryParse(loanID, out guid);
                int rowsAffected = 0;
                using (PecuniaEntities pecEnt = new PecuniaEntities())
                {
                    var loanEntry = pecEnt.EduLoans.SingleOrDefault(t => t.LoanID == guid);
                    if (loanEntry != null)
                    {
                        loanEntry.LoanStatus = updatedStatus;
                        pecEnt.SaveChanges();
                    }
                    else
                    {
                        BusinessLogicUtil.logException("entry not found in database", "no stacktrace", "eduloanDaL.approveLoanDAL");
                        return default(List<EduLoan>);
                    }
                    eduLoan = pecEnt.EduLoans.Where(t => t.LoanID == guid).ToList();
                }
                return eduLoan;
            }
            catch (Exception e)
            {
                BusinessLogicUtil.logException(e.Message, e.StackTrace, "EduLoanDAL.ApproveLoanDAL");
                return default(List<EduLoan>);
            }
        }

        public override List<EduLoan> GetLoanByCustomerIDDAL(string customerID)
        {
            try
            {
                List<EduLoan> eduLoans = new List<EduLoan>();
                Guid guid;
                Guid.TryParse(customerID, out guid);
                using (PecuniaEntities pecEnt = new PecuniaEntities())
                {
                    eduLoans = pecEnt.EduLoans.Where(t => t.CustomerID == guid).ToList();
                    
                }
                return eduLoans;
            }
            catch (Exception e)
            {
                BusinessLogicUtil.logException(e.Message, e.StackTrace, "EduLoanDAL.getLoanByCustomerID");
                return default(List<EduLoan>);
            }
        }

        public override List<EduLoan> GetLoanByLoanIDDAL(string loanID)
        {
            try
            {
                List<EduLoan> eduLoans = new List<EduLoan>();
                Guid guid;
                Guid.TryParse(loanID, out guid);
                using (PecuniaEntities pecEnt = new PecuniaEntities())
                {
                    eduLoans = pecEnt.EduLoans.Where(t => t.LoanID == guid).ToList();
                }
                return eduLoans;
            }
            catch (Exception e)
            {
                BusinessLogicUtil.logException(e.Message, e.StackTrace, "EduLoanDAL.getLoanByLoanID");
                return default(List<EduLoan>);
            }
        }

        public override string GetLoanStatusDAL(string loanID)
        {
            try
            {
                List<EduLoan> eduLoans = new List<EduLoan>();
                Guid guid;
                Guid.TryParse(loanID, out guid);
                using (PecuniaEntities pecEnt = new PecuniaEntities())
                {
                    eduLoans = pecEnt.EduLoans.Where(t => t.LoanID == guid).ToList();
                }
                return eduLoans.ElementAt(0).LoanStatus;
            }
            catch (Exception e)
            {
                BusinessLogicUtil.logException(e.Message, e.StackTrace, "EduLoanDAL.getLoanStatus");
                return default(string);
            }
        }

        
        public override List<EduLoan> ListAllLoansDAL()
        {
            try
            {
                List<EduLoan> eduLoans = new List<EduLoan>();
                using (PecuniaEntities pecEnt = new PecuniaEntities())
                {
                    eduLoans = pecEnt.EduLoans.ToList();
                }
                return eduLoans;
            }
            catch (Exception e)
            {
                BusinessLogicUtil.logException(e.Message, e.StackTrace, "EduLoanDAL.ListAllLoans");
                return default(List<EduLoan>);
            }
            
        }

        public bool DeleteLoanEntryDAL(string loanID)
        {
            Guid loanIDguid;
            Guid.TryParse(loanID, out loanIDguid);
            using(PecuniaEntities pecEnt  = new PecuniaEntities())
            {
                var loanToDelete = pecEnt.EduLoans.SingleOrDefault(t => t.LoanID == loanIDguid);
                if (loanToDelete != null)
                {
                    pecEnt.EduLoans.Remove(loanToDelete);
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
