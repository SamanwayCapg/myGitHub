using System.Collections.Generic;
using Capgemini.Pecunia.Entities;
using Newtonsoft.Json;
using System.IO;
using System;
using Pecunia.Contracts.DALcontracts.LoanDALBase;
using System.Data.SqlClient;
using System.Data;
using Capgemini.Pecunia.Helpers;

namespace Capgemini.Pecunia.DataAccessLayer.LoanDAL
{
    public class EduLoanDAL : EduLoanDALBase, IDisposable
    {
        public static List<EduLoan> EduLoans;

        public override bool ApplyLoanDAL(EduLoan edu)
        {

            return true;
        }

        public override EduLoan ApproveLoanDAL(string loanID, LoanStatus updatedStatus)
        {

            return default(EduLoan);
        }

        public override EduLoan GetLoanByCustomerIDDAL(string customerID)
        {

            return default(EduLoan);
        }

        public override EduLoan GetLoanByLoanIDDAL(string loanID)
        {
            return default(EduLoan);
        }

        public override string GetLoanStatusDAL(string loanID)
        {
            return "";
        }

        
        public override DataSet ListAllLoansDAL()
        {
            SqlConnection conn = SQLServerUtil.getConnetion("ndamssql\\sqlilearn", "13th Aug CLoud PT Immersive", "sqluser", "sqluser");
            //SqlConnection conn = SQLServerUtil.getConnetionWinAuth("Pecunia");
            SqlDataAdapter adapter = new SqlDataAdapter("select * from TeamF.EduLoan", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            return ds;
        }

        public override bool IsLoanIDExistDAL(string loanID)
        {
            return true;
        }

        //EduLoan getNETdataTypes(SqlDataReader reader, EduLoan objToReturn)
        //{
        //    objToReturn.LoanID = reader.GetGuid(0);
        //    objToReturn.CustomerID = reader.GetGuid(1);
        //    objToReturn.AmountApplied = Convert.ToDouble(reader.GetDecimal(2));
        //    objToReturn.InterestRate = Convert.ToDouble(reader.GetDecimal(3));
        //    objToReturn.EMI_Amount = Convert.ToDouble(reader.GetDecimal(4));
        //    objToReturn.RepaymentPeriod = reader.GetByte(5);
        //    objToReturn.DateOfApplication = reader.GetDateTime(6);
        //    LoanStatus status;
        //    Enum.TryParse(reader.GetString(7), out status);
        //    objToReturn.Status = status;
        //    CourseType course;
        //    Enum.TryParse(reader.GetString(8), out course);
        //    objToReturn.Course = course;
        //    objToReturn.InstituteName = reader.GetString(9);
        //    objToReturn.StudentID = reader.GetString(10);
        //    objToReturn.RepaymentHoliday = reader.GetByte(11);
        //    return objToReturn;
        //}
        /// <summary>
        /// Clears unmanaged resources such as db connections or file streams.
        /// </summary>
        public void Dispose()
        {
            //No unmanaged resources currently
        }


    }
}
