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
    //public class FixedDepositDAL : FixedDepositBase
    //{
    //    public override bool AddFixedDepositDAL(FixedDeposit fixedDepositObject)
    //    {
    //        SqlConnection sqlConn = new SqlConnection(Properties.Settings.Default.DbCon);

    //        //string Connect =  $"Data Source =ndamssql\\sqlilearn;Initial Catalog=13th Aug CLoud PT Immersive;User ID=sqluser;Password=sqluser";
    //        //SqlConnection sqlConn = new SqlConnection(Connect);
    //        try
    //        {
    //            sqlConn.Open();
    //            Console.WriteLine("connected to the database");
    //            SqlCommand com = new SqlCommand("TeamF.FdAdding", sqlConn);




    //            //string fixedDepositID = "F03CA392-2A6A-4823-A83B-185E3A82DC48";
    //            //string customerID = "F10C745E-0C94-4E58-B4C0-0582F99A9               
    //            SqlParameter para1 = new SqlParameter("@CustomerID", fixedDepositObject.CustomerID);
    //            para1.SqlDbType = SqlDbType.UniqueIdentifier;
    //            SqlParameter para2 = new SqlParameter("@AccountID", fixedDepositObject.AccountID);
    //            para2.SqlDbType = SqlDbType.UniqueIdentifier;
    //            SqlParameter para3 = new SqlParameter("@HomeBranch", fixedDepositObject.HomeBranch);
    //            SqlParameter para4 = new SqlParameter("@Tenure", fixedDepositObject.tenure);
    //            SqlParameter para5 = new SqlParameter("@FdDeposit", fixedDepositObject.FdDeposit);
    //            SqlParameter para6 = new SqlParameter("@InterestRate", fixedDepositObject.InterestRate);
    //            SqlParameter para7 = new SqlParameter("@AccountNumber", fixedDepositObject.AccountNo);
    //            SqlParameter para8 = new SqlParameter("@IsActive", 1);


    //            List<SqlParameter> listOfParameters = new List<SqlParameter>();

    //            listOfParameters.Add(para1);
    //            listOfParameters.Add(para2);
    //            listOfParameters.Add(para3);
    //            listOfParameters.Add(para4);
    //            listOfParameters.Add(para5);
    //            listOfParameters.Add(para6);
    //            listOfParameters.Add(para7);
    //            listOfParameters.Add(para8);

    //            com.Parameters.AddRange(listOfParameters.ToArray());
    //            com.CommandType = CommandType.StoredProcedure;
    //            com.ExecuteNonQuery();
    //            sqlConn.Close();




    //            return true;
    //        }
    //        catch (Exception e)
    //        {
    //            Console.WriteLine(e.Message);
    //            Console.WriteLine(e.StackTrace);
    //            return false;

    //        }

    //    }

    //    public override bool DeleteFixedDepositDAL(Guid accountID, string feedback)
    //    {
    //        SqlConnection sqlConn = new SqlConnection(Properties.Settings.Default.DbCon);
    //        try
    //        {
    //            sqlConn.Open();
    //            Console.WriteLine("connected to the database");


    //        }
    //        catch (Exception e)
    //        {
    //            Console.WriteLine(e.Message);
    //            return false;
    //        }
    //        SqlCommand com = new SqlCommand("TeamF.DeleteFixedDepositDAL", sqlConn);

    //        SqlParameter para1 = new SqlParameter("@AccountID", accountID);
    //        para1.SqlDbType = SqlDbType.UniqueIdentifier;

    //        SqlParameter para2 = new SqlParameter("@Feedback", feedback);
    //        para2.SqlDbType = SqlDbType.VarChar;

    //        List<SqlParameter> listOfParameters = new List<SqlParameter>();

    //        listOfParameters.Add(para1);
    //        listOfParameters.Add(para2);
    //        com.Parameters.AddRange(listOfParameters.ToArray());
    //        com.CommandType = CommandType.StoredProcedure;
    //        com.ExecuteNonQuery();
    //        sqlConn.Close();
    //        return true;
    //    }


    //    public override List<FixedDeposit> GetFixedDepositByCustomerIDDAL(Guid customerID)
    //    {

    //        List<FixedDeposit> fixedDeposits = new List<FixedDeposit>();
    //        SqlConnection sqlConn = new SqlConnection(Properties.Settings.Default.DbCon);
    //        Guid fixedDepositID = Guid.NewGuid();
    //        try
    //        {
    //            sqlConn.Open();
    //            Console.WriteLine("connected to the database");

    //        }
    //        catch (Exception e)
    //        {
    //            Console.WriteLine(e.Message);
    //            //throw exception
    //        }
    //        SqlCommand com = new SqlCommand("Select * from TeamF.FixedDeposit where CustomerID = @CustomerID", sqlConn);

    //        com.Parameters.AddWithValue("@CustomerID", customerID).SqlDbType = SqlDbType.UniqueIdentifier;
    //        com.CommandType = CommandType.Text;


    //        SqlDataAdapter sqlAdapter = new SqlDataAdapter();
    //        sqlAdapter.SelectCommand = com;

    //        DataSet dataSet = new DataSet();
    //        sqlAdapter.Fill(dataSet);

    //        DataRow datarow;
    //        for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
    //        {
    //            datarow = dataSet.Tables[0].Rows[i];
    //            FixedDeposit fixedDeposit = new FixedDeposit();

    //            fixedDeposit.AccountID = (Guid)datarow["AccountID"];
    //            fixedDeposit.AccountNo = (long)datarow["AccountNumber"];
    //            fixedDeposit.FdDeposit = (long)datarow["FdDeposit"];
    //            fixedDeposit.DateOfCreation = (DateTime)datarow["DateOfCreation"];
    //            fixedDeposit.HomeBranch = (string)datarow["HomeBranch"];
    //            fixedDeposit.IsActive = (bool)datarow["IsActive"];
    //            fixedDeposit.CustomerID = (Guid)datarow["CustomerID"];
    //            fixedDeposit.InterestRate = (int)datarow["InterestRate"];


    //            fixedDeposits.Add(fixedDeposit);
    //        }



    //        return fixedDeposits;
    //    }

    //    public override List<FixedDeposit> GetAllFixedDepositsDAL()
    //    {
    //        List<FixedDeposit> fixedDeposits = new List<FixedDeposit>();
    //        SqlConnection sqlConn = new SqlConnection(Properties.Settings.Default.DbCon);
    //        try
    //        {
    //            sqlConn.Open();
    //            Console.WriteLine("connected to the database");

    //        }
    //        catch (Exception e)
    //        {
    //            Console.WriteLine(e.Message);

    //        }
    //        SqlCommand com = new SqlCommand("Select * from TeamF.FixedDeposit where IsActive =1", sqlConn);
    //        com.CommandType = CommandType.Text;

    //        SqlDataAdapter sqlAdapter = new SqlDataAdapter();
    //        sqlAdapter.SelectCommand = com;

    //        DataSet dataSet = new DataSet();
    //        sqlAdapter.Fill(dataSet);

    //        DataRow datarow;
    //        for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
    //        {
    //            datarow = dataSet.Tables[0].Rows[i];
    //            FixedDeposit fixedDeposit = new FixedDeposit();

    //            fixedDeposit.AccountID = (Guid)datarow["AccountID"];
    //            fixedDeposit.AccountNo = (long)datarow["AccountNumber"];
    //            fixedDeposit.FdDeposit = (long)datarow["FdDeposit"];
    //            fixedDeposit.DateOfCreation = (DateTime)datarow["DateOfCreation"];
    //            fixedDeposit.HomeBranch = (string)datarow["HomeBranch"];
    //            fixedDeposit.IsActive = (bool)datarow["IsActive"];
    //            fixedDeposit.CustomerID = (Guid)datarow["CustomerID"];
    //            fixedDeposit.InterestRate = (double)datarow["InterestRate"];

    //            fixedDeposits.Add(fixedDeposit);
    //        }



    //        return fixedDeposits;
    //    }


    //    public override FixedDeposit GetFixedDepositByAccountIDDAL(Guid accountID)
    //    {

    //        FixedDeposit fixedDeposit = new FixedDeposit();
    //        SqlConnection sqlConn = new SqlConnection(Properties.Settings.Default.DbCon);
    //        try
    //        {
    //            sqlConn.Open();
    //            Console.WriteLine("connected to the database");

    //        }
    //        catch (Exception e)
    //        {
    //            Console.WriteLine(e.Message);

    //        }
    //        SqlCommand com = new SqlCommand("Select * from TeamF.FixedDeposit where AccountID = @AccountID", sqlConn);
    //        Guid tp;
    //        tp = accountID;

    //        com.Parameters.AddWithValue("@AccountID", accountID).SqlDbType = SqlDbType.UniqueIdentifier;
    //        com.CommandType = CommandType.Text;

    //        SqlDataAdapter sqlAdapter = new SqlDataAdapter();
    //        sqlAdapter.SelectCommand = com;

    //        DataSet dataSet = new DataSet();
    //        sqlAdapter.Fill(dataSet);

    //        DataRow datarow;
    //        if (dataSet.Tables[0].Rows.Count > 0)
    //        {
    //            datarow = dataSet.Tables[0].Rows[0];

    //            fixedDeposit.AccountID = (Guid)datarow["AccountID"];
    //            fixedDeposit.AccountNo = (long)datarow["AccountNumber"];
    //            fixedDeposit.FdDeposit = (long)datarow["FdDeposit"];
    //            fixedDeposit.DateOfCreation = (DateTime)datarow["DateOfCreation"];
    //            fixedDeposit.HomeBranch = (string)datarow["HomeBranch"];
    //            fixedDeposit.IsActive = (bool)datarow["IsActive"];
    //            fixedDeposit.CustomerID = (Guid)datarow["CustomerID"];
    //            fixedDeposit.InterestRate = (double)datarow["InterestRate"];

    //        }
    //        return fixedDeposit;
    //    }

    //    public override bool AccountIDExistsFixedDeposit(Guid accountID)
    //    {
    //        SqlConnection sqlConn = new SqlConnection(Properties.Settings.Default.DbCon);
    //        try
    //        {
    //            sqlConn.Open();
    //            Console.WriteLine("connected to the database");

    //        }
    //        catch (Exception e)
    //        {
    //            Console.WriteLine(e.Message);
    //            return false;

    //        }

    //        SqlCommand com = new SqlCommand("Select * from TeamF.FixedDeposit where AccountID = @AccountID ", sqlConn);

    //        com.Parameters.AddWithValue("@AccountID", accountID);
    //        com.CommandType = CommandType.Text;

    //        SqlDataAdapter sqlAdapter = new SqlDataAdapter();
    //        sqlAdapter.SelectCommand = com;

    //        DataSet dataSet = new DataSet();
    //        sqlAdapter.Fill(dataSet);

    //        if (dataSet.Tables[0].Rows.Count > 0)
    //        {
    //            return true;
    //        }
    //        else
    //        {
    //            return false;
    //        }

    //    }

    //    public override bool ChangeBranchOfFixedDeposit(Guid accountID, string homebranch)
    //    {
    //        SqlConnection sqlConn = new SqlConnection(Properties.Settings.Default.DbCon);
    //        try
    //        {
    //            sqlConn.Open();
    //            Console.WriteLine("connected to the database");

    //        }
    //        catch (Exception e)
    //        {
    //            Console.WriteLine(e.Message);
    //            return false;

    //        }
    //        SqlCommand com = new SqlCommand("TeamF.ChangeBranchOfFixedDeposit", sqlConn);
    //        SqlParameter para1 = new SqlParameter("@AccountID", accountID);
    //        para1.SqlDbType = SqlDbType.UniqueIdentifier;
    //        SqlParameter para2 = new SqlParameter("@HomeBranch", homebranch);

    //        List<SqlParameter> listOfParameters = new List<SqlParameter>();
    //        listOfParameters.Add(para1);
    //        listOfParameters.Add(para2);

    //        com.Parameters.AddRange(listOfParameters.ToArray());
    //        com.CommandType = CommandType.StoredProcedure;
    //        com.ExecuteNonQuery();
    //        sqlConn.Close();
    //        return true;
    //    }
    //    public override bool ChangeFdAmount(Guid accountID, double amount)
    //    {
    //        SqlConnection sqlConn = new SqlConnection(Properties.Settings.Default.DbCon);
    //        try
    //        {
    //            sqlConn.Open();
    //            Console.WriteLine("connected to the database");

    //        }
    //        catch (Exception e)
    //        {
    //            Console.WriteLine(e.Message);
    //            return false;

    //        }
    //        SqlCommand com = new SqlCommand("TeamF.ChangeFDDeposit", sqlConn);
    //        SqlParameter para1 = new SqlParameter("@AccountID", accountID);
    //        para1.SqlDbType = SqlDbType.UniqueIdentifier;
    //        SqlParameter para2 = new SqlParameter("@FdDeposit", amount);

    //        List<SqlParameter> listOfParameters = new List<SqlParameter>();
    //        listOfParameters.Add(para1);
    //        listOfParameters.Add(para2);

    //        com.Parameters.AddRange(listOfParameters.ToArray());
    //        com.CommandType = CommandType.StoredProcedure;
    //        com.ExecuteNonQuery();
    //        sqlConn.Close();
    //        return true;
    //    }


    //}
}
