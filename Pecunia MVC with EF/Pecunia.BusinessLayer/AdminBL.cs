using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capgemini.Pecunia.Entities;
using Capgemini.Pecunia.Exceptions;
using Capgemini.Pecunia.DataAccessLayer;
using Capgemini.Pecunia.Contracts.BLContracts;
using Capgemini.Pecunia.Contracts.DALContracts;

namespace Capgemini.Pecunia.BusinessLayer
{
    //public class AdminBL : BLbase<Admin>, IAdminBL, IDisposable
    //{
    //    //fields
    //    AdminDALBase adminDAL;

    //    /// <summary>
    //    /// Constructor.
    //    /// </summary>
    //    public AdminBL()
    //    {
    //        this.adminDAL = new AdminDAL();
    //    }

    //    /// <summary>
    //    /// Gets admin based on AdminID.
    //    /// </summary>
    //    /// <param name="searchAdminID">Represents AdminID to search.</param>
    //    /// <returns>Returns Admin object.</returns>
    //    public async Task<Admin> GetAdminByAdminIDBL(Guid searchAdminID)
    //    {
    //        Admin matchingAdmin = null;
    //        try
    //        {
    //            await Task.Run(() =>
    //            {
    //                matchingAdmin = adminDAL.GetAdminByAdminIDDAL(searchAdminID);
    //            });
    //        }
    //        catch (PecuniaException ex)
    //        {
    //            throw new InvalidAdminException(ex.Message);
    //        }
    //        return matchingAdmin;
    //    }

    //    /// <summary>
    //    /// Gets admin based on Password.
    //    /// </summary>
    //    /// <param name="email">Represents Admin's Email Address.</param>
    //    /// <param name="password">Represents Admin's Password.</param>
    //    /// <returns>Returns Admin object.</returns>
    //    public async Task<Admin> GetAdminByEmailAndPasswordBL(string email, string password)
    //    {
    //        Admin matchingAdmin = new Admin();
    //        try
    //        {
    //            await Task.Run(() =>
    //            {
    //                matchingAdmin = adminDAL.GetAdminByEmailAndPasswordDAL(email, password);
    //            });
    //            if (matchingAdmin == default(Admin))
    //                return default(Admin);
    //        }
    //        catch (PecuniaException ex)
    //        {
    //            throw new InvalidAdminException(ex.Message);
    //        }
    //        return matchingAdmin;
    //    }

    //    /// <summary>
    //    /// Updates admin based on AdminID.
    //    /// </summary>
    //    /// <param name="updateAdmin">Represents Admin details including AdminID, AdminName etc.</param>
    //    /// <returns>Determinates whether the existing admin is updated.</returns>
    //    public async Task<bool> UpdateAdminBL(Admin updateAdmin)
    //    {
    //        bool adminUpdated = false;
    //        try
    //        {
    //            bool isValid = await Validate(updateAdmin);
    //            Console.WriteLine("isvalid:"+isValid);
    //            if ((isValid == true) && (await GetAdminByAdminIDBL(updateAdmin.AdminID)) != null)
    //            {
    //                this.adminDAL.UpdateAdminDAL(updateAdmin);
    //                adminUpdated = true;
    //                Serialize();
    //            }
               
    //        }
    //        catch (PecuniaException ex)
    //        {
    //            throw new AdminUpdateException(ex.Message);
    //        }
    //        return adminUpdated;
    //    }

    //    /// <summary>
    //    /// Updates admin's password based on AdminID.
    //    /// </summary>
    //    /// <param name="updateAdmin">Represents Admin details including AdminID, Password.</param>
    //    /// <returns>Determinates whether the existing admin's password is updated.</returns>
    //    public async Task<bool> UpdateAdminPasswordBL(Admin updateAdmin)
    //    {
    //        bool passwordUpdated = false;
    //        try
    //        {
    //            bool isValid = await Validate(updateAdmin);
    //            //Console.WriteLine("isvalid:"+isValid);
    //            if ((isValid == true) && (await GetAdminByAdminIDBL(updateAdmin.AdminID)) != null)
    //            {
    //                this.adminDAL.UpdateAdminPasswordDAL(updateAdmin);
    //                passwordUpdated = true;
    //                Serialize();
    //            }
    //        }
    //        catch(InvalidStringException )
    //        {
    //            Console.WriteLine("password not updated");
    //        }
    //        catch (PecuniaException ex)
    //        {
    //            throw new AdminUpdateException(ex.Message);
    //        }
    //        return passwordUpdated;
    //    }

    //    /// <summary>
    //    /// Disposes DAL object(s).
    //    /// </summary>
    //    public void Dispose()
    //    {
    //        ((AdminDAL)adminDAL).Dispose();
    //    }

    //    /// <summary>
    //    /// Invokes Serialize method of DAL.
    //    /// </summary>
    //    public void Serialize()
    //    {
    //        try
    //        {
    //            AdminDAL.Serialize();
    //        }
    //        catch 
    //        {
    //            throw;
    //        }
    //    }

    //    /// <summary>
    //    ///Invokes Deserialize method of DAL.
    //    /// </summary>
    //    public void Deserialize()
    //    {
    //        try
    //        {
    //            AdminDAL.Deserialize();
    //        }
    //        catch 
    //        {
    //            throw;
    //        }
    //    }
    //}
}
