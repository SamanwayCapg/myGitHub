using System;
using System.Collections.Generic;
using Capgemini.Pecunia.BusinessLayer;
using Capgemini.Pecunia.Exceptions;
using System.Threading.Tasks;
using Capgemini.Pecunia.Helpers;
using Capgemini.Pecunia.Entities;


namespace Capgemini.Pecunia.PresentationLayer
{
   /*public static class MainClass
    {
        [STAThread]
        public static void Main(string[] args)
        {
            TransactionPresentation.MenuOfTransaction().Wait();
        }
    }*/
       
   
    public static class TransactionPresentation
    {
        /// <summary>
        /// Menu for Transaction
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> MenuOfTransaction()
        {
            int input;
            do
            {
                //Menu
                Console.Clear();
                Console.WriteLine("--------- Your Transactions Here ---------");
                Console.WriteLine("1. Credit");
                Console.WriteLine("2. Debit");
                Console.WriteLine("3. Show Transaction Records");
                Console.WriteLine("4. Back");
                Console.WriteLine("Enter your choice:");
                input = Convert.ToInt16(Console.ReadLine());

                if (input != 4)
                {
                    switch (input)
                    {
                        case 1:
                            await MenuOfCredit();
                            break;

                        case 2:
                            await MenuOfDebit();
                            break;

                        case 3:
                            await MenuOfShowTransactionRecords();
                            break;

                        default:
                            Console.WriteLine("Invalid Input\nPress Any Key -> Try Again");
                            Console.ReadKey();
                            break;
                    }
                }

            } while (input != 4);
            return true;
        }

        /// <summary>
        /// Menu for Credit
        /// </summary>
        /// <returns></returns>
        public static async Task MenuOfCredit()
        {
            int input;
           
            do
            {
                //Menu
                Console.Clear();
                Console.WriteLine("-------- Select Mode for Credit Transaction --------");
                Console.WriteLine("1. By Cheque");
                Console.WriteLine("2. By Deposit Slip");
                Console.WriteLine("3. Back");
                input = Convert.ToInt32(Console.ReadLine());

                if (input != 3)
                {
                    switch (input)
                    {
                        case 1:

                            if (await CreditTransactionByCheque())
                                Console.WriteLine("Transaction credited.");
                            else
                                await MenuOfCredit();

                            Console.ReadKey();
                            break;
                            
                        case 2:
                            
                            if (await CreditTransactionByDepositSlip())
                                Console.WriteLine("Transaction credited.");

                            else
                                await MenuOfCredit();
                            Console.ReadKey();
                            break;

                        default:
                            Console.WriteLine("Invalid Input\nPress Any Key -> Try Again");
                            Console.ReadKey();
                            break;
                    }
                }
            } while (input != 3);
           
        }

        /// <summary>
        /// Menu for Debit
        /// </summary>
        /// <returns></returns>
        public static async Task MenuOfDebit()
        {
            int input;

            do
            {
                //Menu
                Console.Clear();
                Console.WriteLine("-------- Select Mode for Debit Transaction --------");
                Console.WriteLine("1. By Cheque");
                Console.WriteLine("2. By Withdrawal Slip");
                Console.WriteLine("3. Back");
                input = Convert.ToInt32(Console.ReadLine());

                if (input != 3)
                {
                    switch (input)
                    {
                        case 1:
                            if (await DebitTransactionByCheque())
                                Console.WriteLine("Transaction debited.");
                            else
                                await MenuOfDebit();

                            Console.ReadKey();
                            break;
                            
                        case 2:
                            if (await DebitTransactionByWithdrawalSlip())
                                Console.WriteLine("Transaction debited.");
                            else
                                await MenuOfDebit();

                            Console.ReadKey();
                            break;
                        
                        default:
                            Console.WriteLine("Invalid Input\nPress Any Key -> Try Again");
                            Console.ReadKey();
                            break;
                    }
                }
            } while (input != 3);
            
        }

        /// <summary>
        /// Menu for Transaction Records
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> MenuOfShowTransactionRecords()
        {
            int input;
            
            do
            {
                //Menu
                Console.Clear();
                Console.WriteLine("------- Your Transaction Records Here -------");
                Console.WriteLine("1. Show All Transactions");
                Console.WriteLine("2. Show Debit Transactions");
                Console.WriteLine("3. Show Credit Transactions");
                Console.WriteLine("4. Show By Transaction ID");
                Console.WriteLine("5. Show By Account ID");
                Console.WriteLine("6. Back");
                input = Convert.ToInt32(Console.ReadLine());

                if (input != 6)
                {
                    switch (input)
                    {
                        case 1:
                            if (await GetAllTransactions())
                                return true;
                            else
                               await MenuOfShowTransactionRecords();
                            Console.ReadKey();
                            break;

                        case 2:
                            if (await MenuOfShowDebitTransactions())
                                return true;
                            else
                                await MenuOfShowTransactionRecords();
                            Console.ReadKey();
                            break;

                        case 3:
                            if (await MenuOfShowCreditTransactions())
                                return true;
                            else
                                await MenuOfShowTransactionRecords();
                            Console.ReadKey();
                            break;

                        case 4:
                            if (await ListTransactionByTransactionID())
                                return true;
                            else
                                await MenuOfShowTransactionRecords();
                            Console.ReadKey();
                            break;

                        case 5:
                            if (await MenuOfShowTransactionsByAccountID())
                                return true;
                            else
                                await MenuOfShowTransactionRecords();
                            Console.ReadKey();
                            break;

                        default:
                            Console.WriteLine("Invalid Input\nPress Any Key -> Try Again");
                            Console.ReadKey();
                            break;
                    }
                }
            } while (input != 6);

            return true;
        }

        /// <summary>
        /// Menu for Debit Transactions
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> MenuOfShowDebitTransactions()
        {
            int input;
            
            do
            {
                //Menu
                Console.Clear();
                Console.WriteLine("-------- Debit Transactions --------");
                Console.WriteLine("1. List Transactions by Date Range");
                Console.WriteLine("2. List Transactions of Specific Date");
                Console.WriteLine("3. List All Debit Transactions");
                Console.WriteLine("4. Back");
                input = Convert.ToInt32(Console.ReadLine());

                if (input != 4)
                {
                    switch (input)
                    {
                        case 1:
                            if (await ListDebitTransactionsByDateRange() == true)
                                return true;
                            else
                                await MenuOfShowDebitTransactions();
                            Console.ReadKey();
                            break;

                        case 2:
                            if (await ListDebitTransactionsOfSpecificDate() == true)
                                return true;
                            else
                                await MenuOfShowDebitTransactions();
                            Console.ReadKey();
                            break;

                        case 3:
                            if (await ListAllDebitTransactions() == true)
                                return true;
                            else
                                await MenuOfShowDebitTransactions();
                            Console.ReadKey();
                            break;

                        default:
                            Console.WriteLine("Invalid Input\nPress Any Key -> Try Again");
                            Console.ReadKey();
                            break;
                    }
                }
            } while (input != 4);

            return true;
        }

        /// <summary>
        /// Menu for Credit Transactions
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> MenuOfShowCreditTransactions()
        {
            int input;
            
            do
            {
                //Menu
                Console.Clear();
                Console.WriteLine("-------- Credit Transactions --------");
                Console.WriteLine("1. List Transactions by Date Range");
                Console.WriteLine("2. List Transactions of Specific Date");
                Console.WriteLine("3. List All Credit Transactions");
                Console.WriteLine("4. Back");
                input = Convert.ToInt32(Console.ReadLine());

                if (input != 4)
                {
                    switch (input)
                    {
                        case 1:
                            if (await ListCreditTransactionsByDateRange() == true)
                                return true;
                            else
                                await MenuOfShowCreditTransactions();
                            Console.ReadKey();
                            break;

                        case 2:
                            if (await ListCreditTransactionsOfSpecificDate() == true)
                                return true;
                            else
                                await MenuOfShowCreditTransactions();
                            Console.ReadKey();
                            break;

                        case 3:
                            if (await ListAllCreditTransactions() == true)
                                return true;
                            else
                                await MenuOfShowCreditTransactions();
                            Console.ReadKey();
                            break;

                        default:
                            Console.WriteLine("Invalid Input\nPress Any Key -> Try Again");
                            Console.ReadKey();
                            break;
                    }
                }
            } while (input != 4);

            return true;
        }



        /// <summary>
        /// Menu for Transactions by Account ID
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> MenuOfShowTransactionsByAccountID()
        {
            int input;
            do
            {
                //Menu
                Console.Clear();
                Console.WriteLine("-------- Account's Transactions --------");
                Console.WriteLine("1. List Transactions by Date Range");
                Console.WriteLine("2. List Transactions of Specific Date");
                Console.WriteLine("3. List All Debit Transactions");
                Console.WriteLine("4. List All Credit Transactions");
                Console.WriteLine("5. List All Transactions");
                Console.WriteLine("6. Back");
                input = Convert.ToInt32(Console.ReadLine());

                if (input != 6)
                {
                    switch (input)
                    {
                        case 1:
                            if (await ListTransactionsByDateRangeOfAccountID() == true)
                                return true;
                            else
                                await MenuOfShowTransactionsByAccountID();
                            Console.ReadKey();
                            break;

                        case 2:
                            if (await ListTransactionsOfSpecificDateOfAccountID() == true)
                                return true;
                            else
                                await MenuOfShowTransactionsByAccountID();
                            Console.ReadKey();
                            break;

                        case 3:
                            if (await ListAllDebitTransactionsOfAccountID() == true)
                                return true;
                            else
                                await MenuOfShowTransactionsByAccountID();
                            Console.ReadKey();
                            break;

                        case 4:
                            if (await ListAllCreditTransactionsOfAccountID() == true)
                                return true;
                            else
                                await MenuOfShowTransactionsByAccountID();
                            Console.ReadKey();
                            break;

                        case 5:
                            if (await ListTransactionByAccountID() == true)
                                return true;
                            else
                                await MenuOfShowTransactionsByAccountID();
                            Console.ReadKey();
                            break;

                        default:
                            Console.WriteLine("Invalid Input\nPress Any Key -> Try Again");
                            Console.ReadKey();
                            break;
                    }
                }
            } while (input != 6);

            return true;

        }

        /// <summary>
        /// Menu for Credit Transaction by Cheque
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> CreditTransactionByCheque()
        {
            Guid accountID;
            double amount;
            string chequeNumber;
            bool transactionCredited = false;
            
            try
            {
                //Menu
                Console.Clear();
                Console.WriteLine("------- Credit Transaction By Cheque -------");
                Console.Write("Enter Account ID:");
                accountID = Guid.Parse(Console.ReadLine());
                Console.WriteLine("Maximum Allowed Amount Rs.50000");
                Console.Write("Enter Amount (Rs.):");
                amount = Convert.ToDouble(Console.ReadLine());
                Console.Write("Enter Cheque No:");
                chequeNumber = Console.ReadLine();

                    TransactionBL transBL = new TransactionBL();
                transactionCredited = await transBL.CreditTransactionByChequeBL(accountID, amount, chequeNumber);
               
                return transactionCredited;
            }
            catch (CreditChequeException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Press Any Key -> Try Again");
                Console.ReadKey();
                return false;
            }
            
        }

        /// <summary>
        /// Menu for Credit Transaction by Deposit Slip
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> CreditTransactionByDepositSlip()
        {
            Console.Clear();
            Guid accountID;
            double amount;
            bool transactionCredited = false;

            try
            {
                //Menu
                Console.WriteLine("--------- Credit Transaction By Deposit Slip ---------");
                Console.Write("Enter Account ID:");
                accountID = Guid.Parse(Console.ReadLine());
                Console.WriteLine("Maximum Allowed Amount is Rs.50000");
                Console.Write("Enter Amount (Rs.):");
                amount = Convert.ToDouble(Console.ReadLine());

                TransactionBL transBL = new TransactionBL();
                transactionCredited = await transBL.CreditTransactionByDepositSlipBL(accountID, amount);
                return transactionCredited;
            }
            catch (CreditSlipException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        /// <summary>
        /// Menu for Debit Transaction by Cheque
        /// </summary>
        /// <returns></returns>
        public static async Task <bool> DebitTransactionByCheque()
        {
            Guid accountID;
            double amount;
            string chequeNumber;
            bool transactionDebited = false;
            try
            {
                //Menu
                Console.Clear();
                Console.WriteLine("------- Debit Transaction By Cheque -------");
                Console.Write("Enter Account ID:");
                accountID = Guid.Parse(Console.ReadLine());
                Console.WriteLine("Maximum Allowed Amount Rs.50000");
                Console.Write("Enter Amount (Rs.):");
                amount = Convert.ToDouble(Console.ReadLine());
                Console.Write("Enter Cheque No:");
                chequeNumber = Console.ReadLine();

                TransactionBL transBL = new TransactionBL();
                transactionDebited = await transBL.DebitTransactionByChequeBL(accountID, amount, chequeNumber);
                return transactionDebited;
            }
            catch (DebitChequeException e)
            {
                Console.WriteLine(e.Message+"\nPress Any Key -> Try Again");
                Console.ReadKey();
                return false;
            }
            catch(InsufficientBalanceException e)
            {
                Console.WriteLine(e.Message + "\nPress Any Key -> Try Again");
                Console.ReadKey();
                return false;
            }
            
        }

        /// <summary>
        /// Menu for Debit Transaction by Withdrawal Slip
        /// </summary>
        /// <returns></returns>
        public static async Task <bool> DebitTransactionByWithdrawalSlip()
        {
            Console.Clear();
            Guid accountID;
            double amount;
            bool TransactionDebited = false;

            try
            {
                //Menu
                Console.WriteLine("--------- Debit Transaction By Withdrawal Slip ---------");
                Console.Write("Enter Account No:");
                accountID = Guid.Parse(Console.ReadLine());
                Console.WriteLine("Maximum Allowed Amount is Rs.50000");
                Console.Write("Enter Amount (Rs.):");
                amount = Convert.ToDouble(Console.ReadLine());

                TransactionBL transBL = new TransactionBL();
                TransactionDebited = await transBL.DebitTransactionByWithdrawalSlipBL(accountID, amount);
                return TransactionDebited;
            }
            catch (CreditSlipException e)
            {
                Console.WriteLine(e.Message + "\nPress Any Key -> Try Again");
                Console.ReadKey();
                return false;
            }
            catch (InsufficientBalanceException e)
            {
                Console.WriteLine(e.Message + "\nPress Any Key -> Try Again");
                Console.ReadKey();
                return false;
            }
            catch (DebitSlipException e)
            {
                Console.WriteLine(e.Message + "\nPress Any Key -> Try Again");
                Console.ReadKey();
                return false;
            }
        }

        /// <summary>
        /// Menu for All Transactions
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> GetAllTransactions()
        {
            Console.Clear();
            Console.WriteLine("------ All Transactions ------");
            try
            {
                TransactionBL transactionBL = new TransactionBL();
                List<Transaction> transactions = await transactionBL.GetAllTransactionBL();

                foreach (Transaction transaction in transactions)
                {
                    ShowTransactionDetails(transaction);
                }

                Console.WriteLine("Press Any Key -> Previous Menu");
                Console.ReadKey();
                return true;
            }
            catch (GetAllTransactionException e)
            {
                Console.WriteLine(e.Message + "\nPress Any Key -> Try Again");
                Console.ReadKey();
                return false;
            }
            
        }

        /// <summary>
        /// Menu for All Transactions by Transaction ID
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> ListTransactionByTransactionID()
        {
            Console.Clear();
            Console.WriteLine("------ Transaction Details ------");
            
            Console.Write("Enter Transaction ID:");
            string input = Console.ReadLine();
            Guid transactionID;
            bool isGuid = Guid.TryParse(input, out transactionID);
            
            if(isGuid == false)
            {
                Console.WriteLine("Not a valid transaction ID\nPress any Key -> Try Again");
                Console.ReadKey();
                return false;
            }

            try
            {
                TransactionBL transactionBL = new TransactionBL();
                Transaction transaction = await transactionBL.DisplayTransactionByTransactionIDBL(transactionID);
                if (transaction == null)
                {
                    Console.WriteLine($"No Records found for {transactionID}");
                    Console.ReadKey();
                    return false;
                }
                else
                {
                    ShowTransactionDetails(transaction);
                    Console.WriteLine("Press Any Key -> Previous Menu");
                    Console.ReadKey();
                    return true;
                }
            }
            catch(TransactionDetailsException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Press Any Key -> Try Again");
                return false;
            }
        }

        /// <summary>
        /// Menu for All Debit Transactions
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> ListAllDebitTransactions()
        {
            Console.Clear();
            Console.WriteLine("------ All Debit Transactions ------");
            try
            {
                TransactionBL transactionBL = new TransactionBL();
                List<Transaction> transactions = await transactionBL.GetAllTransactionBL();
                bool isTransactionFound = false;

                foreach (Transaction transaction in transactions)
                {
                    // Enum for Debit is 1
                    if (transaction.Type == (TypeOfTranscation)1)
                    {
                        ShowTransactionDetails(transaction);
                        isTransactionFound = true;
                    }
                }

                if(isTransactionFound == false)
                    Console.WriteLine("No transactions found");
                Console.WriteLine("Press Any Key -> Previous Menu");
                Console.ReadKey();
                return true;
            }
            catch(GetAllTransactionException e)
            {
                Console.WriteLine(e.Message + "\nPress Any Key -> Try Again");
                Console.ReadKey();
                return false;
            }
           
        }

        /// <summary>
        /// Menu for All Debit Transactions for a specific date
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> ListDebitTransactionsOfSpecificDate()
        {
            Console.Clear();
            Console.WriteLine("------ Debit Transactions ------");
            try
            {
                Console.Write("Enter Date (in dd-MM-yyyy format only):");
                string inputDateString = Console.ReadLine();
                DateTime inputDate = BusinessLogicUtil.validateDate("dd-MM-yyyy", inputDateString);

                // validateDate returns default(DateTime) if date is not in valid format because DateTime is non nullable
                if (inputDate == default(DateTime))
                {
                    Console.WriteLine("Wrong Date Format\nInput date needs to be in dd-MM-yyyy format");
                    Console.WriteLine("Press any key -> Try Again");
                    Console.ReadKey();
                    return false;
                }

                TransactionBL transactionBL = new TransactionBL();
                List<Transaction> transactions = await transactionBL.GetAllTransactionBL();

                bool transactionsFound = false;
                Console.WriteLine($"------ All Debit Transactions of {inputDate.Date} ------");
                foreach (var transaction in transactions)
                {
                    // Enum for Debit is 1
                    if (transaction.Type == (TypeOfTranscation)1 && DateTime.Compare(inputDate.Date, transaction.DateOfTransaction.Date) == 0)
                    {
                        ShowTransactionDetails(transaction);
                        transactionsFound = true;
                    }
                }

                if (transactionsFound == false)
                    Console.WriteLine($"No Debit Transactions found on {inputDate.Date}");

                Console.WriteLine("Press Any Key -> Previous Menu");
                Console.ReadKey();
                return true;
            }
            catch(GetAllTransactionException e)
            {
                Console.WriteLine(e.Message + "\nPress Any Key -> Try Again");
                Console.ReadKey();
                return false;
            }
            
        }

        /// <summary>
        /// Menu for All Debit Transactions between specified dates
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> ListDebitTransactionsByDateRange()
        {
            Console.Clear();
            Console.WriteLine("------. All Debit Transaction ------");
            string FromDateStr, ToDateStr;
            try
            {
                Console.WriteLine("All dates must be in dd-MM-yyyy format");
                Console.Write("Enter Start Date:");
                FromDateStr = Console.ReadLine();
                DateTime FromDate = BusinessLogicUtil.validateDate("dd-MM-yyyy", FromDateStr);

                Console.Write("Enter End Date:");
                ToDateStr = Console.ReadLine();
                DateTime ToDate = BusinessLogicUtil.validateDate("dd-MM-yyyy", ToDateStr);

                // validateDate returns default(DateTime) if date is not in valid format because DateTime is non nullable
                if (FromDate == default(DateTime) || ToDate == default(DateTime))
                {
                    Console.WriteLine("One or more dates are not in specified format\nSpecified Format dd-MM-yyyy");
                    Console.WriteLine("Press Any Key -> Try Again");
                    Console.ReadKey();
                    return false;
                }

                TransactionBL transactionBL = new TransactionBL();
                List<Transaction> transactions = await transactionBL.GetAllTransactionBL();

                bool transactionsFound = false;
                foreach (var transaction in transactions)
                {
                    // Enum for Debit is 1
                    if (transaction.Type == (TypeOfTranscation)1 && DateTime.Compare(FromDate.Date, transaction.DateOfTransaction.Date) < 0 && DateTime.Compare(transaction.DateOfTransaction.Date, ToDate.Date) < 0)
                    {
                        ShowTransactionDetails(transaction);
                        transactionsFound = true;
                    }
                }

                if (transactionsFound == false)
                    Console.WriteLine($"No Debit Transactions found between {FromDate.Date} and {ToDate.Date}");

                Console.WriteLine("Press Any Key -> Previous Menu");
                Console.ReadKey();
                return true;
            }
            catch(GetAllTransactionException e)
            {
                Console.WriteLine(e.Message + "\nPress Any Key -> Try Again");
                Console.ReadKey();
                return false;
            }
            
        }

        /// <summary>
        /// Menu for All Credit Transactions between specified dates
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> ListCreditTransactionsByDateRange()
        {
            Console.Clear();
            Console.WriteLine("------. All Credit Transaction ------");
            string FromDateStr, ToDateStr;
            try
            {
                Console.WriteLine("All dates must be in dd-MM-yyyy format");
                Console.Write("Enter Start Date:");
                FromDateStr = Console.ReadLine();
                DateTime FromDate = BusinessLogicUtil.validateDate("dd-MM-yyyy", FromDateStr);

                Console.Write("Enter End Date:");
                ToDateStr = Console.ReadLine();
                DateTime ToDate = BusinessLogicUtil.validateDate("dd-MM-yyyy", ToDateStr);

                // validateDate returns default(DateTime) if date is not in valid format because DateTime is non nullable
                if (FromDate == default(DateTime) || ToDate == default(DateTime))
                {
                    Console.WriteLine("One or more dates are not in specified format\nSpecified Format dd-MM-yyyy");
                    Console.WriteLine("Press Any Key -> Try Again");
                    Console.ReadKey();
                    return false;
                }

                TransactionBL transactionBL = new TransactionBL();
                List<Transaction> transactions = await transactionBL.GetAllTransactionBL();

                bool transactionsFound = false;
                foreach (var transaction in transactions)
                {
                    // Enum for Credit is 0
                    if (transaction.Type == (TypeOfTranscation)0 && DateTime.Compare(FromDate.Date, transaction.DateOfTransaction.Date) < 0 && DateTime.Compare(transaction.DateOfTransaction.Date, ToDate.Date) < 0)
                    {
                        ShowTransactionDetails(transaction);
                        transactionsFound = true;
                    }
                }

                if (transactionsFound == false)
                    Console.WriteLine($"No Credit Transactions found between {FromDate.Date} and {ToDate.Date}");

                Console.WriteLine("Press Any Key -> Previous Menu");
                Console.ReadKey();
                return true;
            }
            catch (GetAllTransactionException e)
            {
                Console.WriteLine(e.Message + "\nPress Any Key -> Try Again");
                Console.ReadKey();
                return false;
            }
            
        }

        /// <summary>
        /// Menu for All Credit Transactions for specific date
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> ListCreditTransactionsOfSpecificDate()
        {
            Console.Clear();
            Console.WriteLine("------ Credit Transactions ------");
            try
            {
                Console.Write("Enter Date (in dd-MM-yyyy format only):");
                string inputDateStr = Console.ReadLine();
                DateTime inputDate = BusinessLogicUtil.validateDate("dd-MM-yyyy", inputDateStr);

                // validateDate returns default(DateTime) if date is not in valid format because DateTime is non nullable
                if (inputDate == default(DateTime))
                {
                    Console.WriteLine("Wrong Date Format\nInput date needs to be in dd-MM-yyyy format");
                    Console.WriteLine("Press any key -> Try Again");
                    Console.ReadKey();
                    return false;
                }

                TransactionBL transactionBL = new TransactionBL();
                List<Transaction> transactions = await transactionBL.GetAllTransactionBL();

                bool transactionsFound = false;
                Console.WriteLine($"------ All Credit Transactions of {inputDate.Date} ------");
                foreach (var transaction in transactions)
                {
                    // Enum for Credit is 0
                    if (transaction.Type == (TypeOfTranscation)0 && DateTime.Compare(inputDate.Date, transaction.DateOfTransaction.Date) == 0)
                    {
                        ShowTransactionDetails(transaction);
                        transactionsFound = true;
                    }
                }

                if (transactionsFound == false)
                    Console.WriteLine($"No Credit Transactions found on {inputDate.Date}");

                Console.WriteLine("Press Any Key -> Previous Menu");
                Console.ReadKey();
                return true;
            }
            catch (GetAllTransactionException e)
            {
                Console.WriteLine(e.Message + "\nPress Any Key -> Try Again");
                Console.ReadKey();
                return false;
            }
        }

        /// <summary>
        /// Menu for All Credit Transactions
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> ListAllCreditTransactions()
        {
            Console.Clear();
            Console.WriteLine("------ All Credit Transactions ------");
            try
            {
                TransactionBL transactionBL = new TransactionBL();
                List<Transaction> transactions = await transactionBL.GetAllTransactionBL();
                bool isTransactionFound = false;

                foreach (var transaction in transactions)
                {
                    // Enum for Credit is 0
                    if (transaction.Type == (TypeOfTranscation)0)
                    {
                        ShowTransactionDetails(transaction);
                        isTransactionFound = true;
                    }
                }


                if(isTransactionFound == false)
                    Console.WriteLine("No transactions found");
                Console.WriteLine("Press Any Key -> Previous Menu");
                Console.ReadKey();
                return true;
            }
            catch (GetAllTransactionException e)
            {
                Console.WriteLine(e.Message + "\nPress Any Key -> Try Again");
                Console.ReadKey();
                return false;
            }
            
        }

        /// <summary>
        /// Menu for All Transactions between specific dates
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> ListTransactionsByDateRangeOfAccountID()
        {
            Console.Clear();
            Console.Write("Enter Account ID");
            try
            {
                Guid accountID;
                bool isGuid = Guid.TryParse(Console.ReadLine(), out accountID);
                if(isGuid == false)
                {
                    Console.WriteLine("not a valid account ID\nPress any key -> Try Again");
                    Console.ReadKey();
                    return false;
                } 
                    
                AccountBL accountBL = new AccountBL();
                if (accountBL.AccountIDExists(accountID) == false)
                {
                    Console.WriteLine("Account ID not found\nPress Any Key -> Try Again");
                    Console.ReadKey();
                    return false;
                }

                string FromDateStr, ToDateStr;

                Console.WriteLine("All dates must be in dd-MM-yyyy format");
                Console.Write("Enter Start Date:");
                FromDateStr = Console.ReadLine();
                DateTime FromDate = BusinessLogicUtil.validateDate("dd-MM-yyyy", FromDateStr);

                Console.Write("Enter End Date:");
                ToDateStr = Console.ReadLine();
                DateTime ToDate = BusinessLogicUtil.validateDate("dd-MM-yyyy", ToDateStr);

                // validateDate returns default(DateTime) if date is not in valid format because DateTime is non nullable
                if (FromDate == default(DateTime) || ToDate == default(DateTime))
                {
                    Console.WriteLine("One or more dates are not in specified format\nSpecified Format dd-MM-yyyy");
                    Console.WriteLine("Press Any Key -> Try Again");
                    Console.ReadKey();
                    return false;
                }

                // required transactions will be filered out in foreach loop from all transactions
                TransactionBL transactionBL = new TransactionBL();
                List<Transaction> transactions = await transactionBL.GetAllTransactionBL();

                bool transactionsFound = false;
                foreach (var transaction in transactions)
                {
                    if (transaction.AccountID == accountID && DateTime.Compare(FromDate.Date, transaction.DateOfTransaction.Date) < 0 && DateTime.Compare(transaction.DateOfTransaction.Date, ToDate.Date) < 0)
                    {
                        ShowTransactionDetails(transaction);
                        transactionsFound = true;
                    }
                }

                if (transactionsFound == false)
                    Console.WriteLine($"No Transactions found between {FromDate.Date} and {ToDate.Date} of account:{accountID}");

                Console.WriteLine("Press Any Key -> Previous Menu");
                Console.ReadKey();
                return true;
            }
            catch (GetAllTransactionException e)
            {
                Console.WriteLine(e.Message + "\nPress Any Key -> Try Again");
                Console.ReadKey();
                return false;
            }
            
        }
        /// <summary>
        /// Menu for All Transactions for specific date
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> ListTransactionsOfSpecificDateOfAccountID()
        {
            Console.Clear();
            Console.Write("Enter Account ID");
            try
            {
                Guid accountID;
                bool isGuid = Guid.TryParse(Console.ReadLine(), out accountID);
                if (isGuid == false)
                {
                    Console.WriteLine("not a valid account ID\nPress Any Key -> Try Again");
                    Console.ReadKey();
                    return false;
                }
                AccountBL accountBL = new AccountBL();
                if (accountBL.AccountIDExists(accountID) == false)
                {
                    Console.WriteLine("Account ID not found\nPress Any Key -> Try Again");
                    Console.ReadKey();
                    return false;
                }

                Console.Write("Enter Date (in dd-MM-yyyy format only):");
                string inputDateStr = Console.ReadLine();
                DateTime inputDate = BusinessLogicUtil.validateDate("dd-MM-yyyy", inputDateStr);

                // validateDate returns default(DateTime) if date is not in valid format because DateTime is non nullable
                if (inputDate == default(DateTime))
                {
                    Console.WriteLine("Wrong Date Format\nInput date needs to be in dd-MM-yyyy format");
                    Console.WriteLine("Press any key -> Try Again");
                    Console.ReadKey();
                    return false;
                }

                // required transaction will be filtered in foreach loop from all transaction
                TransactionBL transactionBL = new TransactionBL();
                List<Transaction> transactions =  await transactionBL.GetAllTransactionBL();

                bool transactionsFound = false;
                Console.WriteLine($"------ All Debit Transactions of {inputDate.Date} ------");
                foreach (var transaction in transactions)
                {
                    if (transaction.AccountID == accountID && DateTime.Compare(inputDate.Date, transaction.DateOfTransaction.Date) == 0)
                    {
                        ShowTransactionDetails(transaction);
                        transactionsFound = true;
                    }
                }

                if (transactionsFound == false)
                    Console.WriteLine($"No Transactions found on {inputDate.Date} for account {accountID}");

                Console.WriteLine("Press Any Key -> Previous Menu");
                Console.ReadKey();

                return true;
            }
            catch (GetAllTransactionException e)
            {
                Console.WriteLine(e.Message + "\nPress Any Key -> Try Again");
                Console.ReadKey();
                return false;
            }
            
        }
        /// <summary>
        /// Menu for All Debit Transactions using Account ID
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> ListAllDebitTransactionsOfAccountID()
        {
            Console.Clear();
            Console.Write("Enter account ID.");
            try
            {

                Guid accountID;
                bool isGuid = Guid.TryParse(Console.ReadLine(), out accountID);
                if (isGuid == false)
                {
                    Console.WriteLine("not a valid account ID\nPress Any Key -> Try Again");
                    Console.ReadKey();
                    return false;
                }
                AccountBL accountBL = new AccountBL();
                if (accountBL.AccountIDExists(accountID) == false)
                {
                    Console.WriteLine("Account ID not found\nPress Any Key -> Try Again");
                    Console.ReadKey();
                    return false;
                }

                TransactionBL transactionBL = new TransactionBL();
                List<Transaction> transactions = await transactionBL.GetAllTransactionBL();

                bool transactionsFound = false;
                foreach (var transaction in transactions)
                {
                    // Enum for Debit is 1
                    if (transaction.Type == (TypeOfTranscation)1 && transaction.AccountID == accountID)
                    {
                        ShowTransactionDetails(transaction);
                        transactionsFound = true;
                    }
                }

                if (transactionsFound == false)
                    Console.WriteLine($"No Debit transactions founds in records of {accountID}");

                Console.WriteLine("Press Any Key -> Previous Menu");
                Console.ReadKey();

                return true;
            }
            catch (GetAllTransactionException e)
            {
                Console.WriteLine(e.Message + "\nPress Any Key -> Try Again");
                Console.ReadKey();
                return false;
            }
           
        }

        /// <summary>
        /// Menu for All Credit Transactions using Account ID
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> ListAllCreditTransactionsOfAccountID()
        {
            Console.Clear();
            Console.Write("Enter Account ID:");
            try
            {
                Guid accountID;
                bool isGuid = Guid.TryParse(Console.ReadLine(), out accountID);
                if (isGuid == false)
                {
                    Console.WriteLine("not a valid account ID\nPress Any Key -> Try Again");
                    Console.ReadKey();
                    return false;
                }
                AccountBL accountBL = new AccountBL();
                if (accountBL.AccountIDExists(accountID) == false)
                {
                    Console.WriteLine("Account ID not found\nPress Any Key -> Try Again");
                    Console.ReadKey();
                    return false;
                }

                TransactionBL transactionBL = new TransactionBL();
                List<Transaction> transactions = await transactionBL.GetAllTransactionBL();

                bool transactionsFound = false;
                foreach (var transaction in transactions)
                {
                    // Enum for Credit is 0
                    if (transaction.Type == (TypeOfTranscation)0 && transaction.AccountID == accountID)
                    {
                        ShowTransactionDetails(transaction);
                        transactionsFound = true;
                    }
                }

                if (transactionsFound == false)
                    Console.WriteLine($"No Credit transactions founds in account No {accountID}");

                Console.WriteLine("Press Any Key -> Previous Menu");
                Console.ReadKey();

                return true;
            }
            catch (GetAllTransactionException e)
            {
                Console.WriteLine(e.Message + "\nPress Any Key -> Try Again");
                Console.ReadKey();
                return false;
            }
            
        }
        /// <summary>
        /// Menu for All Transactions 
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> ListTransactionByAccountID()
        {
            Console.Clear();
            Console.Write("Enter Account ID:");
            try
            {
                Guid accountID;
                bool isGuid = Guid.TryParse(Console.ReadLine(), out accountID);
                if (isGuid == false)
                {
                    Console.WriteLine("not a valid account ID\nPress Any Key -> Try Again");
                    Console.ReadKey();
                    return false;
                }
                AccountBL accountBL = new AccountBL();
                if (accountBL.AccountIDExists(accountID) == false)
                {
                    Console.WriteLine("Account ID not found\nPress Any Key -> Try Again");
                    Console.ReadKey();
                    return false;
                }

                TransactionBL transactionBL = new TransactionBL();
                List<Transaction> transactions = await transactionBL.GetAllTransactionBL();

                bool transactionsFound = false;
                foreach (var transaction in transactions)
                {
                    if (transaction.AccountID == accountID)
                    {
                        ShowTransactionDetails(transaction);
                        transactionsFound = true;
                    }
                }

                if (transactionsFound == false)
                    Console.WriteLine($"No Transactions founds in account {accountID}");

                Console.WriteLine("Press Any Key -> Previous Menu");
                Console.ReadKey();
                return true;
            }
            catch (GetAllTransactionException e)
            {
                Console.WriteLine(e.Message + "\nPress Any Key -> Try Again");
                Console.ReadKey();
                return false;
            }
            
        }
        /// <summary>
        /// Menu for All Transaction Details
        /// </summary>
        /// <returns></returns>
        public static void ShowTransactionDetails(Transaction transaction)
        {
            Console.WriteLine($"TransactionID:{transaction.TransactionID}");
            //Console.WriteLine($"Customer ID:{transaction.CustomerID}");
            //Console.WriteLine($"Account No:{transaction.AccountNo}");
            Console.WriteLine($"Amount:{transaction.Amount}");
            Console.WriteLine($"Debit/Credit:{transaction.Type}");
            Console.WriteLine($"Date of Transaction:{transaction.DateOfTransaction}");
            Console.WriteLine($"Mode:{transaction.Mode}");
            Console.WriteLine("------------------------------------------------------");
        }
    }

}
