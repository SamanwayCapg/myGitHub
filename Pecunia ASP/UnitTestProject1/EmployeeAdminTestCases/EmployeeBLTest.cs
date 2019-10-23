using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Capgemini.Pecunia.BusinessLayer;
using Capgemini.Pecunia.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capgemini.Pecunia.Exceptions;

namespace Capgemini.Pecunia.UnitTest
{
    [TestClass]
    public class AddEmployeeBLTest
    {
        /// <summary>
        /// Add Employee to the Collection if it is valid.
        /// </summary>
        [TestMethod]
        public async Task AddValidEmployee()
        {
            //Arrange
            EmployeeBL employeeBL = new EmployeeBL();
            Employee employee = new Employee() { EmployeeName = "Rakesh", Mobile = "9876543210", Password = "Rakesh123#", Email = "rakesh@gmail.com" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await employeeBL.AddEmployeeBL(employee);
            }
            catch (EmployeeAddedException ex)
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
        /// Employee Name can't be null
        /// </summary>
        [TestMethod]
        public async Task EmployeeNameCannotBeNull()
        {
            //Arrange
            EmployeeBL employeeBL = new EmployeeBL();
            Employee employee = new Employee() { EmployeeName = null, Mobile = "9988776655", Password = "Smith123#", Email = "smith@gmail.com" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await employeeBL.AddEmployeeBL(employee);
            }
            catch (InvalidEmployeeException ex)
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
        /// Employee Mobile can't be null
        /// </summary>
        [TestMethod]
        public async Task EmployeeMobileCannotBeNull()
        {
            //Arrange
            EmployeeBL employeeBL = new EmployeeBL();
            Employee employee = new Employee() { EmployeeName = "Smith", Mobile = null, Password = "Smith123#", Email = "smith@gmail.com" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await employeeBL.AddEmployeeBL(employee);
            }
            catch (InvalidEmployeeException ex)
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
        /// Employee Password can't be null
        /// </summary>
        [TestMethod]
        public async Task EmployeePasswordCannotBeNull()
        {
            //Arrange
            EmployeeBL employeeBL = new EmployeeBL();
            Employee employee = new Employee() { EmployeeName = "Allen", Mobile = "9877766554", Password = null, Email = "allen@gmail.com" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await employeeBL.AddEmployeeBL(employee);
            }
            catch (InvalidEmployeeException ex)
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
        /// Employee Email can't be null
        /// </summary>
        [TestMethod]
        public async Task EmployeeEmailCannotBeNull()
        {
            //Arrange
            EmployeeBL employeeBL = new EmployeeBL();
            Employee employee = new Employee() { EmployeeName = "John", Mobile = "9876543210", Password = "John123#", Email = null };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await employeeBL.AddEmployeeBL(employee);
            }
            catch (InvalidEmployeeException ex)
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
        /// EmployeeName should contain at least two characters
        /// </summary>
        [TestMethod]
        public async Task EmployeeNameShouldContainAtLeastTwoCharacters()
        {
            //Arrange
            EmployeeBL employeeBL = new EmployeeBL();
            Employee employee = new Employee() { EmployeeName = "J", Mobile = "9877897890", Password = "John123#", Email = "john@gmail.com" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await employeeBL.AddEmployeeBL(employee);
            }
            catch (InvalidEmployeeException ex)
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
        /// EmployeeMobile should be a valid mobile number
        /// </summary>
        [TestMethod]
        public async Task EmployeeMobileRegExp()
        {
            //Arrange
            EmployeeBL employeeBL = new EmployeeBL();
            Employee employee = new Employee() { EmployeeName = "John", Mobile = "9877", Password = "John123#", Email = "john@gmail.com" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await employeeBL.AddEmployeeBL(employee);
            }
            catch (InvalidEmployeeException ex)
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
        /// Password should be a valid password as per regular expression
        /// </summary>
        [TestMethod]
        public async Task EmployeePasswordRegExp()
        {
            //Arrange
            EmployeeBL employeeBL = new EmployeeBL();
            Employee employee = new Employee() { EmployeeName = "John", Mobile = "9877897890", Password = "John", Email = "john@gmail.com" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await employeeBL.AddEmployeeBL(employee);
            }
            catch (InvalidEmployeeException ex)
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
        /// Email should be a valid email as per regular expression
        /// </summary>
        [TestMethod]
        public async Task EmployeeEmailRegExp()
        {
            //Arrange
            EmployeeBL employeeBL = new EmployeeBL();
            Employee employee = new Employee() { EmployeeName = "John", Mobile = "9877897890", Password = "John123#", Email = "john" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await employeeBL.AddEmployeeBL(employee);
            }
            catch (InvalidEmployeeException ex)
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

    [TestClass]
    public class GetAllEmployeesBLTest
    {
        [TestMethod]
        public async Task GetEmployeeList()
        {
            //Arrange
            
            bool isAdded = false;
            bool isAddedToList = false;
            Employee employee = new Employee() { EmployeeName = "Kabir", Mobile = "9876543987", Password = "Kabir123#", Email = "kabir@gmail.com" };
            EmployeeBL employeeBL = new EmployeeBL();
            List<Employee> employeeList = await employeeBL.GetAllEmployeesBL();
            int count1 = employeeList.Count;

            isAdded = await employeeBL.AddEmployeeBL(employee);
            employeeList = await employeeBL.GetAllEmployeesBL();
            int count2 = employeeList.Count;
            string errorMessage = null;
 
            //Act
            try
            {
                if (count2 == count1 + 1)
                    isAddedToList = true;
            }
            catch (EmployeeListException ex)
            {
                isAddedToList = false;
                errorMessage = ex.Message;
            }
            finally
            {
                Assert.IsTrue(isAddedToList, errorMessage);
            }
        }

    } 

    [TestClass]
    public class GetEmployeeByEmployeeIDBLTest
    {
        [TestMethod]
        public async Task EmployeeIDCannotBeNull()
        {
            //Arrange
            Guid employeeID = Guid.Empty;
            EmployeeBL employeeBL = new EmployeeBL();
            Employee employee = new Employee();
            string errorMessage = null;

            //Act
            try
            {
                employee = await employeeBL.GetEmployeeByEmployeeIDBL(employeeID);
            }
            catch (InvalidEmployeeException ex)
            {
                errorMessage = ex.Message + "Employee ID cannot be null";

            }
            finally
            {
                //Assert
                Assert.IsNull(employee, errorMessage);
            }
        }

        [TestMethod]
        public async Task EmployeeIDDoesNotMatch()
        {
            //Arrange
            Guid employeeID = Guid.Parse("6a1b8831 - 9806 - 4db0 - b650 - c2772a6b84f4");
            EmployeeBL employeeBL = new EmployeeBL();
            Employee employee = new Employee();
            string errorMessage = null;

            //Act
            try
            {
                employee = await employeeBL.GetEmployeeByEmployeeIDBL(employeeID);
            }
            catch (InvalidEmployeeException ex)
            {
                errorMessage = ex.Message + "Employee ID does not match";
            }
            finally
            {
                //Assert
                Assert.IsNull(employee, errorMessage);
            }
        }
    }


   /* [TestClass]
    public class GetEmployeesByNameBLTest
    {
        [TestMethod]
        public async Task EmployeeNameCannotBeNull()
        {
            //Arrange
            string employeeName = null;
            List<Employee> employeeList = new List<Employee>();
            EmployeeBL employeeBL = new EmployeeBL();
            string errorMessage = null;
           
            //Act
            try
            {
                employeeList = await employeeBL.GetEmployeesByNameBL(employeeName);
            }
            catch (InvalidEmployeeException ex)
            {
                errorMessage = ex.Message + "Employee name cannot be null";
            }
            finally
            {
                //Assert
                CollectionAssert.
            }
        }
    }*/

    [TestClass]
    public class UpdateEmployeeTest
    {
        ///<summary>Tests if the valid employee is updated in the list or not</summary>
        [TestMethod]
        public async Task UpdateEmployee()
        {
            //Arrange
            Employee employee = new Employee() {EmployeeName = "Kabir", Email="kabir@gmail.com", Password ="kabir#123", Mobile = "9234545678" };
            EmployeeBL employeeBL = new EmployeeBL();
            bool isUpdated = false;
            bool isAdded = false;
            isAdded = await employeeBL.AddEmployeeBL(employee);
            employee.EmployeeName = "samar";
            employee.Email = "samar@gmail.com";
            employee.Mobile = "9234598765";
            string errorMessage = null;

            //Act
            try
            {
                isUpdated = await employeeBL.UpdateEmployeeBL(employee);
            }
            catch (EmployeeAddedException ex)
            {
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isUpdated, errorMessage);
            }
        }
    }

}
