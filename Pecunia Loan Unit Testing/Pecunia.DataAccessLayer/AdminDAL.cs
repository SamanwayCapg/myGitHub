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

        /// <summary>
        /// Gets admin based on AdminID.
        /// </summary>
        /// <param name="searchAdminID">Represents AdminID to search.</param>
        /// <returns>Returns Admin object.</returns>
        public override Admin GetAdminByAdminIDDAL(Guid searchAdminID)
        {
            Admin matchingAdmin = null;
            try
            {
                //Find Admin based on searchAdminID
                matchingAdmin = adminList.Find(
                    (item) => { return item.AdminID == searchAdminID; }
                );
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
            Admin matchingAdmin = null;
            try
            {
                //Find Admin based on Email and Password
                List<Admin> adminList = DeserializeFromJSON("admins.json");
                
                matchingAdmin = adminList.Find(
                    (item) => { return item.Email.Equals(email) && item.Password.Equals(password); }
                );
            }
            catch (PecuniaException)
            {
                throw new InvalidAdminException("Admin not found.");
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
                //Find Admin based on AdminID
                Admin matchingAdmin = GetAdminByAdminIDDAL(updateAdmin.AdminID);

                if (matchingAdmin != null)
                {
                    //Update admin details
                    ReflectionHelper.CopyProperties(updateAdmin, matchingAdmin, new List<string>() { "AdminName", "Email" });
                    matchingAdmin.LastModifiedDateTime = DateTime.Now;

                    adminUpdated = true;
                }
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
                //Find Admin based on AdminID
                Admin matchingAdmin = GetAdminByAdminIDDAL(updateAdmin.AdminID);

                if (matchingAdmin != null)
                {
                    //Update admin details
                    ReflectionHelper.CopyProperties(updateAdmin, matchingAdmin, new List<string>() { "Password" });
                    matchingAdmin.LastModifiedDateTime = DateTime.Now;

                    passwordUpdated = true;
                }
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
