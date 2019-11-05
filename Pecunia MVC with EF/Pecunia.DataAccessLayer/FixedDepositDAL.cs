using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capgemini.Pecunia.Entities;
using Capgemini.Pecunia.Contracts.DALContracts;
using System.IO;
using Capgemini.Pecunia.Exceptions;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Windows.Input;

namespace Capgemini.Pecunia.DataAccessLayer
{
    public class FixedDepositDAL : FixedDepositBase
    {
        public override bool AddFixedDepositDAL(FixedDeposit fixedDepositObject)
        {
            using (PecuniaEntities db = new PecuniaEntities())
            {
                fixedDepositObject.IsActive = true;

                //db.Employees.Add(emp);
                //db.SaveChanges();
                db.AddFixedDepositDAL1(fixedDepositObject.AccountID, fixedDepositObject.CustomerID, fixedDepositObject.AccountNumber
                    , fixedDepositObject.HomeBranch, fixedDepositObject.IsActive, fixedDepositObject.Tenure, fixedDepositObject.FdDeposit
                    , Convert.ToDecimal(fixedDepositObject.InterestRate));
            }

            return true;

        }




        public override bool DeleteFixedDepositDAL(Guid accountID, string feedback)
        {

            using (PecuniaEntities db = new PecuniaEntities())
            {
                FixedDeposit fixedDeposit = db.FixedDeposits.Where(temp => temp.AccountID == accountID).FirstOrDefault();
                db.FixedDeposits.Remove(fixedDeposit);
                db.SaveChanges();

            }
            return true;
        }


        public override List<FixedDeposit> GetFixedDepositByCustomerIDDAL(Guid customerID)
        {
            List<FixedDeposit> fixedDeposits = new List<FixedDeposit>();

            using (PecuniaEntities db = new PecuniaEntities())
            {
                fixedDeposits = db.FixedDeposits.Where(temp => temp.CustomerID == customerID).ToList();

            }
            return fixedDeposits;

        }

        public override List<FixedDeposit> GetAllFixedDepositsDAL()
        {
            List<FixedDeposit> fixedDeposits = new List<FixedDeposit>();

            using (PecuniaEntities db = new PecuniaEntities())
            {
                fixedDeposits = db.FixedDeposits.ToList();

            }
            return fixedDeposits;
        }


        public override FixedDeposit GetFixedDepositByAccountIDDAL(Guid accountID)
        {
            FixedDeposit fixedDeposit = new FixedDeposit();

            using (PecuniaEntities db = new PecuniaEntities())
            {
                fixedDeposit = db.FixedDeposits.Where(temp => temp.AccountID == accountID).FirstOrDefault();

            }
            return fixedDeposit;

        }

        public override bool AccountIDExistsFixedDeposit(Guid accountID)
        {


            using (PecuniaEntities db = new PecuniaEntities())
            {
                FixedDeposit fixedDeposit = db.FixedDeposits.Where(temp => temp.AccountID == accountID).FirstOrDefault();

                if (fixedDeposit == null)
                {
                    return false;
                }
                else
                    return true;
            }


        }

        public override bool ChangeBranchOfFixedDeposit(Guid accountID, string homebranch)
        {
            using (PecuniaEntities db = new PecuniaEntities())
            {
                db.ChangeBranchofFixedDeposit(accountID, homebranch);
            }
            return true;
        }


        public override bool ChangeFdAmount(Guid accountID, double amount)
        {

            using (PecuniaEntities db = new PecuniaEntities())
            {
                db.ChangeFDDeposit(accountID, (decimal)amount);
            }
            return true;

        }
    }
}
