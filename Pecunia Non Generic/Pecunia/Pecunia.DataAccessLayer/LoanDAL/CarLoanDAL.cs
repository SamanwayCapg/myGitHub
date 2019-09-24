using System.Collections.Generic;
using Capgemini.Pecunia.Entities;
using Newtonsoft.Json;
using System.IO;

namespace Capgemini.Pecunia.DataAccessLayer.LoanDAL
{
    public class CarLoanDAL //: ILoanDAL
    {
        public static List<CarLoan> CarLoans;
        public bool ApplyLoanDAL(CarLoan car)
        {
            //CarLoan car = (CarLoan)(object)obj;
            List<CarLoan> loanList = DeserializeFromJSON("CarLoans.txt");
            loanList.Add(car);
            return SerializeIntoJSON(loanList, "CarLoans.txt");
        }

        public CarLoan ApproveLoanDAL(string loanID, LoanStatus updatedStatus)
        {
            List<CarLoan> carLoans = DeserializeFromJSON("CarLoans.txt");
            CarLoan objToReturn = new CarLoan();
            foreach (var Loan in carLoans)
            {
                if (Loan.LoanID.ToString().Equals(loanID) == true)
                {
                    Loan.Status = updatedStatus;
                    objToReturn = Loan;
                    break;
                }
            }
            SerializeIntoJSON(carLoans, "CarLoans.txt");
            return objToReturn;
        }

        public CarLoan GetLoanByCustomerID_DAL(string customerID)
        {
            List<CarLoan> carLoans = DeserializeFromJSON("CarLoans.txt");
            foreach (CarLoan Loan in carLoans)
            {
                if (Loan.CustomerID.ToString().Equals(customerID) == true)
                    return Loan;
            }
            return default(CarLoan);
        }

        public CarLoan GetLoanByLoanID_DAL(string loanID)
        {
            List<CarLoan> carLoans = DeserializeFromJSON("CarLoans.txt");
            foreach (CarLoan Loan in carLoans)
            {
                if (Loan.LoanID.ToString().Equals(loanID) == true)
                    return Loan;
            }
            return default(CarLoan);
        }

        public LoanStatus GetLoanStatusDAL(string loanID)
        {
            List<CarLoan> carLoans = DeserializeFromJSON("CarLoans.txt");
            foreach (CarLoan Loan in carLoans)
            {
                if (Loan.LoanID.ToString().Equals(loanID) == true)
                    return Loan.Status;
            }
            return (LoanStatus)4;//LoanStatus for INVALID 
        }

        public static List<CarLoan> DeserializeFromJSON(string FileName)
        {
            List<CarLoan> carLoans = JsonConvert.DeserializeObject<List<CarLoan>>(File.ReadAllText(FileName));// Done to read data from file
            return carLoans;
        }

        public static bool SerializeIntoJSON(List<CarLoan> CarLoans, string fileName)
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

        public List<CarLoan> ListAllLoans()
        {
            List<CarLoan> carLoans = DeserializeFromJSON("CarLoans.txt");
            return carLoans;
        }

        public bool isLoanIDExistDAL(string loanID)
        {
            List<CarLoan> loans = DeserializeFromJSON("CarLoans.txt");
            foreach (var loan in loans)
            {
                if (loan.LoanID.Equals(loanID))
                    return true;
            }
            return false;
        }

    }
}
