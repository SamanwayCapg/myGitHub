using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Capgemini.Pecunia.BusinessLayer;
using Capgemini.Pecunia.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capgemini.Pecunia.UnitTest
{
    [TestClass]
    public class DeleteAccountBLTest
    {
        /*
        //=======================DeleteAccountTest Class==================
        public async Task DeleteValidAccountTest()
        {
            //Arrange
            AccountBL accountBL = new AccountBL();
            Guid accountID = Guid.Parse("bdc8e59d-f8ac-4cd6-92eb-4c3ed5baacf7");
            string feedback = "Not Satisfied";
            bool isAdded = false;
            string errorMessage = null;
            //Act
            try
            {
                isAdded = await accountBL.DeleteAccount(accountID, feedback);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsTrue(isAdded, errorMessage);
            }
        }
        */
        public async Task DeleteInValidAccountTest()
        {
            //Arrange
            AccountBL accountBL = new AccountBL();


            Guid accountID = Guid.Parse("bdc8e59d-f8ac-4cd6-92eb-4c3ed5baacf"); // Given wrong account ID
            string feedback = "Not Satisfied";
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await accountBL.DeleteAccount(accountID, feedback);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isAdded, errorMessage);
            }
        }
    }
}