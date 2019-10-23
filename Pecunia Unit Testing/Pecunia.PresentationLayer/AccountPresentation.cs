using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capgemini.Pecunia.BusinessLayer;
using Capgemini.Pecunia.Entities;
using static System.Console;
using Capgemini.Pecunia.Exceptions;


namespace Capgemini.Pecunia.PresentationLayer
{
    public class AccountPresentation
    {
        
       public static async Task MenuOfAccount()
        {

            AccountBL a = new AccountBL();

            await DisplayMenu();

            async Task DisplayMenu()
            {
                Console.WriteLine("1.Add Account\n2.Remove Account\n3.Update AAccount\n4.GetAccountByCustomerID\n5.GetAccountByAccountNumber\n6.Display All Accounts");
                int choice;
                choice = int.Parse(ReadLine());
                switch (choice)
                {
                    case 1:
                        await AddAccount();
                        break;
                    case 2:
                        await RemoveAccount();
                        break;

                    case 3:
                        await UpdateAccount();
                        break;
                    case 4:
                        await GetAccountByCustomerID();
                        break;
                    case 5:
                        await  GetAccountByAccountID();
                        break;
                    case 6:
                        await DisplayAllAccounts();
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
           async Task AddAccount()
            {
                Console.WriteLine("1.Add Current Or Savings Account\n2.Add New FD");
                int choice = int.Parse(ReadLine());
                switch (choice)
                {
                    case 1:
                        await AccountType();
                        break;
                    case 2:
                        await CreateFixedDeposit();
                        break;
                    default:
                        break;
                }
            }

            async Task AccountType()
            {
                Console.WriteLine("1. Existing Customer\n 2. New Customer");
                int choice1 = int.Parse(ReadLine());
                Account account = new Account();
                switch (choice1)
                {
                    
                    case 1:
                        Console.WriteLine("Enter Account Type(Current or Savings )");
                        string accountType = ReadLine();
                        Console.WriteLine("Enter Home Branch");
                        account.HomeBranch = ReadLine();
                        Console.WriteLine("Enter CustomerID");
                       bool isGuid =  Guid.TryParse(ReadLine(), out Guid customerID);
                        if(isGuid == false)
                        {
                            Console.WriteLine("Invalid Guid");
                            await DisplayMenu();

                        }
                        AccountBL accountBL = new AccountBL();

                        if (await accountBL.AddAccountBL(account, customerID, accountType))
                        {
                            Console.WriteLine("Account Added Sucessfully");
                            await DisplayMenu();
                        }
                        else

                        {
                            Console.WriteLine("Account Not Added");
                            await DisplayMenu();
                        }
                        await DisplayMenu();
                        break;

                    case 2:
                        Customer customerEntities = new Customer();
                        Console.WriteLine("Enter Name");
                        customerEntities.CustomerName = ReadLine();
                        Console.WriteLine("Enter Mobile number");
                        customerEntities.CustomerMobile = ReadLine();
                        Console.WriteLine("Enter Address");
                        customerEntities.CustomerAddress = ReadLine();

                        Console.WriteLine("Enter Email");
                        customerEntities.CustomerEmail = ReadLine();

                        Console.WriteLine("Enter PAN");
                        customerEntities.CustomerPan = ReadLine();

                        CustomerBL cbl = new CustomerBL();
                        await cbl.AddCustomerBL(customerEntities);
                        Console.WriteLine("Enter Account Type");
                        string accountTypeNew = ReadLine();
                        
                        Console.WriteLine("Enter Home Branch");
                        account.HomeBranch = ReadLine();

                        AccountBL accountBL2 = new AccountBL();
                        if (await accountBL2.AddAccountBL(account, customerEntities.CustomerID, accountTypeNew))
                        {
                            Console.WriteLine("Account Added SUccessfully\n");
                            await DisplayMenu();
                        }

                        // Call the Function which displays main

                        break;


                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
               

            }
            async Task CreateFixedDeposit()
            {
                Console.WriteLine("1. Existing Customer\n 2. New Customer");
                int choice1 = int.Parse(ReadLine());
                FixedDeposit fixedDeposit1 = new FixedDeposit();
                switch (choice1)
                {
                    case 1:
                        Console.WriteLine("Enter Home Branch");
                        fixedDeposit1.HomeBranch = ReadLine();
                        Console.WriteLine("Enter CustomerID");
                        bool isGuid = Guid.TryParse(ReadLine(), out Guid customerID);
                        if (isGuid == false)
                        {
                            Console.WriteLine("Invalid Guid");
                            await DisplayMenu();

                        }
                        Console.WriteLine("Enter FixedDeposit");
                        fixedDeposit1.FdDeposit = double.Parse(ReadLine());
                        FixedDepositBL fixedDepositBL = new FixedDepositBL();
                        if (await fixedDepositBL.AddFixedDepositBL(fixedDeposit1, customerID))
                        {
                            Console.WriteLine("Account Added Sucessfully");
                            await DisplayMenu();
                        }
                        else
                            Console.WriteLine("Account Not Added");

                        break;
                    case 2:
                        Customer customerEntities = new Customer();
                        Console.WriteLine("Enter Name");
                        customerEntities.CustomerName = ReadLine();
                        Console.WriteLine("Enter Mobile number");
                        customerEntities.CustomerMobile = ReadLine();
                        Console.WriteLine("Enter Address");
                        customerEntities.CustomerAddress = ReadLine();

                        Console.WriteLine("Enter Email");
                        customerEntities.CustomerEmail = ReadLine();

                        Console.WriteLine("Enter PAN");
                        customerEntities.CustomerPan = ReadLine();

                        CustomerBL cbl = new CustomerBL();
                        await cbl.AddCustomerBL(customerEntities);

                        Console.WriteLine("Enter Home Branch");
                        fixedDeposit1.HomeBranch = ReadLine();
                       
                        Console.WriteLine("Enter FixedDeposit");
                        fixedDeposit1.FdDeposit = double.Parse(ReadLine());
                        FixedDepositBL fixedDepositBL1 = new FixedDepositBL();
                        if (await fixedDepositBL1.AddFixedDepositBL(fixedDeposit1, fixedDeposit1.CustomerID))
                        {
                            Console.WriteLine("Account Added Sucessfully");
                            await DisplayMenu();
                        }
                        else
                            Console.WriteLine("Account Not Added");
                        break;


                    default:
                        Console.WriteLine("Enter Valid Choice");
                        break;
                }

            }

            async Task UpdateAccount()
            {
                Console.WriteLine("1.Update Current or Savings Account\n2.Update FixedDeposit");
                int choice = int.Parse(ReadLine());
                switch (choice)
                {
                    case 1:
                         await UpdateAccountType();
                        break;
                    case 2:
                        await UpdateFixedDeposit();
                        break;
                    default:
                        break;
                }

            }
            async Task UpdateAccountType()
            {
                Console.WriteLine("1.Update Account Type\n 2. Update Home Branch\n 3.Update FD Amount\n");
                int choice2 = int.Parse(ReadLine());
                Account account = new Account();
                switch (choice2)
                {
                    case 1:
                        Console.WriteLine("Enter Account ID");
                        bool isGuid = Guid.TryParse(ReadLine(), out Guid accountID);
                        if (isGuid == false)
                        {
                            Console.WriteLine("Invalid Guid");
                            await DisplayMenu();

                        }
                        account.AccountID = accountID;
                        Console.WriteLine("Enter New Account Type(Only Current and Savings)");
                        string accountType = ReadLine();
                        AccountBL accountBL = new AccountBL();
                        try
                        {
                            if (await accountBL.ChangeAccountTypeBL(account.AccountID, accountType))

                            {
                                Console.WriteLine("Account Type CHanged");
                                await DisplayMenu();
                            }
                            else
                            {
                                Console.WriteLine("Error while changing Account");
                                await DisplayMenu();
                            }
                        }
                        catch (AccountDoesNotExistException ae)
                        {

                            Console.WriteLine(ae.Message);
                        }
                        await DisplayMenu();
                        break;

                    case 2:
                        Console.WriteLine("Enter ID");
                        bool isGuid1 = Guid.TryParse(ReadLine(), out Guid accountID1);
                        if (isGuid1 == false)
                        {
                            Console.WriteLine("Invalid Guid");
                            await DisplayMenu();

                        }
                        account.AccountID = accountID1;
                        Console.WriteLine("Enter Home Branch");
                        string homeBranch = ReadLine();
                        AccountBL accountBL1 = new AccountBL();
                        try
                        {
                            if (await accountBL1.ChangeBranchBL(account.AccountID, homeBranch))
                                Console.WriteLine("Branch Changed Successfully");
                            else
                                Console.WriteLine("Branch Change Failed");
                        }
                        catch (AccountDoesNotExistException e )
                        {

                            Console.WriteLine(e.Message);
                        }
                       
                        await DisplayMenu();
                        break;
                   




                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }

            }

            async Task UpdateFixedDeposit()
            {
                Console.WriteLine("1. Update Home Branch\n 2.Update FD Amount\n");
                int choice2 = int.Parse(ReadLine());
                FixedDeposit fixedDeposit = new FixedDeposit();
                switch (choice2)
                {
                    case 1:
                        Console.WriteLine("Enter ID");
                        bool isGuid1 = Guid.TryParse(ReadLine(), out Guid accountID1);
                        if (isGuid1 == false)
                        {
                            Console.WriteLine("Invalid Guid");
                            await DisplayMenu();

                        }
                      fixedDeposit.AccountID = accountID1;
                        Console.WriteLine("Enter Home Branch");
                        string homeBranch = ReadLine();
                        FixedDepositBL fixedDepositBL1 = new FixedDepositBL();
                        if (await fixedDepositBL1.ChangeBranchBL(fixedDeposit.AccountID, homeBranch))
                            Console.WriteLine("Branch Changed Successfully");
                        else
                            Console.WriteLine("Branch Change Failed");
                        break;

                    default:
                        Console.WriteLine("Enter Valid Choice");
                        break;

                    case 2:
                        Console.WriteLine("Enter New FD Amount");
                       double newAmount= double.Parse(ReadLine());
                        Console.WriteLine("Enter AccountID");
                        bool isGuid2 = Guid.TryParse(ReadLine(), out Guid accountID2);
                        if (isGuid2 == false)
                        {
                            Console.WriteLine("Invalid Guid");
                            await DisplayMenu();

                        }
                        fixedDeposit.AccountID = accountID2;
                        FixedDepositBL fixedDepositBL2 = new FixedDepositBL();
                        if (fixedDepositBL2.UpdateFDAmountBL(fixedDeposit.AccountID,newAmount ))
                        {
                            Console.WriteLine("FD Amount Updated");
                            await DisplayMenu();
                        }
                        else
                        {
                            Console.WriteLine("AMount Not Updated");
                            await DisplayMenu();
                        }
                        break;

                }
            }

            async Task RemoveAccount()
            {
                Console.WriteLine("1.To Remove Current or Savings Account\n2.Remove Fixed Deposit");
                int choice = int.Parse(ReadLine());
                switch (choice)
                {
                    case 1:
                        await RemoveAccountType();
                        break;
                    case 2:
                        await RemoveFixedDeposit();
                        break;
                    default:
                        break;
                }
            }
            async Task RemoveFixedDeposit()
            {
               FixedDeposit fixedDeposit = new FixedDeposit();
                Console.WriteLine("ENter AccountID");
                bool isGuid1 = Guid.TryParse(ReadLine(), out Guid accountID1);
                if (isGuid1 == false)
                {
                    Console.WriteLine("Invalid Guid");
                    await DisplayMenu();

                }
                fixedDeposit.AccountID = accountID1;
                Console.WriteLine("Please Give your FeedBack why you want to delete the Account");
                string feedback = ReadLine();
               FixedDepositBL fixedDepositBL= new FixedDepositBL();
                try
                {
                    if (await fixedDepositBL.DeleteFixedDeposit(fixedDeposit.AccountID, feedback))
                    {
                        Console.WriteLine("Account Deleted Successfully");
                        await DisplayMenu();
                    }
                    else
                    {
                        Console.WriteLine("Error while Deleting Account");
                        await DisplayMenu();
                    }
                }
                catch (AccountDoesNotExistException e)
                {

                    Console.WriteLine(e.Message);
                }
                await DisplayMenu();
            }

            async Task RemoveAccountType()
            {
                Account account = new Account();
                Console.WriteLine("ENter AccountID");
                bool isGuid1 = Guid.TryParse(ReadLine(), out Guid accountID1);
                if (isGuid1 == false)
                {
                    Console.WriteLine("Invalid Guid");
                    await DisplayMenu();

                }
                account.AccountID = accountID1;
                Console.WriteLine("Please Give your FeedBack why you want to delete the Account");
                string feedback = ReadLine();
                AccountBL accountBL = new AccountBL();
                try
                {
                    if (await accountBL.DeleteAccount(account.AccountID, feedback))
                    {
                        Console.WriteLine("Account Deleted Successfully");

                        await DisplayMenu();
                    }
                    else
                    {
                        Console.WriteLine("Error while Deleting Account");
                        await DisplayMenu();

                    }
                }
                catch (AccountDoesNotExistException e)
                {

                    Console.WriteLine(e.Message);
                }

                await DisplayMenu();

            }

            async Task GetAccountByCustomerID()
            {
                Console.WriteLine("1.Get CUrrent or Savings Account\n 2. Get Fixed Deposits");
                int choice = int.Parse(ReadLine());
                switch (choice)
                {
                    case 1:
                        await GetAccountTypeByCustomerID();
                        break;
                    case 2:
                        await GetFixedDepositsByCustomerID();
                        break;
                    default:
                        break;
                }
            }

            async Task GetAccountTypeByCustomerID()
            {
                Account account = new Account();
                Console.WriteLine("Enter CustomerID");
                account.CustomerID = Guid.Parse(ReadLine());
                AccountBL accountBL = new AccountBL();
                CustomerBL customerBL = new CustomerBL();
                List<Account> accountList = new List<Account>();
                //CustomerEntities customerEntities = new CustomerEntities();
                //customerEntities = customerBL.GetCustomerByCustomerIDBL(account.CustomerID);
                try
                {
                    accountList = accountBL.GetAccountByCustomerIDBL(account.CustomerID);
                }
                catch (EnterValidCustomerIDException e)
                {
                    Console.WriteLine(e.Message);


                }
               catch(CustomerDoesNotExistException e)
                {
                    Console.WriteLine(e.Message);
                }

                foreach(Account acc in accountList)

                {
                        Console.WriteLine("Customer Account Number " + acc.AccountNo);
                        Console.WriteLine("Customer Balance " + acc.Balance);
                        Console.WriteLine("Customer Branch " + acc.HomeBranch);
                        
                }

               await  DisplayMenu();


            }

            async Task GetFixedDepositsByCustomerID()
            {

               FixedDeposit fixedDeposit = new FixedDeposit();
                Console.WriteLine("Enter CustomerID");
                fixedDeposit.CustomerID = Guid.Parse(ReadLine());
                FixedDepositBL fixedDepositBL = new FixedDepositBL();
                //CustomerBL customerBL = new CustomerBL();
                List<FixedDeposit> fixedDepositList = new List<FixedDeposit>();
                //CustomerEntities customerEntities = new CustomerEntities();
                //customerEntities = customerBL.GetCustomerByCustomerIDBL(account.CustomerID);
                try
                {
                    fixedDepositList = fixedDepositBL.GetFixedDepositByCustomerIDBL(fixedDeposit.CustomerID);
                }
                catch (EnterValidCustomerIDException ev)
                {
                    Console.WriteLine(ev.Message);
                  
                }
                

                foreach (FixedDeposit index in fixedDepositList)

                {
                    Console.WriteLine("Customer Account Number " + index.AccountNo);
                    Console.WriteLine("Customer FD Amount " + index.FdDeposit);
                    Console.WriteLine("Customer Branch " + index.HomeBranch);

                }

                await DisplayMenu();


            }

            async Task GetAccountByAccountID()
            {
                Console.WriteLine("1.Get CUrrent or Savings Account By Account ID\n 2. Get Fixed Deposits By Account ID");
                int choice = int.Parse(ReadLine());
                switch (choice)
                {
                    case 1:
                        await GetAccountTypeByAccountID();
                        break;
                    case 2:
                        await GetFixedDepositsByAccountID();
                        break;
                    default:
                        break;
                }
            }
            async Task<bool> GetAccountTypeByAccountID()
            {
                Account account = new Account();
                Console.WriteLine("Enter Account ID");
                account.AccountID = Guid.Parse(ReadLine());
                AccountBL accountBL = new AccountBL();
                try
                {
                    account = await accountBL.GetAccountByAccountIDBL(account.AccountID);
                    

               }
                catch (CustomerDoesNotExistException c)
                {
                    Console.WriteLine(c.Message);
                    return false;
                   
                   
                }
                catch(EnterValidCustomerIDException c)
                {
                    Console.WriteLine(c.Message);
                    return false;
                }
                

                if (account != default(Account))
                {
                    Console.WriteLine("Customer Account Number " + account.AccountNo);
                    Console.WriteLine("Customer Balance " + account.Balance);
                    Console.WriteLine("Customer Branch " + account.HomeBranch);
                    return true;
                }

                await DisplayMenu();
                return false;
            }
            async Task GetFixedDepositsByAccountID()
            {
                FixedDeposit fixedDeposit = new FixedDeposit();
                Console.WriteLine("Enter Account ID");
                fixedDeposit.AccountID = Guid.Parse(ReadLine());
                FixedDepositBL fixedDepositBL = new FixedDepositBL();
                try
                {
                    fixedDeposit = await fixedDepositBL.GetFixedDepositByAccountIDBL(fixedDeposit.AccountID);

                    Console.WriteLine("Customer Account Number " + fixedDeposit.AccountNo);
                    Console.WriteLine("Customer FD Deposit " + fixedDeposit.FdDeposit);
                    Console.WriteLine("Customer Branch " + fixedDeposit.HomeBranch);

                }
                catch (CustomerDoesNotExistException c)
                {

                    Console.WriteLine(c.Message);


                }




                await DisplayMenu();
            }

            async Task DisplayAllAccounts()
            {
                Console.WriteLine("1.Display All Accounts(Current and Savings)\n2. Display All FixedDeposits");
                int choice = int.Parse(ReadLine());
                switch (choice)
               
                {
                    case 1:
                        await DisplayAllAccountsType();
                        break;
                    case 2:
                        await DisplayAllFixedDeposits();
                        break;
                    default:
                        break;
                }
            }
            async Task DisplayAllAccountsType()
            {
                List<Account> accountList = new List<Account>();
                AccountBL accountBL = new AccountBL();
                accountList =  accountBL.GetAllAccountsBL();
                foreach(Account acc in accountList)
                {
                if(acc.IsActive == true)
                    {
                        Console.WriteLine("Customer Account Number " + acc.AccountNo);
                        Console.WriteLine("Customer Balance " + acc.Balance);
                        Console.WriteLine("Customer Branch " + acc.HomeBranch);
                        Console.WriteLine("Customer Account Type " + acc._accType);
                        Console.WriteLine("--------------------------------------------------------------------------");
                    }
                       
                }
               await DisplayMenu();
            }

            async Task DisplayAllFixedDeposits()
            {
                List<FixedDeposit> fixedDepositList = new List<FixedDeposit>();
                FixedDepositBL fixedDepositBL = new FixedDepositBL();
                fixedDepositList =  fixedDepositBL.GetAllFixedDepositBL();
                foreach (FixedDeposit index in fixedDepositList )
                {
                    if (index.IsActive == true)
                    {
                        Console.WriteLine("Customer Account Number " + index.AccountNo);
                        Console.WriteLine("Customer FD Amount " + index.FdDeposit);
                        Console.WriteLine("Customer Branch " + index.HomeBranch);
                        Console.WriteLine("--------------------------------------------------------------------------");
                    }

                }
                await DisplayMenu();
            }

        }

    }

}
