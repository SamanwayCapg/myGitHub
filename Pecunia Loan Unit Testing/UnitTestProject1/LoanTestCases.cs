using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Capgemini.Pecunia.BusinessLayer.LoanBL;
using Capgemini.Pecunia.Entities;


namespace Capgemini.Pecunia.UnitTest
{
    
    [TestClass]
    public class IsLoanIDExistTestCases
    {
        [TestMethod]
        public void EduLoanIDNotExist()
        {
            EduLoanBL eduLoanBL = new EduLoanBL();
            bool isExist = false;
            string errorMessage = "loan id must exist in database";
            try
            {
                isExist = eduLoanBL.isLoanIDExistBL("f1386d7b-a12b-42f3-9b47-60ed29ac147f");
            }
            catch (Exception ex)
            {
                isExist = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isExist, errorMessage);
            }
        }


        [TestMethod]
        public void EduLoanIDExist()
        {
            EduLoanBL eduLoanBL = new EduLoanBL();
            bool isExist = false;
            string errorMessage = "loan id exist in database";
            try
            {
                isExist = eduLoanBL.isLoanIDExistBL("08b4ea05-a4b4-4d8c-ae49-d3eb0428943d");
            }
            catch (Exception ex)
            {
                isExist = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsTrue(isExist, errorMessage);
            }
        }


        [TestMethod]
        public void HomeLoanIDNotExist()
        {
            HomeLoanBL homeLoanBL = new HomeLoanBL();
            bool isExist = false;
            string errorMessage = "loan id must exist in database";
            try
            {
                isExist = homeLoanBL.IsLoanIDExistBL("f1386d7b-a12b-42f3-9b47-60ed29ac147f");
            }
            catch (Exception ex)
            {
                isExist = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isExist, errorMessage);
            }
        }


        [TestMethod]
        public void HomeLoanIDExist()
        {
            HomeLoanBL homeLoanBL = new HomeLoanBL();
            bool isExist = false;
            string errorMessage = "loan id exist in database";
            try
            {
                isExist = homeLoanBL.IsLoanIDExistBL("25abfb8c-397a-49ad-9012-a5029ba18ea4");
            }
            catch (Exception ex)
            {
                isExist = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsTrue(isExist, errorMessage);
            }
        }


        [TestMethod]
        public void CarLoanIDNotExist()
        {
            CarLoanBL carLoanBL = new CarLoanBL();
            bool isExist = false;
            string errorMessage = "loan id must exist in database";
            try
            {
                isExist = carLoanBL.isLoanIDExistBL("f1386d7b-a12b-42f3-9b47-60ed29ac147f");
            }
            catch (Exception ex)
            {
                isExist = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isExist, errorMessage);
            }
        }


        [TestMethod]
        public void CarLoanIDExist()
        {
            CarLoanBL carLoanBL = new CarLoanBL();
            bool isExist = false;
            string errorMessage = "loan id exist in database";
            try
            {
                isExist = carLoanBL.isLoanIDExistBL("1f6fdc15-7cec-4818-ab07-e03f44f1da65");
            }
            catch (Exception ex)
            {
                isExist = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsTrue(isExist, errorMessage);
            }
        }
    }
    

/////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////
[TestClass]
    public class ApplyLoanTestCases
    {
        /// <summary>
        /// apply edu loan
        /// </summary>
        [TestMethod]
        public async Task ApplyEduLoan()
        {
            //Arrange
            EduLoanBL eduLoanBL = new EduLoanBL();
            EduLoan homeLoan = new EduLoan()
            {
                CustomerID = Guid.Parse("e7b0d7de-924e-4f9e-a75d-f0fb839c88a0"),
                AmountApplied = 120000,
                RepaymentPeriod = 65,
                Course = (CourseType)0,
                InstituteName = "abc institute",
                StudentID = "12548"
            };
            bool isAdded = false;
            string errorMessage = "amount applied must be less than 2000000";

            //Act
            try
            {
                isAdded = await eduLoanBL.ApplyLoanBL(homeLoan);
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
        /// Amount applied must be in range
        /// </summary>
        [TestMethod]
        public async Task ApplyEduLoanAmountAppliedMustBeInRange()
        {
            //Arrange
            EduLoanBL eduLoanBL = new EduLoanBL();
            EduLoan homeLoan = new EduLoan()
            {
                CustomerID = Guid.Parse("e7b0d7de-924e-4f9e-a75d-f0fb839c88a0"),
                AmountApplied = 12000000,
                RepaymentPeriod = 65,
                Course = (CourseType)0,
                InstituteName = "abc institute",
                StudentID = "12548"
            };
            bool isAdded = false;
            string errorMessage = "amount applied must be less than 2000000";

            //Act
            try
            {
                isAdded = await eduLoanBL.ApplyLoanBL(homeLoan);
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
        /// Amount applied must be positive
        /// </summary>
        [TestMethod]
        public async Task ApplyEduLoanAmountAppliedMustBePositive()
        {
            //Arrange
            EduLoanBL eduLoanBL = new EduLoanBL();
            EduLoan eduLoan = new EduLoan()
            {
                CustomerID = Guid.Parse("e7b0d7de-924e-4f9e-a75d-f0fb839c88a0"),
                AmountApplied = -12000,
                RepaymentPeriod = 65,
                Course = (CourseType)0,
                InstituteName = "abc institute",
                StudentID = "12548"
            };
            bool isAdded = false;
            string errorMessage = "amount applied must be Positive";

            //Act
            try
            {
                isAdded = await eduLoanBL.ApplyLoanBL(eduLoan);
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
        /// repayment period must be less than 180
        /// </summary>
        [TestMethod]
        public async Task ApplyEduLoanRepaymentPeriodMustBeInRange()
        {
            //Arrange
            EduLoanBL eduLoanBL = new EduLoanBL();
            EduLoan eduLoan = new EduLoan()
            {
                CustomerID = Guid.Parse("e7b0d7de-924e-4f9e-a75d-f0fb839c88a0"),
                AmountApplied = 120000,
                RepaymentPeriod = 265,
                Course = (CourseType)0,
                InstituteName = "abc institute",
                StudentID = "12548"
            };
            bool isAdded = false;
            string errorMessage = "repayment period must be less than 96";

            //Act
            try
            {
                isAdded = await eduLoanBL.ApplyLoanBL(eduLoan);
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
        /// repayment period must be positive
        /// </summary>
        [TestMethod]
        public async Task ApplyEduLoanRepaymentPeriodMustPositive()
        {
            //Arrange
            EduLoanBL eduLoanBL = new EduLoanBL();
            EduLoan eduLoan = new EduLoan()
            {
                CustomerID = Guid.Parse("e7b0d7de-924e-4f9e-a75d-f0fb839c88a0"),
                AmountApplied = 120000,
                RepaymentPeriod = -265,
                Course = (CourseType)0,
                InstituteName = "abc institute",
                StudentID = "12548"
            };
            bool isAdded = false;
            string errorMessage = "repayment period must be positive";

            //Act
            try
            {
                isAdded = await eduLoanBL.ApplyLoanBL(eduLoan);
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
        
        /////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Apply home loan
        /// </summary>
        [TestMethod]
        public async Task ApplyHomeLoan()
        {
            //Arrange
            HomeLoanBL homeLoanBL = new HomeLoanBL();
            HomeLoan homeLoan = new HomeLoan()
            {
                CustomerID = Guid.Parse("e7b0d7de-924e-4f9e-a75d-f0fb839c88a0"),
                AmountApplied = 120000,
                RepaymentPeriod = 65,
                Occupation = (ServiceType)0,
                GrossIncome = 52000,
                SalaryDeductions = 4500,
                ServiceYears = 7
            };
            bool isAdded = false;
            string errorMessage = "home loan not applied";

            //Act
            try
            {
                isAdded = await homeLoanBL.ApplyLoanBL(homeLoan);
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
        /// Amount applied must be in range
        /// </summary>
        [TestMethod]
        public async Task ApplyHomeLoanAmountAppliedMustBeInRange()
        {
            //Arrange
            HomeLoanBL homeLoanBL = new HomeLoanBL();
            HomeLoan homeLoan = new HomeLoan()
            {
                CustomerID = Guid.Parse("e7b0d7de-924e-4f9e-a75d-f0fb839c88a0"),
                AmountApplied = 12000000,
                RepaymentPeriod = 65,
                Occupation = (ServiceType)0,
                GrossIncome = 52000,
                SalaryDeductions = 4500,
                ServiceYears = 7
            };
            bool isAdded = false;
            string errorMessage = "amount applied must be less than 2000000";

            //Act
            try
            {
                isAdded = await homeLoanBL.ApplyLoanBL(homeLoan);
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
        /// Amount applied must be positive
        /// </summary>
        [TestMethod]
        public async Task ApplyHomeLoanAmountAppliedMustBePositive()
        {
            //Arrange
            HomeLoanBL homeLoanBL = new HomeLoanBL();
            HomeLoan homeLoan = new HomeLoan()
            {
                CustomerID = Guid.Parse("e7b0d7de-924e-4f9e-a75d-f0fb839c88a0"),
                AmountApplied = -12000,
                RepaymentPeriod = 65,
                Occupation = (ServiceType)0,
                GrossIncome = 52000,
                SalaryDeductions = 4500,
                ServiceYears = 7
            };
            bool isAdded = false;
            string errorMessage = "amount applied must be less than 2000000";

            //Act
            try
            {
                isAdded = await homeLoanBL.ApplyLoanBL(homeLoan);
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
        /// repayment period must be less than 180
        /// </summary>
        [TestMethod]
        public async Task ApplyHomeLoanRepaymentPeriodMustBeInRange()
        {
            //Arrange
            HomeLoanBL homeLoanBL = new HomeLoanBL();
            HomeLoan homeLoan = new HomeLoan()
            {
                CustomerID = Guid.Parse("e7b0d7de-924e-4f9e-a75d-f0fb839c88a0"),
                AmountApplied = 120000,
                RepaymentPeriod = 265,
                Occupation = (ServiceType)0,
                GrossIncome = 52000,
                SalaryDeductions = 4500,
                ServiceYears = 7
            };
            bool isAdded = false;
            string errorMessage = "repayment period must be less than 180";

            //Act
            try
            {
                isAdded = await homeLoanBL.ApplyLoanBL(homeLoan);
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
        /// repayment period must be positive
        /// </summary>
        [TestMethod]
        public async Task ApplyHomeLoanRepaymentPeriodMustPositive()
        {
            //Arrange
            HomeLoanBL homeLoanBL = new HomeLoanBL();
            HomeLoan homeLoan = new HomeLoan()
            {
                CustomerID = Guid.Parse("e7b0d7de-924e-4f9e-a75d-f0fb839c88a0"),
                AmountApplied = 120000,
                RepaymentPeriod = -265,
                Occupation = (ServiceType)0,
                GrossIncome = 52000,
                SalaryDeductions = 4500,
                ServiceYears = 7
            };
            bool isAdded = false;
            string errorMessage = "repayment period must be positive";

            //Act
            try
            {
                isAdded = await homeLoanBL.ApplyLoanBL(homeLoan);
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
        ///deductions must be less than income
        /// </summary>
        [TestMethod]
        public async Task ApplyHomeLoanDeductionsMustBeLessThanIncome()
        {
            //Arrange
            HomeLoanBL homeLoanBL = new HomeLoanBL();
            HomeLoan homeLoan = new HomeLoan()
            {
                CustomerID = Guid.Parse("e7b0d7de-924e-4f9e-a75d-f0fb839c88a0"),
                AmountApplied = 120000,
                RepaymentPeriod = 65,
                Occupation = (ServiceType)0,
                GrossIncome = 200,
                SalaryDeductions = 4500,
                ServiceYears = 7
            };
            bool isAdded = false;
            string errorMessage = "repayment period must be positive";

            //Act
            try
            {
                isAdded = await homeLoanBL.ApplyLoanBL(homeLoan);
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
        /// Experience must be positive
        /// </summary>
        [TestMethod]
        public async Task ApplyHomeLoanExperienceMustBePositive()
        {
            //Arrange
            HomeLoanBL homeLoanBL = new HomeLoanBL();
            HomeLoan homeLoan = new HomeLoan()
            {
                CustomerID = Guid.Parse("e7b0d7de-924e-4f9e-a75d-f0fb839c88a0"),
                AmountApplied = 120000,
                RepaymentPeriod = 65,
                Occupation = (ServiceType)0,
                GrossIncome = 52000,
                SalaryDeductions = 4500,
                ServiceYears = -7
            };
            bool isAdded = false;
            string errorMessage = "experience must be positive";

            //Act
            try
            {
                isAdded = await homeLoanBL.ApplyLoanBL(homeLoan);
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
        /// Experience must be in range
        /// </summary>
        [TestMethod]
        public async Task ApplyHomeLoanExperienceMustBeInRange()
        {
            //Arrange
            HomeLoanBL homeLoanBL = new HomeLoanBL();
            HomeLoan homeLoan = new HomeLoan()
            {
                CustomerID = Guid.Parse("e7b0d7de-924e-4f9e-a75d-f0fb839c88a0"),
                AmountApplied = 120000,
                RepaymentPeriod = 65,
                Occupation = (ServiceType)0,
                GrossIncome = 52000,
                SalaryDeductions = 4500,
                ServiceYears = 1
            };
            bool isAdded = false;
            string errorMessage = "experience must be in range";

            //Act
            try
            {
                isAdded = await homeLoanBL.ApplyLoanBL(homeLoan);
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

        
        /////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// apply car loan
        /// </summary>
        [TestMethod]
        public async Task ApplyCarLoan()
        {
            //Arrange
            CarLoanBL carLoanBL = new CarLoanBL();
            CarLoan carLoan = new CarLoan()
            {
                CustomerID = Guid.Parse("e7b0d7de-924e-4f9e-a75d-f0fb839c88a0"),
                AmountApplied = 120000,
                RepaymentPeriod = 65,
                Occupation = (ServiceType)0,
                GrossIncome = 52000,
                SalaryDeductions = 4500,
                Vehicle = (VehicleType)0
            };
            bool isAdded = false;
            string errorMessage = "car loan not applied";

            //Act
            try
            {
                isAdded = await carLoanBL.ApplyLoanBL(carLoan);
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
        /// Amount applied must be in range
        /// </summary>
        [TestMethod]
        public async Task ApplyCarLoanAmountAppliedMustBeInRange()
        {
            //Arrange
            CarLoanBL carLoanBL = new CarLoanBL();
            CarLoan carLoan = new CarLoan() {
                CustomerID = Guid.Parse("e7b0d7de-924e-4f9e-a75d-f0fb839c88a0"),
                AmountApplied = 12000000,
                RepaymentPeriod = 65,
                Occupation = (ServiceType)0,
                GrossIncome = 52000,
                SalaryDeductions = 4500,
                Vehicle = (VehicleType)0
            };
            bool isAdded = false;
            string errorMessage = "amount applied must be less than 2000000";

            //Act
            try
            {
                isAdded = await carLoanBL.ApplyLoanBL(carLoan);
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
        /// Amount applied must be positive
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task ApplyCarLoanAmountAppliedMustBePositive()
        {
            //Arrange
            CarLoanBL carLoanBL = new CarLoanBL();
            CarLoan carLoan = new CarLoan()
            {
                CustomerID = Guid.Parse("e7b0d7de-924e-4f9e-a75d-f0fb839c88a0"),
                AmountApplied = -120,
                RepaymentPeriod = 65,
                Occupation = (ServiceType)0,
                GrossIncome = 52000,
                SalaryDeductions = 4500,
                Vehicle = (VehicleType)0
            };
            bool isAdded = false;
            string errorMessage = "amount applied must be positive";

            //Act
            try
            {
                isAdded = await carLoanBL.ApplyLoanBL(carLoan);
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
        /// Repayment period must be in range
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task ApplyCarLoanRepaymentPeriodMustBeInRange()
        {
            //Arrange
            CarLoanBL carLoanBL = new CarLoanBL();
            CarLoan carLoan = new CarLoan()
            {
                CustomerID = Guid.Parse("e7b0d7de-924e-4f9e-a75d-f0fb839c88a0"),
                AmountApplied = 120000,
                RepaymentPeriod = 140,
                Occupation = (ServiceType)0,
                GrossIncome = 52000,
                SalaryDeductions = 4500,
                Vehicle = (VehicleType)0
            };
            bool isAdded = false;
            string errorMessage = "repayment period must be less than 120";

            //Act
            try
            {
                isAdded = await carLoanBL.ApplyLoanBL(carLoan);
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
        /// Repayment period must be positive
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task ApplyCarLoanRepaymentPeriodMustBePositive()
        {
            //Arrange
            CarLoanBL carLoanBL = new CarLoanBL();
            CarLoan carLoan = new CarLoan()
            {
                CustomerID = Guid.Parse("e7b0d7de-924e-4f9e-a75d-f0fb839c88a0"),
                AmountApplied = 12000,
                RepaymentPeriod = -65,
                Occupation = (ServiceType)0,
                GrossIncome = 52000,
                SalaryDeductions = 4500,
                Vehicle = (VehicleType)0
            };
            bool isAdded = false;
            string errorMessage = "repayment period must be positive";

            //Act
            try
            {
                isAdded = await carLoanBL.ApplyLoanBL(carLoan);
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
        /// Deductions must be less than or equal to Gross Income
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task ApplyCarLoanDeductionMustBeLessThanIncome()
        {
            //Arrange
            CarLoanBL carLoanBL = new CarLoanBL();
            CarLoan carLoan = new CarLoan()
            {
                CustomerID = Guid.Parse("e7b0d7de-924e-4f9e-a75d-f0fb839c88a0"),
                AmountApplied = 12000,
                RepaymentPeriod = 65,
                Occupation = (ServiceType)0,
                GrossIncome = 2000,
                SalaryDeductions = 4500,
                Vehicle = (VehicleType)0
            };
            bool isAdded = false;
            string errorMessage = "deductions must be less than gross income";

            //Act
            try
            {
                isAdded = await carLoanBL.ApplyLoanBL(carLoan);
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
