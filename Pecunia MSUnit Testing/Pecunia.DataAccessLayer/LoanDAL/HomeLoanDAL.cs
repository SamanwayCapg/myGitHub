using System.Collections.Generic;
using Capgemini.Pecunia.Entities;
using Newtonsoft.Json;
using System.IO;
using System;
using Capgemini.Pecunia.Contracts.DALcontracts.LoanDALBase;
using System.Data.SqlClient;
using System.Data;
using Capgemini.Pecunia.Helpers;

namespace Capgemini.Pecunia.DataAccessLayer.LoanDAL
{
    /// <summary>
    /// Contains data access layer methods for validating, inserting, updating, deleting Home Loan from Home Loans collection.
    /// </summary>
    public class HomeLoanDAL : HomeLoanDALBase, IDisposable
    {
        public static List<HomeLoan> HomeLoans = new List<HomeLoan>();

        /// <summary>
        /// Validation before applying a new loan.
        /// </summary>
        /// <param name="HomeLoan">Represents home loan object that contains details of home loan.</param>
        /// <returns>Returns a boolean value, that indicates whether loan is applied or not.</returns>
        public override bool ApplyLoanDAL(HomeLoan home)
        {

            //var loanList = DeserializeFromJSON(fileName);
            //loanList.Add(home);
            //return SerializeIntoJSON(loanList, fileName);

            //SqlConnection conn = SQLServerUtil.getConnetion("ndamssql\\sqlilearn", "13th Aug CLoud PT Immersive", "sqluser", "sqluser");
            SqlConnection conn = SQLServerUtil.getConnetionWinAuth("Pecunia");
            try
            {
                conn.Open();


                SqlCommand comm = new SqlCommand("TeamF.applyHomeLoan", conn);

                Guid loanID = Guid.NewGuid();
                SqlParameter param1 = new SqlParameter("@LoanID", loanID);
                param1.SqlDbType = SqlDbType.UniqueIdentifier;

                //Guid customerID;
                //Guid.TryParse(car.CustomerID, out customerID);
                SqlParameter param2 = new SqlParameter("@CustomerID", home.CustomerID);
                param2.SqlDbType = SqlDbType.UniqueIdentifier;

                SqlParameter param3 = new SqlParameter("@AmountApplied", home.AmountApplied);
                param3.SqlDbType = SqlDbType.Money;

                SqlParameter param4 = new SqlParameter("@InterestRate", home.InterestRate);
                param4.SqlDbType = SqlDbType.Money;

                SqlParameter param5 = new SqlParameter("@EMI_amount", home.EMI_Amount);
                param5.SqlDbType = SqlDbType.Money;

                SqlParameter param6 = new SqlParameter("@RepaymentPeriod", home.RepaymentPeriod);
                param6.SqlDbType = SqlDbType.TinyInt;

                DateTime dateOfApplication = DateTime.Now;
                SqlParameter param7 = new SqlParameter("@DateOfApplication", dateOfApplication);
                param7.SqlDbType = SqlDbType.DateTime;

                SqlParameter param8 = new SqlParameter("@LoanStatus", home.Status);
                param8.SqlDbType = SqlDbType.VarChar;

                SqlParameter param9 = new SqlParameter("@Occupation", home.Occupation);
                param9.SqlDbType = SqlDbType.VarChar;

                SqlParameter param10 = new SqlParameter("@ServiceYears", home.ServiceYears);
                param10.SqlDbType = SqlDbType.TinyInt;

                SqlParameter param11 = new SqlParameter("@GrossIncome", home.GrossIncome);
                param11.SqlDbType = SqlDbType.Money;

                SqlParameter param12 = new SqlParameter("@SalaryDeduction", home.SalaryDeductions);
                param12.SqlDbType = SqlDbType.Money;

                

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
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                BusinessLogicUtil.PecuniaLogException("applyHomeLoan", e.Message);
                return false;
            }
        }

        /// <summary>
        /// For approving loan.
        /// </summary>
        /// <param name="loanID">Represents Loan ID.</param>
        /// <param name="updatedStatus">Represents Updated Loan Status.</param>
        /// <returns>Returns Home loan object.</returns>
        public override HomeLoan ApproveLoanDAL(string loanID, LoanStatus updatedStatus)
        {

            //SqlConnection conn = SQLServerUtil.getConnetion("ndamssql\\sqlilearn", "13th Aug CLoud PT Immersive", "sqluser", "sqluser");
            SqlConnection conn = SQLServerUtil.getConnetionWinAuth("Pecunia");
            try
            {
                conn.Open();
                Console.WriteLine("connected");
                SqlCommand comm = new SqlCommand("TeamF.approveHomeLoan", conn);

                Guid LoanID;
                Guid.TryParse(loanID, out LoanID);
                SqlParameter param1 = new SqlParameter("@LoanID", LoanID);
                param1.SqlDbType = SqlDbType.UniqueIdentifier;

                SqlParameter param2 = new SqlParameter("@updatedStatus", updatedStatus);
                param2.SqlDbType = SqlDbType.VarChar;

                List<SqlParameter> Params = new List<SqlParameter>();
                Params.Add(param1);
                Params.Add(param2);
                comm.Parameters.AddRange(Params.ToArray());
                comm.CommandType = CommandType.StoredProcedure;
                comm.ExecuteNonQuery();
                

                HomeLoan objToReturn = new HomeLoan();
                comm = new SqlCommand($"select * from TeamF.HomeLoan where LoanID='{loanID}'", conn);

                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    if (reader == null)
                        reader.Close();
                    else
                        objToReturn = getNETdataTypes(reader, objToReturn);

                }
                conn.Close();
                return objToReturn;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.ReadKey();
                return default(HomeLoan);
            }

            
        }

        /// <summary>
        /// For displaying loan for specific customer ID.
        /// </summary>
        /// <param name="customerID">Represents Customer ID.</param>
        /// <returns>Returns Home Loan for Customer.</returns>
        public override HomeLoan GetLoanByCustomerIDDAL(string customerID)
        {
            //SqlConnection conn = SQLServerUtil.getConnetion("ndamssql\\sqlilearn", "13th Aug CLoud PT Immersive", "sqluser", "sqluser");
            SqlConnection conn = SQLServerUtil.getConnetionWinAuth("Pecunia");
            HomeLoan objToReturn = new HomeLoan();
            try
            {
                conn.Open();
                Console.WriteLine("connected");
                SqlCommand comm = new SqlCommand("TeamF.getHomeLoanByCustomerID", conn);

                Guid CustomerID;
                Guid.TryParse(customerID, out CustomerID);
                SqlParameter param1 = new SqlParameter("@CustomerID", CustomerID);
                param1.SqlDbType = SqlDbType.UniqueIdentifier;

                List<SqlParameter> Params = new List<SqlParameter>();
                Params.Add(param1);
                comm.Parameters.AddRange(Params.ToArray());
                comm.CommandType = CommandType.StoredProcedure;
                comm.ExecuteNonQuery();



                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    if (reader == null)
                        reader.Close();
                    else
                        objToReturn = getNETdataTypes(reader, objToReturn);

                }
                conn.Close();
                return objToReturn;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.ReadKey();
                return default(HomeLoan);
            }
            
        }

        /// <summary>
        /// Gets Loan by Loan ID.
        /// </summary>
        /// <param name="loanID">Represents Loan ID.</param>
        /// <returns>Returns Home loan object.</returns>
        public override HomeLoan GetLoanByLoanIDDAL(string loanID)
        {
            //SqlConnection conn = SQLServerUtil.getConnetion("ndamssql\\sqlilearn", "13th Aug CLoud PT Immersive", "sqluser", "sqluser");
            SqlConnection conn = SQLServerUtil.getConnetionWinAuth("Pecunia");
            HomeLoan objToReturn = new HomeLoan();
            try
            {
                conn.Open();
                Console.WriteLine("connected");
                SqlCommand comm = new SqlCommand("TeamF.getHomeLoanByLoanID", conn);

                Guid LoanID;
                Guid.TryParse(loanID, out LoanID);
                SqlParameter param1 = new SqlParameter("@LoanID", LoanID);
                param1.SqlDbType = SqlDbType.UniqueIdentifier;

                List<SqlParameter> Params = new List<SqlParameter>();
                Params.Add(param1);
                comm.Parameters.AddRange(Params.ToArray());
                comm.CommandType = CommandType.StoredProcedure;
                comm.ExecuteNonQuery();



                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    if (reader == null)
                        reader.Close();
                    else
                        objToReturn = getNETdataTypes(reader, objToReturn);

                }
                conn.Close();
                return objToReturn;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.ReadKey();
                return default(HomeLoan);
            }
        }

        /// <summary>
        /// For displaying loan status.
        /// </summary>
        /// <param name="loanID">Represents Loan ID.</param>
        /// <returns>Returns Loan Status for Loans.</returns>
        public override string GetLoanStatusDAL(string loanID)
        {
            //SqlConnection conn = SQLServerUtil.getConnetion("ndamssql\\sqlilearn", "13th Aug CLoud PT Immersive", "sqluser", "sqluser");
            SqlConnection conn = SQLServerUtil.getConnetionWinAuth("Pecunia");
            string status = "";
            try
            {
                conn.Open();
                Console.WriteLine("connected");
                SqlCommand comm = new SqlCommand("TeamF.getHomeLoanStatus", conn);

                Guid LoanID;
                Guid.TryParse(loanID, out LoanID);
                SqlParameter param1 = new SqlParameter("@LoanID", LoanID);
                param1.SqlDbType = SqlDbType.UniqueIdentifier;

                List<SqlParameter> Params = new List<SqlParameter>();
                Params.Add(param1);
                comm.Parameters.AddRange(Params.ToArray());
                comm.CommandType = CommandType.StoredProcedure;
                comm.ExecuteNonQuery();



                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    if (reader == null)
                        reader.Close();
                    else
                        status = reader.GetString(0);

                }
                conn.Close();
                return status;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.ReadKey();
                return default(string);
            }
        }

        

        /// <summary>
        /// Lists all Loans.
        /// </summary>    
        /// <returns>Returns list of Home loan objects.</returns>
        public override DataSet ListAllLoansDAL()
        {
            List<HomeLoan> HomeLoans = new List<HomeLoan>();
            //SqlConnection conn = SQLServerUtil.getConnetion("ndamssql\\sqlilearn", "13th Aug CLoud PT Immersive", "sqluser", "sqluser");
            SqlConnection conn = SQLServerUtil.getConnetionWinAuth("Pecunia");
            SqlDataAdapter adapter = new SqlDataAdapter("select * from TeamF.HomeLoan", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            return ds;
        }

        /// <summary>
        /// Checks if a particular loan ID exists.
        /// </summary>    
        /// <returns>Returns bool value to know if loan ID exists or not.</returns>
        public override bool IsLoanIDExistDAL(string loanID)
        {
            return true;
        }


        HomeLoan getNETdataTypes(SqlDataReader reader, HomeLoan objToReturn)
        {
            objToReturn.LoanID = reader.GetGuid(0);
            objToReturn.CustomerID = reader.GetGuid(1);
            objToReturn.AmountApplied = Convert.ToDouble(reader.GetDecimal(2));
            objToReturn.InterestRate = Convert.ToDouble(reader.GetDecimal(3));
            objToReturn.EMI_Amount = Convert.ToDouble(reader.GetDecimal(4));
            objToReturn.RepaymentPeriod = reader.GetByte(5);
            objToReturn.DateOfApplication = reader.GetDateTime(6);
            LoanStatus status;
            Enum.TryParse(reader.GetString(7), out status);
            objToReturn.Status = status;
            ServiceType service;
            Enum.TryParse(reader.GetString(8), out service);
            objToReturn.Occupation = service;
            objToReturn.ServiceYears = reader.GetByte(9);
            objToReturn.GrossIncome = Convert.ToDouble(reader.GetDecimal(10));
            objToReturn.SalaryDeductions = Convert.ToDouble(reader.GetDecimal(11));
            return objToReturn;
        }
        /// <summary>
        /// Clears unmanaged resources such as db connections or file streams.
        /// </summary>
        public void Dispose()
        {
            //No unmanaged resources currently
        }
    }
}
