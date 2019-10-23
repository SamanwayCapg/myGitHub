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
    public class EduLoanDAL : EduLoanDALBase, IDisposable
    {
        public static List<EduLoan> EduLoans;

        public override bool ApplyLoanDAL(EduLoan edu)
        {

            SqlConnection conn = SQLServerUtil.getConnetion("ndamssql\\sqlilearn", "13th Aug CLoud PT Immersive", "sqluser", "sqluser");
            //SqlConnection conn = SQLServerUtil.getConnetionWinAuth("Pecunia");
            try
            {
                conn.Open();


                SqlCommand comm = new SqlCommand("TeamF.applyEduLoan", conn);

                Guid loanID = Guid.NewGuid();
                SqlParameter param1 = new SqlParameter("@LoanID", loanID);
                param1.SqlDbType = SqlDbType.UniqueIdentifier;

                //Guid customerID;
                //Guid.TryParse(car.CustomerID, out customerID);
                SqlParameter param2 = new SqlParameter("@CustomerID", edu.CustomerID);
                param2.SqlDbType = SqlDbType.UniqueIdentifier;

                SqlParameter param3 = new SqlParameter("@AmountApplied", edu.AmountApplied);
                param3.SqlDbType = SqlDbType.Money;

                SqlParameter param4 = new SqlParameter("@InterestRate", edu.InterestRate);
                param4.SqlDbType = SqlDbType.Money;

                SqlParameter param5 = new SqlParameter("@EMI_amount", edu.EMI_Amount);
                param5.SqlDbType = SqlDbType.Money;

                SqlParameter param6 = new SqlParameter("@RepaymentPeriod", edu.RepaymentPeriod);
                param6.SqlDbType = SqlDbType.TinyInt;

                DateTime dateOfApplication = DateTime.Now;
                SqlParameter param7 = new SqlParameter("@DateOfApplication", dateOfApplication);
                param7.SqlDbType = SqlDbType.DateTime;

                SqlParameter param8 = new SqlParameter("@LoanStatus", edu.Status);
                param8.SqlDbType = SqlDbType.VarChar;

                SqlParameter param9 = new SqlParameter("@Course", edu.Course);
                param9.SqlDbType = SqlDbType.VarChar;

                SqlParameter param10 = new SqlParameter("@InstituteName", edu.InstituteName);
                param10.SqlDbType = SqlDbType.VarChar;

                SqlParameter param11 = new SqlParameter("@StudentID", edu.StudentID);
                param11.SqlDbType = SqlDbType.VarChar;

                SqlParameter param12 = new SqlParameter("@RepaymentHoliday", edu.RepaymentHoliday);
                param12.SqlDbType = SqlDbType.TinyInt;

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
                //BusinessLogicUtil.PecuniaLogException("applyEduLoan", e.Message);
                return false;
            }

        }

        public override EduLoan ApproveLoanDAL(string loanID, LoanStatus updatedStatus)
        {
            EduLoan objToReturn = new EduLoan();
            SqlConnection conn = SQLServerUtil.getConnetion("ndamssql\\sqlilearn", "13th Aug CLoud PT Immersive", "sqluser", "sqluser");
            //SqlConnection conn = SQLServerUtil.getConnetionWinAuth("Pecunia");
            try
            {
                conn.Open();
                Console.WriteLine("connected");
                SqlCommand comm = new SqlCommand("TeamF.approveEduLoan", conn);

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


                comm = new SqlCommand($"select * from TeamF.EduLoan where LoanID='{loanID}'", conn);

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
                return default(EduLoan);
            }

        }

        public override EduLoan GetLoanByCustomerIDDAL(string customerID)
        {
            SqlConnection conn = SQLServerUtil.getConnetion("ndamssql\\sqlilearn", "13th Aug CLoud PT Immersive", "sqluser", "sqluser");
            //SqlConnection conn = SQLServerUtil.getConnetionWinAuth("Pecunia");
            EduLoan objToReturn = new EduLoan();
            try
            {
                conn.Open();
                Console.WriteLine("connected");
                SqlCommand comm = new SqlCommand("TeamF.getEduLoanByCustomerID", conn);

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
                return default(EduLoan);
            }

        }

        public override EduLoan GetLoanByLoanIDDAL(string loanID)
        {
            SqlConnection conn = SQLServerUtil.getConnetion("ndamssql\\sqlilearn", "13th Aug CLoud PT Immersive", "sqluser", "sqluser");
            //SqlConnection conn = SQLServerUtil.getConnetionWinAuth("Pecunia");
            EduLoan objToReturn = new EduLoan();
            try
            {
                conn.Open();
                Console.WriteLine("connected");
                SqlCommand comm = new SqlCommand("TeamF.getEduLoanByLoanID", conn);

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
                return default(EduLoan);
            }
        }

        public override string GetLoanStatusDAL(string loanID)
        {
            SqlConnection conn = SQLServerUtil.getConnetion("ndamssql\\sqlilearn", "13th Aug CLoud PT Immersive", "sqluser", "sqluser");
            //SqlConnection conn = SQLServerUtil.getConnetionWinAuth("Pecunia");
            string status = "";
            try
            {
                conn.Open();
                Console.WriteLine("connected");
                SqlCommand comm = new SqlCommand("TeamF.getEduLoanStatus", conn);

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

        EduLoan getNETdataTypes(SqlDataReader reader, EduLoan objToReturn)
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
            CourseType course;
            Enum.TryParse(reader.GetString(8), out course);
            objToReturn.Course = course;
            objToReturn.InstituteName = reader.GetString(9);
            objToReturn.StudentID = reader.GetString(10);
            objToReturn.RepaymentHoliday = reader.GetByte(11);
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
