using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminNamespace;

namespace AdminServiceNamespace
{
    interface IAdminService
    {
        Admin GetAdminByIDandPassword(long id, string password);
    }

    [Serializable]
    public class AdminService
    {
        public Admin GetAdminByIDandPassword(long id, string password)
        {
            Admin admin = new Admin(id, password);
            return admin;
        }
    }
}
