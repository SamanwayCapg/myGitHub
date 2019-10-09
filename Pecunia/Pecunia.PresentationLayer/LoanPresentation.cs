using System;
using System.Collections.Generic;
using Capgemini.Pecunia.Exceptions;
using Capgemini.Pecunia.Entities;
using Capgemini.Pecunia.BusinessLayer;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Capgemini.Pecunia.BusinessLayer.LoanBL;

namespace Capgemini.Pecunia.PresentationLayer
{
    /*public class LoanPL{
        [STAThread]
        public static void Main(string[] args)
        {
            LoanPresentationLayer loan = new LoanPresentationLayer();
            loan.MenuOfLoan().Wait();
        }
    }*/

    public class LoanPresentation
    {
        
        public async Task<bool> MenuOfLoan()
        {
           
            int input;
            ///////Loan level 1 Menu
            do
            {
                Console.Clear();
                Console.WriteLine("---------Loan Menu --------");
                Console.WriteLine("1. Apply for loan");
                //Console.WriteLine("2. Approve Loan (Admin Only!)");
                Console.WriteLine("2. Show Loan List");
                Console.WriteLine("3. Back");

                
                Console.WriteLine("Enter Your Choice");
                input = Convert.ToInt32(Console.ReadLine());
                if (input != 3) // at input = 4 menu exit
                {
                    switch (input)
                    {
                        case 1:
                            await MenuOfApplyForLoan();
                            break;

                        /*case 2:
                            if (AdminLogin() == true)
                                await MenuOfApproveLoan();
                            else
                            {
                                Console.WriteLine("Invalid Credential!\nPress any key -> Previous Menu");
                                Console.ReadKey();
                                await MenuOfLoan();
                                break;
                            }
                            break;
                            */
                        case 2:
                            await MenuOfShowLoanList();
                            break;

                        default:
                            Console.WriteLine("Not a valid entry!\nPress any key -> Continue");
                            Console.ReadKey();
                            break;
                    }
                }
            } while (input != 3);

            return true;
        }


        public async Task<bool> MenuOfShowLoanList()
        {
            
            int input;
            do
            {
                Console.Clear();
                Console.WriteLine("------- List Loan Menu ----------");
                Console.WriteLine("1. Search by CustomerID");
                Console.WriteLine("2. Search by LoanID");
                Console.WriteLine("3. Show LoanID with Status");
                Console.WriteLine("4. Back");


                Console.WriteLine("Enter your input");
                input = Convert.ToInt16(Console.ReadLine());

                if(input != 4)
                {
                    switch (input)
                    {
                        case 1:
                            if (await GetLoanByCustomerID_PL() == true)
                                return true;
                            else
                                await MenuOfShowLoanList();
                            break;

                        case 2:
                            if (await GetLoanByLoanID_PL() == true)
                                return true;
                            else
                                await MenuOfShowLoanList();
                            break;

                        case 3:
                            //if (AdminLogin() == true)
                            //{
                                if (ListAllLoan_PL() == true)
                                    return true;
                                else
                                    await MenuOfShowLoanList();
                            //}
                           /* else
                            {
                                Console.WriteLine("Invalid Credential\nPress any key -> Previous Menu");
                                Console.ReadKey();
                                await MenuOfShowLoanList();
                            }*/
                            break;

                        default:
                            Console.WriteLine("Not a valid entry!\nPress any key -> Continue");
                            Console.ReadKey();
                            break;
                    }
                }
            } while (input != 4);

            return true;
        }

        private bool ListAllLoan_PL()
        {
            Console.Clear();
            Console.WriteLine("                     ALL LOANS");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("# | Loan ID                              | Type | Status");
            Console.WriteLine("-------------------------------------------------------");
            bool isLoanFound = false;
            int loanCount = 1;

            // printing educational loans with ID and current status
            EduLoanBL edu = new EduLoanBL();
            List<EduLoan> eduLoans = edu.ListAllLoans();
            foreach (EduLoan loan in eduLoans)
            {   
                isLoanFound = true;
                Console.WriteLine($"{loanCount++} | {loan.LoanID} | EDU  | {loan.Status}");
            }

            // printing car loans with ID and current status
            CarLoanBL car = new CarLoanBL();
            List<CarLoan> carLoans = car.ListAllLoans();
            foreach (CarLoan loan in carLoans)
            {
                isLoanFound = true;
                Console.WriteLine($"{loanCount++} | {loan.LoanID} | CAR  | {loan.Status}");
            }

            // printing home loans with ID and current status
            EduLoanBL home = new EduLoanBL();
            List<EduLoan> EduLoans = home.ListAllLoans();
            foreach (EduLoan loan in EduLoans)
            {
                isLoanFound = true;
                Console.WriteLine($"{loanCount++} | {loan.LoanID} | HOME | {loan.Status}");
            }

            // if there is not any type of loans applied at all
            if(isLoanFound == false)
                Console.WriteLine("No loans found");

            Console.WriteLine("Press any key -> Loan Menu");
            Console.ReadKey();
            return true;

        }

        public async Task<bool> GetLoanByCustomerID_PL()
        {
            Console.Clear();
            Console.WriteLine("                  Loans of Customer");
            Console.Write("Enter Customer ID:");
            string input = Console.ReadLine();

            Guid customerID;
            bool isGuid = Guid.TryParse(input, out customerID);

            if(isGuid == false)
            {
                Console.WriteLine("not a valid customer id\nPress any key -> Try Again");
                Console.ReadKey();
                return false;
            }

            // if customerID is not found in customer DB
            CustomerBL cust = new CustomerBL();
            bool isExist = await cust.isCustomerIDExistBL(customerID);
            if (isExist == false)
            {
                Console.WriteLine($"No customer found in database as {customerID}\nPress any key -> Search Again");
                Console.ReadKey();
                return false;
            }
            bool loanFound = false;

            //searching if the customer has any EduLoan
            EduLoanBL EduLoanBL = new EduLoanBL();
            List<EduLoan> EduLoans = EduLoanBL.ListAllLoans();
            foreach(var loan in EduLoans)
            {
                if (loan.CustomerID == customerID)
                {
                    Console.WriteLine($"loan ID:{loan.LoanID}|Type:HOME -> Status:{loan.Status}");
                    loanFound = true;
                }
            }


            //searching if the customer has any carloan
            CarLoanBL carLoanBL = new CarLoanBL();
            List<CarLoan> carLoans = carLoanBL.ListAllLoans();
            foreach (var loan in carLoans)
            {
                if (loan.CustomerID == customerID)
                {
                    Console.WriteLine($"loan ID:{loan.LoanID}|Type:CAR -> Status:{loan.Status}");
                    loanFound = true;
                }
            }


            //searching if the customer has any eduloan
            EduLoanBL eduLoanBL = new EduLoanBL();
            List<EduLoan> eduLoans = eduLoanBL.ListAllLoans();
            foreach (var loan in eduLoans)
            {
                if (loan.CustomerID == customerID)
                {
                    Console.WriteLine($"loan ID:{loan.LoanID}|Type:EDU -> Status:{loan.Status}");
                    loanFound = true;
                }
            }

            if (loanFound == false)
            {
                Console.WriteLine($"No loan found in the records of {customerID}\nPress any key -> Search Again");
                Console.ReadKey();
                return false;
            }

            Console.WriteLine("Press any key -> Previous Menu");
            Console.ReadKey();
            return true;
        }

        public async Task<bool> GetLoanByLoanID_PL()
        {
            Console.Clear();
            Console.WriteLine("----------------- Search Loan with LoanID -----------------");
            Console.Write("Enter Loan ID:");
            string loanID = Console.ReadLine();
            bool loanFound = false;

            EduLoanBL eduLoan = new EduLoanBL();
            HomeLoanBL homeLoan = new HomeLoanBL();
            CarLoanBL carLoan = new CarLoanBL();

            try
            {
                
                if (eduLoan.isLoanIDExistBL(loanID) == true)
                {
                    EduLoan loan = new EduLoan();
                    EduLoanBL loanBL = new EduLoanBL();
                    loan = await loanBL.GetLoanByLoanIDBL(loanID);

                    Console.WriteLine("Loan Details:");
                    Console.WriteLine($"Loan ID:{loan.LoanID}");
                    Console.WriteLine($"Customer ID:{loan.CustomerID}");
                    Console.WriteLine($"Amount Applied:Rs.{loan.AmountApplied}");
                    Console.WriteLine($"Interest Rate:{loan.InterestRate}% per annum");
                    Console.WriteLine($"EMI:Rs.{loan.EMI_Amount}/month");
                    Console.WriteLine($"Repayment Period:{loan.RepaymentPeriod} year(s)");
                    Console.WriteLine($"Date of Application:{loan.DateOfApplication}");
                    Console.WriteLine($"Current Status:{loan.Status}");
                    Console.WriteLine($"Course of Study:{loan.Course}");
                    Console.WriteLine($"Institute Name:{loan.InstituteName}");
                    Console.WriteLine($"Student ID:{loan.StudentID}");
                    Console.WriteLine($"Repayment Holiday:{loan.RepaymentHoliday}");
                    loanFound = true;

                }

                // if loanID is not found in eduloan list
                if (loanFound == false && homeLoan.IsLoanIDExistBL(loanID) == true )
                {
                    HomeLoan loan = new HomeLoan();
                    HomeLoanBL loanBL = new HomeLoanBL();
                    loan = await loanBL.GetLoanByLoanIDBL(loanID);

                    Console.WriteLine("Loan Details:");
                    Console.WriteLine($"Loan ID:{loan.LoanID}");
                    Console.WriteLine($"Customer ID:{loan.CustomerID}");
                    Console.WriteLine($"Amount Applied:Rs.{loan.AmountApplied}");
                    Console.WriteLine($"Interest Rate:{loan.InterestRate}% per annum");
                    Console.WriteLine($"EMI:Rs.{loan.EMI_Amount}/month");
                    Console.WriteLine($"Repayment Period:{loan.RepaymentPeriod} year(s)");
                    Console.WriteLine($"Date of Application:{loan.DateOfApplication}");
                    Console.WriteLine($"Current Status:{loan.Status}");
                    Console.WriteLine($"Occupation of Applicant:{loan.Occupation}");
                    Console.WriteLine($"Net Income per month:Rs.{loan.GrossIncome - loan.SalaryDeductions}");
                    Console.WriteLine($"Total service years:{loan.ServiceYears}");
                    loanFound = true;

                }

                // if loanID is not found in eduloan list as well as EduLoan list
                if (loanFound == false && carLoan.isLoanIDExistBL(loanID) == true)
                {
                    CarLoan loan = new CarLoan();
                    CarLoanBL loanBL = new CarLoanBL();
                    loan = await loanBL.GetLoanByLoanID_BL(loanID);

                    Console.WriteLine("Loan Details:");
                    Console.WriteLine($"Loan ID:{loan.LoanID}");
                    Console.WriteLine($"Customer ID:{loan.CustomerID}");
                    Console.WriteLine($"Amount Applied:Rs.{loan.AmountApplied}");
                    Console.WriteLine($"Interest Rate:{loan.InterestRate}% per annum");
                    Console.WriteLine($"EMI:Rs.{loan.EMI_Amount}/month");
                    Console.WriteLine($"Repayment Period:{loan.RepaymentPeriod} year(s)");
                    Console.WriteLine($"Date of Application:{loan.DateOfApplication}");
                    Console.WriteLine($"Current Status:{loan.Status}");
                    Console.WriteLine($"Occupation of Applicant:{loan.Occupation}");
                    Console.WriteLine($"Net Income per month:Rs.{loan.GrossIncome - loan.SalaryDeductions}");
                    Console.WriteLine($"Vehicle Type:{loan.Vehicle}");
                    loanFound = true;

                }
                else
                {
                    // nothing to do
                }

                if (loanFound == false)
                {
                    Console.WriteLine("Not a valid Loan ID\nPress any key -> Search Again");
                    Console.ReadKey();
                    return false;
                }

                Console.WriteLine("Press any key -> Previous Menu");
                Console.ReadKey();
                return true;
            }
            catch(InvalidStringException e)
            {
                Console.WriteLine($"{e.Message}\nPress any key -> List Loans");
                return false;
            }
        }
        public async Task<bool> MenuOfApplyForLoan()
        {
            int input;
            
            ///////Loan level 1 Menu
            do
            {
                bool result;
                Console.Clear();
                Console.WriteLine("--------- Apply Loan Menu --------");
                Console.WriteLine("1. Apply for a Home Loan");
                Console.WriteLine("2. Apply for a Car Loan");
                Console.WriteLine("3. Apply for a Educational Loan");
                Console.WriteLine("4. Back");

            
                Console.WriteLine("Enter your choice: ");
                input = Convert.ToInt32(Console.ReadLine());

                if (input != 4)
                {
                    switch (input)
                    {
                        case 1:
                            result = await ApplyHomeLoan();
                            if (result == true)
                            {
                                Console.WriteLine("Loan Applied successfully");
                                Console.WriteLine("To get your loan ID, please press BACK and select SHOW LOAN LIST");
                                Console.WriteLine("Press any key to get back to previous menu");
                                Console.ReadKey();
                                return true;
                            }// if operation unsuccessful get back to previous menu
                            else
                                await MenuOfApplyForLoan();
                            break;

                        case 2:
                            if( await ApplyCarLoan() == true)
                            {
                                Console.WriteLine("Loan Applied successfully");
                                Console.WriteLine("To get your loan ID, please press BACK and select SHOW LOAN LIST");
                                Console.WriteLine("Press any key to get back to previous menu");
                                Console.ReadKey();
                                return true;
                            }// if operation unsuccessful get back to previous menu
                            else
                                await MenuOfApplyForLoan();
                            break;

                        case 3:
                            result = await ApplyEduLoan();
                            if ( result == true)
                            {
                                Console.WriteLine("Loan Applied successfully");
                                Console.WriteLine("To get your loan ID, please press BACK and select SHOW LOAN LIST");
                                Console.WriteLine("Press any key to get back to previous menu");
                                Console.ReadKey();
                                return true;
                            }// if operation unsuccessful get back to previous menu
                            else
                                await MenuOfApplyForLoan();
                            break;

                        default:
                            Console.WriteLine("Not a valid entry!\nPress any key -> Continue");
                            Console.ReadKey();
                            break;
                    }
                }
            } while (input != 4);

            //MenuOfLoan();
            return true;
        }

        
        public async Task<bool> ApplyEduLoan()
        {
            Console.Clear();
            Console.WriteLine("--------Educational Loan Application---------");
            Console.WriteLine("If you don't have a customerID, please apply for one.");
            Console.WriteLine("Only registered customers are eligible for loans.");
            Console.WriteLine("If you are not a customer, hence need one, enter CustomerID as NEW (case sensitive)");

            Guid customerID;
            string instituteName, studentID;
            double amountApplied;
            int repaymentPeriod, courseDuration;
            CourseType course;
            bool isApplied;

            try
            {
                Console.Write("Enter your CustomerID:");
                string input = Console.ReadLine();
                bool isGuid = Guid.TryParse(input, out customerID);

                if (isGuid == false && string.Equals(input, "NEW", StringComparison.OrdinalIgnoreCase) == true)
                {
                    MenuOfCustomer();
                    Console.ReadKey();
                    return false;
                }

                if(isGuid == false)
                {
                    Console.WriteLine("not a valid customer id\nPress any key -> Try Again");
                    return false;
                }

                if (isGuid == true)
                {
                    Console.WriteLine("Maximum Loan Amount is Rs.20Lakh");
                    Console.Write("Enter amount of loan (in Rs.) you want to apply for:");
                    amountApplied = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Maximum Allowed Repayment Period is 96 months ");
                    Console.Write("Enter Repayment Period (in months) you want to opt for:");
                    repaymentPeriod = Convert.ToInt16(Console.ReadLine());

                    Console.WriteLine("Available choices (case sensitive)\nUNDERGRADUATE\nMASTERS\nPHD\nM_PHIL\nOTHERS ");
                    Console.Write("Enter type of your eductional degree:");
                    string degree = Console.ReadLine();
                    bool isValidCourseType = Enum.TryParse(degree, out course);

                    Console.Write("Enter Course Duration (years):");
                    courseDuration = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Only alphabets, digits and comma(,)");
                    Console.Write("Enter Institute Name:");
                    instituteName = Console.ReadLine();

                    Console.WriteLine("Only alphabets and digits");
                    Console.Write("Enter ID provided by your institution:");
                    studentID = Console.ReadLine();

                    if (isValidCourseType == false)
                    {
                        Console.WriteLine("Not a valid Course Type\nPress any key to get back to previous menu");
                        Console.ReadKey();
                        return false;
                    }

                    EduLoan newLoan = new EduLoan();
                    newLoan.CustomerID = customerID;
                    newLoan.AmountApplied = amountApplied;
                    newLoan.RepaymentPeriod = repaymentPeriod;
                    newLoan.Course = course;
                    newLoan.InstituteName = instituteName;
                    newLoan.StudentID = studentID;
                    newLoan.CourseDuration = courseDuration;

                    EduLoanBL newLoanBL = new EduLoanBL();
                    isApplied = await newLoanBL.ApplyLoanBL(newLoan);
                    return isApplied;
                }
            }
            catch(InvalidStringException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(InvalidAmountException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(InvalidRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            
            Console.WriteLine("Current Application Cancelled. Please Start a Fresh One");
            Console.ReadKey();
            return false;
            
        }

        public async Task<bool> ApplyCarLoan()
        {
            Console.Clear();
            Console.WriteLine("--------Car Loan Application---------");
            Console.WriteLine("If you don't have a customerID, please apply for one.");
            Console.WriteLine("Only registered customers are eligible for loans.");
            Console.WriteLine("If you are not a customer, hence need one, enter CustomerID as NEW (case sensitive)");

            Guid customerID;
            double amountApplied, grossIncome, salaryDeduction;
            int repaymentPeriod;
            ServiceType currentOccupation;
            VehicleType EnumVehicle;
            bool isApplied;

            try
            {
                Console.Write("Enter your CustomerID:");
                string input = Console.ReadLine();
                bool isGuid = Guid.TryParse(input, out customerID);
                if (isGuid == false && string.Equals(input, "NEW", StringComparison.OrdinalIgnoreCase) == true)
                {
                    MenuOfCustomer();
                    return false;
                }

                if(isGuid  == false)
                {
                    Console.WriteLine("Invalid customer ID\npress any key -> Try Again");
                    return false;
                }

                if (isGuid == true)
                {
                    Console.WriteLine("Maixmum Loan Amount is Rs.20 Lakh");
                    Console.Write("Enter amount of loan (in Rs.) you want to apply for:");
                    amountApplied = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Maximum Allowed Repayment Period is 120 months");
                    Console.Write("Enter Repayment Period (in months) you want to opt for:");
                    repaymentPeriod = Convert.ToInt16(Console.ReadLine());

                    Console.WriteLine("Available choices (case sensitive)\nAGRICULTURE\nBUSINESS\nOTHERS\nRETIRED\nSELF_EMPLOYED\nSERVICE\nOTHERS");
                    Console.Write("Enter your current occupation:");
                    string occupation = Console.ReadLine();
                    bool isValidOccupation = Enum.TryParse(occupation, out currentOccupation);

                    Console.Write("Enter your gross income (Rs.) per month :");
                    grossIncome = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Deductions must be less than gross income");
                    Console.Write("Enter your salary deductions amount (Rs.) per month:");
                    salaryDeduction = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Available choices (case sensitive)\nTWO_WHEELER\nFOUR_WHEELER\nMULTI_AXLE\nOTHERS");
                    Console.Write("Enter vehicle type for which you wish to apply a loan:");
                    string vehicle = Console.ReadLine();
                    bool isValidVehicle = Enum.TryParse(vehicle, out EnumVehicle);

                    if (isValidVehicle == false || isValidOccupation == false)
                    {
                        Console.WriteLine("Not a valid Vehicle Type or Occupation Type\nPress any key to get to previous menu to start a fresh application");
                        Console.ReadKey();
                        return false;
                    }

                    CarLoan newLoan = new CarLoan();
                    newLoan.CustomerID = customerID;
                    newLoan.AmountApplied = amountApplied;
                    newLoan.RepaymentPeriod = repaymentPeriod;
                    newLoan.Occupation = currentOccupation;
                    newLoan.GrossIncome = grossIncome;
                    newLoan.SalaryDeductions = salaryDeduction;
                    newLoan.Vehicle = EnumVehicle;

                    CarLoanBL newLoanBL = new CarLoanBL();
                    isApplied = await newLoanBL.ApplyLoanBL(newLoan);
                    return isApplied;
                }
            }
            catch(InvalidStringException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(InvalidRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(InvalidAmountException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Current Application Cancelled. Please Start a Fresh One");
            Console.ReadKey();
            return false;
        }

        public async Task<bool> ApplyHomeLoan()
        {
            Console.Clear();
            Console.WriteLine("--------Home Loan Application---------");
            Console.WriteLine("If you don't have a customerID, please apply for one");
            Console.WriteLine("Only registered customers are eligible for loans.");
            Console.WriteLine("If you are not a customer, hence need one, enter CustomerID as NEW ");

            Guid customerID;
            double amountApplied, grossIncome, salaryDeduction;
            int repaymentPeriod, serviceYears;
            ServiceType currentOccupation;

            try
            {
                Console.Write("Enter your CustomerID:");
                string input = Console.ReadLine();
                bool isGuid;
                isGuid = Guid.TryParse(input, out customerID);
                
                // in case customer dont have a ID
                if (isGuid == false && string.Equals(input, "NEW", StringComparison.OrdinalIgnoreCase) == true)
                {
                    MenuOfCustomer();
                    Console.ReadKey();
                    return false;
                }

                if(isGuid == false)
                {
                    Console.WriteLine("invalid customer id\nPress any key -> try Again");
                    Console.ReadKey();
                    return false;
                }

                if (isGuid == true)
                {
                    //check if customerID exists
                    CustomerBL cust = new CustomerBL();
                    bool isExist = await cust.isCustomerIDExistBL(customerID);
                    if (isExist == false)
                    {
                        Console.WriteLine("CustomerID not found in database\nPress Any key -> Try Again");
                        Console.ReadKey();
                        return false;
                    }


                    Console.WriteLine("Maximum Loan Amount is Rs.20 Lakh");
                    Console.Write("Enter amount of loan (in Rs.) you want to apply for:");
                    amountApplied = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Maximum Repayment Period is 180 months");
                    Console.Write("Enter Repayment Period (in months) you want to opt for:");
                    repaymentPeriod = Convert.ToInt16(Console.ReadLine());

                    Console.WriteLine("Available choices (case sensitive)\nAGRICULTURE\nBUSINESS\nOTHERS\nRETIRED\nSELF_EMPLOYED\nSERVICE\nOTHERS");
                    Console.Write("Enter your current occupation:");
                    string occupation = Console.ReadLine();
                    bool isValidOccupation = Enum.TryParse(occupation, out currentOccupation);

                    Console.WriteLine("Need a minimum service experience of 5 years");
                    Console.Write("Enter years of experience in your current occupation:");
                    serviceYears = Convert.ToInt16(Console.ReadLine());

                    Console.Write("Enter your gross income (Rs.) per month :");
                    grossIncome = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Deductions must be less than gross income");
                    Console.Write("Enter your income deductions amount (Rs.) per month:");
                    salaryDeduction = Convert.ToDouble(Console.ReadLine());

                    if (isValidOccupation == false)
                    {
                        Console.WriteLine("Not a valid Occupation\nPress any key to get to previous menu");
                        Console.ReadKey();
                        return false;
                    }
                    HomeLoan newLoan = new HomeLoan();
                    newLoan.CustomerID = customerID;
                    newLoan.AmountApplied = amountApplied;
                    newLoan.RepaymentPeriod = repaymentPeriod;
                    newLoan.Occupation = currentOccupation;
                    newLoan.ServiceYears = serviceYears;
                    newLoan.GrossIncome = grossIncome;
                    newLoan.SalaryDeductions = salaryDeduction;

                    HomeLoanBL newLoanBL = new HomeLoanBL();
                    bool isApplied = await newLoanBL.ApplyLoanBL(newLoan);
                    return isApplied;
                }
            }
            catch (InvalidStringException e)
            {
                Console.WriteLine(e.Message+"\nPress Any Key -> Try Again");
                
            }
            catch (InvalidRangeException e)
            {
                Console.WriteLine(e.Message + "\nPress Any Key -> Try Again");
                
            }
            catch (InvalidAmountException e)
            {
                Console.WriteLine(e.Message + "\nPress Any Key -> Try Again");
                
            }

            Console.WriteLine("Current Application Cancelled. Please Start a Fresh One");
            Console.ReadKey();
            return false;

        }

        public async Task<bool> MenuOfApproveLoan()
        {
            int input;
            string loanID;
            ///////Loan level 1 Menu
            do
            {
                Console.Clear();
                Console.WriteLine("--------- Approve Loan Menu --------");
                Console.WriteLine("1. List of Non-approved Home Loan");
                Console.WriteLine("2. List of Non-approved Car Loan");
                Console.WriteLine("3. List of Non-approved Educational Loan");
                Console.WriteLine("4. Back");

            
                Console.WriteLine("Enter your choice: ");
                input = Convert.ToInt32(Console.ReadLine());

                if (input != 4)
                {
                    switch (input)
                    {
                        case 1:
                            await ListNonApprovedLoans("HOME");
                            Console.WriteLine("Enter loanID to take action:");
                            loanID = Console.ReadLine();
                            await ApproveLoanPL(loanID, 1);
                            break;

                        case 2:
                            await ListNonApprovedLoans("CAR");
                            Console.WriteLine("Enter loanID to take action:");
                            loanID = Console.ReadLine();
                            await ApproveLoanPL(loanID, 2);
                            break;

                        case 3:
                            await ListNonApprovedLoans("EDU");
                            Console.WriteLine("Enter loanID to take action:");
                            loanID = Console.ReadLine();
                            await ApproveLoanPL(loanID, 3);
                            break;

                        default:
                            Console.WriteLine("Not a valid entry!\nPress any key -> Continue");
                            Console.ReadKey(); 
                            break;
                    }

                }
            } while (input != 4);
            return true;
        }

        public async Task ListNonApprovedLoans(string typeOfLoan)
        {
            if(typeOfLoan == "HOME")
            {
                HomeLoanBL HomeLoanBL = new HomeLoanBL();
                List<HomeLoan> HomeLoans = await HomeLoanBL.ListAllLoansBL();
                foreach(var loan in HomeLoans)
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
        //

        // if type = 1 then homeLoan
        // if type = 2 then carloan
        // if type = 3 then eduloan
        public async Task<bool> ApproveLoanPL(string loanID, int type)
        {
            bool isValidStatus = false;
            bool isValidLoanID = false;

            HomeLoanBL homeLoanBL = new HomeLoanBL();
            CarLoanBL carLoanBL = new CarLoanBL();
            EduLoanBL eduLoanBL = new EduLoanBL();

            try
            {
                // checking edu loan
                if (eduLoanBL.isLoanIDExistBL(loanID) == true && type == 3)
                {
                    isValidLoanID = true;
                    //EduLoanBL eduLoanBL = new EduLoanBL();
                    EduLoan eduLoan = new EduLoan();

                    eduLoan = await eduLoanBL.GetLoanByLoanIDBL(loanID);
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
                    Console.Write("Enter the updated loan status:");
                    string updatedStatusStr = Console.ReadLine();
                    isValidStatus = Enum.TryParse(updatedStatusStr, out updatedStatus);

                    if (isValidStatus == true)
                    {
                        eduLoan = await eduLoanBL.ApproveLoanBL(loanID, updatedStatus);
                        Console.WriteLine($"New Status of {loanID} is {eduLoan.Status}");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Thats not a valid status");
                        Console.WriteLine("Press any key -> Approve Loan");
                        Console.ReadKey();
                        return false;
                    }

                }

                //checking car loan
                if (carLoanBL.isLoanIDExistBL(loanID) == true && type  == 2)
                {
                    isValidLoanID = true;
                    //CarLoanBL carLoanBL = new CarLoanBL();
                    CarLoan carLoan = new CarLoan();

                    carLoan = await carLoanBL.GetLoanByLoanID_BL(loanID);
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
                    isValidStatus = Enum.TryParse(updatedStatusStr, out updatedStatus);

                    if (isValidStatus == true)
                    {
                        carLoan = await carLoanBL.ApproveLoanBL(loanID, updatedStatus);
                        Console.WriteLine($"New Status of {loanID} is {carLoan.Status}");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Thats not a valid status");
                        Console.WriteLine("Press any key -> Approve Loan");
                        Console.ReadKey();
                        return false;
                    }
                }

                //checking home loan
                if (homeLoanBL.IsLoanIDExistBL(loanID) == true && type  == 1)
                {
                    isValidLoanID = true;
                    //EduLoanBL EduLoanBL = new EduLoanBL();
                    HomeLoan homeLoan = new HomeLoan();

                    homeLoan = await homeLoanBL.GetLoanByLoanIDBL(loanID);
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
                    isValidStatus = Enum.TryParse(updatedStatusStr, out updatedStatus);

                    if (isValidStatus == true)
                    {
                        homeLoan = await homeLoanBL.ApproveLoanBL(loanID, updatedStatus);
                        Console.WriteLine($"New Status of {loanID} is {homeLoan.Status}");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Thats not a valid status");
                        Console.WriteLine("Press any key -> Approve Loan");
                        Console.ReadKey();
                        return false;
                    }
                }

                if (isValidLoanID == false)
                {
                    Console.WriteLine("Please enter a valid loan ID");
                    Console.WriteLine("Press any Key -> Approve Loan");
                    Console.ReadKey();
                    return false;
                }
            }
            catch(InvalidStringException e)
            {
                Console.WriteLine($"{e.Message}\nPress any key -> Approve Loan");
                Console.ReadKey();
                return false;
            }
            return true;
        }
        public bool AdminLogin()
        {
            return true;
        }

        public bool IsValidCustomer(string customerID)
        {
            return true;
        }
        public void MenuOfCustomer()
        {
            Console.WriteLine("Customer Menu here");
        }
    }
}
