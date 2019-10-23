using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Capgemini.Pecunia.BusinessLayer;
using Capgemini.Pecunia.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capgemini.Pecunia.UnitTest
{
    [TestClass]
    public class AddAccountBLTest
    {
        /// <summary>
        /// Add account to the Collection if it is valid.
        /// </summary>
        [TestMethod]
        public async Task AddValidAccount()
        {
            //Arrange
            AccountBL accountBL = new AccountBL();
            Account account = new Account() { HomeBranch = "Pune" };

            Guid customerID = Guid.Parse("6eb874f3-6233-4a97-b2c5-fac7b66635c0");
            string accountType = "Savings";
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await accountBL.AddAccountBL(account, customerID, accountType);
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


        /// <summary>
        /// Home Branch can't be null
        /// </summary>
        [TestMethod]
        public async Task accountHomeBranchCanNotBeNull()
        {
            //Arrange
            AccountBL accountBL = new AccountBL();
            Account account = new Account() { HomeBranch = "" };
            Guid customerID = Guid.Parse("6eb874f3-6233-4a97-b2c5-fac7b66635c0");
            string accountType = "Savings";
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await accountBL.AddAccountBL(account, customerID, accountType);
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
        /// <summary>
        /// Account Type can't be null
        /// </summary>

        [TestMethod]
        public async Task accountAccountTypeCanNotBeNull()
        {
            //Arrange
            AccountBL accountBL = new AccountBL();
            Account account = new Account() { HomeBranch = "Pune" };
            Guid customerID = Guid.Parse("6eb874f3-6233-4a97-b2c5-fac7b66635c0");
            string accountType = "";
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await accountBL.AddAccountBL(account, customerID, accountType);
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

        /// <summary>
        /// Home Branch can't contain more than 20 Characters
        /// </summary>
        /// 
        [TestMethod]
        public async Task accountHomeBranchLimit()
        {
            //Arrange
            AccountBL accountBL = new AccountBL();
            Account account = new Account() { HomeBranch = "Puneaaaaaaaaaaaaaaaaaaaaaaaaaaa" };
            Guid customerID = Guid.Parse("6eb874f3-6233-4a97-b2c5-fac7b66635c0");
            string accountType = "Savings";
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await accountBL.AddAccountBL(account, customerID, accountType);
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