using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capgemini.Pecunia.BusinessLayer.LoanBL;
using Capgemini.Pecunia.Entities;
using System.Threading.Tasks;
using System;
using System.IO;

namespace UnitTestProject2
{
    public class MainClass
    {
        [STAThread]
        public static void Main()
        {

            UnitTest1 test = new UnitTest1();
            test.TestApplyHomeLoan().Wait();
        }
    }

    [TestClass]
    public class UnitTest1
    {
        

        [TestMethod]
        public async Task TestApplyHomeLoan()
        {
            HomeLoan loan = new HomeLoan();
            loan.CustomerID = Guid.Parse("6eb874f3-6233-4a97-b2c5-fac7b66635c0");
            loan.AmountApplied = 10000;
            loan.RepaymentPeriod = 10;
            loan.Occupation = (ServiceType)3;
            loan.ServiceYears = 7;
            loan.GrossIncome = 45000;
            loan.SalaryDeductions = 5600;

            HomeLoanBL homeLoan = new HomeLoanBL();
            bool result = await homeLoan.ApplyLoanBL(loan);
            Assert.AreEqual(result, true);
            bool testStatus = false ;
            if (result == true)
                testStatus = true;

            
            string csvLine = $"ApplyHomeLoan, verify inputs, enter valid inputs, need a valid customerID," +
                $"{loan.CustomerID},{loan.AmountApplied},{loan.RepaymentPeriod},{loan.Occupation},{loan.ServiceYears},{loan.GrossIncome},{loan.SalaryDeductions}" +
                $"{true},{result},{testStatus}";

            File.WriteAllText("testcase.csv", csvLine);
        }
    }
}
