using System.Collections.Generic;
using Capgemini.Pecunia.Entities;
using Newtonsoft.Json;
using System.IO;
using System;
using Pecunia.Contracts.DALcontracts.LoanDALBase;

namespace Capgemini.Pecunia.DataAccessLayer.LoanDAL
{
    public class CarLoanDAL : CarLoanDALBase, IDisposable
    {
        public static List<CarLoan> CarLoans;
        public override bool ApplyLoanDAL(CarLoan car)
        {
            //CarLoan car = (CarLoan)(object)obj;
            List<CarLoan> loanList = DeserializeFromJSON("CarLoans.txt");
            loanList.Add(car);
            return SerializeIntoJSON(loanList, "CarLoans.txt");
        }

        public override CarLoan ApproveLoanDAL(string loanID, LoanStatus updatedStatus)
        {
            List<CarLoan> carLoans = DeserializeFromJSON("CarLoans.txt");
            CarLoan objToReturn = new CarLoan();

            Guid loanIDGuid;
            bool isValidGuid = Guid.TryParse(loanID, out loanIDGuid);

            if (isValidGuid == true)
            {
                foreach (var Loan in carLoans)
                {
                    if (loanIDGuid == Loan.LoanID)
                    {
                        Loan.Status = updatedStatus;
                        objToReturn = Loan;
                        break;
                    }
                }
            }
            SerializeIntoJSON(carLoans, "CarLoans.txt");
            return objToReturn;
        }

        public override CarLoan GetLoanByCustomerIDDAL(string customerID)
        {
            List<CarLoan> carLoans = DeserializeFromJSON("CarLoans.txt");
            Guid customerIDGuid;
            bool isValidGuid = Guid.TryParse(customerID, out customerIDGuid);

            if (isValidGuid == true)
            {
                foreach (CarLoan Loan in carLoans)
                {
                    if (customerIDGuid == Loan.CustomerID)
                        return Loan;
                }
            }
            return default(CarLoan);
        }

        public override CarLoan GetLoanByLoanIDDAL(string loanID)
        {
            List<CarLoan> carLoans = DeserializeFromJSON("CarLoans.txt");
            Guid loanIDGuid;
            bool isValidGuid = Guid.TryParse(loanID, out loanIDGuid);

            if (isValidGuid == true)
            {
                foreach (CarLoan Loan in carLoans)
                {
                    if (loanIDGuid == Loan.LoanID)
                        return Loan;
                }
            }
            return default(CarLoan);
        }

        public override LoanStatus GetLoanStatusDAL(string loanID)
        {
            List<CarLoan> carLoans = DeserializeFromJSON("CarLoans.txt");
            Guid loanIDGuid;
            bool isValidGuid = Guid.TryParse(loanID, out loanIDGuid);

            if (isValidGuid == true)
            {
                foreach (CarLoan Loan in carLoans)
                {
                    if (loanIDGuid == Loan.LoanID)
                        return Loan.Status;
                }
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

        public override List<CarLoan> ListAllLoansDAL()
        {
            List<CarLoan> carLoans = DeserializeFromJSON("CarLoans.txt");
            return carLoans;
        }

        public override bool IsLoanIDExistDAL(string loanID)
        {
            List<CarLoan> loans = DeserializeFromJSON("CarLoans.txt");

            Guid loanIDGuid;
            bool isValidGuid = Guid.TryParse(loanID, out loanIDGuid);

            if (isValidGuid == true)
            {
                foreach (var loan in loans)
                {
                    if (loanIDGuid == loan.LoanID)
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
