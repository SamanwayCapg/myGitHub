using System;
using System.Collections.Generic;
using Pecunia.Entities;
using Newtonsoft.Json;
using System.IO;

namespace Pecunia.DataAccessLayer
{
   /* public interface ILoanDAL
    {
        bool ApplyLoanDAL<T>(T obj);
        LoanStatus GetLoanStatusDAL<T>(string loanID);
        Object GetLoanByCustomerID_DAL<T>(string customerID);
        Object ApproveLoanDAL<T>(string loanID, LoanStatus updatedStatus);
        Object GetLoanByLoanID_DAL<T>(string loanID);
        
    }*/




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
                if (Loan.LoanID == loanID)
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
                if (Loan.CustomerID == customerID)
                    return Loan;
            }
            return default(EduLoan);
        }

        public EduLoan GetLoanByLoanID_DAL(string loanID)
        {
            List<EduLoan> eduLoans = DeserializeFromJSON("EduLoans.txt");
            foreach (EduLoan Loan in eduLoans)
            {
                if (Loan.LoanID == loanID)
                    return Loan;
            }
            return default(EduLoan);
        }

        public LoanStatus GetLoanStatusDAL(string loanID)
        {
            List<EduLoan> eduLoans = DeserializeFromJSON("EduLoans.txt");
            foreach (EduLoan Loan in eduLoans)
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
            try
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

        
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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
            foreach(var Loan in carLoans)
            {
                if (Loan.LoanID == loanID)
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
                if (Loan.CustomerID == customerID)
                    return Loan;
            }
            return default(CarLoan);
        }

        public CarLoan GetLoanByLoanID_DAL(string loanID)
        {
            List<CarLoan> carLoans = DeserializeFromJSON("CarLoans.txt");
            foreach (CarLoan Loan in carLoans)
            {
                if (Loan.LoanID == loanID)
                    return Loan;
            }
            return default(CarLoan);
        }

        public LoanStatus GetLoanStatusDAL(string loanID)
        {
            List<CarLoan> carLoans = DeserializeFromJSON("CarLoans.txt");
            foreach (CarLoan Loan in carLoans)
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
            try
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

    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
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
                if (Loan.LoanID == loanID)
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
                if (Loan.CustomerID == customerID)
                    return Loan;
            }
            return default(HomeLoan);
        }

        public HomeLoan GetLoanByLoanID_DAL(string loanID)
        {
            List<HomeLoan> homeLoans = DeserializeFromJSON("HomeLoans.txt");
            foreach (HomeLoan Loan in homeLoans)
            {
                if (Loan.LoanID == loanID)
                    return Loan;
            }
            return default(HomeLoan);
        }

        public LoanStatus GetLoanStatusDAL(string loanID)
        {
            List<HomeLoan> homeLoans = DeserializeFromJSON("HomeLoans.txt");
            foreach (HomeLoan Loan in homeLoans)
            {
                if (Loan.LoanID == loanID)
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
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    


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
                   