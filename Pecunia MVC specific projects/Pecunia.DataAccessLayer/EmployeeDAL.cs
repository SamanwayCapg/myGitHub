using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capgemini.Pecunia.Exceptions;
using System.Data.Common;
using Newtonsoft.Json;
using System.IO;
using Capgemini.Pecunia.Contracts.DALContracts;
using Capgemini.Pecunia.Entities;
using Capgemini.Pecunia.Helper;
using System.Data.SqlClient;
using Capgemini.Pecunia.Helpers;
using System.Data;

namespace Capgemini.Pecunia.DataAccessLayer
{
    /// <summary>
    /// Contains data access layer methods for inserting, updating, deleting Employee from Employees collection.
    /// </summary>
    //public class EmployeeDAL : EmployeeDALBase, IDisposable
    //{

    //    SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.DbConnection);
    //    /// <summary>
    //    /// Adds new Employee to Employees collection.
    //    /// </summary>
    //    /// <param name="newEmployee">Contains the Employee details to be added.</param>
    //    /// <returns>Determinates whether the new Employee is added.</returns>
    //    public override bool AddEmployeeDAL(Employee newEmployee)
    //    {

    //        bool employeeAdded = false;
    //        try
    //        {
    //            newEmployee.EmployeeID = Guid.NewGuid();
    //            sqlConnection.Open();
    //            SqlCommand sqlCommand = new SqlCommand("TeamF.AddEmployees", sqlConnection);
    //            SqlParameter p1 = new SqlParameter("@empid", newEmployee.EmployeeID);
    //            p1.DbType = DbType.Guid;
    //            SqlParameter p2 = new SqlParameter("@empname", newEmployee.EmployeeName);
    //            SqlParameter p3 = new SqlParameter("@empemail", newEmployee.EmployeeEmail);
    //            SqlParameter p4 = new SqlParameter("@emppassword", newEmployee.EmployeePassword);
    //            SqlParameter p5 = new SqlParameter("@empmobile", newEmployee.Mobile);


    //            List<SqlParameter> sqlParameters = new List<SqlParameter>();
    //            sqlParameters.Add(p1);
    //            sqlParameters.Add(p2);
    //            sqlParameters.Add(p3);
    //            sqlParameters.Add(p4);
    //            sqlParameters.Add(p5);
    //            sqlCommand.Parameters.AddRange(sqlParameters.ToArray());

    //            sqlCommand.CommandType = CommandType.StoredProcedure;
                
    //            sqlCommand.ExecuteNonQuery();
    //            sqlConnection.Close();

    //            //EmployeeList.Add(newEmployee);
    //            employeeAdded = true;
    //        }
    //        catch (PecuniaException)
    //        {
    //            throw new EmployeeAddedException("Employee not added");
    //        }
    //        return employeeAdded;
    //    }

    //    /// <summary>
    //    /// Gets all Employees from the collection.
    //    /// </summary>
    //    /// <returns>Returns list of all Employees.</returns>
    //    public override List<Employee> GetAllEmployeesDAL()
    //    {
    //        List<Employee> employeesList = new List<Employee>();
    //        try
    //        {
    //            sqlConnection.Open();
    //            SqlCommand sqlCommand = new SqlCommand("TeamF.GetAllEmployees",sqlConnection);
    //            sqlCommand.CommandType = CommandType.StoredProcedure;
    //            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
    //            sqlDataAdapter.SelectCommand = sqlCommand;

    //            DataSet dataSet = new DataSet();
    //            sqlDataAdapter.Fill(dataSet);
    //            DataRow dataRow;
    //            for(int i=0; i<dataSet.Tables[0].Rows.Count; i++)
    //            {
    //                dataRow = dataSet.Tables[0].Rows[i];
    //                Employee employee = new Employee();

    //                employee.EmployeeID = (Guid)dataRow["EmployeeID"];
    //                employee.EmployeeName = (string)dataRow["EmployeeName"];
    //                employee.EmployeeEmail = (string)dataRow["EmployeeEmail"];
    //                employee.Mobile = (string)dataRow["Mobile"];
    //                employee.CreationDateTime = (DateTime)dataRow["CreationDateTime"];
    //                employee.LastModifiedDateTime = (DateTime)dataRow["LastModifiedDateTime"];


    //                employeesList.Add(employee);
    //            }

               
    //            sqlCommand.ExecuteNonQuery();
    //            sqlConnection.Close();

    //        }
    //        catch (PecuniaException)
    //        {

    //            throw new EmployeeListException("Employee List cannot be displayed.");
    //        }
    //        return employeesList;
    //    }

    //    /// <summary>
    //    /// Gets Employee based on EmployeeID.
    //    /// </summary>
    //    /// <param name="searchEmployeeID">Represents EmployeeID to search.</param>
    //    /// <returns>Returns Employee object.</returns>
    //    public override Employee GetEmployeeByEmployeeIDDAL(Guid searchEmployeeID)
    //    {
    //        Employee matchingEmployee = new Employee();
    //        try
    //        {
    //            //List<Employee> EmployeeList = DeserializeFromJSON("employees.json");
    //            ////Find Employee based on searchEmployeeID
    //            //matchingEmployee = EmployeeList.Find(
    //            //    (item) => { return item.EmployeeID == searchEmployeeID; }
    //            //);
    //            sqlConnection.Open();
    //            SqlCommand sqlCommand = new SqlCommand("TeamF.GetEmployeeByEmployeeID", sqlConnection);
    //            SqlParameter sqlParameter = new SqlParameter("@empid", searchEmployeeID);
    //            sqlParameter.DbType = DbType.Guid;
    //            sqlCommand.Parameters.Add(sqlParameter);
    //            sqlCommand.CommandType = CommandType.StoredProcedure;

    //            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
    //            if (sqlDataReader.HasRows)
    //            {
    //                while (sqlDataReader.Read())
    //                {
    //                    matchingEmployee.EmployeeID = sqlDataReader.GetGuid(0);
    //                    matchingEmployee.EmployeeName = sqlDataReader.GetString(1);
    //                    matchingEmployee.EmployeeEmail = sqlDataReader.GetString(2);
    //                    matchingEmployee.Mobile = sqlDataReader.GetString(3);
    //                    matchingEmployee.CreationDateTime = sqlDataReader.GetDateTime(4);
    //                    matchingEmployee.LastModifiedDateTime = sqlDataReader.GetDateTime(5);
    //                }
    //            }
    //            sqlDataReader.Close();

               
    //            sqlCommand.ExecuteNonQuery();
    //            sqlConnection.Close();

    //        }
    //        catch (PecuniaException)
    //        {
    //            throw new InvalidEmployeeException("Employee not found.");
    //        }
    //        return matchingEmployee;
    //    }

    //    /// <summary>
    //    /// Gets Employee based on EmployeeName.
    //    /// </summary>
    //    /// <param name="EmployeeName">Represents EmployeeName to search.</param>
    //    /// <returns>Returns Employee object.</returns>
    //    public override List<Employee> GetEmployeesByNameDAL(string EmployeeName)
    //    {
    //        List<Employee> matchingEmployees = new List<Employee>();
    //        Employee employee = new Employee();
    //        try
    //        {
    //            //List<Employee> EmployeeList = DeserializeFromJSON("employees.json");
    //            ////Find All Employees based on EmployeeName
    //            //matchingEmployees = EmployeeList.FindAll(
    //            //    (item) => { return item.EmployeeName.Equals(EmployeeName, StringComparison.OrdinalIgnoreCase); }
    //            //);

    //            SqlCommand sqlCommand = new SqlCommand("TeamF.GetEmployeesByName", sqlConnection);
    //            sqlCommand.Parameters.AddWithValue("@empname", EmployeeName);
    //            sqlCommand.CommandType = CommandType.StoredProcedure;

    //            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
    //            sqlDataAdapter.SelectCommand = sqlCommand;

    //            DataSet dataSet = new DataSet();
    //            sqlDataAdapter.Fill(dataSet);
    //            DataRow dataRow;
    //            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
    //            {
    //                dataRow = dataSet.Tables[0].Rows[i];

    //                employee.EmployeeID = (Guid)dataRow["EmployeeID"];
    //                employee.EmployeeName = (string)dataRow["EmployeeName"];
    //                employee.EmployeeEmail = (string)dataRow["EmployeeEmail"];
    //                employee.Mobile = (string)dataRow["Mobile"];
    //                employee.CreationDateTime = (DateTime)dataRow["CreationDateTime"];
    //                employee.LastModifiedDateTime = (DateTime)dataRow["LastModifiedDateTime"];

    //                matchingEmployees.Add(employee);


    //            }

    //            sqlConnection.Open();
    //            sqlCommand.ExecuteNonQuery();
    //            sqlConnection.Close();

    //        }
    //        catch (PecuniaException)
    //        {
    //            throw new InvalidEmployeeException("Employee not found.");
    //        }
    //        return matchingEmployees;
    //    }

    //    /// <summary>
    //    /// Gets Employee based on email.
    //    /// </summary>
    //    /// <param name="email">Represents Employee's Email Address.</param>
    //    /// <returns>Returns Employee object.</returns>
    //    public override Employee GetEmployeeByEmailDAL(string email)
    //    {
    //        Employee matchingEmployee = null;
    //        try
    //        {
    //            //List<Employee> EmployeeList = DeserializeFromJSON("employees.json");
    //            ////Find Employee based on Email and Password
    //            //matchingEmployee = EmployeeList.Find(
    //            //    (item) => { return item.Email.Equals(email); }
    //            //);

    //            sqlConnection.Open();
    //            SqlCommand sqlCommand = new SqlCommand("TeamF.GetEmployeeByEmail", sqlConnection);
    //            sqlCommand.Parameters.AddWithValue("@empemail", email);
    //            sqlCommand.CommandType = CommandType.StoredProcedure;

    //            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
    //            if (sqlDataReader.HasRows)
    //            {
    //                while (sqlDataReader.Read())
    //                {
    //                    matchingEmployee.EmployeeID = sqlDataReader.GetGuid(0);
    //                    matchingEmployee.EmployeeName = sqlDataReader.GetString(1);
    //                    matchingEmployee.EmployeeEmail = sqlDataReader.GetString(2);
    //                    matchingEmployee.Mobile = sqlDataReader.GetString(3);
    //                    matchingEmployee.CreationDateTime = sqlDataReader.GetDateTime(4);
    //                    matchingEmployee.LastModifiedDateTime = sqlDataReader.GetDateTime(5);
    //                }
    //            }
    //            sqlDataReader.Close();

               
    //            sqlCommand.ExecuteNonQuery();
    //            sqlConnection.Close();



    //        }
    //        catch (PecuniaException)
    //        {
    //            throw new InvalidEmployeeException("Employee not found.");
    //        }
    //        return matchingEmployee;
    //    }

    //    /// <summary>
    //    /// Gets Employee based on Email and Password.
    //    /// </summary>
    //    /// <param name="email">Represents Employee's Email Address.</param>
    //    /// <param name="password">Represents Employee's Password.</param>
    //    /// <returns>Returns Employee object.</returns>
    //    public override Employee GetEmployeeByEmailAndPasswordDAL(string email, string password)
    //    {
    //        Employee matchingEmployee = new Employee();
    //        try
    //        {
    //            //List<Employee> EmployeeList = DeserializeFromJSON("employees.json");
    //            ////Find Employee based on Email and Password
    //            //matchingEmployee = EmployeeList.Find(
    //            //    (item) => { return item.Email.Equals(email) && item.Password.Equals(password); }
    //            //);
    //            sqlConnection.Open();
    //            SqlCommand sqlCommand = new SqlCommand("TeamF.GetEmployeeByEmailandPassword", sqlConnection);
    //            sqlCommand.Parameters.AddWithValue("@empemail", email);
    //            sqlCommand.Parameters.AddWithValue("@emppassword", password);
    //            sqlCommand.CommandType = CommandType.StoredProcedure;

    //            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
    //            if (sqlDataReader.HasRows)
    //            {
    //                while (sqlDataReader.Read())
    //                {
    //                    matchingEmployee.EmployeeID = sqlDataReader.GetGuid(0);
    //                    matchingEmployee.EmployeeName = sqlDataReader.GetString(1);
    //                    matchingEmployee.EmployeeEmail = sqlDataReader.GetString(2);
    //                    matchingEmployee.Mobile = sqlDataReader.GetString(3);
    //                    matchingEmployee.CreationDateTime = sqlDataReader.GetDateTime(4);
    //                    matchingEmployee.LastModifiedDateTime = sqlDataReader.GetDateTime(5);
    //                }
    //            }
    //            sqlDataReader.Close();

               
    //            sqlCommand.ExecuteNonQuery();
    //            sqlConnection.Close();



    //        }
    //        catch (Exception)
    //        {
    //            //throw new InvalidEmployeeException("Employee not found");
    //            return default(Employee);
    //        }
    //        return matchingEmployee;
    //    }

    //    /// <summary>
    //    /// Updates Employee based on EmployeeID.
    //    /// </summary>
    //    /// <param name="updateEmployee">Represents Employee details including EmployeeID, EmployeeName etc.</param>
    //    /// <returns>Determinates whether the existing Employee is updated.</returns>
    //    public override bool UpdateEmployeeDAL(Employee updateEmployee)
    //    {
    //        bool EmployeeUpdated = false;
    //        try
    //        {
    //            ////Find Employee based on EmployeeID
    //            //Employee matchingEmployee = GetEmployeeByEmployeeIDDAL(updateEmployee.EmployeeID);

    //            //if (matchingEmployee != null)
    //            //{
    //            //    //Update Employee details
    //            //    ReflectionHelper.CopyProperties(updateEmployee, matchingEmployee, new List<string>() { "EmployeeName", "Email" });
    //            //    matchingEmployee.LastModifiedDateTime = DateTime.Now;

    //            //    EmployeeUpdated = true;
    //            //}

    //            sqlConnection.Open();
    //            SqlCommand sqlCommand = new SqlCommand("TeamF.UpdateAllEmployeeDetails", sqlConnection);
    //            SqlParameter p1 = new SqlParameter("@empid", updateEmployee.EmployeeID);
    //            p1.DbType = DbType.Guid;
    //            SqlParameter p2 = new SqlParameter("@empname", updateEmployee.EmployeeName);
    //            SqlParameter p3 = new SqlParameter("@empemail", updateEmployee.EmployeeEmail);              
    //            SqlParameter p4 = new SqlParameter("@empmobile", updateEmployee.Mobile);
               
    //            List<SqlParameter> sqlParameters = new List<SqlParameter>();
    //            sqlParameters.Add(p1);
    //            sqlParameters.Add(p2);
    //            sqlParameters.Add(p3);
    //            sqlParameters.Add(p4);                
    //            sqlCommand.Parameters.AddRange(sqlParameters.ToArray());

    //            sqlCommand.CommandType = CommandType.StoredProcedure;
               
    //            sqlCommand.ExecuteNonQuery();
    //            sqlConnection.Close();



    //        }
    //        catch (PecuniaException)
    //        {
    //            throw new EmployeeUpdateException("Employee details could not be updated.");
    //        }
    //        return EmployeeUpdated;
    //    }

    //    /// <summary>
    //    /// Deletes Employee based on EmployeeID.
    //    /// </summary>
    //    /// <param name="deleteEmployeeID">Represents EmployeeID to delete.</param>
    //    /// <returns>Determinates whether the existing Employee is updated.</returns>
    //    public override bool DeleteEmployeeDAL(Guid deleteEmployeeID)
    //    {
    //        bool EmployeeDeleted = false;
    //        try
    //        {
    //            ////Find Employee based on searchEmployeeID
    //            //Employee matchingEmployee = EmployeeList.Find(
    //            //    (item) => { return item.EmployeeID == deleteEmployeeID; }
    //            //);

    //            //if (matchingEmployee != null)
    //            //{
    //            //    //Delete Employee from the collection
    //            //    EmployeeList.Remove(matchingEmployee);
    //            //    EmployeeDeleted = true;
    //            //}
    //            sqlConnection.Open();
    //            SqlCommand sqlCommand = new SqlCommand("TeamF.DeleteEmployee", sqlConnection);
    //            SqlParameter sqlParameter = new SqlParameter("@empid", deleteEmployeeID);
    //            sqlParameter.DbType = DbType.Guid;
    //            sqlCommand.Parameters.Add(sqlParameter);
    //            sqlCommand.CommandType = CommandType.StoredProcedure;
              
    //            sqlCommand.ExecuteNonQuery();
    //            sqlConnection.Close();



    //            EmployeeDeleted = true;
    //        }
    //        catch (PecuniaException)
    //        {
    //            throw new EmployeeDeletedException("Employee could not be deleted.");
    //        }
    //        return EmployeeDeleted;
    //    }

    //    /// <summary>
    //    /// Updates Employee's password based on EmployeeID.
    //    /// </summary>
    //    /// <param name="updateEmployee">Represents Employee details including EmployeeID, Password.</param>
    //    /// <returns>Determinates whether the existing Employee's password is updated.</returns>
    //    public override bool UpdateEmployeePasswordDAL(Employee updateEmployee)
    //    {
    //        bool passwordUpdated = false;
    //        try
    //        {
    //            sqlConnection.Open();
    //            ////Find Employee based on EmployeeID
    //            //Employee matchingEmployee = GetEmployeeByEmployeeIDDAL(updateEmployee.EmployeeID);

    //            //if (matchingEmployee != null)
    //            //{
    //            //    //Update Employee details
    //            //    ReflectionHelper.CopyProperties(updateEmployee, matchingEmployee, new List<string>() { "Password" });
    //            //    matchingEmployee.LastModifiedDateTime = DateTime.Now;

    //            //    passwordUpdated = true;
    //            //}


    //            SqlCommand sqlCommand = new SqlCommand("TeamF.UpdateEmployeePassword", sqlConnection);
    //            SqlParameter p1 = new SqlParameter("@empid", updateEmployee.EmployeeID);
    //            p1.DbType = DbType.Guid;
    //            SqlParameter p2 = new SqlParameter("@emppassword", updateEmployee.EmployeePassword);
    //            List<SqlParameter> sqlParameters = new List<SqlParameter>();
    //            sqlParameters.Add(p1);
    //            sqlParameters.Add(p2);
    //            sqlCommand.Parameters.AddRange(sqlParameters.ToArray());
    //            sqlCommand.CommandType = CommandType.StoredProcedure;
               
    //            sqlCommand.ExecuteNonQuery();
    //            sqlConnection.Close();


    //        }
    //        catch (PecuniaException)
    //        {
    //            throw new EmployeeUpdateException("Employee password could not be updated.");
    //        }
    //        return passwordUpdated;
    //    }



    //    /// <summary>
    //    /// Clears unmanaged resources such as db connections or file streams.
    //    /// </summary>
    //    public void Dispose()
    //    {
    //        //No unmanaged resources currently
    //    }

    //    public static List<Employee> DeserializeFromJSON(string fileName)
    //    {
    //        List<Employee> emp = JsonConvert.DeserializeObject<List<Employee>>(File.ReadAllText(fileName));// Done to read data from file
    //        return emp;
    //    }
    //}
}
