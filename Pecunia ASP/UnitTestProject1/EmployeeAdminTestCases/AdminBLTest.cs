using System;
using System.Threading.Tasks;
using Capgemini.Pecunia.BusinessLayer;
using Capgemini.Pecunia.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capgemini.Pecunia.UnitTest
{
    [TestClass]
    public class AdminBLTest
    {
        [TestMethod]
        public async Task GetAdminByEmailAndPasswordBLTest()
        {
            //Arrange
            AdminBL adminBL = new AdminBL();

            //Act
            Admin admin = await adminBL.GetAdminByEmailAndPasswordBL("admin@capgemini.com", "manager");

            //Assert
            Assert.AreEqual(admin.AdminName, "Admin");
        }
    }
}
