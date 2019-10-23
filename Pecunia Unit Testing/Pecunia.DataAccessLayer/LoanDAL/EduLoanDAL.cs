using System.Collections.Generic;
using Capgemini.Pecunia.Entities;
using Newtonsoft.Json;
using System.IO;
using System;
using Capgemini.Pecunia.Contracts.DALcontracts.LoanDALBase;

namespace Capgemini.Pecunia.DataAccessLayer.LoanDAL
{
    public class EduLoanDAL : EduLoanDALBase, IDisposable
    {
        public static List<EduLoan> EduLoans;

        public override bool ApplyLoanDAL(EduLoan edu)
        {
            //EduLoan edu = (EduLoan)(object)obj;
            List<EduLoan> loanList = DeserializeFromJSON("EduLoans.txt");
            loanList.Add(edu);
            return SerializeIntoJSON(loanList, "EduLoans.txt");
        }

        public override EduLoan ApproveLoanDAL(string loanID, LoanStatus updatedStatus)
        {
            List<EduLoan> eduLoans = DeserializeFromJSON("EduLoans.txt");
            EduLoan objToReturn = new EduLoan();
            foreach (EduLoan Loan in eduLoans)
            {
                if (Guid.Parse(loanID) == Loan.LoanID)
                {
                    Loan.Status = updatedStatus;
                    objToReturn = Loan;
                    break;
                }
            }

            SerializeIntoJSON(eduLoans, "EduLoans.txt");
            return objToReturn;
        }

        public override EduLoan GetLoanByCustomerIDDAL(string customerID)
        {
            List<EduLoan> eduLoans = DeserializeFromJSON("EduLoans.txt");
            Guid customerIDGuid;
            bool isValidGuid = Guid.TryParse(customerID, out customerIDGuid);

            if (isValidGuid == true)
            {
                foreach (EduLoan Loan in eduLoans)
                {
                    if (Guid.Parse(customerID) == Loan.CustomerID)
                        return Loan;
                }
            }
            return default(EduLoan);
        }

        public override EduLoan GetLoanByLoanIDDAL(string loanID)
        {
            List<EduLoan> eduLoans = DeserializeFromJSON("EduLoans.txt");
            Guid loanIDGuid;
            bool isValidGuid = Guid.TryParse(loanID, out loanIDGuid);

            if (isValidGuid == true)
            {
                foreach (EduLoan Loan in eduLoans)
                {
                    if (Guid.Parse(loanID) == Loan.LoanID)
                        return Loan;
                }
            }
            return default(EduLoan);
        }

        public override LoanStatus GetLoanStatusDAL(string loanID)
        {
            List<EduLoan> eduLoans = DeserializeFromJSON("EduLoans.txt");
            Guid loanIDGuid;
            bool isValidGuid = Guid.TryParse(loanID, out loanIDGuid);

            if (isValidGuid == true)
            {
                foreach (EduLoan Loan in eduLoans)
                {
                    if (Guid.Parse(loanID) == Loan.LoanID)
                        return Loan.Status;
                }
            }
            return (LoanStatus)4;//LoanStatus for INVALID
        }

        public static List<EduLoan> DeserializeFromJSON(string FileName)
        {
            List<EduLoan> eduLoans = JsonConvert.DeserializeObject<List<EduLoan>>(File.ReadAllText(FileName));// Done to read data from file
            return eduLoans;
        }

        public static bool SerializeIntoJSON(List<EduLoan> eduLoans, string fileName)
        {
            try
            {
                JsonSerializer serializer = new JsonSerializer();
                using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs))   //filename is used so that we can have access over our own file
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, eduLoans);
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

        public override List<EduLoan> ListAllLoansDAL()
        {
            List<EduLoan> eduLoans = DeserializeFromJSON("EduLoans.txt");
            return eduLoans;
        }

        public override bool IsLoanIDExistDAL(string loanID)
        {
            List<EduLoan> loans = DeserializeFromJSON("EduLoans.txt");
            Guid loanIDGuid;
            bool isValidGuid = Guid.TryParse(loanID, out loanIDGuid);

            if (isValidGuid == true)
            {
                foreach (var loan in loans)
                {
                    if (Guid.Parse(loanID) == loan.LoanID)
                        return true;
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
