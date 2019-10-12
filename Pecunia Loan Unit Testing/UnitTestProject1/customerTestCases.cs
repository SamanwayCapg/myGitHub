using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Capgemini.Pecunia.BusinessLayer.LoanBL;
using Capgemini.Pecunia.BusinessLayer;
using Capgemini.Pecunia.Entities;
using Capgemini.Pecunia.Exceptions;
using System.Collections.Generic;
using Capgemini.Pecunia.DataAccessLayer;

namespace Capgemini.Pecunia.UnitTest
{
    [TestClass]
    public class AddCustomerBLTest
    {


        /// <summary>
        /// Add Customer to the Collection if it is valid.
        /// </summary>
        [TestMethod]
        public async Task AddValidCustomer()
        {
            //Arrange
            CustomerBL customerBL = new CustomerBL();
            Customer customer = new Customer() { CustomerName = "Akshay", CustomerMobile = "9988776655", CustomerAddress = "9/A,Street-13,Sector-5,Bhilai", CustomerEmail = "smith@gmail.com", CustomerPan = "AAAPL1234C", CustomerAadhaarNumber = "1234 4554 2345", DOB = "20/03/1991" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await customerBL.AddCustomerBL(customer);
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
        /// Customer Name can't be null
        /// </summary>
        [TestMethod]
        public async Task CustomerNameCanNotBeNull()
        {
            //Arrange
            CustomerBL customerBL = new CustomerBL();
            Customer customer = new Customer() { CustomerName = null, CustomerMobile = "9988776655", CustomerAddress = "9/A,Street-13,Sector-5,Bhilai", CustomerEmail = "smith@gmail.com", CustomerPan = "AAAPL1234C", CustomerAadhaarNumber = "1234 4554 2345", DOB = "20/03/1991" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await customerBL.AddCustomerBL(customer);
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
        /// Customer Mobile can't be null
        /// </summary>
        [TestMethod]
        public async Task CustomerMobileCanNotBeNull()
        {
            //Arrange
            CustomerBL customerBL = new CustomerBL();
            Customer customer = new Customer() { CustomerName = "Akku", CustomerMobile = null, CustomerAddress = "2/A,Street-2,Sector-4,Durg", CustomerEmail = "smith@gmail.com", CustomerPan = "AAAPL1234C", CustomerAadhaarNumber = "1234 4554 2345", DOB = "20/03/1991" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await customerBL.AddCustomerBL(customer);
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
        ///  CustomerAddress can't be null
        /// </summary>
        [TestMethod]
        public async Task CustomerAddressCanNotBeNull()
        {
            //Arrange
            CustomerBL customerBL = new CustomerBL();
            Customer customer = new Customer() { CustomerName = "Annie", CustomerMobile = "9988776655", CustomerAddress = null, CustomerEmail = "annie@gmail.com", CustomerPan = "AAAPL1234C", CustomerAadhaarNumber = "1234 4554 2345", DOB = "20/03/1991" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await customerBL.AddCustomerBL(customer);
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
        ///  CustomerEmail can't be null
        /// </summary>
        [TestMethod]
        public async Task CustomerEmailCanNotBeNull()
        {
            //Arrange
            CustomerBL customerBL = new CustomerBL();
            Customer customer = new Customer() { CustomerName = "Annie", CustomerMobile = "9988776655", CustomerAddress = "9/A,Street-13,Sector-5,Bhilai", CustomerEmail = null, CustomerPan = "AAAPL1234C", CustomerAadhaarNumber = "1234 4554 2345", DOB = "20/03/1991" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await customerBL.AddCustomerBL(customer);
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
        /// Customer Pan can't be null
        /// </summary>
        [TestMethod]
        public async Task CustomerPanCanNotBeNull()
        {
            //Arrange
            CustomerBL customerBL = new CustomerBL();
            Customer customer = new Customer() { CustomerName = "Aadi", CustomerMobile = "9988776655", CustomerAddress = "9/j,Street-16,Sector-10,Airoli", CustomerEmail = "aadi@gmail.com", CustomerPan = null, CustomerAadhaarNumber = "1234 4554 2345", DOB = "20/03/1991" };

            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await customerBL.AddCustomerBL(customer);
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
        /// Customer Aadhaar can't be null
        /// </summary>
        [TestMethod]
        public async Task CustomerAadhaarCanNotBeNull()
        {
            //Arrange
            CustomerBL customerBL = new CustomerBL();
            Customer customer = new Customer() { CustomerName = "Rikie", CustomerMobile = "9988776655", CustomerAddress = "21-A,Street-13,Sector-5,Bhilai", CustomerEmail = "smith@gmail.com", CustomerPan = "AAAPL1234C", CustomerAadhaarNumber = null, DOB = "20/08/1991" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await customerBL.AddCustomerBL(customer);
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
        ///  Customer DOB can't be null
        /// </summary>
        [TestMethod]
        public async Task CustomerDOBCanNotBeNull()
        {
            //Arrange
            CustomerBL customerBL = new CustomerBL();
            Customer customer = new Customer() { CustomerName = "Rikie", CustomerMobile = "9988776655", CustomerAddress = "21-A,Street-13,Sector-5,Bhilai", CustomerEmail = "smith@gmail.com", CustomerPan = "AAAPL1234C", CustomerAadhaarNumber = "2234 5674 7890", DOB = null };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await customerBL.AddCustomerBL(customer);
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
        /// CustomerName should contain at least two characters
        /// </summary>
        [TestMethod]
        public async Task CustomerNameShouldContainAtLeastTwoCharacters()
        {
            //Arrange
            CustomerBL customerBL = new CustomerBL();
            Customer customer = new Customer() { CustomerName = "J", CustomerMobile = "9988776655", CustomerAddress = "21-A,Street-13,Sector-5,Bhilai", CustomerEmail = "smith@gmail.com", CustomerPan = "AAAPL1234C", CustomerAadhaarNumber = "2234 5674 7890", DOB = "04-09-1998" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await customerBL.AddCustomerBL(customer);
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
        /// CustomerMobile should be a valid mobile number
        /// </summary>
        [TestMethod]
        public async Task CustomerMobileRegExp()
        {
            //Arrange
            CustomerBL customerBL = new CustomerBL();
            Customer customer = new Customer() { CustomerName = "John", CustomerMobile = "998", CustomerAddress = "21-A,Street-13,Sector-1,Bhilai", CustomerEmail = "smith@gmail.com", CustomerPan = "AAAPL1234C", CustomerAadhaarNumber = "2234 5674 7890", DOB = "20-09-1993" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await customerBL.AddCustomerBL(customer);
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
        /// CustomerEmail should be a valid email as per regular expression
        /// </summary>
        [TestMethod]
        public async Task CustomerEmailRegExp()
        {
            //Arrange
            CustomerBL customerBL = new CustomerBL();
            Customer customer = new Customer() { CustomerName = "John", CustomerMobile = "9988776655", CustomerAddress = "21-A,Street-13,Sector-5,Bhilai", CustomerEmail = "smith", CustomerPan = "AAAPL1234C", CustomerAadhaarNumber = "2234 5674 7890", DOB = "20-09-1997" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await customerBL.AddCustomerBL(customer);
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
        /// Customer Address should be  valid 
        /// </summary>
        [TestMethod]
        public async Task CustomerAddressRegExp()
        {
            //Arrange
            CustomerBL customerBL = new CustomerBL();
            Customer customer = new Customer() { CustomerName = "John", CustomerMobile = "9877658970", CustomerAddress = "21", CustomerEmail = "smith", CustomerPan = "AAAPL1234C", CustomerAadhaarNumber = "2234 5674 7890", DOB = "09-04-1996" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await customerBL.AddCustomerBL(customer);
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
        /// Customer Pan should be  valid 
        /// </summary>
        [TestMethod]
        public async Task CustomerPanRegExp()
        {
            //Arrange
            CustomerBL customerBL = new CustomerBL();
            Customer customer = new Customer() { CustomerName = "John", CustomerMobile = "9877658970", CustomerAddress = "21-A,Street-13,Sector-5,Bhilai", CustomerEmail = "smith", CustomerPan = "AA", CustomerAadhaarNumber = "2234 5674 7890", DOB = "09-04-1996" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await customerBL.AddCustomerBL(customer);
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
        /// Customer Aadhaar should be  valid 
        /// </summary>
        [TestMethod]
        public async Task CustomerAadhaarRegExp()
        {
            //Arrange
            CustomerBL customerBL = new CustomerBL();
            Customer customer = new Customer() { CustomerName = "John", CustomerMobile = "9877658970", CustomerAddress = "21-A,Street-13,Sector-5,Bhilai", CustomerEmail = "smith", CustomerPan = "AAAPL1234C", CustomerAadhaarNumber = "2234", DOB = "09-04-1996" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await customerBL.AddCustomerBL(customer);
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
        /// Customer DOB should be  valid 
        /// </summary>
        [TestMethod]
        public async Task CustomerDOBRegExp()
        {
            //Arrange
            CustomerBL customerBL = new CustomerBL();
            Customer customer = new Customer() { CustomerName = "John", CustomerMobile = "9877658970", CustomerAddress = "21-A,Street-13,Sector-5,Bhilai", CustomerEmail = "smith", CustomerPan = "AAAPL1234C", CustomerAadhaarNumber = "2234 2354 6789", DOB = "09" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await customerBL.AddCustomerBL(customer);
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
    // //////////////Update Customer///////////////
    [TestClass]
    public class UpdateCustomerBLTest
    {


        /// <summary>
        /// Add Customer to the Collection if it is valid.
        /// </summary>
        [TestMethod]
        public async Task UPDATEValidCustomer()
        {
            //Arrange
            CustomerBL customerBL = new CustomerBL();
            Customer customer = new Customer() { CustomerName = "Akshay", CustomerMobile = "9988776655", CustomerAddress = "9/A,Street-13,Sector-5,Bhilai", CustomerEmail = "smith@gmail.com", CustomerPan = "AAAPL1234C", CustomerAadhaarNumber = "1234 4554 2345", DOB = "20/03/1991" };
            bool isupdated = false;
            string errorMessage = null;

            //Act
            try
            {
                isupdated = await customerBL.UpdateCustomerByCustomerIDBL(customer);
            }
            catch (Exception ex)
            {
                isupdated = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isupdated, errorMessage);
            }
        }

        /// <summary>
        /// Customer Name can't be null
        /// </summary>
        [TestMethod]
        public async Task CustomerNameCanNotBeNull()
        {
            //Arrange
            CustomerBL customerBL = new CustomerBL();
            Customer customer = new Customer() { CustomerName = null, CustomerMobile = "9988776655", CustomerAddress = "9/A,Street-13,Sector-5,Bhilai", CustomerEmail = "smith@gmail.com", CustomerPan = "AAAPL1234C", CustomerAadhaarNumber = "1234 4554 2345", DOB = "20/03/1991" };
            bool isupdated = false;
            string errorMessage = null;

            //Act
            try
            {
                isupdated = await customerBL.UpdateCustomerByCustomerIDBL(customer);
            }
            catch (Exception ex)
            {
                isupdated = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isupdated, errorMessage);
            }
        }

        /// <summary>
        /// Customer Mobile can't be null
        /// </summary>
        [TestMethod]
        public async Task CustomerMobileCanNotBeNull()
        {
            //Arrange
            CustomerBL customerBL = new CustomerBL();
            Customer customer = new Customer() { CustomerName = "Akku", CustomerMobile = null, CustomerAddress = "2/A,Street-2,Sector-4,Durg", CustomerEmail = "smith@gmail.com", CustomerPan = "AAAPL1234C", CustomerAadhaarNumber = "1234 4554 2345", DOB = "20/03/1991" };
            bool isupdated = false;
            string errorMessage = null;

            //Act
            try
            {
                isupdated = await customerBL.UpdateCustomerByCustomerIDBL(customer);
            }
            catch (Exception ex)
            {
                isupdated = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isupdated, errorMessage);
            }
        }
        /// <summary>
        ///  CustomerAddress can't be null
        /// </summary>
        [TestMethod]
        public async Task CustomerAddressCanNotBeNull()
        {
            //Arrange
            CustomerBL customerBL = new CustomerBL();
            Customer customer = new Customer() { CustomerName = "Annie", CustomerMobile = "9988776655", CustomerAddress = null, CustomerEmail = "annie@gmail.com", CustomerPan = "AAAPL1234C", CustomerAadhaarNumber = "1234 4554 2345", DOB = "20/03/1991" };
            bool isupdated = false;
            string errorMessage = null;

            //Act
            try
            {
                isupdated = await customerBL.UpdateCustomerByCustomerIDBL(customer);
            }
            catch (Exception ex)
            {
                isupdated = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isupdated, errorMessage);
            }
        }




        /// <summary>
        ///  CustomerEmail can't be null
        /// </summary>
        [TestMethod]
        public async Task CustomerEmailCanNotBeNull()
        {
            //Arrange
            CustomerBL customerBL = new CustomerBL();
            Customer customer = new Customer() { CustomerName = "Annie", CustomerMobile = "9988776655", CustomerAddress = "9/A,Street-13,Sector-5,Bhilai", CustomerEmail = null, CustomerPan = "AAAPL1234C", CustomerAadhaarNumber = "1234 4554 2345", DOB = "20/03/1991" };
            bool isupdated = false;
            string errorMessage = null;

            //Act
            try
            {
                isupdated = await customerBL.UpdateCustomerByCustomerIDBL(customer);
            }
            catch (Exception ex)
            {
                isupdated = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isupdated, errorMessage);
            }
        }

        /// <summary>
        /// Customer Pan can't be null
        /// </summary>
        [TestMethod]
        public async Task CustomerPanCanNotBeNull()
        {
            //Arrange
            CustomerBL customerBL = new CustomerBL();
            Customer customer = new Customer() { CustomerName = "Aadi", CustomerMobile = "9988776655", CustomerAddress = "9/j,Street-16,Sector-10,Airoli", CustomerEmail = "aadi@gmail.com", CustomerPan = null, CustomerAadhaarNumber = "1234 4554 2345", DOB = "20/03/1991" };

            bool isupdated = false;
            string errorMessage = null;

            //Act
            try
            {
                isupdated = await customerBL.UpdateCustomerByCustomerIDBL(customer);
            }
            catch (Exception ex)
            {
                isupdated = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isupdated, errorMessage);
            }
        }

        /// <summary>
        /// Customer Aadhaar can't be null
        /// </summary>
        [TestMethod]
        public async Task CustomerAadhaarCanNotBeNull()
        {
            //Arrange
            CustomerBL customerBL = new CustomerBL();
            Customer customer = new Customer() { CustomerName = "Rikie", CustomerMobile = "9988776655", CustomerAddress = "21-A,Street-13,Sector-5,Bhilai", CustomerEmail = "smith@gmail.com", CustomerPan = "AAAPL1234C", CustomerAadhaarNumber = null, DOB = "20/08/1991" };
            bool isupdated = false;
            string errorMessage = null;

            //Act
            try
            {
                isupdated = await customerBL.UpdateCustomerByCustomerIDBL(customer);
            }
            catch (Exception ex)
            {
                isupdated = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isupdated, errorMessage);
            }
        }

        /// <summary>
        ///  Customer DOB can't be null
        /// </summary>
        [TestMethod]
        public async Task CustomerDOBCanNotBeNull()
        {
            //Arrange
            CustomerBL customerBL = new CustomerBL();
            Customer customer = new Customer() { CustomerName = "Rikie", CustomerMobile = "9988776655", CustomerAddress = "21-A,Street-13,Sector-5,Bhilai", CustomerEmail = "smith@gmail.com", CustomerPan = "AAAPL1234C", CustomerAadhaarNumber = "2234 5674 7890", DOB = null };
            bool isupdated = false;
            string errorMessage = null;

            //Act
            try
            {
                isupdated = await customerBL.UpdateCustomerByCustomerIDBL(customer);
            }
            catch (Exception ex)
            {
                isupdated = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isupdated, errorMessage);
            }
        }



        /// <summary>
        /// CustomerName should contain at least two characters
        /// </summary>
        [TestMethod]
        public async Task CustomerNameShouldContainAtLeastTwoCharacters()
        {
            //Arrange
            CustomerBL customerBL = new CustomerBL();
            Customer customer = new Customer() { CustomerName = "J", CustomerMobile = "9988776655", CustomerAddress = "21-A,Street-13,Sector-5,Bhilai", CustomerEmail = "smith@gmail.com", CustomerPan = "AAAPL1234C", CustomerAadhaarNumber = "2234 5674 7890", DOB = "04-09-1998" };
            bool isupdated = false;
            string errorMessage = null;

            //Act
            try
            {
                isupdated = await customerBL.UpdateCustomerByCustomerIDBL(customer);
            }
            catch (Exception ex)
            {
                isupdated = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isupdated, errorMessage);
            }
        }

        /// <summary>
        /// CustomerMobile should be a valid mobile number
        /// </summary>
        [TestMethod]
        public async Task CustomerMobileRegExp()
        {
            //Arrange
            CustomerBL customerBL = new CustomerBL();
            Customer customer = new Customer() { CustomerName = "John", CustomerMobile = "998", CustomerAddress = "21-A,Street-13,Sector-1,Bhilai", CustomerEmail = "smith@gmail.com", CustomerPan = "AAAPL1234C", CustomerAadhaarNumber = "2234 5674 7890", DOB = "20-09-1993" };
            bool isupdated = false;
            string errorMessage = null;

            //Act
            try
            {
                isupdated = await customerBL.UpdateCustomerByCustomerIDBL(customer);
            }
            catch (Exception ex)
            {
                isupdated = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isupdated, errorMessage);
            }
        }



        /// <summary>
        /// CustomerEmail should be a valid email as per regular expression
        /// </summary>
        [TestMethod]
        public async Task CustomerEmailRegExp()
        {
            //Arrange
            CustomerBL customerBL = new CustomerBL();
            Customer customer = new Customer() { CustomerName = "John", CustomerMobile = "9988776655", CustomerAddress = "21-A,Street-13,Sector-5,Bhilai", CustomerEmail = "smith", CustomerPan = "AAAPL1234C", CustomerAadhaarNumber = "2234 5674 7890", DOB = "20-09-1997" };
            bool isupdated = false;
            string errorMessage = null;

            //Act
            try
            {
                isupdated = await customerBL.UpdateCustomerByCustomerIDBL(customer);
            }
            catch (Exception ex)
            {
                isupdated = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isupdated, errorMessage);
            }
        }

        /// <summary>
        /// Customer Address should be  valid 
        /// </summary>
        [TestMethod]
        public async Task CustomerAddressRegExp()
        {
            //Arrange
            CustomerBL customerBL = new CustomerBL();
            Customer customer = new Customer() { CustomerName = "John", CustomerMobile = "9877658970", CustomerAddress = "21", CustomerEmail = "smith", CustomerPan = "AAAPL1234C", CustomerAadhaarNumber = "2234 5674 7890", DOB = "09-04-1996" };
            bool isupdated = false;
            string errorMessage = null;

            //Act
            try
            {
                isupdated = await customerBL.UpdateCustomerByCustomerIDBL(customer);
            }
            catch (Exception ex)
            {
                isupdated = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isupdated, errorMessage);
            }
        }

        /// <summary>
        /// Customer Pan should be  valid 
        /// </summary>
        [TestMethod]
        public async Task CustomerPanRegExp()
        {
            //Arrange
            CustomerBL customerBL = new CustomerBL();
            Customer customer = new Customer() { CustomerName = "John", CustomerMobile = "9877658970", CustomerAddress = "21-A,Street-13,Sector-5,Bhilai", CustomerEmail = "smith", CustomerPan = "AA", CustomerAadhaarNumber = "2234 5674 7890", DOB = "09-04-1996" };
            bool isupdated = false;
            string errorMessage = null;

            //Act
            try
            {
                isupdated = await customerBL.UpdateCustomerByCustomerIDBL(customer);
            }
            catch (Exception ex)
            {
                isupdated = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isupdated, errorMessage);
            }
        }

        /// <summary>
        /// Customer Aadhaar should be  valid 
        /// </summary>
        [TestMethod]
        public async Task CustomerAadhaarRegExp()
        {
            //Arrange
            CustomerBL customerBL = new CustomerBL();
            Customer customer = new Customer() { CustomerName = "John", CustomerMobile = "9877658970", CustomerAddress = "21-A,Street-13,Sector-5,Bhilai", CustomerEmail = "smith", CustomerPan = "AAAPL1234C", CustomerAadhaarNumber = "2234", DOB = "09-04-1996" };
            bool isupdated = false;
            string errorMessage = null;

            //Act
            try
            {
                isupdated = await customerBL.UpdateCustomerByCustomerIDBL(customer);
            }
            catch (Exception ex)
            {
                isupdated = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isupdated, errorMessage);
            }
        }

        /// <summary>
        /// Customer DOB should be  valid 
        /// </summary>
        [TestMethod]
        public async Task CustomerDOBRegExp()
        {
            //Arrange
            CustomerBL customerBL = new CustomerBL();
            Customer customer = new Customer() { CustomerName = "John", CustomerMobile = "9877658970", CustomerAddress = "21-A,Street-13,Sector-5,Bhilai", CustomerEmail = "smith", CustomerPan = "AAAPL1234C", CustomerAadhaarNumber = "2234 2354 6789", DOB = "09" };
            bool isupdated = false;
            string errorMessage = null;

            //Act
            try
            {
                isupdated = await customerBL.UpdateCustomerByCustomerIDBL(customer);
            }
            catch (Exception ex)
            {
                isupdated = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isupdated, errorMessage);
            }

        }

    }
    [TestClass]
    public class CustomerBLTest
    {
        [TestMethod]
        public async Task GetCustomerByWrongCustomerIDTest()
        {
            CustomerBL customerBL = new CustomerBL();

            bool isAdded = false;
            string errorMessage = null;

            Customer customer = new Customer();
            Customer atemp = new Customer();
            atemp.CustomerID = Guid.Parse("1234");

            //Act
            try
            {
                atemp = await customerBL.GetCustomerByCustomerIDBL(customer.CustomerID);
                isAdded = ReferenceEquals(customer, atemp);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                //Replace with collection.AssertEqual false 
                Assert.IsFalse(isAdded, errorMessage);
            }

        }
    }
}
