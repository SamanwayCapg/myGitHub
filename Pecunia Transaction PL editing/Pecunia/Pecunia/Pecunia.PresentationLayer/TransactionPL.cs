using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pecunia.PresentationLayer
{
    class MainClass
    {
        public static void Main()
        {
            TransactionPL trans = new TransactionPL();
            trans.MenuOfTransaction();
        }
    }
    class TransactionPL
    {
        public bool MenuOfTransaction()
        {
            Console.Clear();
            int input;
            do
            {
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
                            if (MenuOfCredit() == true)
                                return true;
                            else
                                return false;
                            break;

                        case 2:
                            if (MenuOfDebit() == true)
                                return true;
                            else
                                return false;
                            break;

                        case 3:
                            if (MenuOfShowTransactionRecords() == true)
                                return true;
                            else
                                return false;
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


        public bool MenuOfCredit()
        {
            Console.Clear();
            int input;

            do
            {
                Console.WriteLine("-------- Select Mode for Credit Transaction --------");
                Console.WriteLine("1. By Cheque");
                Console.WriteLine("2. By Deposit Slilp");
                Console.WriteLine("3. Back");
                input = Convert.ToInt32(Console.ReadLine());

                if (input != 3)
                {
                    switch (input)
                    {
                        case 1:
                            if (CreditTransactionByChequePL() == true)
                                return true;
                            else
                                return false;
                            break;

                        case 2:
                            if (CreditTransactionByDepositPL() == true)
                                return true;
                            else
                                return false;
                            break;

                        default:
                            Console.WriteLine("Invalid Input\nPress Any Key -> Try Again");
                            Console.ReadKey();
                            break;
                    }
                }
            } while (input != 3);
            return true;
        }


        public bool MenuOfDebit()
        {
            Console.Clear();
            int input;

            do
            {
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
                            if (DebitTransactionByChequeBL() == true)
                                return true;
                            else
                                return false;
                           
                        case 2:
                            if (DebitTransactionByWithdrawalSlipBL() == true)
                                return true;
                            else
                                return false;
                           
                        default:
                            Console.WriteLine("Invalid Input\nPress Any Key -> Try Again");
                            Console.ReadKey();
                            break;
                    }
                }
            } while (input != 3);
            return true;
        }


        public bool MenuOfShowTransactionRecords()
        {
            int input;
            Console.Clear();

            do
            {
                Console.WriteLine("------- Your Transaction Records Here -------");
                Console.WriteLine("1. Show All Transactions");
                Console.WriteLine("2. Show Debit Transactions");
                Console.WriteLine("3. Show Credit Transactions");
                Console.WriteLine("4. Show By Transaction ID");
                Console.WriteLine("5. Show By Customer ID");
                Console.WriteLine("6. Back");
                input = Convert.ToInt32(Console.ReadLine());

                if (input != 6)
                {
                    switch (input)
                    {
                        case 1:
                            if (ShowAllTransactionsPL() == true)
                                return true;
                            else
                                return false;
                           
                        case 2:
                            if (MenuOfShowDebitTransactions() == true)
                                return true;
                            else
                                return false;
                           
                        case 3:
                            if (MenuOfShowCreditTransactions() == true)
                                return true;
                            else
                                return false;
                           
                        case 4:
                            if (DisplayTransactionDetailsByTransactionID_PL() == true)
                                return true;
                            else
                                return false;

                        case 5:
                            if (MenuOfShowTransactionsByCustomerID() == true)
                                return true;
                            else
                                return false;

                        default:
                            Console.WriteLine("Invalid Input\nPress Any Key -> Try Again");
                            Console.ReadKey();
                            break;
                    }
                }
            } while (input != 6);

            return true;
        }

        public bool MenuOfShowDebitTransactions()
        {
            int input;
            Console.Clear();
            do
            {
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
                            if (ListDebitTransactionsByDateRangePL() == true)
                                return true;
                            else
                                return false;

                        case 2:
                            if (ListDebitTransactionsOfSpecificDatePL() == true)
                                return true;
                            else
                                return false;

                        case 3:
                            if (DisplayAllDebitTransactionsPL() == true)
                                return true;
                            else
                                return false;

                        default:
                            Console.WriteLine("Invalid Input\nPress Any Key -> Try Again");
                            Console.ReadKey();
                            break;
                    }
                }
            } while (input != 4);

            return true;
        }

        public bool MenuOfShowCreditTransactions()
        {
            int input;
            Console.Clear();
            do
            {
                Console.WriteLine("-------- Creit Transactions --------");
                Console.WriteLine("1. List Transactions by Date Range");
                Console.WriteLine("2. List Transactions of Specific Date");
                Console.WriteLine("3. List All Creit Transactions");
                Console.WriteLine("4. Back");
                input = Convert.ToInt32(Console.ReadLine());

                if (input != 4)
                {
                    switch (input)
                    {
                        case 1:
                            if (ListCreitTransactionsByDateRangePL() == true)
                                return true;
                            else
                                return false;

                        case 2:
                            if (ListCreitTransactionsOfSpecificDatePL() == true)
                                return true;
                            else
                                return false;

                        case 3:
                            if (DisplayAllCreitTransactionsPL() == true)
                                return true;
                            else
                                return false;

                        default:
                            Console.WriteLine("Invalid Input\nPress Any Key -> Try Again");
                            Console.ReadKey();
                            break;
                    }
                }
            } while (input != 4);

            return true;
        }

        public bool MenuOfShowTransactionsByCustomerID()
        {
            int input;
            Console.Clear()
            do
            {
                Console.WriteLine("-------- Customer's Transactions --------");
                Console.WriteLine("1. List Transactions by Date Range");
                Console.WriteLine("2. List Transactions of Specific Date");
                Console.WriteLine("3. List All Debit Transactions");
                Console.WriteLine("4. List All Creit Transactions");
                Console.WriteLine("5. List All Transactions");
                Console.WriteLine("6. Back");
                input = Convert.ToInt32(Console.ReadLine());

                if (input != 6)
                {
                    switch (input)
                    {
                        case 1:
                            if (ListTransactionsByDateRangeOfCustomerID_PL() == true)
                                return true;
                            else
                                return false;

                        case 2:
                            if (ListTransactionsOfSpecificDateOfCustomerID_PL() == true)
                                return true;
                            else
                                return false;

                        case 3:
                            if (DisplayAllDebitTransactionsOfCustomerID_PL() == true)
                                return true;
                            else
                                return false;

                        case 4:
                            if (DisplayAllCreditTransactionsOfCustomerID_PL() == true)
                                return true;
                            else
                                return false;

                        case 5:
                            if (DisplayTransactionByCustomerID_PL() == true)
                                return true;
                            else
                                return false;

                        default:
                            Console.WriteLine("Invalid Input\nPress Any Key -> Try Again");
                            Console.ReadKey();
                            break;
                    }
                }
            } while (input != 6);

            return true;
        }
    }

   
    
}
