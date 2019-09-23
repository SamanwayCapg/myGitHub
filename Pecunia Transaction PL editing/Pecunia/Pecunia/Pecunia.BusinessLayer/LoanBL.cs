using Pecunia.Entities;
using Pecunia.Exceptions;
using Pecunia.DataAccessLayer;
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;

namespace Pecunia.BusinessLayer
{/*
    public  interface ILoanBL
    {
        bool ApplyLoanBL<T> (T obj);
        LoanStatus GetLoanStatusBL<T> (string loanID);
        T GetLoanByCustomerID_BL<T> (string customerID);
        T GetLoanByLoanID_BL<T>(string loanID);
        T ApproveLoanBL<T>(string loanID, LoanStatus updatedStatus);
       
        

    }
    */

    /////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////

    public class EduLoanBL 
    {
        public bool ApplyLoanBL(EduLoan edu)
        {
            //EduLoan edu = (EduLoan)(Object)obj;
            if (validate(edu) == true)
            {
                edu.LoanID = "EDU" + BusinessLogicUtil.SystemDateToString();
                edu.InterestRate = 10.65;
                edu.EMI_Amount = BusinessLogicUtil.ComputeEMI(edu.AmountApplied, edu.RepaymentPeriod, edu.InterestRate);
                edu.DateOfApplication = DateTime.Now;
                edu.Status = (LoanStatus)0;
                edu.RepaymentHoliday = 1;

                EduLoanDAL eduDAL = new EduLoanDAL();
                return eduDAL.ApplyLoanDAL(edu);
            }
            return false;
        }
        

        public EduLoan ApproveLoanBL(string loanID, LoanStatus updatedStatus)
        {
            if (BusinessLogicUtil.validate(loanID) == false)
                throw new InvalidStringException("Invalid loan ID");

            EduLoanDAL EduLoanDALobj = new EduLoanDAL();
            return EduLoanDALobj.ApproveLoanDAL(loanID, updatedStatus);
        }

        public EduLoan GetLoanByCustomerID_BL(string customerID)
        {
            if (BusinessLogicUtil.validate(customerID) == false)
                throw new InvalidStringException("Invalid customer ID");

            EduLoanDAL EduLoanDALobj = new EduLoanDAL();
            return EduLoanDALobj.GetLoanByCustomerID_DAL(customerID);
        }

        public LoanStatus GetLoanStatusBL(string loanID)
        {
            if (BusinessLogicUtil.validate(loanID) == false)
                throw new InvalidStringException("Invalid loan ID");

            EduLoanDAL EduLoanDALobj = new EduLoanDAL();
            return EduLoanDALobj.GetLoanStatusDAL(loanID);
        }

        public EduLoan GetLoanByLoanID_BL(string loanID)
        {
            if (BusinessLogicUtil.validate(loanID) == false)
                throw new InvalidStringException("Invalid loan ID");

            EduLoanDAL EduLoanDALobj = new EduLoanDAL();
            return EduLoanDALobj.GetLoanByLoanID_DAL(loanID);
        }
      
        public bool validate(EduLoan edu)
        {
            if (BusinessLogicUtil.validate(edu.CustomerID) == false)
                throw new InvalidStringException("Invalid Customer ID");

            if (edu.AmountApplied >= 2000001)
                throw new InvalidAmountException("Maximum Education loan amount is Rs.20 lakh");

            if (edu.RepaymentPeriod >= 11)
                throw new InvalidRangeException("Repayment period can be maximum of 10 years");

            if (Regex.IsMatch(edu.InstituteName, "[a-zA-Z,]$") == false)
                throw new InvalidStringException("Institute name can contains alphabets and comma(,) only");

            if (Regex.IsMatch(edu.StudentID, "[a-zA-Z0-9]$") == false)
                throw new InvalidStringException("Student can consists of alphabets and digits only");

            
            return true;
        }


        public List<EduLoan> ListAllLoans()
        {
            EduLoanDAL loanDAL = new EduLoanDAL();
            return loanDAL.ListAllLoans();
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public class CarLoanBL : CarLoan //, ILoanBL
    {
        public bool ApplyLoanBL(CarLoan car)
        {
            //CarLoan car = (CarLoan)(Object)obj;
            if(validate(car) == true)
            {
                car.LoanID = "CAR" + BusinessLogicUtil.SystemDateToString();
                car.InterestRate = 10.65;
                car.EMI_Amount = BusinessLogicUtil.ComputeEMI(car.AmountApplied, car.RepaymentPeriod, car.InterestRate);
                car.DateOfApplication = DateTime.Now;
                car.Status = (LoanStatus)0;
                
                CarLoanDAL carDAL = new CarLoanDAL();
                return carDAL.ApplyLoanDAL(car);
            }
            return false;
        }

        public CarLoan ApproveLoanBL(string loanID, LoanStatus updatedStatus)
        {
            if (BusinessLogicUtil.validate(loanID) == false)
                throw new InvalidStringException("Invalid loan ID");

            CarLoanDAL carDAL = new CarLoanDAL();
            return carDAL.ApproveLoanDAL(loanID, updatedStatus);
        }

        public CarLoan GetLoanByCustomerID_BL(string customerID)
        {
            if (BusinessLogicUtil.validate(customerID) == false)
                throw new InvalidStringException("Invalid customer ID");

            CarLoanDAL carDAL = new CarLoanDAL();
            return carDAL.GetLoanByCustomerID_DAL(customerID);
        }

        public CarLoan GetLoanByLoanID_BL(string loanID)
        {
            if (BusinessLogicUtil.validate(loanID) == false)
                throw new InvalidStringException("Invalid loan ID");

            CarLoanDAL CarDAL = new CarLoanDAL();
            return CarDAL.GetLoanByLoanID_DAL(loanID);
        }

        public LoanStatus GetLoanStatusBL(string loanID)
        {
            if (BusinessLogicUtil.validate(loanID) == false)
                throw new InvalidStringException("Invalid loan ID");

            CarLoanDAL carDAL = new CarLoanDAL();
            return carDAL.GetLoanStatusDAL(loanID);

        }

        public bool validate(CarLoan car)
        {
            if (BusinessLogicUtil.validate(car.CustomerID) == false)
                throw new InvalidStringException("Invalid Customer ID");

            if (car.AmountApplied >= 2000001)
                throw new InvalidAmountException("Maximum loan amount is Rs.20 lakh");

            if (car.RepaymentPeriod >= 11)
                throw new InvalidRangeException("Repayment period can be maximum of 10 years");

            if (car.SalaryDeductions >= car.GrossIncome)
                throw new InvalidAmountException("Salary deduction can't be greater than or equal to Gross salary");

            return true;
        }

        public List<CarLoan> ListAllLoans()
        {
            CarLoanDAL loanDAL = new CarLoanDAL();
            return loanDAL.ListAllLoans();
        }

    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////

    public class HomeLoanBL : HomeLoan//, ILoanBL
    {
        public bool ApplyLoanBL(HomeLoan home)
        {
            //HomeLoan home = (HomeLoan)(Object)obj;
            if(validate(home) == true)
            {
                home.LoanID = "HOME" + BusinessLogicUtil.SystemDateToString();
                home.InterestRate = 8.50;
                home.EMI_Amount = BusinessLogicUtil.ComputeEMI(home.AmountApplied, home.RepaymentPeriod, home.InterestRate);
                home.DateOfApplication = DateTime.Now;
                home.Status = (LoanStatus)0; // APPLIED

                HomeLoanDAL homeDAL = new HomeLoanDAL();
                return homeDAL.ApplyLoanDAL(home);
            }
            return false;
        }

        public LoanStatus GetLoanStatusBL(string loanID)
        {
            if (BusinessLogicUtil.validate(loanID) == false)
                throw new InvalidStringException("Invalid Loan ID");

            HomeLoanDAL homeloanDALobj = new HomeLoanDAL();
            return homeloanDALobj.GetLoanStatusDAL(loanID);
        }

        public HomeLoan GetLoanByCustomerID_BL(string customerID)
        {
            if (BusinessLogicUtil.validate(customerID) == false)
                throw new InvalidStringException("Invalid Customer ID");

            HomeLoanDAL homeloanDALobj = new HomeLoanDAL();
            return homeloanDALobj.GetLoanByCustomerID_DAL(customerID);
        }

        public HomeLoan ApproveLoanBL(string loanID, LoanStatus updatedStatus)
        {
            if (BusinessLogicUtil.validate(loanID) == false)
                throw new InvalidStringException("Invalid Loan ID");

            HomeLoanDAL homeloanDALobj = new HomeLoanDAL();
            return homeloanDALobj.ApproveLoanDAL(loanID, updatedStatus);
        }

        public HomeLoan GetLoanByLoanID_BL(string loanID)
        {
            if (BusinessLogicUtil.validate(loanID) == false)
                throw new InvalidStringException("Invalid loan ID");

            HomeLoanDAL LoanDALobj = new HomeLoanDAL();
            return LoanDALobj.GetLoanByLoanID_DAL(loanID);
        }

        public bool validate(HomeLoan home)
        {
            if (BusinessLogicUtil.validate(home.CustomerID) == false)
                throw new InvalidStringException("Invalid Customer ID");

            if (home.AmountApplied >= 2000001)
                throw new InvalidAmountException("Maximum loan amount is Rs.20 lakh");

            if (home.RepaymentPeriod >= 16)
                throw new InvalidRangeException("Repayment period can be maximum of 15 years");

            if (home.SalaryDeductions >= home.GrossIncome)
                throw new InvalidAmountException("Salary deduction can't be greater than or equal to Gross salary");

            if (home.ServiceYears < 5)
                throw new InvalidRangeException("Service experience must be minimum of 5 years");

            return true;
        }

        public List<HomeLoan> ListAllLoans()
        {
            HomeLoanDAL loanDAL = new HomeLoanDAL();
            return loanDAL.ListAllLoans();
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public static class BusinessLogicUtil
    {
        public static bool validate(string ID)
        {
            //check if ID is a valid customerID or if a valid loanID
            if (Regex.IsMatch(ID, "[0-9]{14}$") == true || Regex.IsMatch(ID, "[EDU|HOME|CAR][0-9]{14}$") == true)
                return true;

            return false;
        }

        public static string SystemDateToString()
        {
            DateTime time = DateTime.Now;
            return time.ToString("yyyyMMddhhmmss");
        }

        public static double ComputeEMI(double Amount, int RepaymentPeriod, double InterestRate)
        {
            // implements simple interset 
            double TotalAmountToBePaid = Amount * (1 + (InterestRate / 100));
            int TotalMonths = RepaymentPeriod * 12;
            double EMI = TotalAmountToBePaid / (double)TotalMonths;

            Console.WriteLine($"total mounts to be paid {TotalAmountToBePaid}");
            return EMI;
        }

        public static DateTime validateDate(string dateFormat, string date)
        {
            DateTime Date;
            bool isValidDate = DateTime.TryParseExact(date, dateFormat, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out Date);
            if (isValidDate == true)
                return Date;
            else
                return default(DateTime);
        }

        public static bool validateAccountNo(string accountNo)
        {
            long accNo = long.Parse(accountNo);
            if ((accNo > 300000 && accNo < 399999) || (accNo > 400000 && accNo < 499999) || (accNo > 500000 && accNo < 599999))
                return true;
            else
                return false;
        }

        public static void ShowTransactionDetails(TransactionEntities transaction)
        {
            Console.WriteLine($"TransactionID:{transaction.TransactionID}");
            Console.WriteLine($"Customer ID:{transaction.CustomerID}");
            Console.WriteLine($"Account No:{transaction.AccountNo}");
            Console.WriteLine($"Amount:{transaction.Amount}");
            Console.WriteLine($"Debit/Credit:{transaction.Type}");
            Console.WriteLine($"Date of Transaction:{transaction.DateOfTransaction}");
            Console.WriteLine($"Mode:{transaction.Mode}");
            Console.WriteLine("------------------------------------------------------");
        }
    }



    /*
    public class LoanBL
    {
        public bool ApplyLoanBL(LoanEntities loan)
        {

            if (Regex.IsMatch(loan.CustomerID, "[0-9]{14}$") == false)
                throw new InvalidStringException("Customer ID must be of 14 digits!");

            if (loan.AmountApplied < 50000 || loan.AmountApplied > 10000000)
                throw new InvalidAmountException("Loan amount must be between Rs.50000 to Rs.10000000 !");

            if (loan.Tenure > 10)
                throw new InvalidRangeException("Tenure can be maximum of 10 years!");

           
                if ((int)loan.Type == 1 && loan.Income < 50000) // home loan
                    throw new InvalidAmountException("For applying home loan you must have minimum income of Rs.50000/month !");

                if((int)loan.Type == 2 && loan.Income < 30000) //car loan
                    throw new InvalidAmountException("For applying car loan you must have minimum income of Rs.30000/month !");
            
            LoanDAL loanDALobj = new LoanDAL(); 
            return loanDALobj.ApplyLoanDAL(loan);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////
        public bool GetLoanStatusBL(string loanID)
        {
            if (Regex.IsMatch(loanID, "[CARLOAN|HOMELOAN|EDULOAN][0-9]{14}$") == false)
                throw new InvalidStringException("Not a valid load ID!");

            LoanDAL loanDALobj = new LoanDAL();
            return loanDALobj.GetLoanStatusDAL(loanID);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public LoanEntities GetLoanByCustomerID_BL(string customerID)
        {
            if (Regex.IsMatch(customerID, "[0-9]{14}$") == false)
                throw new InvalidStringException("Not a valid customer ID");

            LoanDAL loanDALobj = new LoanDAL();
            return loanDALobj.GetLoanByCustomerID_DAL(customerID);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////
        public LoanEntities GetLoanByLoanID_BL(string loanID)
        {
            if (Regex.IsMatch(loanID, "[CARLOAN|HOMELOAN|EDULOAN][0-9]{14}$") == false)
                throw new InvalidStringException("Not a valid loan ID");

            LoanDAL loanDALobj = new LoanDAL();
            return loanDALobj.GetLoanByLoanID_DAL(loanID);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////
        public void ApproveLoanBL(string loanID)
        {
            if (Regex.IsMatch(loanID, "[CARLOAN|HOMELOAN|EDULOAN][0-9]{14}$") == false)
                throw new InvalidStringException("Not a valid loan ID");

            LoanDAL loanDALobj = new LoanDAL();
            loanDALobj.ApproveLoanDAL(loanID);
        }

    }


    /////////////////////////////////////////// 
    */
   
}
