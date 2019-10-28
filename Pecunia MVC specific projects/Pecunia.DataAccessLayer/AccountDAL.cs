using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capgemini.Pecunia.Entities;
using Capgemini.Pecunia.Exceptions;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using Capgemini.Pecunia.Contracts.DALContracts;
//using Pecunia.Contracts.DALContracts;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Windows.Input;

namespace Capgemini.Pecunia.DataAccessLayer
{
    
    //public class AccountDAL : AccountDALBase
    //{


    //    //----------------------------------------------------------------------------------------------1)
    //    public override bool AddAccountDAL(Account accountObject)
    //    {

    //        SqlConnection sqlConn = new SqlConnection(Properties.Settings.Default.DbCon);

    //        //string Connect =  $"Data Source =ndamssql\\sqlilearn;Initial Catalog=13th Aug CLoud PT Immersive;User ID=sqluser;Password=sqluser";
    //        //SqlConnection sqlConn = new SqlConnection(Connect);
    //        try
    //        {
    //            sqlConn.Open();
    //            Console.WriteLine("connected to the database");
    //            SqlCommand com = new SqlCommand("TeamF.AddAccountDAL1", sqlConn);

    //            Guid accountID = Guid.NewGuid();
    //            Console.WriteLine(accountID);
    //            Guid customerID;
    //            Guid.TryParse("6E41CF21-1589-4581-9F59-2A327DD72F2D", out customerID);
    //            string accType = accountObject._accType.ToString();

    //            //string accountID = "F03CA392-2A6A-4823-A83B-185E3A82DC48";
    //            //string customerID = "F10C745E-0C94-4E58-B4C0-0582F99A9412";
    //            SqlParameter para1 = new SqlParameter("@AccountType", accType);
    //            SqlParameter para2 = new SqlParameter("@AccountNumber", accountObject.AccountNo);
    //            SqlParameter para3 = new SqlParameter("@AccountID", accountObject.AccountID);
    //            para3.SqlDbType = SqlDbType.UniqueIdentifier;
    //            SqlParameter para4 = new SqlParameter("@CustomerID", accountObject.CustomerID);
    //            para4.SqlDbType = SqlDbType.UniqueIdentifier;
    //            SqlParameter para5 = new SqlParameter("@HomeBranch", accountObject.HomeBranch);
    //            SqlParameter para6 = new SqlParameter("@IsActive", 1);
    //            List<SqlParameter> listOfParameters = new List<SqlParameter>();

    //            listOfParameters.Add(para1);
    //            listOfParameters.Add(para2);
    //            listOfParameters.Add(para3);
    //            listOfParameters.Add(para4);
    //            listOfParameters.Add(para5);
    //            listOfParameters.Add(para6);

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
    //    //---------------------------------------------------------------------------------------------2)
    //    public override bool DeleteAccountDAL(Guid accountID, string feedback)
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
    //        SqlCommand com = new SqlCommand("TeamF.DeleteAccountDAL1", sqlConn);

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
    //    //-------------------------------------------------------------------------------3)
    //    public override List<Account> GetAccountByCustomerIDDAL(Guid customerID)
    //    {

    //        List<Account> accounts = new List<Account>();
    //        SqlConnection sqlConn = new SqlConnection(Properties.Settings.Default.DbCon);
    //        Guid accountID = Guid.NewGuid();
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
    //        SqlCommand com = new SqlCommand("Select * from TeamF.Account where CustomerID = @CustomerID", sqlConn);

    //        com.Parameters.AddWithValue("@CustomerID", customerID);
    //        com.CommandType = CommandType.Text;


    //        SqlDataAdapter sqlAdapter = new SqlDataAdapter();
    //        sqlAdapter.SelectCommand = com;

    //        DataSet dataSet = new DataSet();
    //        sqlAdapter.Fill(dataSet);

    //        DataRow datarow;
    //        for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
    //        {
    //            datarow = dataSet.Tables[0].Rows[i];
    //            Account account = new Account();

    //            account.AccountID = (Guid)datarow["AccountID"];
    //            account.AccountNo = (long)datarow["AccountNumber"];
    //            account.Balance = (long)datarow["AccountBalance"];
    //            account.DateOfCreation = (DateTime)datarow["DateOfCreation"];
    //            account.HomeBranch = (string)datarow["HomeBranch"];
    //            account.Feedback = (string)datarow["Feedback"];
    //            account.IsActive = (bool)datarow["IsActive"];
    //            Enum.TryParse((string)datarow["AccountType"], out account._accType);
    //            accounts.Add(account);
    //        }



    //        return accounts;
    //    }
    //    //----------------------------------------------------------------------------------------4)

    //    public override List<Account> GetAllAccountsDAL()
    //    {
    //        List<Account> accounts = new List<Account>();
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
    //        SqlCommand com = new SqlCommand("Select * from TeamF.Account where IsActive =1", sqlConn);
    //        com.CommandType = CommandType.Text;

    //        SqlDataAdapter sqlAdapter = new SqlDataAdapter();
    //        sqlAdapter.SelectCommand = com;

    //        DataSet dataSet = new DataSet();
    //        sqlAdapter.Fill(dataSet);

    //        DataRow datarow;
    //        for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
    //        {
    //            datarow = dataSet.Tables[0].Rows[i];
    //            Account account = new Account();

    //            account.AccountID = (Guid)datarow["AccountID"];
    //            account.AccountNo = (long)datarow["AccountNumber"];

    //            account.DateOfCreation = (DateTime)datarow["DateOfCreation"];
    //            account.HomeBranch = (string)datarow["HomeBranch"];
    //            account.Feedback = (string)datarow["Feedback"];
    //            account.IsActive = (bool)datarow["IsActive"];
    //            Enum.TryParse((string)datarow["AccountType"], out account._accType);
    //            accounts.Add(account);
    //        }

    //        return accounts;
    //    }
    //    public override Account GetAccountByAccountIDDAL(Guid accountID)
    //    {

    //        Account account = new Account();
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
    //        SqlCommand com = new SqlCommand("Select * from TeamF.Account where AccountID =@AccountID", sqlConn);

    //        com.Parameters.AddWithValue("@AccountID", accountID);
    //        com.CommandType = CommandType.Text;

    //        SqlDataAdapter sqlAdapter = new SqlDataAdapter();
    //        sqlAdapter.SelectCommand = com;

    //        DataSet dataSet = new DataSet();
    //        sqlAdapter.Fill(dataSet);

    //        DataRow datarow;
    //        if (dataSet.Tables[0].Rows.Count > 0)
    //        {
    //            datarow = dataSet.Tables[0].Rows[0];

    //            account.AccountID = (Guid)datarow["AccountID"];
    //            account.AccountNo = (long)datarow["AccountNumber"];
    //            account.Balance = Convert.ToDouble((decimal)datarow["AccountBalance"]);
    //            account.DateOfCreation = (DateTime)datarow["DateOfCreation"];
    //            account.HomeBranch = (string)datarow["HomeBranch"];
    //            account.Feedback = (string)datarow["Feedback"];
    //            account.IsActive = (bool)datarow["IsActive"];
    //            Enum.TryParse((string)datarow["AccountType"], out account._accType);

    //        }
    //        return account;
    //    }


    //    public override bool AccountIDExistsAccount(Guid accountID)
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

    //        SqlCommand com = new SqlCommand("Select * from TeamF.Account where AccountID = @AccountID", sqlConn);
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

    //    public override bool ChangeBranchOfAccount(Guid accountID, string homebranch)
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
    //        SqlCommand com = new SqlCommand("TeamF.ChangeBranchOfAccount", sqlConn);
    //        SqlParameter para1 = new SqlParameter("@AccountID", accountID);
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

    //    public bool ChangeAccountType(Guid accountID, string accountType)
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
    //        SqlCommand com = new SqlCommand("TeamF.ChangeAccountType1", sqlConn);
    //        SqlParameter para1 = new SqlParameter("@AccountID", accountID);
    //        SqlParameter para2 = new SqlParameter("@AccountType", accountType);

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
