using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capgemini.Pecunia.Helpers;
using System.Data.SqlClient;
using System.Data;

namespace TestADO
{
    class Program
    {
        static void Main(string[] args)
        {
            //SqlConnection conn = SQLServerUtil.getConnetion("ndamssql\\sqlilearn", "13th Aug CLoud PT Immersive", "sqluser", "sqluser");
            SqlConnection conn = SQLServerUtil.getConnetion("Pecunia");
            try
            {
                conn.Open();
                Console.WriteLine("connected to the database");

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }


            SqlCommand comm = new SqlCommand("TeamF.applyCarLoan", conn);

            Guid loanID = Guid.NewGuid(); Console.WriteLine(loanID);
            SqlParameter param1 = new SqlParameter("@LoanID", loanID);
            param1.SqlDbType = SqlDbType.UniqueIdentifier;

            Guid customerID;
            Guid.TryParse("33EA6038-57D3-4912-8EA8-662BC1B1C413", out customerID);
            SqlParameter param2 = new SqlParameter("@CustomerID", customerID);
            param2.SqlDbType = SqlDbType.UniqueIdentifier;

            SqlParameter param3 = new SqlParameter("@AmountApplied", 120000);
            param3.SqlDbType = SqlDbType.Money;

            SqlParameter param4 = new SqlParameter("@InterestRate", 10.65);
            param4.SqlDbType = SqlDbType.Money;

            SqlParameter param5 = new SqlParameter("@EMI_amount", 4512.12);
            param5.SqlDbType = SqlDbType.Money;

            SqlParameter param6 = new SqlParameter("@RepaymentPeriod", 120);
            param6.SqlDbType = SqlDbType.TinyInt;

            DateTime dateOfApplication = DateTime.Now;
            SqlParameter param7 = new SqlParameter("@DateOfApplication", dateOfApplication);
            param7.SqlDbType = SqlDbType.DateTime;

            SqlParameter param8 = new SqlParameter("@LoanStatus", "APPLIED");
            param8.SqlDbType = SqlDbType.VarChar;

            SqlParameter param9 = new SqlParameter("@Occupation", "SERVICE");
            param9.SqlDbType = SqlDbType.VarChar;

            SqlParameter param10 = new SqlParameter("@GrossIncome", 50200);
            param10.SqlDbType = SqlDbType.Money;

            SqlParameter param11 = new SqlParameter("@SalaryDeduction", 2015);
            param11.SqlDbType = SqlDbType.Money;

            SqlParameter param12 = new SqlParameter("@VehicleType", "OTHERS");
            param12.SqlDbType = SqlDbType.VarChar;

            List<SqlParameter> Params = new List<SqlParameter>();
            Params.Add(param1);
            Params.Add(param2);
            Params.Add(param3);
            Params.Add(param4);
            Params.Add(param5);
            Params.Add(param6);
            Params.Add(param7);
            Params.Add(param8);
            Params.Add(param9);
            Params.Add(param10);
            Params.Add(param11);
            Params.Add(param12);

            comm.Parameters.AddRange(Params.ToArray());
            comm.CommandType = CommandType.StoredProcedure;
            comm.ExecuteNonQuery();
            conn.Close();

        }
    }
}
