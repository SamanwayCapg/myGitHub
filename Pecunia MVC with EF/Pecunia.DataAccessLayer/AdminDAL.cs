using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capgemini.Pecunia.Contracts.DALContracts;
using Capgemini.Pecunia.Entities;
using Capgemini.Pecunia.Helper;
using Capgemini.Pecunia.Exceptions;

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
            //Serialize();
            //Deserialize();
        }

        //"ndamssql\\sqlilearn", "13th Aug Cloud PT Immersive", "sqluser", "sqluser"


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
                using (PecuniaEntities pecuniaEntities = new PecuniaEntities())
                {
                    matchingAdmin = pecuniaEntities.Admins.Where(e => e.AdminID == searchAdminID).FirstOrDefault();
                }

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
                using (PecuniaEntities pecuniaEntities = new PecuniaEntities())
                {
                    matchingAdmin = pecuniaEntities.Admins.Where(e => e.AdminEmail == email && e.AdminPassword == password).FirstOrDefault();
                }
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
                using (PecuniaEntities pecuniaEntities = new PecuniaEntities())
                {
                    int affectedRowsCount = pecuniaEntities.UpdateAdminNameAndEmail(updateAdmin.AdminID, updateAdmin.AdminName, updateAdmin.AdminEmail);
                    if (affectedRowsCount >= 1)
                    {
                        adminUpdated = true;
                    }
                    else
                    {
                        adminUpdated = false;
                    }
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
                using (PecuniaEntities pecuniaEntities = new PecuniaEntities())
                {
                    int affectedRowsCount = pecuniaEntities.UpdateAdminPassword(updateAdmin.AdminID, updateAdmin.AdminPassword);
                    if (affectedRowsCount >= 1)
                    {
                        passwordUpdated = true;
                    }
                    else
                    {
                        passwordUpdated = false;
                    }
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

        
    }
}
