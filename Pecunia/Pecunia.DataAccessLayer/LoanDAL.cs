using System;
using System.Collections.Generic;
using Pecunia.Entities;
using Newtonsoft.Json;
using System.IO;

namespace Pecunia.DataAccessLayer
{
    public interface ILoanDAL
    {
        bool ApplyLoanDAL<T>(T obj);
        LoanStatus GetLoanStatusDAL<T>(string loanID);
        Object GetLoanByCustomerID_DAL<T>(string customerID);
        Object ApproveLoanDAL<T>(string loanID, LoanStatus updatedStatus);
        Object GetLoanByLoanID_DAL<T>(string loanID);
        
    }

    public class CarLoanDAL : ILoanDAL
    {
        public static List<CarLoan> CarLoans;
        public bool ApplyLoanDAL<T>(T obj)
        {
            CarLoan car = (CarLoan)(object)obj;
            List<CarLoan> loanList = DeserializeFromJSON("CarLoans.txt");
            loanList.Add(car);
            return SerializeIntoJSON(loanList, "CarLoans.txt");
        }

        public Object ApproveLoanDAL<T>(string loanID, LoanStatus updatedStatus)
        {
            List<CarLoan> carLoans = DeserializeFromJSON("CarLoans.txt");
            foreach(var Loan in carLoans)
            {
                if (Loan.LoanID == loanID)
                {
                    Loan.Status = updatedStatus;
                    return Loan;
                }
            }
            return default(CarLoan);
        }

        public Object GetLoanByCustomerID_DAL<T>(string customerID)
        {
            List<CarLoan> carLoans = DeserializeFromJSON("CarLoans.txt");
            foreach (var Loan in carLoans)
            {
                if (Loan.CustomerID == customerID)
                    return Loan;
            }
            return default(CarLoan);
        }

        public Object GetLoanByLoanID_DAL<T>(string loanID)
        {
            List<CarLoan> carLoans = DeserializeFromJSON("CarLoans.txt");
            foreach (var Loan in carLoans)
            {
                if (Loan.LoanID == loanID)
                    return Loan;
            }
            return default(CarLoan);
        }

        public LoanStatus GetLoanStatusDAL<T>(string loanID)
        {
            List<CarLoan> carLoans = DeserializeFromJSON("CarLoans.txt");
            foreach (var Loan in carLoans)
            {
                if (Loan.LoanID == loanID)
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
                JsonSerializer serializer = new JsonSerializer();
                using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs))   //filename is used so that we can have access over our own file
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, CarLoans); 
                    return true;
                }
        }

    }

    public class HomeLoanDAL : ILoanDAL
    {
        public static List<HomeLoan> HomeLoans;

        public bool ApplyLoanDAL<HomeLoan>(HomeLoan obj)
        {
            throw new NotImplementedException();
        }

        public HomeLoan ApproveLoanDAL<HomeLoan>(string loanID)
        {
            throw new NotImplementedException();
        }

        public HomeLoan GetLoanByCustomerID_DAL<HomeLoan>(string customerID)
        {
            throw new NotImplementedException();
        }

        public HomeLoan GetLoanByLoanID_DAL<HomeLoan>(string loanID)
        {
            throw new NotImplementedException();
        }

        public HomeLoan GetLoanStatusDAL<HomeLoan>(string loanID)
        {
            throw new NotImplementedException();
        }
    }

    public class EduLoanDAL : ILoanDAL
    {
        public static List<EduLoan> EduLoans;

        public bool ApplyLoanDAL<T>(T obj)
        {
            EduLoan edu = (EduLoan)(object)obj;
            List<EduLoan> loanList = DeserializeFromJSON("EduLoans.txt");
            loanList.Add(edu);
            return SerializeIntoJSON(loanList, "EduLoans.txt");
        }

        public Object ApproveLoanDAL<T>(string loanID, LoanStatus updatedStatus)
        {
            List<EduLoan> eduLoans = DeserializeFromJSON("EduLoans.txt");
            foreach (var Loan in eduLoans)
            {
                if (Loan.LoanID == loanID)
                {
                    Loan.Status = updatedStatus;
                    return Loan;
                }
            }
            return default(EduLoan);
        }

        public Object GetLoanByCustomerID_DAL<T>(string customerID)
        {
            List<EduLoan> eduLoans = DeserializeFromJSON("EduLoans.txt");
            foreach (var Loan in eduLoans)
            {
                if (Loan.CustomerID == customerID)
                    return Loan;
            }
            return default(EduLoan);
        }

        public Object GetLoanByLoanID_DAL<T>(string loanID)
        {
            throw new NotImplementedException();
        }

        public LoanStatus GetLoanStatusDAL<T>(string loanID)
        {
            List<EduLoan> eduLoans = DeserializeFromJSON("EduLoans.txt");
            foreach (var Loan in eduLoans)
            {
                if (Loan.LoanID == loanID)
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
            JsonSerializer serializer = new JsonSerializer();
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))   //filename is used so that we can have access over our own file
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, eduLoans);
                return true;
            }
        }
    }


    /*
    public class LoanDAL
    {
        static List<LoanEntities> Loans = new List<LoanEntities>();
        public bool ApplyLoanDAL(LoanEntities loan)
        {
            try
            {
                
                DateTime time = DateTime.Now;
                string currentTime = time.ToString("yyyyMMddhhmmss");

                if ((int)loan.Type == 0)
                {//eduloan
                    loan.LoanID = "EDU" + currentTime; //string concatenation loanID sample : EDULOAN20190912101552
                    loan.InterestRate = 10;
                }
                else if ((int)loan.Type == 1)
                { //homeloan
                    loan.LoanID = "HOME" + currentTime; //string concatenation loanID sample : HOMELOAN20190912101552
                    loan.InterestRate = 10.85;
                }
                else//car loan
                {
                    loan.LoanID = "CAR" + currentTime; //string concatenation loanID sample : CARLOAN20190912101552
                    loan.InterestRate = 8;
                }
                
                loan.DateOfApplication = time;
                loan.Status = (LoanStatus)Enum.Parse(typeof(LoanStatus), "APPLIED");

                Loans.Add(loan);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool GetLoanStatusDAL(string loanID)
        {
            try
            {
                foreach (LoanEntities loan in Loans)
                {
                    if (loan.LoanID.Equals(loanID))
                    {
                        Console.WriteLine(loan.Status);
                        break;
                    }
                }
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////
        public LoanEntities GetLoanByCustomerID_DAL(string customerID)
        {
            foreach(LoanEntities loan in Loans)
            {
                if (loan.CustomerID.Equals(customerID) == true)
                    return loan;
            }

            //// if not found return a null object
            LoanEntities emptyObj = new LoanEntities();
            return emptyObj;
        }

        ////////////////////////////////////////////////////////////////////////////////
        public LoanEntities GetLoanByLoanID_DAL(string loanID)
        {
            foreach (LoanEntities loan in Loans)
            {
                if (loan.LoanID.Equals(loanID) == true)
                    return loan;
            }

            //// if not found return a null object
            LoanEntities emptyObj = new LoanEntities();
            return emptyObj;
        }

        ////////////////////////////////////////////////////////////////////////////////
        public void ApproveLoanDAL(string loanID)
        {
            try
            {
                foreach (LoanEntities loan in Loans)
                {
                    if (loan.LoanID.Equals(loanID))
                    {
                        Console.WriteLine("Current status of loan is as follows : ");
                        Console.WriteLine("Cusotmer ID : " + loan.CustomerID);
                        Console.WriteLine("Income : " + loan.Income);
                        Console.WriteLine("Amount Applied : " + loan.AmountApplied);
                        Console.WriteLine("Interest Rate : " + loan.InterestRate);
                        Console.WriteLine("Applied EMI : " + loan.EMI);
                        Console.WriteLine("Tenure : " + loan.Tenure);
                        Console.WriteLine("Date of application : " + loan.DateOfApplication);
                        Console.WriteLine("Types : " + loan.Type);
                        Console.WriteLine("Current Status : " + loan.Status);

                        Console.WriteLine("Enter modified status");
                        string modStatus = Console.ReadLine();
                        LoanStatus modStatusEnum;
                        bool isValid = Enum.TryParse(modStatus, out modStatusEnum);
                        if (isValid == true)
                            loan.Status = modStatusEnum;
                        else
                            Console.WriteLine("Not a valid loan status!");
                        break;
                    }
                }
            }
            catch(Exception e)
            {

            }
            
                
        }
    }
    */
}
                   