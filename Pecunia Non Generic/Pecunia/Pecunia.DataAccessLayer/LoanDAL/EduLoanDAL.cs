using System.Collections.Generic;
using Capgemini.Pecunia.Entities;
using Newtonsoft.Json;
using System.IO;

namespace Capgemini.Pecunia.DataAccessLayer.LoanDAL
{
    public class EduLoanDAL// : ILoanDAL
    {
        public static List<EduLoan> EduLoans;

        public bool ApplyLoanDAL(EduLoan edu)
        {
            //EduLoan edu = (EduLoan)(object)obj;
            List<EduLoan> loanList = DeserializeFromJSON("EduLoans.txt");
            loanList.Add(edu);
            return SerializeIntoJSON(loanList, "EduLoans.txt");
        }

        public EduLoan ApproveLoanDAL(string loanID, LoanStatus updatedStatus)
        {
            List<EduLoan> eduLoans = DeserializeFromJSON("EduLoans.txt");
            EduLoan objToReturn = new EduLoan();
            foreach (EduLoan Loan in eduLoans)
            {
                if (Loan.LoanID.ToString().Equals(loanID) == true)
                {
                    Loan.Status = updatedStatus;
                    objToReturn = Loan;
                    break;
                }
            }

            SerializeIntoJSON(eduLoans, "EduLoans.txt");
            return objToReturn;
        }

        public EduLoan GetLoanByCustomerID_DAL(string customerID)
        {
            List<EduLoan> eduLoans = DeserializeFromJSON("EduLoans.txt");
            foreach (EduLoan Loan in eduLoans)
            {
                if (Loan.CustomerID.ToString().Equals(customerID) == true)
                    return Loan;
            }
            return default(EduLoan);
        }

        public EduLoan GetLoanByLoanID_DAL(string loanID)
        {
            List<EduLoan> eduLoans = DeserializeFromJSON("EduLoans.txt");
            foreach (EduLoan Loan in eduLoans)
            {
                if (Loan.LoanID.ToString().Equals(loanID) == true)
                    return Loan;
            }
            return default(EduLoan);
        }

        public LoanStatus GetLoanStatusDAL(string loanID)
        {
            List<EduLoan> eduLoans = DeserializeFromJSON("EduLoans.txt");
            foreach (EduLoan Loan in eduLoans)
            {
                if (Loan.LoanID.ToString().Equals(loanID) == true)
                    return Loan.Status;
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

        public List<EduLoan> ListAllLoans()
        {
            List<EduLoan> eduLoans = DeserializeFromJSON("EduLoans.txt");
            return eduLoans;
        }

        public bool isLoanIDExistDAL(string loanID)
        {
            List<EduLoan> loans = DeserializeFromJSON("EduLoans.txt");
            foreach (var loan in loans)
            {
                if (loan.LoanID.Equals(loanID))
                    return true;
            }
            return false;
        }


    }
}
