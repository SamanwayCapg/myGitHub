using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Capgemini.Pecunia.BusinessLayer;
using Capgemini.Pecunia.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Capgemini.Pecunia.UnitTest
{
    [TestClass]
    public class ChangeAccountTypeBLTest
    {
        [TestMethod]
        public async Task ChangeValidAccountType()
        {
            //Arrange
            AccountBL accountBL = new AccountBL();


            Guid accountID = Guid.Parse("9baff2f5 - 2be2 - 4d57 - 9dc2 - e7473ed26ac7");
            string accountType = "Savings";
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await accountBL.ChangeAccountTypeBL(accountID, accountType);
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


        [TestMethod]
        public async Task ChangeNotValidAccountType()
        {
            //Arrange
            AccountBL accountBL = new AccountBL();


            Guid accountID = Guid.Parse("9baff2f5 - 2be2 - 4d57 - 9dc2 - e7473ed26ac7");
            string accountType = "Savings";
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await accountBL.ChangeAccountTypeBL(accountID, accountType);
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

        [TestMethod]
        public async Task ChangeValidAccountTypeWrongAccountType()
        {
            //Arrange
            AccountBL accountBL = new AccountBL();


            Guid accountID = Guid.Parse("9baff2f5 - 2be2 - 4d57 - 9dc2 - e7473ed26ac"); // Wrong Account Number
            string accountType = "Saving";
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await accountBL.ChangeAccountTypeBL(accountID, accountType);
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