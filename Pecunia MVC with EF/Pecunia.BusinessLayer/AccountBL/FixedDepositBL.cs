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

        public bool ValidateInitialAmount(long initialAmount)         // Validate if FD amount is atleast 20,000
        {
            bool result = true;
            if (initialAmount < 20000)
            {
                result = false;
                throw new InitialAmountOfFDException("Minimum amount for FD is 20000");
            }
            if (initialAmount > 1000000)
            {
                result = false;
                throw new InitialAmountOfFDException("Max amount for FD is 1000000");
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
            if (newAmount > 1000000)
            {
                result = false;
                throw new InitialAmountOfFDException("Max amount for FD is 1000000");
            }

            return result;

        }
        public bool UpdateFDAmountBL(Guid accountID, double newAmount)
        {
            FixedDepositDAL fixedDepositDAL = new FixedDepositDAL();

            bool result = false;
            if (fixedDepositDAL.AccountIDExistsFixedDeposit(accountID) && ValidateNewAount(newAmount))
            {


                result = fixedDepositDAL.ChangeFdAmount(accountID, newAmount);



            }
            return result;
        }


        public override async Task<bool> Validate(FixedDeposit fixedDeposit)
        {
            bool valid = true;
            valid = await base.Validate(fixedDeposit);
            //if(ValidateInitialAmount(fixedDeposit.FdDeposit))
            //    valid = true;
            valid = ValidateInitialAmount((long)fixedDeposit.FdDeposit);
            return valid;


        }

        //====================================================================================================================
        public async Task<bool> AddFixedDepositBL(FixedDeposit fixedDeposit, Guid customerID)
        {

            bool result = false;

            FixedDepositDAL fixedDepositDAL = new FixedDepositDAL();


            CustomerDAL customerDAL = new CustomerDAL();

            fixedDeposit.CustomerID = customerID;


            if (await Validate(fixedDeposit))
            {
                await Task.Run(() =>
                {
                    Guid AccountIDGenerator = Guid.NewGuid();
                    fixedDeposit.AccountID = AccountIDGenerator;

                    if (FDAccountNumberGenerator.Count == 0)
                    {
                        fixedDeposit.AccountNumber = 300001;
                        long temp = (long)fixedDeposit.AccountNumber;

                        FDAccountNumberGenerator.Add(temp);

                    }
                    else
                    {
                        int index = FDAccountNumberGenerator.Count;
                        long temp = (FDAccountNumberGenerator[index - 1]) + 1;
                        FDAccountNumberGenerator.Add(temp);
                        fixedDeposit.AccountNumber = temp;
                    }

                    if (fixedDeposit.Tenure == 5)
                    {
                        fixedDeposit.InterestRate = 4;
                    }
                    else if (fixedDeposit.Tenure == 10)
                    {
                        fixedDeposit.InterestRate = 6;
                    }
                    else
                    {
                        fixedDeposit.InterestRate = 8;
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
                if (FixedDepositDAL.AccountIDExistsFixedDeposit(accountID))
                {

                    result = FixedDepositDAL.DeleteFixedDepositDAL(accountID, feedback);         // Calling DAL Method of Delete Account
                }
                else
                {
                    throw new AccountDoesNotExistException("Enter Valid Account ID");
                }
            });

            return result;
        }

        public List<FixedDeposit> GetFixedDepositByCustomerIDBL(Guid customerID)
        {
            CustomerDAL customerDAL = new CustomerDAL();



            FixedDepositDAL fixedDepositDAL = new FixedDepositDAL();
            return fixedDepositDAL.GetFixedDepositByCustomerIDDAL(customerID);


        }





        public async Task<FixedDeposit> GetFixedDepositByAccountIDBL(Guid accountID)
        {

            FixedDepositDAL fixedDepositDAL = new FixedDepositDAL();
            FixedDeposit fixedDeposit = new FixedDeposit();
            await Task.Run(() =>
            {
                if (fixedDepositDAL.AccountIDExistsFixedDeposit(accountID))
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
                if (fixedDepositDAL.AccountIDExistsFixedDeposit(accountID))
                {
                    res = fixedDepositDAL.ChangeBranchOfFixedDeposit(accountID, homeBranch);
                }

                res = true;
            });

            return res;
        }
        public List<FixedDeposit> GetAllFixedDepositBL()
        {
            FixedDepositDAL fixedDepositDAL = new FixedDepositDAL();



            return fixedDepositDAL.GetAllFixedDepositsDAL();
        }
    }
}

