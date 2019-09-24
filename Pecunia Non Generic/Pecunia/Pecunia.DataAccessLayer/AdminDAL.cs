using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capgemini.Pecunia.Entities;
using Capgemini.Pecunia.Exceptions;

namespace Capgemini.Pecunia.DataAccessLayer
{
    public class AdminDAL
    {
        public bool AdminLogInDAL(Admin admin)
        {
            bool adminLogin = false;
            try
            {
                if (admin.AdminID == 101 && admin.AdminPassword == " ")
                {
                    adminLogin = true;
                }

            }
            catch (Exception ex)
            {

                throw new PecuniaException(ex.Message);
            }
            return adminLogin;
        }
    }
}
