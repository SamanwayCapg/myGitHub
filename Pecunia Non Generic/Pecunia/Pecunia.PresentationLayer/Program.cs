using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pecunia.Exceptions;
using Pecunia.Entities;
using Pecunia.BusinessLayer;
using System.Text.RegularExpressions;

namespace Pecunia.PresentationLayer
{
    public class Program{

        public static void Main() {
            LoanPresentationLayer loan = new LoanPresentationLayer();
            loan.MenuOfLoan();
        }
    }

    public class LoanPresentationLayer
    {
        
        public bool MenuOfLoan()
        {
            int input;
            ///////Loan level 1 Menu
            Console.WriteLine("---------Loan Menu --------");
            Console.WriteLine("1. Apply for loan");
            Console.WriteLine("2. Approve Loan (Admin Only!)");
            Console.WriteLine("3. Show Loan List");
            Console.WriteLine("4. Back");


            do
            {
                Console.WriteLine("Enter Your Choice");
                input = Convert.ToInt32(Console.ReadLine());
                if (input != 4) // at input = 4 menu exit
                {
                    switch (input)
                    {
                        case 1:
                            MenuOfApplyForLoan();
                            break;

                        case 2:
                            if (AdminLogin() == true)
                                MenuOfApproveLoan();
                            else
                                break;
                            break;

                        case 3:
                            MenuOfShowLoanList();
                            break;

                        default:
                            Console.WriteLine("Not a valid entry!");
                            break;
                    }
                }
            } while (input != 4);

            return true;
        }


        public void MenuOfShowLoanList()
        {
            int input;

            Console.WriteLine("------- List Loan Menu ----------");
            Console.WriteLine("1. Search by CustomerID");
            Console.WriteLine("2. Search by LoanID");
            Console.WriteLine("3. Back");

            do
            {
                Console.WriteLine("Enter your input");
                input = Convert.ToInt16(Console.ReadLine());

                if(input != 3)
                {
                    switch (input)
                    {
                        case 1:
                            GetLoanByCustomerID_PL();
                            break;

                        case 2:
                            GetLoanByLoanID_PL();
                            break;

                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }
                }
            } while (input != 3);
        }


        public void GetLoanByCustomerID_PL()
        {
            Console.WriteLine("Enter Customer ID:");
            string customerID = Console.ReadLine();

            
            bool loanFound = false;

            HomeLoanBL homeLoanBL = new HomeLoanBL();
            List<HomeLoan> homeLoans = homeLoanBL.ListAllLoans();
            foreach(var loan in homeLoans)
            {
                if (loan.CustomerID == customerID)
                {
                    Console.WriteLine($"loan ID:{loan.LoanID}");
                    loanFound = true;
                }
            }


            CarLoanBL carLoanBL = new CarLoanBL();
            List<CarLoan> carLoans = carLoanBL.ListAllLoans();
            foreach (var loan in carLoans)
            {
                if (loan.CustomerID == customerID)
                {
                    Console.WriteLine($"loan ID:{loan.LoanID}");
                    loanFound = true;
                }
            }


            EduLoanBL eduLoanBL = new EduLoanBL();
            List<EduLoan> eduLoans = eduLoanBL.ListAllLoans();
            foreach (var loan in eduLoans)
            {
                if (loan.CustomerID == customerID)
                {
                    Console.WriteLine($"loan ID:{loan.LoanID}");
                    loanFound = true;
                }
            }

            if(loanFound == false)
                Console.WriteLine($"No loan found for the {customerID}");
        }

        public void GetLoanByLoanID_PL()
        {
            Console.WriteLine("Enter Loan ID:");
            string loanID = Console.ReadLine();

            if(Regex.IsMatch(loanID, "[EDU][0-9]{14}") == true)
            {
                EduLoanBL loanBL = new EduLoanBL();
                List<EduLoan> loans = loanBL.ListAllLoans();
                foreach(var loan in loans)
                {
                    if(loan.LoanID == loanID)
                    {
                        Console.WriteLine("Loan Details:");
                        Console.WriteLine($"Loan ID:{loan.LoanID}");
                        Console.WriteLine($"Customer ID:{loan.CustomerID}");
                        Console.WriteLine($"Amount Applied:{loan.AmountApplied}");
                        Console.WriteLine($"Interest Rate:{loan.InterestRate}");
                        Console.WriteLine($"EMI:{loan.EMI_Amount}");
                        Console.WriteLine($"Repayment Period:{loan.RepaymentPeriod}");
                        Console.WriteLine($"Date of Application:{loan.DateOfApplication}");
                        Console.WriteLine($"Current Status:{loan.Status}");
                        Console.WriteLine($"Course of Study:{loan.Course}");
                        Console.WriteLine($"Institute Name:{loan.InstituteName}");
                        Console.WriteLine($"Student ID:{loan.StudentID}");
                        Console.WriteLine($"Repayment Holiday:{loan.RepaymentHoliday}");
                        break;
                    }
                }
            }
            else if (Regex.IsMatch(loanID, "[HOME][0-9]{14}") == true)
            {
                HomeLoanBL loanBL = new HomeLoanBL();
                List<HomeLoan> loans = loanBL.ListAllLoans();
                foreach (var loan in loans)
                {
                    if (loan.LoanID == loanID)
                    {
                        Console.WriteLine("Loan Details:");
                        Console.WriteLine($"Loan ID:{loan.LoanID}");
                        Console.WriteLine($"Customer ID:{loan.CustomerID}");
                        Console.WriteLine($"Amount Applied:{loan.AmountApplied}");
                        Console.WriteLine($"Interest Rate:{loan.InterestRate}");
                        Console.WriteLine($"EMI:{loan.EMI_Amount}");
                        Console.WriteLine($"Repayment Period:{loan.RepaymentPeriod}");
                        Console.WriteLine($"Date of Application:{loan.DateOfApplication}");
                        Console.WriteLine($"Current Status:{loan.Status}");
                        Console.WriteLine($"Occupation of Applicant:{loan.Occupation}");
                        Console.WriteLine($"Net Income per month:{loan.GrossIncome - loan.SalaryDeductions}");
                        Console.WriteLine($"Total service years:{loan.ServiceYears}");
                        break;
                    }
                }
            }
            else if (Regex.IsMatch(loanID, "[CAR][0-9]{14}") == true)
            {
                CarLoanBL loanBL = new CarLoanBL();
                List<CarLoan> loans = loanBL.ListAllLoans();
                foreach (var loan in loans)
                {
                    if (loan.LoanID == loanID)
                    {
                        Console.WriteLine("Loan Details:");
                        Console.WriteLine($"Loan ID:{loan.LoanID}");
                        Console.WriteLine($"Customer ID:{loan.CustomerID}");
                        Console.WriteLine($"Amount Applied:{loan.AmountApplied}");
                        Console.WriteLine($"Interest Rate:{loan.InterestRate}");
                        Console.WriteLine($"EMI:{loan.EMI_Amount}");
                        Console.WriteLine($"Repayment Period:{loan.RepaymentPeriod}");
                        Console.WriteLine($"Date of Application:{loan.DateOfApplication}");
                        Console.WriteLine($"Current Status:{loan.Status}");
                        Console.WriteLine($"Occupation of Applicant:{loan.Occupation}");
                        Console.WriteLine($"Net Income per month:{loan.GrossIncome - loan.SalaryDeductions}");
                        Console.WriteLine($"Vehicle Type:{loan.Vehicle}");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Not a valid Loan ID");
            }
        }
        public bool MenuOfApplyForLoan()
        {
            int input;
            ///////Loan level 1 Menu
            Console.WriteLine("--------- Apply Loan Menu --------");
            Console.WriteLine("1. Apply for a Home Loan");
            Console.WriteLine("2. Apply for a Car Loan");
            Console.WriteLine("3. Apply for a Educational Loan");
            Console.WriteLine("4. Back");

            do
            {
                Console.WriteLine("Enter your choice: ");
                input = Convert.ToInt32(Console.ReadLine());

                if (input != 4)
                {
                    switch (input)
                    {
                        case 1:
                            if (ApplyHomeLoan() == true)
                            {
                                Console.WriteLine("Loan Applied successfully");
                                Console.WriteLine("To get your loan ID, please press BACK and select SHOW LOAN LIST");
                            }
                            break;

                        case 2:
                            if( ApplyCarLoan() == true)
                            {
                                Console.WriteLine("Loan Applied successfully");
                                Console.WriteLine("To get your loan ID, please press BACK and select SHOW LOAN LIST");
                            }
                            break;

                        case 3:
                            if(ApplyEduLoan() == true)
                            {
                                Console.WriteLine("Loan Applied successfully");
                                Console.WriteLine("To get your loan ID, please press BACK and select SHOW LOAN LIST");
                            }
                            break;

                        default:
                            Console.WriteLine("Invalid Entry!");
                            break;
                    }
                }
            } while (input != 4);

            //MenuOfLoan();
            return true;
        }

        
        public bool ApplyEduLoan()
        {
            Console.WriteLine("--------Educational Loan Application---------");
            Console.WriteLine("If you don't have a customerID, please apply for one.");
            Console.WriteLine("Only registered customers are eligible for loans.");
            Console.WriteLine("If you are not a customer, hence need one, enter CustomerID as NEW (case sensitive)");

            string customerID, instituteName, studentID;
            double amountApplied;
            int repaymentPeriod;
            CourseType course;

            Console.WriteLine("Enter your CustomerID:");
            customerID = Console.ReadLine();
            if (customerID == "NEW")
            {
                MenuOfCustomer();
                return false;
            }

            Console.WriteLine("Enter amount of loan (in Rs.) you want to apply for:");
            amountApplied = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter Repayment Period (in years) you want to opt for:");
            repaymentPeriod = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Available choices (case sensitive)\nUNDERGRADUATE\nMASTERS\nPHD\nM_PHIL\nOTHERS ");
            Console.WriteLine("Enter type of your eductional degree:");
            string degree = Console.ReadLine();
            Enum.TryParse(degree, out course);

            Console.WriteLine("Enter Institute Name:");
            instituteName = Console.ReadLine();

            Console.WriteLine("Enter ID provided by your institution");
            studentID = Console.ReadLine();

            EduLoan newLoan = new EduLoan();
            newLoan.CustomerID = customerID;
            newLoan.AmountApplied = amountApplied;
            newLoan.RepaymentPeriod = repaymentPeriod;
            newLoan.Course = course;
            newLoan.InstituteName = instituteName;
            newLoan.StudentID = studentID;

            EduLoanBL newLoanBL = new EduLoanBL();
            return newLoanBL.ApplyLoanBL<EduLoan>(newLoan);
        }
        public bool ApplyCarLoan()
        {
            Console.WriteLine("--------Car Loan Application---------");
            Console.WriteLine("If you don't have a customerID, please apply for one.");
            Console.WriteLine("Only registered customers are eligible for loans.");
            Console.WriteLine("If you are not a customer, hence need one, enter CustomerID as NEW (case sensitive)");

            string customerID;
            double amountApplied, grossIncome, salaryDeduction;
            int repaymentPeriod;
            ServiceType currentOccupation;
            VehicleType EnumVehicle;

            Console.WriteLine("Enter your CustomerID:");
            customerID = Console.ReadLine();
            if (customerID == "NEW")
            {
                MenuOfCustomer();
                return false;
            }

            Console.WriteLine("Enter amount of loan (in Rs.) you want to apply for:");
            amountApplied = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter Repayment Period (in years) you want to opt for:");
            repaymentPeriod = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Available choices (case sensitive)\nAGRICULTURE\nBUSINESS\nOTHERS\nRETIRED\nSELF_EMPLOYED\nSERVICE\nOTHERS");
            Console.WriteLine("Enter your current occupation:");
            string occupation = Console.ReadLine();
            Enum.TryParse(occupation, out currentOccupation);
            
            Console.WriteLine("Enter your gross salary (Rs.) per month :");
            grossIncome = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter your salary deductions amount (Rs.):");
            salaryDeduction = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Available choices (case sensitive)\nTWO_WHEELER\nFOUR_WHEELER\nMULTI_AXLE\nOTHERS");
            Console.WriteLine("Enter vehicle type for which you wish to apply a loan:");
            string vehicle = Console.ReadLine();
            Enum.TryParse(vehicle, out EnumVehicle);

            CarLoan newLoan = new CarLoan();
            newLoan.CustomerID = customerID;
            newLoan.AmountApplied = amountApplied;
            newLoan.RepaymentPeriod = repaymentPeriod;
            newLoan.Occupation = currentOccupation;
            newLoan.GrossIncome = grossIncome;
            newLoan.SalaryDeductions = salaryDeduction;
            newLoan.Vehicle = EnumVehicle;

            CarLoanBL newLoanBL = new CarLoanBL();
            return newLoanBL.ApplyLoanBL<CarLoan>(newLoan);

        }

        public bool ApplyHomeLoan()
        {
            Console.WriteLine("--------Home Loan Application---------");
            Console.WriteLine("If you don't have a customerID, please apply for one");
            Console.WriteLine("Only registered customers are eligible for loans.");
            Console.WriteLine("If you are not a customer, hence need one, enter CustomerID as NEW (case sensitive)");

            string customerID;
            double amountApplied, grossIncome, salaryDeduction;
            int repaymentPeriod, serviceYears;
            ServiceType currentOccupation;

            Console.WriteLine("Enter your CustomerID:");
            customerID = Console.ReadLine();
            // in case customer dont have a ID
            if (customerID == "NEW")
            {
                MenuOfCustomer();
                return false;
            }

            Console.WriteLine("Enter amount of loan (in Rs.) you want to apply for:");
            amountApplied = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter Repayment Period (in years) you want to opt for:");
            repaymentPeriod = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Available choices (case sensitive)\nAGRICULTURE\nBUSINESS\nOTHERS\nRETIRED\nSELF_EMPLOYED\nSERVICE\nOTHERS");
            Console.WriteLine("Enter your current occupation:");
            string occupation = Console.ReadLine();
            Enum.TryParse(occupation, out currentOccupation);

            Console.WriteLine("Enter years of experience in your current occupation:");
            serviceYears = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Enter your gross salary (Rs.) per month :");
            grossIncome = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter your salary deductions amount (Rs.):");
            salaryDeduction = Convert.ToDouble(Console.ReadLine());

            HomeLoan newLoan = new HomeLoan();
            newLoan.CustomerID = customerID;
            newLoan.AmountApplied = amountApplied;
            newLoan.RepaymentPeriod = repaymentPeriod;
            newLoan.Occupation = currentOccupation;
            newLoan.ServiceYears = serviceYears;
            newLoan.GrossIncome = grossIncome;
            newLoan.SalaryDeductions = salaryDeduction;

            HomeLoanBL newLoanBL = new HomeLoanBL();
            return newLoanBL.ApplyLoanBL<HomeLoan>(newLoan);
        }

        public void MenuOfApproveLoan()
        {
            int input;
            string loanID;
            ///////Loan level 1 Menu
            Console.WriteLine("--------- Approve Loan Menu --------");
            Console.WriteLine("1. List of Non-approved Home Loan");
            Console.WriteLine("2. List of Non-approved Car Loan");
            Console.WriteLine("3. List of Non-approved Educational Loan");
            Console.WriteLine("4. Back");

            do
            {
                Console.WriteLine("Enter your choice: ");
                input = Convert.ToInt32(Console.ReadLine());

                if (input != 4)
                {
                    switch (input)
                    {
                        case 1:
                            ListNonApprovedLoans("HOME");
                            Console.WriteLine("Enter loanID to take action:");
                            loanID = Console.ReadLine();
                            ApproveLoanPL(loanID);
                            break;

                        case 2:
                            ListNonApprovedLoans("CAR");
                            Console.WriteLine("Enter loanID to take action:");
                            loanID = Console.ReadLine();
                            ApproveLoanPL(loanID);
                            break;

                        case 3:
                            ListNonApprovedLoans("EDU");
                            Console.WriteLine("Enter loanID to take action:");
                            loanID = Console.ReadLine();
                            ApproveLoanPL(loanID);
                            break;

                        default:
                            Console.WriteLine("Invalid entry!");
                            break;
                    }

                }
            } while (input != 4);

        }

        public void ListNonApprovedLoans(string typeOfLoan)
        {
            if(typeOfLoan == "HOME")
            {
                HomeLoanBL homeLoanBL = new HomeLoanBL();
                List<HomeLoan> homeLoans = homeLoanBL.ListAllLoans();
                foreach(var loan in homeLoans)
                {
                    // 3 is for Approved loans
                    if(loan.Status != (LoanStatus)3)
                        Console.WriteLine($"LoanID:{loan.LoanID} | Current Status:{loan.Status}"); 
                }
            }
            else if(typeOfLoan == "CAR")
            {
                CarLoanBL carLoanBL = new CarLoanBL();
                List<CarLoan> carLoans = carLoanBL.ListAllLoans();
                foreach (var loan in carLoans)
                {
                    // 3 is for Approved loans
                    if (loan.Status != (LoanStatus)3)
                        Console.WriteLine($"LoanID:{loan.LoanID} | Current Status:{loan.Status}");
                }
            }
            else if(typeOfLoan == "EDU")
            {
                EduLoanBL eduLoanBL = new EduLoanBL();
                List<EduLoan> eduLoans = eduLoanBL.ListAllLoans();
                foreach (var loan in eduLoans)
                {
                    // 3 is for Approved loans
                    if (loan.Status != (LoanStatus)3)
                        Console.WriteLine($"LoanID:{loan.LoanID} | Current Status:{loan.Status}");
                }
            }
            else
                Console.WriteLine("Input must be one of the following (case sensitive):\nHOME\nCAR\nEDU");
        }
        public void ApproveLoanPL(string loanID)
        {
            
            if(Regex.IsMatch(loanID, "[EDU][0-9]{14}") == true)
            {
                EduLoanBL eduLoanBL = new EduLoanBL();
                EduLoan eduLoan = new EduLoan();

                eduLoan = eduLoanBL.GetLoanByLoanID_BL<EduLoan>(loanID);
                Console.WriteLine("Current Status and Loan Details:");
                Console.WriteLine($"Loan ID:{eduLoan.LoanID}");
                Console.WriteLine($"Customer ID:{eduLoan.CustomerID}");
                Console.WriteLine($"Amount Applied:{eduLoan.AmountApplied}");
                Console.WriteLine($"EMI:{eduLoan.EMI_Amount}");
                Console.WriteLine($"Repayment Period:{eduLoan.RepaymentPeriod}");
                Console.WriteLine($"Date of Application:{eduLoan.DateOfApplication}");
                Console.WriteLine($"Current Status:{eduLoan.Status}");
                Console.WriteLine($"Course of Study:{eduLoan.Course}");
                Console.WriteLine($"Institute Name:{eduLoan.InstituteName}");
                Console.WriteLine($"Student ID:{eduLoan.StudentID}");

                LoanStatus updatedStatus;
                Console.WriteLine("Available Choices (Case Sensitive):\nAPPLIED\nPROCESSING\nREJECTED\nAPPROVED\nINVALID");
                Console.WriteLine("Enter the updated loan status");
                string updatedStatusStr = Console.ReadLine();
                Enum.TryParse(updatedStatusStr, out updatedStatus);

                eduLoan = eduLoanBL.ApproveLoanBL<EduLoan>(loanID, updatedStatus);
                Console.WriteLine($"New Status of {loanID} is {eduLoan.Status}");

            }
            else if(Regex.IsMatch(loanID, "[CAR][0-9]{14}") == true)
            {
                CarLoanBL carLoanBL = new CarLoanBL();
                CarLoan carLoan = new CarLoan();

                carLoan = carLoanBL.GetLoanByLoanID_BL<CarLoan>(loanID);
                Console.WriteLine("Current Status and Loan Details:");
                Console.WriteLine($"Loan ID:{carLoan.LoanID}");
                Console.WriteLine($"Customer ID:{carLoan.CustomerID}");
                Console.WriteLine($"Amount Applied:{carLoan.AmountApplied}");
                Console.WriteLine($"EMI:{carLoan.EMI_Amount}");
                Console.WriteLine($"Repayment Period:{carLoan.RepaymentPeriod}");
                Console.WriteLine($"Date of Application:{carLoan.DateOfApplication}");
                Console.WriteLine($"Current Status:{carLoan.Status}");
                Console.WriteLine($"Occupation of Applicant:{carLoan.Occupation}");
                Console.WriteLine($"Net Income per month:{carLoan.GrossIncome - carLoan.SalaryDeductions}");
                Console.WriteLine($"Loan applied for {carLoan.Vehicle} type of vehicle");

                LoanStatus updatedStatus;
                Console.WriteLine("Available Choices (Case Sensitive):\nAPPLIED\nPROCESSING\nREJECTED\nAPPROVED\nINVALID");
                Console.WriteLine("Enter the updated loan status");
                string updatedStatusStr = Console.ReadLine();
                Enum.TryParse(updatedStatusStr, out updatedStatus);

                carLoan = carLoanBL.ApproveLoanBL<CarLoan>(loanID, updatedStatus);
                Console.WriteLine($"New Status of {loanID} is {carLoan.Status}");
            }
            else if(Regex.IsMatch(loanID, "[HOME][0-9]{14}") == true)
            {
                HomeLoanBL homeLoanBL = new HomeLoanBL();
                HomeLoan homeLoan = new HomeLoan();

                homeLoan = homeLoanBL.GetLoanByLoanID_BL<HomeLoan>(loanID);
                Console.WriteLine("Current Status and Loan Details:");
                Console.WriteLine($"Loan ID:{homeLoan.LoanID}");
                Console.WriteLine($"Customer ID:{homeLoan.CustomerID}");
                Console.WriteLine($"Amount Applied:{homeLoan.AmountApplied}");
                Console.WriteLine($"EMI:{homeLoan.EMI_Amount}");
                Console.WriteLine($"Repayment Period:{homeLoan.RepaymentPeriod}");
                Console.WriteLine($"Date of Application:{homeLoan.DateOfApplication}");
                Console.WriteLine($"Current Status:{homeLoan.Status}");
                Console.WriteLine($"Occupation of Applicant:{homeLoan.Occupation}");
                Console.WriteLine($"Net Income per month:{homeLoan.GrossIncome - homeLoan.SalaryDeductions}");
                Console.WriteLine($"Total service years:{homeLoan.ServiceYears}");

                LoanStatus updatedStatus;
                Console.WriteLine("Available Choices (Case Sensitive):\nAPPLIED\nPROCESSING\nREJECTED\nAPPROVED\nINVALID");
                Console.WriteLine("Enter the updated loan status");
                string updatedStatusStr = Console.ReadLine();
                Enum.TryParse(updatedStatusStr, out updatedStatus);

                homeLoan = homeLoanBL.ApproveLoanBL<HomeLoan>(loanID, updatedStatus);
                Console.WriteLine($"New Status of {loanID} is {homeLoan.Status}");
            }
            else
            {
                Console.WriteLine("Please enter a valid loan ID");
            }
        }
        public bool AdminLogin()
        {
            return true;
        }

        public void MenuOfCustomer()
        {
            Console.WriteLine("Customer Menu here");
        }
    }
}
