using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capgemini.Pecunia.Entities;
using Capgemini.Pecunia.Exceptions;
using Capgemini.Pecunia.DataAccessLayer;
using System.Text.RegularExpressions;
using static System.Console;
using System.IO;
using Pecunia.Contracts.BLContracts;
using Capgemini.Pecunia.BusinessLayer;
using Capgemini.Pecunia.Contracts.BLContracts;


namespace Capgemini.Pecunia.BusinessLayer
{
    public class FixedDepositBL : BLbase<FixedDeposit>, IFixedDepositBL
    {
        public static List<long> FDAccountNumberGenerator = new List<long>();

        public bool ValidateInitialAmount(double initialAmount)         // Validate if FD amount is atleast 20,000
        {
            bool result = true;
          if(initialAmount < 20000)
            {
                result = false;
                throw new InitialAmountOfFDException("Minimum amount for FD is 20000");
            }


            return result;
        }
        public bool ValidateNewAount(double newAmount)
        {
            bool result = true;
            if (newAmount < 20000)
            {
                result = false;
                throw new InitialAmountOfFDException("Amount should be Atleast 20000");

            }

            return result;

        }
        public bool UpdateFDAmountBL(Guid accountID, double newAmount)
        {
            FixedDepositDAL fixedDepositDAL = new FixedDepositDAL();
            
            bool result = false;
            if (fixedDepositDAL.AccountIDExists(accountID) && ValidateNewAount(newAmount))
            {

                FixedDeposit fixedDepositTemporary = fixedDepositDAL.GetFixedDepositByAccountIDDAL(accountID);
                
                fixedDepositTemporary.FdDeposit = newAmount;
                if (newAmount > 100000)
                {
                    fixedDepositTemporary.InterestRate = 5;
                    result = true;
                }

                else
                {
                    fixedDepositTemporary.InterestRate = 6;
                    result = true;
                }
                fixedDepositDAL.SerializeUpdated(fixedDepositTemporary);

            }
            return result;
        }


        public override async Task<bool> Validate(FixedDeposit fixedDeposit)
        {
            bool valid = true;
             valid = await base.Validate(fixedDeposit);
            //if(ValidateInitialAmount(fixedDeposit.FdDeposit))
            //    valid = true;

            return valid;
           

        }

        //====================================================================================================================
        public async Task<bool> AddFixedDepositBL(FixedDeposit fixedDeposit, Guid customerID)
        {

            bool result = false;

            FixedDepositDAL fixedDepositDAL = new FixedDepositDAL();


            CustomerDAL customerDAL = new CustomerDAL();
            if (customerDAL.isCustomerIDExistDAL(customerID))
            {
                fixedDeposit.CustomerID = customerID;
            }

            if(await Validate(fixedDeposit))
            {
                await Task.Run(() =>
                {
                    Guid AccountIDGenerator = Guid.NewGuid();
                    fixedDeposit.AccountID = AccountIDGenerator;

                    if (FDAccountNumberGenerator.Count == 0)
                    {
                        fixedDeposit.AccountNo = 300001;
                        FDAccountNumberGenerator.Add(fixedDeposit.AccountNo);

                    }
                    else
                    {
                        int index = FDAccountNumberGenerator.Count;
                        fixedDeposit.AccountNo = (FDAccountNumberGenerator[index - 1]) + 1;
                        FDAccountNumberGenerator.Add(fixedDeposit.AccountNo);
                    }

                    result = fixedDepositDAL.AddFixedDepositDAL(fixedDeposit);
                });
              
            }
           
               
            return result;
            }

       

        public async Task<bool> DeleteFixedDeposit(Guid accountID, string feedback)
        {
            bool result = false;
            FixedDepositDAL FixedDepositDAL = new FixedDepositDAL();
            await Task.Run(() =>
            {
                if (FixedDepositDAL.AccountIDExists(accountID))
                {

                    result = FixedDepositDAL.DeleteFixedDepositDAL(accountID, feedback);         // Calling DAL Method of Delete Account
                }
                else
                {
                    throw new AccountDoesNotExistException("Enter Valid Customer ID");
                }
            });

            return result;
        }

        public List<FixedDeposit> GetFixedDepositByCustomerIDBL(Guid customerID)
        {
            CustomerDAL customerDAL = new CustomerDAL();
          

            if (customerDAL.isCustomerIDExistDAL(customerID))
            {
                FixedDepositDAL fixedDepositDAL = new FixedDepositDAL();
                return fixedDepositDAL.GetFixedDepositByCustomerIDDAL(customerID);
            }
            else
            {
                throw new EnterValidCustomerIDException("ENter Valid Customer ID");
            }

        }

        

          

        public async Task<FixedDeposit> GetFixedDepositByAccountIDBL(Guid accountID)
        {

            FixedDepositDAL fixedDepositDAL = new FixedDepositDAL();
            FixedDeposit fixedDeposit = new FixedDeposit();
            await Task.Run(() =>
            {
                if (fixedDepositDAL.AccountIDExists(accountID))
                {

                    fixedDeposit = fixedDepositDAL.GetFixedDepositByAccountIDDAL(accountID);
                }
                else
                {
                    throw new EnterValidAccountIDException("ENter Valid AccountID"); // Account Number Kar Hyala
                }
            });
            
            return fixedDeposit;
        }

        public async Task<bool> ChangeBranchBL(Guid accountID, string homeBranch)
        {
            FixedDeposit temporaryObject = new FixedDeposit();
            FixedDepositDAL fixedDepositDAL = new FixedDepositDAL();
            bool res = false;
            await Task.Run(() =>
            {
                if (fixedDepositDAL.AccountIDExists(accountID))
                {
                    temporaryObject = fixedDepositDAL.GetFixedDepositByAccountIDDAL(accountID);
                }
                temporaryObject.HomeBranch = homeBranch;
                fixedDepositDAL.SerializeUpdated(temporaryObject);
                res = true;
            });
         
            return res;
        }
        public List<FixedDeposit> GetAllFixedDepositBL()
        {
            FixedDepositDAL fixedDepositDAL = new FixedDepositDAL();
          
          
       
            return  fixedDepositDAL.GetAllFixedDepositsDAL();
        }
    }
    }

