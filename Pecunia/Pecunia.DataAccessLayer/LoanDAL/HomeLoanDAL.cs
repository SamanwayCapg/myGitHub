using System.Collections.Generic;
using Capgemini.Pecunia.Entities;
using Newtonsoft.Json;
using System.IO;
using System;
using Capgemini.Pecunia.Contracts.DALcontracts.LoanDALBase;

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
            //List<HomeLoan> loanList = new List<HomeLoan>();
            var loanList = DeserializeFromJSON(fileName);
            loanList.Add(home);
            return SerializeIntoJSON(loanList, fileName);
        }

        /// <summary>
        /// For approving loan.
        /// </summary>
        /// <param name="loanID">Represents Loan ID.</param>
        /// <param name="updatedStatus">Represents Updated Loan Status.</param>
        /// <returns>Returns Home loan object.</returns>
        public override HomeLoan ApproveLoanDAL(string loanID, LoanStatus updatedStatus)
        {
            List<HomeLoan> HomeLoans = DeserializeFromJSON(fileName);
            HomeLoan objToReturn = new HomeLoan();
            Guid loanIDGuid;
            bool isValidGuid = Guid.TryParse(loanID, out loanIDGuid);

            if (isValidGuid == true)
            {
                foreach (HomeLoan Loan in HomeLoans)
                {
                    if (Guid.Parse(loanID) == Loan.LoanID)
                    {
                        Loan.Status = updatedStatus;
                        objToReturn = Loan;
                        break;
                    }
                }
            }

            SerializeIntoJSON(HomeLoans, fileName);
            return objToReturn;
        }

        /// <summary>
        /// For displaying loan for specific customer ID.
        /// </summary>
        /// <param name="customerID">Represents Customer ID.</param>
        /// <returns>Returns Home Loan for Customer.</returns>
        public override HomeLoan GetLoanByCustomerIDDAL(string customerID)
        {
            List<HomeLoan> HomeLoans = DeserializeFromJSON(fileName);
            Guid customerIDGuid;
            bool isValidGuid = Guid.TryParse(customerID, out customerIDGuid);

            if (isValidGuid == true)
            {
                foreach (HomeLoan Loan in HomeLoans)
                {
                    if (Guid.Parse(customerID) == Loan.CustomerID)
                        return Loan;
                }
            }
            return default(HomeLoan);
        }

        /// <summary>
        /// Gets Loan by Loan ID.
        /// </summary>
        /// <param name="loanID">Represents Loan ID.</param>
        /// <returns>Returns Home loan object.</returns>
        public override HomeLoan GetLoanByLoanIDDAL(string loanID)
        {
            List<HomeLoan> HomeLoans = DeserializeFromJSON(fileName);
            Guid loanIDGuid;
            bool isValidGuid = Guid.TryParse(loanID, out loanIDGuid);

            if (isValidGuid == true)
            {
                foreach (HomeLoan Loan in HomeLoans)
                {
                    if (Guid.Parse(loanID) == Loan.LoanID)
                        return Loan;
                }
            }
            return default(HomeLoan);
        }

        /// <summary>
        /// For displaying loan status.
        /// </summary>
        /// <param name="loanID">Represents Loan ID.</param>
        /// <returns>Returns Loan Status for Loans.</returns>
        public override LoanStatus GetLoanStatusDAL(string loanID)
        {
            List<HomeLoan> HomeLoans = DeserializeFromJSON(fileName);
            Guid loanIDGuid;
            bool isValidGuid = Guid.TryParse(loanID, out loanIDGuid);

            if (isValidGuid == true)
            {
                foreach (HomeLoan Loan in HomeLoans)
                {
                    if (Guid.Parse(loanID) == Loan.LoanID)
                        return Loan.Status;
                }
            }
            return (LoanStatus)4;//LoanStatus for INVALID 
        }

        public static List<HomeLoan> DeserializeFromJSON(string fileName)
        {
            List<HomeLoan> HomeLoans = JsonConvert.DeserializeObject<List<HomeLoan>>(File.ReadAllText(fileName));// Done to read data from file
            return HomeLoans;
        }

        public static bool SerializeIntoJSON(List<HomeLoan> CarLoans, string fileName)
        {
            try
            {
                JsonSerializer serializer = new JsonSerializer();
                using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs))   //filename is used so that we can have access over our own file
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, CarLoans);
                    sw.Close();
                    fs.Close();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Lists all Loans.
        /// </summary>    
        /// <returns>Returns list of Home loan objects.</returns>
        public override List<HomeLoan> ListAllLoansDAL()
        {
            List<HomeLoan> HomeLoans = DeserializeFromJSON(fileName);
            return HomeLoans;
        }

        /// <summary>
        /// Checks if a particular loan ID exists.
        /// </summary>    
        /// <returns>Returns bool value to know if loan ID exists or not.</returns>
        public override bool IsLoanIDExistDAL(string loanID)
        {
            List<HomeLoan> loans = DeserializeFromJSON(fileName);
            Guid loanIDGuid;
            bool isValidGuid = Guid.TryParse(loanID, out loanIDGuid);

            if (isValidGuid == true)
            {
                foreach (var loan in loans)
                {
                    //if (loan.LoanID.Equals(loanID))
                    if (Guid.Parse(loanID) == loan.LoanID)
                    {
                        return true;
                    }
                }
            }
            return false;
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
