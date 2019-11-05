using System.Collections.Generic;
using Capgemini.Pecunia.Entities;

using System.IO;
using System;
using Pecunia.Contracts.DALcontracts.LoanDALBase;
using Capgemini.Pecunia.Helpers;
using System.Data.SqlClient;
using System.Data;
using System.Linq;

namespace Capgemini.Pecunia.DataAccessLayer.LoanDAL
{
    public class CarLoanDAL : CarLoanDALBase, IDisposable
    {
        public static List<CarLoan> CarLoans;
        public override bool  ApplyLoanDAL(CarLoan car)
        {
            int rowsAffected = 0;
            try
            {
                using (PecuniaEntities pecEnt = new PecuniaEntities())
                {
                    rowsAffected = pecEnt.applyCarLoan(car.LoanID,
                                        car.CustomerID,
                                        car.AmountApplied,
                                        car.InterestRate,
                                        car.EMI_amount,
                                        car.RepaymentPeriod,
                                        car.DateOfApplication,
                                        car.LoanStatus,
                                        car.Occupation,
                                        car.GrossIncome,
                                        car.SalaryDeduction,
                                        car.VehicleType);
                }
                if (rowsAffected == 1)
                    return true;
                else
                {
                    BusinessLogicUtil.logException("rows affected != 1", "no stacktrace", "carLoanBL.ApplyCarLoan");
                    return false;
                }
            }
            catch (Exception e)
            {
                BusinessLogicUtil.logException(e.Message, e.StackTrace, "carLoanDAL.ApplyCarLoan");
                return false;
            }
        }

        public override List<CarLoan> ApproveLoanDAL(string loanID, string updatedStatus)
        {
            // status  - priority
            // applied - 1 lowest
            // processing - 2
            // approved - 3
            // rejected - 3
            // invalid - 3 highest
            // possible updation from low to high
            try
            {
                List<CarLoan> carLoan = new List<CarLoan>();
                int rowsAffected = 0;
                using (PecuniaEntities pecEnt = new PecuniaEntities())
                {
                    Guid guid;
                    Guid.TryParse(loanID, out guid);

                    var loanEntry = pecEnt.CarLoans.SingleOrDefault(t => t.LoanID == guid);
                    if (loanEntry != null)
                    {
                        if (loanEntry.LoanStatus.Equals("APPLIED") == true)
                        {
                            loanEntry.LoanStatus = updatedStatus;
                        }
                        else if (loanEntry.LoanStatus.Equals("PROCESSING") == true && updatedStatus.Equals("APPLIED") == false)
                        {
                            loanEntry.LoanStatus = updatedStatus;
                        }
                        else
                        {
                            //updation not possible
                        }
                        pecEnt.SaveChanges();
                    }
                    else
                    {
                        BusinessLogicUtil.logException("entry not found in database", "no stacktrace", "carloanDaL.approveLoanDAL");
                        return default(List<CarLoan>);
                    }
                    carLoan = pecEnt.CarLoans.Where(t => t.LoanID == guid).ToList();
                }
                return carLoan;
            }
            catch (Exception e)
            {
                BusinessLogicUtil.logException(e.Message, e.StackTrace, "CarLoanDAL.ApproveLoanDAL");
                return default(List<CarLoan>);
            }

        }

        public override List<CarLoan> GetLoanByCustomerIDDAL(string customerID)
        {
            try
            {
                List<CarLoan> carLoans = new List<CarLoan>();
                Guid guid;
                Guid.TryParse(customerID, out guid);
                using (PecuniaEntities pecEnt = new PecuniaEntities())
                {
                    carLoans = pecEnt.CarLoans.Where(t => t.CustomerID == guid).ToList();
                }
                return carLoans;
            }
            catch (Exception e)
            {
                BusinessLogicUtil.logException(e.Message, e.StackTrace, "CarLoanDAL.getLoanByCustomerID");
                return default(List<CarLoan>);
            }
        }

        public override List<CarLoan> GetLoanByLoanIDDAL(string loanID)
        {
            try
            {
                List<CarLoan> carLoans = new List<CarLoan>();
                Guid guid;
                Guid.TryParse(loanID, out guid);
                using (PecuniaEntities pecEnt = new PecuniaEntities())
                {
                    carLoans = pecEnt.CarLoans.Where(t => t.LoanID == guid).ToList();
                }
                return carLoans;
            }
            catch (Exception e)
            {
                BusinessLogicUtil.logException(e.Message, e.StackTrace, "CarLoanDAL.getLoanByLoanID");
                return default(List<CarLoan>);
            }
        }
        
        public override string GetLoanStatusDAL(string loanID)
        {
            try
            {
                List<CarLoan> carLoans = new List<CarLoan>();
                Guid guid;
                Guid.TryParse(loanID, out guid);
                using (PecuniaEntities pecEnt = new PecuniaEntities())
                {
                    carLoans = pecEnt.CarLoans.Where(t => t.LoanID == guid).ToList();
                }
                return carLoans.ElementAt(0).LoanStatus;
            }
            catch (Exception e)
            {
                BusinessLogicUtil.logException(e.Message, e.StackTrace, "CarLoanDAL.getLoanStatus");
                return default(string);
            }
        }


        public override List<CarLoan> ListAllLoansDAL()
        {
            try
            {
                List<CarLoan> carLoans = new List<CarLoan>();
                using (PecuniaEntities pecEnt = new PecuniaEntities())
                {
                    carLoans = pecEnt.CarLoans.ToList();
                }
                return carLoans;
            }
            catch (Exception e)
            {
                BusinessLogicUtil.logException(e.Message, e.StackTrace, "CarLoanDAL.ListAllLoans");
                return default(List<CarLoan>);
            }
        }

        public bool DeleteLoanEntryDAL(string loanID)
        {
            try
            {
                Guid loanIDguid;
                Guid.TryParse(loanID, out loanIDguid);
                using (PecuniaEntities pecEnt = new PecuniaEntities())
                {
                    System.Diagnostics.Debug.WriteLine(loanIDguid);
                    var loanToDelete = pecEnt.CarLoans.SingleOrDefault(t => t.LoanID == loanIDguid);
                    if (loanToDelete != null)
                    {
                        pecEnt.CarLoans.Remove(loanToDelete);
                        pecEnt.SaveChanges();
                        return true;
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("SingleOrDefault returns null");
                        BusinessLogicUtil.logException("SingleOrDefault returns null ", "no stacktrace", "carLoanDAL.deleteLoanEntry");
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine($"{e.Message} \n {e.StackTrace}");
                BusinessLogicUtil.logException(e.Message, e.StackTrace, "carLoanDAL.deleteLoanEntry");
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
