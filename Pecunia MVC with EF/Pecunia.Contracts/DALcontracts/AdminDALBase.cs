using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capgemini.Pecunia.Entities;


namespace Capgemini.Pecunia.Contracts.DALContracts
{
    /// <summary>
    /// This abstract class acts as a base for AdminDAL class
    /// </summary>
    public abstract class AdminDALBase
    {
        //Collection of Admins
        protected static List<Admin> adminList = new List<Admin>()
        {
            new Admin() { AdminID = Guid.NewGuid(), AdminEmail = "admin@capgemini.com", AdminName = "Admin", AdminPassword = "manager", CreationDateTime = DateTime.Now, LastModifiedDateTime = DateTime.Now }
        };
        //private static string fileName = "admins.json";

        //Methods
        public abstract Admin GetAdminByAdminIDDAL(Guid searchAdminID);
        public abstract Admin GetAdminByEmailAndPasswordDAL(string email, string password);
        public abstract bool UpdateAdminDAL(Admin updateAdmin);
        public abstract bool UpdateAdminPasswordDAL(Admin updateAdmin);

        

        /// <summary>
        /// Static Constructor.
        /// </summary>
        static AdminDALBase()
        {
            //Deserialize();
        }
    }
}
