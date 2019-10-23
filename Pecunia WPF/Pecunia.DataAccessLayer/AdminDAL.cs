using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capgemini.Pecunia.Contracts.DALContracts;
using Capgemini.Pecunia.Entities;
using Capgemini.Pecunia.Helper;
using Capgemini.Pecunia.Exceptions;
using Newtonsoft.Json;
using System.IO;
using System.Data.SqlClient;
using Capgemini.Pecunia.Helpers;
using System.Data;

namespace Capgemini.Pecunia.DataAccessLayer
{
    /// <summary>
    /// Contains data access layer methods for inserting, updating, deleting Admin from Admins collection.
    /// </summary>
    public class AdminDAL : AdminDALBase, IDisposable
    {
        /// <summary>
        /// Constructor for AdminDAL
        /// </summary>
        public AdminDAL()
        {
            Serialize();
            Deserialize();
        }

        //"ndamssql\\sqlilearn", "13th Aug Cloud PT Immersive", "sqluser", "sqluser"
        SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.Setting);

        /// <summary>
        /// Gets admin based on AdminID.
        /// </summary>
        /// <param name="searchAdminID">Represents AdminID to search.</param>
        /// <returns>Returns Admin object.</returns>
        public override Admin GetAdminByAdminIDDAL(Guid searchAdminID)
        {
            Admin matchingAdmin = new Admin();
            try
            {
                //    //Find Admin based on searchAdminID
                //    matchingAdmin = adminList.Find(
                //        (item) => { return item.AdminID == searchAdminID; }
                //    );

                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("TeamF.GetAdminByAdminID", sqlConnection);
                SqlParameter sqlParameter = new SqlParameter("@adminID", searchAdminID);
                sqlParameter.DbType = DbType.Guid;
                sqlCommand.Parameters.Add(sqlParameter);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        matchingAdmin.AdminID = sqlDataReader.GetGuid(0);
                        matchingAdmin.AdminName = sqlDataReader.GetString(1);
                        matchingAdmin.Email = sqlDataReader.GetString(2);
                        matchingAdmin.CreationDateTime = sqlDataReader.GetDateTime(4);
                        matchingAdmin.LastModifiedDateTime = sqlDataReader.GetDateTime(5);
                    }
                }
                sqlDataReader.Close();

               
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

               
            }
            catch (PecuniaException)
            {
                throw new InvalidAdminException("Admin not found.");
            }
            return matchingAdmin;
        }

        /// <summary>
        /// Gets admin based on Password.
        /// </summary>
        /// <param name="email">Represents Admin's Email Address.</param>
        /// <param name="password">Represents Admin's Password.</param>
        /// <returns>Returns Admin object.</returns>
        public override Admin GetAdminByEmailAndPasswordDAL(string email, string password)
        {
            Admin matchingAdmin = new Admin();
            try
            {
                ////Find Admin based on Email and Password
                //List<Admin> adminList = DeserializeFromJSON("admins.json");

                //matchingAdmin = adminList.Find(
                //    (item) => { return item.Email.Equals(email) && item.Password.Equals(password); }
                //);



                SqlCommand sqlCommand = new SqlCommand("TeamF.GetAdminByEmailandPassword", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@adminEmail", email);
                sqlCommand.Parameters.AddWithValue("@adminPassword", password);
                sqlConnection.Open();

                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        matchingAdmin.AdminID = sqlDataReader.GetGuid(0);
                        matchingAdmin.AdminName = sqlDataReader.GetString(1);
                        matchingAdmin.Email = sqlDataReader.GetString(2);
                        matchingAdmin.CreationDateTime = sqlDataReader.GetDateTime(4);
                        matchingAdmin.LastModifiedDateTime = sqlDataReader.GetDateTime(5);
                    }
                }
                sqlDataReader.Close();


                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();


              

            }
            catch (Exception)
            {
                //throw new InvalidAdminException("Admin not found.");
                return default(Admin);
            }
            return matchingAdmin;
        }

        /// <summary>
        /// Updates admin based on AdminID.
        /// </summary>
        /// <param name="updateAdmin">Represents Admin details including AdminID, AdminName etc.</param>
        /// <returns>Determinates whether the existing admin is updated.</returns>
        public override bool UpdateAdminDAL(Admin updateAdmin)
        {
            bool adminUpdated = false;
            try
            {
                ////Find Admin based on AdminID
                //Admin matchingAdmin = GetAdminByAdminIDDAL(updateAdmin.AdminID);

                //if (matchingAdmin != null)
                //{
                //    //Update admin details
                //    ReflectionHelper.CopyProperties(updateAdmin, matchingAdmin, new List<string>() { "AdminName", "Email" });
                //    matchingAdmin.LastModifiedDateTime = DateTime.Now;

                //    adminUpdated = true;
                //}


                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("TeamF.UpdateAdminNameAndEmail", sqlConnection);
                SqlParameter p1 = new SqlParameter("@empid", updateAdmin.AdminID);
                p1.DbType = DbType.Guid;
                SqlParameter p2 = new SqlParameter("@empname", updateAdmin.AdminName);
                SqlParameter p3 = new SqlParameter("@empemail", updateAdmin.Email);
                
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                sqlParameters.Add(p1);
                sqlParameters.Add(p2);
                sqlParameters.Add(p3);
                sqlCommand.Parameters.AddRange(sqlParameters.ToArray());

                sqlCommand.CommandType = CommandType.StoredProcedure;
                
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();


            }
            catch (PecuniaException)
            {
                throw new AdminUpdateException("Admin details could not be updated.");
            }
            return adminUpdated;
        }

        /// <summary>
        /// Updates admin's password based on AdminID.
        /// </summary>
        /// <param name="updateAdmin">Represents Admin details including AdminID, Password.</param>
        /// <returns>Determinates whether the existing admin's password is updated.</returns>
        public override bool UpdateAdminPasswordDAL(Admin updateAdmin)
        {
            bool passwordUpdated = false;
            try
            {
                ////Find Admin based on AdminID
                //Admin matchingAdmin = GetAdminByAdminIDDAL(updateAdmin.AdminID);

                //if (matchingAdmin != null)
                //{
                //    //Update admin details
                //    ReflectionHelper.CopyProperties(updateAdmin, matchingAdmin, new List<string>() { "Password" });
                //    matchingAdmin.LastModifiedDateTime = DateTime.Now;

                //    passwordUpdated = true;
                //}

                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("TeamF.UpdateAdminPassword", sqlConnection);
                SqlParameter p1 = new SqlParameter("@adminID", updateAdmin.AdminID);
                p1.DbType = DbType.Guid;
                SqlParameter p2 = new SqlParameter("@adminPassword", updateAdmin.Password);
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                sqlParameters.Add(p1);
                sqlParameters.Add(p2);
                sqlCommand.Parameters.AddRange(sqlParameters.ToArray());
                sqlCommand.CommandType = CommandType.StoredProcedure;
               
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();




            }
            catch (PecuniaException)
            {
                throw new AdminUpdateException("Admin password could not be updated.");
            }
            return passwordUpdated;
        }

        /// <summary>
        /// Clears unmanaged resources such as db connections or file streams.
        /// </summary>
        public void Dispose()
        {
            //No unmanaged resources currently
        }

        public static List<Admin> DeserializeFromJSON(string fileName)
        {
            List<Admin> admin = JsonConvert.DeserializeObject<List<Admin>>(File.ReadAllText(fileName));// Done to read data from file
            return admin;
        }
    }
}
