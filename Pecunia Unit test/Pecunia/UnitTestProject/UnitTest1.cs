using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capgemini.Pecunia.BusinessLayer.LoanBL;
using Capgemini.Pecunia.Entities;
using System.Threading.Tasks;
using System;
using System.IO;

namespace UnitTestProject2
{
    
    [TestClass]
    public class UnitTest1
    {


        [TestMethod]
        public void TestApplyHomeLoan()
        {
            HomeLoan loan = new HomeLoan();
            loan.CustomerID = Guid.Parse("6eb874f3-6233-4a97-b2c5-fac7b66635c0");
            loan.AmountApplied = 20000;
            loan.RepaymentPeriod = 10;
            loan.Occupation = (ServiceType)3;
            loan.ServiceYears = 10;
            loan.GrossIncome = 45000;
            loan.SalaryDeductions = 5600;

            HomeLoanBL homeLoan = new HomeLoanBL();
            //bool Actual = homeLoan.ApplyLoanBL(loan).Result;
            //bool MyExpected = true;
            Assert.AreEqual(false, homeLoan.ApplyLoanBL(loan).Result, "test case passed");
            
            /*bool testStatus = false;
            if (result == true)
                testStatus = true;


            string csvLine = $"ApplyHomeLoan, verify inputs, enter valid inputs, need a valid customerID," +
                $"{loan.CustomerID},{loan.AmountApplied},{loan.RepaymentPeriod},{loan.Occupation},{loan.ServiceYears},{loan.GrossIncome},{loan.SalaryDeductions}" +
                $"{true},{result},{testStatus}";

            File.WriteAllText("testcase.csv", csvLine);
            */
        }
    }
}
