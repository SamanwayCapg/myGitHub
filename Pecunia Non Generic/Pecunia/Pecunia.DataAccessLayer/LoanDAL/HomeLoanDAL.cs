using System.Collections.Generic;
using Capgemini.Pecunia.Entities;
using Newtonsoft.Json;
using System.IO;

namespace Capgemini.Pecunia.DataAccessLayer.LoanDAL
{
    public class HomeLoanDAL //: ILoanDAL
    {
        public static List<HomeLoan> HomeLoans;

        public bool ApplyLoanDAL(HomeLoan home)
        {
            //List<HomeLoan> loanList = new List<HomeLoan>();
            var loanList = DeserializeFromJSON("HomeLoans.txt");
            loanList.Add(home);
            return SerializeIntoJSON(loanList, "HomeLoans.txt");
        }

        public HomeLoan ApproveLoanDAL(string loanID, LoanStatus updatedStatus)
        {
            List<HomeLoan> homeLoans = DeserializeFromJSON("HomeLoans.txt");
            HomeLoan objToReturn = new HomeLoan();
            foreach (HomeLoan Loan in homeLoans)
            {
                if (Loan.LoanID.ToString().Equals(loanID) == true)
                {
                    Loan.Status = updatedStatus;
                    objToReturn = Loan;
                    break;
                }
            }

            SerializeIntoJSON(homeLoans, "HomeLoans.txt");
            return objToReturn;
        }

        public HomeLoan GetLoanByCustomerID_DAL(string customerID)
        {
            List<HomeLoan> homeLoans = DeserializeFromJSON("HomeLoans.txt");
            foreach (HomeLoan Loan in homeLoans)
            {
                if (Loan.CustomerID.ToString().Equals(customerID) == true)
                    return Loan;
            }
            return default(HomeLoan);
        }

        public HomeLoan GetLoanByLoanID_DAL(string loanID)
        {
            List<HomeLoan> homeLoans = DeserializeFromJSON("HomeLoans.txt");
            foreach (HomeLoan Loan in homeLoans)
            {
                if (Loan.LoanID.ToString().Equals(loanID) == true)
                    return Loan;
            }
            return default(HomeLoan);
        }

        public LoanStatus GetLoanStatusDAL(string loanID)
        {
            List<HomeLoan> homeLoans = DeserializeFromJSON("HomeLoans.txt");
            foreach (HomeLoan Loan in homeLoans)
            {
                if (Loan.LoanID.ToString().Equals(loanID) == true)
                    return Loan.Status;
            }
            return (LoanStatus)4;//LoanStatus for INVALID 
        }

        public static List<HomeLoan> DeserializeFromJSON(string FileName)
        {
            List<HomeLoan> homeLoans = JsonConvert.DeserializeObject<List<HomeLoan>>(File.ReadAllText(FileName));// Done to read data from file
            return homeLoans;
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

        public List<HomeLoan> ListAllLoans()
        {
            List<HomeLoan> homeLoans = DeserializeFromJSON("HomeLoans.txt");
            return homeLoans;
        }

        public bool IsLoanIDExistDAL(string loanID)
        {
            List<HomeLoan> loans = DeserializeFromJSON("HomeLoans.txt");
            foreach (var loan in loans)
            {
                if (loan.LoanID.Equals(loanID))
                    return true;
            }
            return false;
        }
    }
}
