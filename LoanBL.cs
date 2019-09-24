using Capgemini.Pecunia.Entities;
using Capgemini.Pecunia.Exceptions;
using Capgemini.Pecunia.DataAccessLayer;
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;

namespace Capgemini.Pecunia.BusinessLayer
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

    public class EduLoanBL : BLbase<EduLoan> 
    {
        public async Task<bool> ApplyLoanBL(EduLoan edu)
        {
            //EduLoan edu = (EduLoan)(Object)obj;
            try
            {
                if (await Validate(edu))
                {
                    await Task.Run(() =>
                    {
                        //Guid guid = Guid.NewGuid();
                        edu.LoanID = Guid.NewGuid(); //"EDU" + guid.ToString();
                        edu.InterestRate = 10.65;
                        edu.EMI_Amount = BusinessLogicUtil.ComputeEMI(edu.AmountApplied, edu.RepaymentPeriod, edu.InterestRate);
                        edu.DateOfApplication = DateTime.Now;
                        edu.Status = (LoanStatus)0;
                        edu.RepaymentHoliday = 1;

                        EduLoanDAL eduDAL = new EduLoanDAL();
                        return eduDAL.ApplyLoanDAL(edu);
                    });
                }
            }
            catch
            {
                return false;
            }
            return false;
        }


        public async Task<EduLoan> ApproveLoanBL(string loanID, LoanStatus updatedStatus)
        {
            try
            {
                EduLoanDAL EduLoanDALobj = new EduLoanDAL();
                await Task.Run(() =>
                {
                    if (EduLoanDALobj.isLoanIDExistDAL(loanID) == false)
                        throw new InvalidStringException("Loan ID not found");
                });
                return EduLoanDALobj.ApproveLoanDAL(loanID, updatedStatus);
            }
            catch
            {
                return null;
            }
        }

        public async Task<EduLoan> GetLoanByCustomerID_BL(string customerID)
        {
            //if (BusinessLogicUtil.validate(customerID) == false)
            //    throw new InvalidStringException("Invalid customer ID");

            try { 
                EduLoanDAL EduLoanDALobj = new EduLoanDAL();

                await Task.Run(() =>
                {
                    CustomerDAL custDAL = new CustomerDAL();
                    if (custDAL.isCustomerIDExistDAL(customerID) == false)
                        throw new InvalidStringException("Customer ID not found");
                });

                return EduLoanDALobj.GetLoanByCustomerID_DAL(customerID);
            }
            catch
            {
                return null;
            }
        }

        public async Task<LoanStatus> GetLoanStatusBL(string loanID)
        {
            //if (BusinessLogicUtil.validate(loanID) == false)
            //    throw new InvalidStringException("Invalid loan ID");

            try
            {
                EduLoanDAL EduLoanDALobj = new EduLoanDAL();

                await Task.Run(() =>
                {
                    if (EduLoanDALobj.isLoanIDExistDAL(loanID) == false)
                        throw new InvalidStringException("Loan ID not found");
                });

                return EduLoanDALobj.GetLoanStatusDAL(loanID);
            }
            catch
            {
                return 0;
            }
        }

        public async Task<EduLoan> GetLoanByLoanID_BL(string loanID)
        {
            //if (BusinessLogicUtil.validate(loanID) == false)
            //    throw new InvalidStringException("Invalid loan ID");

            try
            {
                EduLoanDAL EduLoanDALobj = new EduLoanDAL();

                await Task.Run(() =>
                {
                    if (EduLoanDALobj.isLoanIDExistDAL(loanID) == false)
                        throw new InvalidStringException("Loan ID not found");
                });

                return EduLoanDALobj.GetLoanByLoanID_DAL(loanID);
            }
            catch
            {
                return null;
            }
        }
      
        
        protected async override Task<bool> Validate(EduLoan eduLoan)
        {
            bool valid = await base.Validate(eduLoan);

            if (valid == false)
                return valid;

            if (eduLoan.AmountApplied >= 2000001)
                throw new InvalidAmountException("Amount must be less than Rs. 20 Lakh");

            if (eduLoan.RepaymentPeriod > 8)
                throw new InvalidRangeException("Maximum Repayment period is 8 years");

            return valid;
        }

        public List<EduLoan> ListAllLoans()
        {
            EduLoanDAL loanDAL = new EduLoanDAL();
            return loanDAL.ListAllLoans();
        }

        public bool isLoanIDExistBL(string loanID)
        {
            EduLoanDAL loanDAL = new EduLoanDAL();
            return loanDAL.isLoanIDExistDAL(loanID);
        }

    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public class CarLoanBL : BLbase<CarLoan> //, ILoanBL
    {
        public async Task<bool> ApplyLoanBL(CarLoan car)
        {
            //CarLoan car = (CarLoan)(Object)obj;
            try {
                if (await Validate(car))
                {
                    await Task.Run(() =>
                    {
                        //Guid guid = Guid.NewGuid();
                        car.LoanID = Guid.NewGuid(); //"CAR" + guid.ToString();
                        car.InterestRate = 10.65;
                        car.EMI_Amount = BusinessLogicUtil.ComputeEMI(car.AmountApplied, car.RepaymentPeriod, car.InterestRate);
                        car.DateOfApplication = DateTime.Now;
                        car.Status = (LoanStatus)0;

                        CarLoanDAL carDAL = new CarLoanDAL();
                        return carDAL.ApplyLoanDAL(car);
                    });
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        public async Task<CarLoan> ApproveLoanBL(string loanID, LoanStatus updatedStatus)
        {
            //if (BusinessLogicUtil.validate(loanID) == false)
            //    throw new InvalidStringException("Invalid loan ID");

            try
            {
                CarLoanDAL carDAL = new CarLoanDAL();

                await Task.Run(() =>
                {
                    if (carDAL.isLoanIDExistDAL(loanID) == false)
                        throw new InvalidStringException("Loan ID not found");
                });

                return carDAL.ApproveLoanDAL(loanID, updatedStatus);
            }
            catch
            {
                return null;
            }
        }

        public async Task<CarLoan> GetLoanByCustomerID_BL(string customerID)
        {
            //if (BusinessLogicUtil.validate(customerID) == false)
            //    throw new InvalidStringException("Invalid customer ID");
            try
            {
                CarLoanDAL carDAL = new CarLoanDAL();

                await Task.Run(() =>
                {
                    CustomerDAL custDAL = new CustomerDAL();
                    if (custDAL.isCustomerIDExistDAL(customerID) == false)
                        throw new InvalidStringException("Customer ID not found");
                });

                return carDAL.GetLoanByCustomerID_DAL(customerID);
            }
            catch
            {
                return null;
            }
        }

        public async Task<CarLoan> GetLoanByLoanID_BL(string loanID)
        {
            //if (BusinessLogicUtil.validate(loanID) == false)
            //    throw new InvalidStringException("Invalid loan ID");
            try
            {
                CarLoanDAL carDAL = new CarLoanDAL();

                await Task.Run(() =>
                {
                    if (carDAL.isLoanIDExistDAL(loanID) == false)
                        throw new InvalidStringException("Loan ID not found");
                });

                return carDAL.GetLoanByLoanID_DAL(loanID);
            }
            catch
            {
                return null;
            }
        }

        public async Task<LoanStatus> GetLoanStatusBL(string loanID)
        {
            //if (BusinessLogicUtil.validate(loanID) == false)
            //    throw new InvalidStringException("Invalid loan ID");
            try
            {
                CarLoanDAL carDAL = new CarLoanDAL();

                await Task.Run(() =>
                {
                    if (carDAL.isLoanIDExistDAL(loanID) == false)
                        throw new InvalidStringException("Loan ID not found");
                });

                return carDAL.GetLoanStatusDAL(loanID);
            }
            catch
            {
                return 0;
            }

        }

        protected async override Task<bool> Validate(CarLoan carLoan)
        {
            bool valid = await base.Validate(carLoan);
            if (valid == false)
                return valid;

            if (carLoan.AmountApplied >= 2000001)
                throw new InvalidAmountException("Maximum loan amount is Rs.20 lakh");

            if (carLoan.RepaymentPeriod >= 11)
                throw new InvalidRangeException("Repayment period can be maximum of 10 years");

            if (carLoan.SalaryDeductions >= carLoan.GrossIncome)
                throw new InvalidAmountException("Salary deduction can't be greater than or equal to Gross salary");

            return valid;
        }


        public List<CarLoan> ListAllLoans()
        {
            CarLoanDAL loanDAL = new CarLoanDAL();
            return loanDAL.ListAllLoans();
        }

        public bool isLoanIDExistBL(string loanID)
        {
            CarLoanDAL loanDAL = new CarLoanDAL();
            return loanDAL.isLoanIDExistDAL(loanID);
        }


    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////

    public class HomeLoanBL : BLbase<HomeLoan>//, ILoanBL
    {
        public async Task<bool> ApplyLoanBL(HomeLoan home)
        {
            //HomeLoan home = (HomeLoan)(Object)obj;
            try
            {
                if (await Validate(home))
                {
                    await Task.Run(() =>
                    {
                        //Guid guid = Guid.NewGuid();
                        home.LoanID = Guid.NewGuid(); ;// "HOME" + guid.ToString();
                        home.InterestRate = 8.50;
                        home.EMI_Amount = BusinessLogicUtil.ComputeEMI(home.AmountApplied, home.RepaymentPeriod, home.InterestRate);
                        home.DateOfApplication = DateTime.Now;
                        home.Status = (LoanStatus)0; // APPLIED

                        HomeLoanDAL homeDAL = new HomeLoanDAL();
                        return homeDAL.ApplyLoanDAL(home);
                    });
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        public async Task<LoanStatus> GetLoanStatusBL(string loanID)
        {
            //if (BusinessLogicUtil.validate(loanID) == false)
            //    throw new InvalidStringException("Invalid Loan ID");

            try
            {
                HomeLoanDAL homeloanDALobj = new HomeLoanDAL();

                await Task.Run(() =>
                {
                    if (homeloanDALobj.isLoanIDExistDAL(loanID) == false)
                        throw new InvalidStringException("Loan ID not found");
                });

                return homeloanDALobj.GetLoanStatusDAL(loanID);
            }
            catch
            {
                return 0;
            }
        }

        public async Task<HomeLoan> GetLoanByCustomerID_BL(string customerID)
        {
            //if (BusinessLogicUtil.validate(customerID) == false)
            //    throw new InvalidStringException("Invalid Customer ID");
            try
            {
                HomeLoanDAL homeloanDALobj = new HomeLoanDAL();

                await Task.Run(() =>
                {
                    CustomerDAL custDAL = new CustomerDAL();
                    if (custDAL.isCustomerIDExistDAL(customerID) == false)
                        throw new InvalidStringException("customer ID not found");
                });

                return homeloanDALobj.GetLoanByCustomerID_DAL(customerID);
            }
            catch
            {
                return null;
            }
        }

        public async Task<HomeLoan> ApproveLoanBL(string loanID, LoanStatus updatedStatus)
        {
            //if (BusinessLogicUtil.validate(loanID) == false)
            //    throw new InvalidStringException("Invalid Loan ID");
            try
            {
                HomeLoanDAL homeloanDALobj = new HomeLoanDAL();
                await Task.Run(() =>
                {
                    if (homeloanDALobj.isLoanIDExistDAL(loanID) == false)
                        throw new InvalidStringException("Loan ID not found");
                });

                return homeloanDALobj.ApproveLoanDAL(loanID, updatedStatus);
            }
            catch
            {
                return null;
            }
        }

        public async Task<HomeLoan> GetLoanByLoanID_BL(string loanID)
        {
            //if (BusinessLogicUtil.validate(loanID) == false)
            //    throw new InvalidStringException("Invalid loan ID");
            try
            {
                HomeLoanDAL LoanDALobj = new HomeLoanDAL();
                await Task.Run(() =>
                {
                    if (LoanDALobj.isLoanIDExistDAL(loanID) == false)
                        throw new InvalidStringException("Loan ID not found");
                });

                return LoanDALobj.GetLoanByLoanID_DAL(loanID);
            }
            catch
            {
                return null;
            }
        }

        protected async override Task<bool> Validate(HomeLoan homeLoan)
        {
            bool valid = await base.Validate(homeLoan);

            if (valid == false)
                return valid;

            if (homeLoan.AmountApplied >= 2000001)
                throw new InvalidAmountException("Maximum loan amount is Rs.20 lakh");

            if (homeLoan.RepaymentPeriod >= 16)
                throw new InvalidRangeException("Repayment period can be maximum of 15 years");

            if (homeLoan.SalaryDeductions >= homeLoan.GrossIncome)
                throw new InvalidAmountException("Salary deduction can't be greater than or equal to Gross salary");

            if (homeLoan.ServiceYears < 5)
                throw new InvalidRangeException("Service experience must be minimum of 5 years");

            return valid;
        }

        

        public List<HomeLoan> ListAllLoans()
        {
            HomeLoanDAL loanDAL = new HomeLoanDAL();
            return loanDAL.ListAllLoans();
        }

        public bool isLoanIDExistBL(string loanID)
        {
            HomeLoanDAL loanDAL = new HomeLoanDAL();
            return loanDAL.isLoanIDExistDAL(loanID);
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
