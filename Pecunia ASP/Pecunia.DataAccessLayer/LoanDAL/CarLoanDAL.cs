using System.Collections.Generic;
using Capgemini.Pecunia.Entities;
using Newtonsoft.Json;
using System.IO;
using System;
using Pecunia.Contracts.DALcontracts.LoanDALBase;
using Capgemini.Pecunia.Helpers;
using System.Data.SqlClient;
using System.Data;

namespace Capgemini.Pecunia.DataAccessLayer.LoanDAL
{
    public class CarLoanDAL : CarLoanDALBase, IDisposable
    {
        public static List<CarLoan> CarLoans;
        public override bool  ApplyLoanDAL(CarLoan car)
        {

            //SqlConnection conn = SQLServerUtil.getConnetion("ndamssql\\sqlilearn", "13th Aug CLoud PT Immersive", "sqluser", "sqluser");
            SqlConnection conn = SQLServerUtil.getConnetionWinAuth("Pecunia");
            try
            {
                conn.Open();
                

                SqlCommand comm = new SqlCommand("TeamF.applyCarLoan", conn);

                Guid loanID = Guid.NewGuid(); 
                SqlParameter param1 = new SqlParameter("@LoanID", loanID);
                param1.SqlDbType = SqlDbType.UniqueIdentifier;

                //Guid customerID;
                //Guid.TryParse(car.CustomerID, out customerID);
                SqlParameter param2 = new SqlParameter("@CustomerID", car.CustomerID);
                param2.SqlDbType = SqlDbType.UniqueIdentifier;

                SqlParameter param3 = new SqlParameter("@AmountApplied", car.AmountApplied);
                param3.SqlDbType = SqlDbType.Money;

                SqlParameter param4 = new SqlParameter("@InterestRate", car.InterestRate);
                param4.SqlDbType = SqlDbType.Money;

                SqlParameter param5 = new SqlParameter("@EMI_amount", car.EMI_Amount);
                param5.SqlDbType = SqlDbType.Money;

                SqlParameter param6 = new SqlParameter("@RepaymentPeriod", car.RepaymentPeriod);
                param6.SqlDbType = SqlDbType.TinyInt;

                DateTime dateOfApplication = DateTime.Now;
                SqlParameter param7 = new SqlParameter("@DateOfApplication", dateOfApplication);
                param7.SqlDbType = SqlDbType.DateTime;

                SqlParameter param8 = new SqlParameter("@LoanStatus", car.Status);
                param8.SqlDbType = SqlDbType.VarChar;

                SqlParameter param9 = new SqlParameter("@Occupation", car.Occupation);
                param9.SqlDbType = SqlDbType.VarChar;

                SqlParameter param10 = new SqlParameter("@GrossIncome", car.GrossIncome);
                param10.SqlDbType = SqlDbType.Money;

                SqlParameter param11 = new SqlParameter("@SalaryDeduction", car.SalaryDeductions);
                param11.SqlDbType = SqlDbType.Money;

                SqlParameter param12 = new SqlParameter("@VehicleType", car.Vehicle);
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
                return true;
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message); Console.ReadKey();
                BusinessLogicUtil.PecuniaLogException("applyCarLoan", e.Message);
                return false;
            }


        }

        public override CarLoan ApproveLoanDAL(string loanID, LoanStatus updatedStatus)
        {
            CarLoan objToReturn = new CarLoan();

            //SqlConnection conn = SQLServerUtil.getConnetion("ndamssql\\sqlilearn", "13th Aug CLoud PT Immersive", "sqluser", "sqluser");
            SqlConnection conn = SQLServerUtil.getConnetionWinAuth("Pecunia");
            try
            {
                conn.Open();
                Console.WriteLine("connected");
                SqlCommand comm = new SqlCommand("TeamF.approveCarLoan", conn);

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


                comm = new SqlCommand($"select * from TeamF.CarLoan where LoanID='{loanID}'", conn);

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
                return default(CarLoan);
            }
         
        }

        public override CarLoan GetLoanByCustomerIDDAL(string customerID)
        {
            CarLoan objToReturn = new CarLoan();
            //SqlConnection conn = SQLServerUtil.getConnetion("ndamssql\\sqlilearn", "13th Aug CLoud PT Immersive", "sqluser", "sqluser");
            SqlConnection conn = SQLServerUtil.getConnetionWinAuth("Pecunia");
            try
            {
                conn.Open();
                Console.WriteLine("connected");
                SqlCommand comm = new SqlCommand("TeamF.getCarLoanByCustomerID", conn);

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
                        objToReturn = getNETdataTypes(reader,objToReturn);
                    
                }
                conn.Close();
                return objToReturn;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.ReadKey();
                return default(CarLoan);
            }
        }

        public override CarLoan GetLoanByLoanIDDAL(string loanID)
        {
            CarLoan objToReturn = new CarLoan();
            //SqlConnection conn = SQLServerUtil.getConnetion("ndamssql\\sqlilearn", "13th Aug CLoud PT Immersive", "sqluser", "sqluser");
            SqlConnection conn = SQLServerUtil.getConnetionWinAuth("Pecunia");
            try
            {
                conn.Open();
                Console.WriteLine("connected");
                SqlCommand comm = new SqlCommand("TeamF.getCarLoanByLoanID", conn);

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
                return default(CarLoan);
            }
        }

        public override string GetLoanStatusDAL(string loanID)
        {
            string status = "";
            //SqlConnection conn = SQLServerUtil.getConnetion("ndamssql\\sqlilearn", "13th Aug CLoud PT Immersive", "sqluser", "sqluser");
            SqlConnection conn = SQLServerUtil.getConnetionWinAuth("Pecunia");
            try
            {
                conn.Open();
                Console.WriteLine("connected");
                SqlCommand comm = new SqlCommand("TeamF.getCarLoanStatus", conn);

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
            //SqlConnection conn = SQLServerUtil.getConnetion("ndamssql\\sqlilearn", "13th Aug CLoud PT Immersive", "sqluser", "sqluser");
            SqlConnection conn = SQLServerUtil.getConnetionWinAuth("Pecunia");
            SqlDataAdapter adapter = new SqlDataAdapter("select * from TeamF.CarLoan", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            return ds;
        }

        public override bool IsLoanIDExistDAL(string loanID)
        {
            return true;
        }

        
        CarLoan getNETdataTypes(SqlDataReader reader, CarLoan objToReturn)
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
            objToReturn.GrossIncome = Convert.ToDouble(reader.GetDecimal(9));
            objToReturn.SalaryDeductions = Convert.ToDouble(reader.GetDecimal(10));
            VehicleType vehicle;
            Enum.TryParse(reader.GetString(11), out vehicle);
            objToReturn.Vehicle = vehicle;
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
