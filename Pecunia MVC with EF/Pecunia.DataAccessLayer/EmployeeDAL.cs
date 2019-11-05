using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capgemini.Pecunia.Exceptions;
using System.Data.Common;

using System.IO;
using Capgemini.Pecunia.Contracts.DALContracts;
using Capgemini.Pecunia.Entities;
using Capgemini.Pecunia.Helper;
using System.Data.SqlClient;
using Capgemini.Pecunia.Helpers;
using System.Data;


namespace Capgemini.Pecunia.DataAccessLayer
{
    /// <summary>
    /// Contains data access layer methods for inserting, updating, deleting Employee from Employees collection.
    /// </summary>
    public class EmployeeDAL : EmployeeDALBase, IDisposable
    {

        //SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.DbConnection);


        /// <summary>
        /// Adds new Employee to Employees collection.
        /// </summary>
        /// <param name="newEmployee">Contains the Employee details to be added.</param>
        /// <returns>Determinates whether the new Employee is added.</returns>
        public override bool AddEmployeeDAL(Employee newEmployee)
        {

            bool employeeAdded = false;
            try
            {
                newEmployee.EmployeeID = Guid.NewGuid();

                using (PecuniaEntities pecuniaEntities = new PecuniaEntities())
                {
                    pecuniaEntities.AddEmployees(newEmployee.EmployeeID, newEmployee.EmployeeName, newEmployee.EmployeeEmail, newEmployee.EmployeePassword, newEmployee.Mobile);
                }

                //EmployeeList.Add(newEmployee);
                employeeAdded = true;
            }
            catch (PecuniaException)
            {
                throw new EmployeeAddedException("Employee not added");
            }
            return employeeAdded;
        }

        /// <summary>
        /// Gets all Employees from the collection.
        /// </summary>
        /// <returns>Returns list of all Employees.</returns>
        public override List<Employee> GetAllEmployeesDAL()
        {
            List<Employee> employeesList = new List<Employee>();
            try
            {

                using (PecuniaEntities pecuniaEntities = new PecuniaEntities())
                {
                    employeesList = pecuniaEntities.Employees.ToList();
                }
            }
            catch (PecuniaException)
            {

                throw new EmployeeListException("Employee List cannot be displayed.");
            }
            return employeesList;
        }

        /// <summary>
        /// Gets Employee based on EmployeeID.
        /// </summary>
        /// <param name="searchEmployeeID">Represents EmployeeID to search.</param>
        /// <returns>Returns Employee object.</returns>
        public override Employee GetEmployeeByEmployeeIDDAL(Guid searchEmployeeID)
        {
            Employee matchingEmployee = new Employee();
            try
            {
                using (PecuniaEntities pecuniaEntities = new PecuniaEntities())
                {
                    matchingEmployee = pecuniaEntities.Employees.Where(e => e.EmployeeID == searchEmployeeID).FirstOrDefault();
                }
            }
            catch (PecuniaException)
            {
                throw new InvalidEmployeeException("Employee not found.");
            }
            return matchingEmployee;
        }

        /// <summary>
        /// Gets Employee based on EmployeeName.
        /// </summary>
        /// <param name="EmployeeName">Represents EmployeeName to search.</param>
        /// <returns>Returns Employee object.</returns>
        public override List<Employee> GetEmployeesByNameDAL(string EmployeeName)
        {

            Employee employee = new Employee();
            List<Employee> matchingEmployees = new List<Employee>();
            try
            {
                using (PecuniaEntities pecuniaEntities = new PecuniaEntities())
                {
                    matchingEmployees = pecuniaEntities.Employees.Where(e => e.EmployeeName == EmployeeName).ToList();
                }
            }
            catch (PecuniaException)
            {
                throw new InvalidEmployeeException("Employee not found.");
            }
            return matchingEmployees;
        }

        /// <summary>
        /// Gets Employee based on email.
        /// </summary>
        /// <param name="email">Represents Employee's Email Address.</param>
        /// <returns>Returns Employee object.</returns>
        public override Employee GetEmployeeByEmailDAL(string email)
        {
            Employee matchingEmployee = null;
            try
            {
                using (PecuniaEntities pecuniaEntities = new PecuniaEntities())
                {
                    matchingEmployee = pecuniaEntities.Employees.Where(e => e.EmployeeEmail == email).FirstOrDefault();
                }


            }
            catch (PecuniaException)
            {
                throw new InvalidEmployeeException("Employee not found.");
            }
            return matchingEmployee;
        }

        /// <summary>
        /// Gets Employee based on Email and Password.
        /// </summary>
        /// <param name="email">Represents Employee's Email Address.</param>
        /// <param name="password">Represents Employee's Password.</param>
        /// <returns>Returns Employee object.</returns>
        public override Employee GetEmployeeByEmailAndPasswordDAL(string email, string password)
        {
            Employee matchingEmployee = null;
            try
            {
                using (PecuniaEntities pecuniaEntities = new PecuniaEntities())
                {
                    matchingEmployee = pecuniaEntities.Employees.Where(e => e.EmployeeEmail == email && e.EmployeePassword == password).FirstOrDefault();
                }

            }
            catch (PecuniaException)
            {
                throw new InvalidEmployeeException("Employee not found");
            }
            return matchingEmployee;
        }

        /// <summary>
        /// Updates Employee based on EmployeeID.
        /// </summary>
        /// <param name="updateEmployee">Represents Employee details including EmployeeID, EmployeeName etc.</param>
        /// <returns>Determinates whether the existing Employee is updated.</returns>
        public override bool UpdateEmployeeDAL(Employee updateEmployee)
        {
            bool EmployeeUpdated = false;
            try
            {
                using (PecuniaEntities pecuniaEntities = new PecuniaEntities())
                {
                    int affectedRowsCount = pecuniaEntities.UpdateAllEmployeeDetails(updateEmployee.EmployeeID, updateEmployee.EmployeeName, updateEmployee.EmployeeEmail, updateEmployee.Mobile);
                    if (affectedRowsCount >= 1)
                    {
                        EmployeeUpdated = true;
                    }
                    else
                    {
                        EmployeeUpdated = false;
                    }
                }

            }
            catch (PecuniaException)
            {
                throw new EmployeeUpdateException("Employee details could not be updated.");
            }
            return EmployeeUpdated;
        }

        /// <summary>
        /// Deletes Employee based on EmployeeID.
        /// </summary>
        /// <param name="deleteEmployeeID">Represents EmployeeID to delete.</param>
        /// <returns>Determinates whether the existing Employee is updated.</returns>
        public override bool DeleteEmployeeDAL(Guid deleteEmployeeID)
        {
            bool EmployeeDeleted = false;
            try
            {
                using (PecuniaEntities pecuniaEntities = new PecuniaEntities())
                {
                    int affectedRowsCount = pecuniaEntities.DeleteEmployee(deleteEmployeeID);
                    if (affectedRowsCount >= 1)
                    {
                        EmployeeDeleted = true;
                    }
                    else
                    {
                        EmployeeDeleted = false;
                    }
                }

            }
            catch (PecuniaException)
            {
                throw new EmployeeDeletedException("Employee could not be deleted.");
            }
            return EmployeeDeleted;
        }

        /// <summary>
        /// Updates Employee's password based on EmployeeID.
        /// </summary>
        /// <param name="updateEmployee">Represents Employee details including EmployeeID, Password.</param>
        /// <returns>Determinates whether the existing Employee's password is updated.</returns>
        public override bool UpdateEmployeePasswordDAL(Employee updateEmployee)
        {
            bool passwordUpdated = false;
            try
            {
                using (PecuniaEntities pecuniaEntities = new PecuniaEntities())
                {
                    int affectedRowsCount = pecuniaEntities.UpdateEmployeePassword(updateEmployee.EmployeeID, updateEmployee.EmployeePassword);
                    if (affectedRowsCount >= 1)
                    {
                        passwordUpdated = true;
                    }
                    else
                    {
                        passwordUpdated = false;
                    }
                }
            }
            catch (PecuniaException)
            {
                throw new EmployeeUpdateException("Employee password could not be updated.");
            }
            return passwordUpdated;
        }



        /// <summary>
        /// Clears unmanaged resources such as db connections or file streams.
        /// </summary>
        public void Dispose()
        {
            //No unmanaged resources currently
        }

        
    }
}
