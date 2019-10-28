using System.Collections.Generic;
using Capgemini.Pecunia.Entities;
using Newtonsoft.Json;
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
            try
            {
                using (PecuniaEntities pecEnt = new PecuniaEntities())
                {
                    pecEnt.applyCarLoan(car.LoanID,
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
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override bool ApproveLoanDAL(string loanID, LoanStatus updatedStatus)
        {
            Guid loanID_guid;
            Guid.TryParse(loanID, out loanID_guid);
            try
            {
                using (PecuniaEntities pecEnt = new PecuniaEntities())
                {
                    pecEnt.approveCarLoan(loanID_guid, Convert.ToString(updatedStatus));
                }
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public override List<CarLoan> GetLoanByCustomerIDDAL(string customerID)
        {
            Guid custID;
            Guid.TryParse(customerID, out custID);
            try
            {
                using (PecuniaEntities pecEnt = new PecuniaEntities())
                {
                    List<CarLoan> carLoans = new List<CarLoan>();
                    carLoans = pecEnt.CarLoans.Where(e => e.CustomerID == custID).ToList();
                    //carLoan.AmountApplied = result.AmountApplied
                    return carLoans;
                }
            }
            catch (Exception)
            {
                return default(List<CarLoan>);
            }
            
        }

        public override List<CarLoan> GetLoanByLoanIDDAL(string loanID)
        {
            Guid Guid_loanID;
            Guid.TryParse(loanID, out Guid_loanID);
            try
            {
                using (PecuniaEntities pecEnt = new PecuniaEntities())
                {
                    List<CarLoan> carLoans = new List<CarLoan>();
                    carLoans = pecEnt.CarLoans.Where(data => data.LoanID == Guid_loanID).ToList();
                    return carLoans;
                }
            }
            catch (Exception)
            {
                return default(List<CarLoan>);
            }
            
        }

        public override string GetLoanStatusDAL(string loanID)
        {
            string status="";
            Guid Guid_loanID;
            Guid.TryParse(loanID, out Guid_loanID);
            using (PecuniaEntities pecEnt = new PecuniaEntities())
            {
                status = pecEnt.CarLoans.Where(data => data.LoanID == Guid_loanID).ToString();
            }
            return status;
        }


        public override List<CarLoan> ListAllLoansDAL()
        {
            List<CarLoan> carLoans = new List<CarLoan>();
            try
            {
                using (PecuniaEntities pecEnt = new PecuniaEntities())
                {
                    carLoans = pecEnt.CarLoans.ToList();
                    return carLoans;
                }
            }
            catch
            {
                return default(List<CarLoan>);
            }
        }

        public override bool IsLoanIDExistDAL(string loanID)
        {
            return true;
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
