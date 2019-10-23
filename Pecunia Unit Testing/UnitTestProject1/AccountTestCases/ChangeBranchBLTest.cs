using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Capgemini.Pecunia.BusinessLayer;
using Capgemini.Pecunia.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capgemini.Pecunia.UnitTest
{
    [TestClass]
    public class ChangeBranchBLTest
    {
        [TestMethod]
        public async Task ChangeValidBranch()
        {
            //Arrange
            AccountBL accountBL = new AccountBL();


            Guid accountID = Guid.Parse("9baff2f5 - 2be2 - 4d57 - 9dc2 - e7473ed26ac7");
            string HomeBranch = "Changed";
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await accountBL.ChangeBranchBL(accountID, HomeBranch);
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
        public async Task ChangeBranchHomeBranchCAnnotBeNull()
        {
            //Arrange
            AccountBL accountBL = new AccountBL();


            Guid accountID = Guid.Parse("9baff2f5 - 2be2 - 4d57 - 9dc2 - e7473ed26ac7");
            string HomeBranch = "";
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await accountBL.ChangeBranchBL(accountID, HomeBranch);
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
        public async Task ChangeBranchInValidAccountID()
        {
            //Arrange
            AccountBL accountBL = new AccountBL();


            Guid accountID = Guid.Parse("9baff2f5 - 2be2 - 4d57 - 9dc2 - e7473ed26ac"); // Wrong AccountID
            string HomeBranch = "Change";
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await accountBL.ChangeBranchBL(accountID, HomeBranch);
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