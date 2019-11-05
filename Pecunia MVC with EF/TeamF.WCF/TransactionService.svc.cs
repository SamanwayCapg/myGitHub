using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TeamF.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class TransactionService : ITransactionService
    {
        public List<TransactionDataContract> GetAllTransactions()
        {
            //Create factory
            DbProviderFactory factory = DbProviderFactories.GetFactory(
                System.Configuration.ConfigurationManager.ConnectionStrings["PecuniaConnectionString"].ProviderName);

            //Create connection
            DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PecuniaConnectionString"].ConnectionString;

            //Create command
            DbCommand command = connection.CreateCommand();
            command.CommandText = "TeamF.GetAllTransactions";
            command.Connection = connection;
            command.CommandType = System.Data.CommandType.StoredProcedure;

            //Create adapter
            DbDataAdapter adapter = factory.CreateDataAdapter();
            adapter.SelectCommand = command;

            //Create dataset
            DataSet ds = new DataSet();

            //Execute
            adapter.Fill(ds);

            //Convert datatable to collection
            List<TransactionDataContract> transactions = ds.Tables[0]
                .AsEnumerable()
                .Select(t => new TransactionDataContract()
                {
                    TransactionID = t.Field<Guid>("TransactionID"),
                    AccountID = t.Field<Guid>("AccountID"),
                    TypeOfTransaction = t.Field<string>("TypeOfTransaction"),
                    Amount = t.Field<decimal>("Amount"),
                    DateOfTransaction = t.Field<DateTime>("DateOfTransaction"),
                    Mode = t.Field<string>("Mode"),
                    ChequeNumber = t.Field<string>("ChequeNumber")

                })
                .ToList();

            return transactions;

        }



        //Connection string definition
        DbProviderFactory factory = DbProviderFactories.GetFactory(System.Configuration.ConfigurationManager.ConnectionStrings["PecuniaConnectionString"].ProviderName);
        /// <summary>       
        /// Developed By Aishwarya Sarna
        /// </summary>        
        /// <returns>Returns List of employees.</returns>
        /// 

        public List<EmployeeDataContract> GetAllEmployees()
        {
            List<EmployeeDataContract> employeeList = new List<EmployeeDataContract>();

            try
            { //Create connection
                DbConnection connection = factory.CreateConnection();
                connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PecuniaConnectionString"].ConnectionString;

                //Create command
                DbCommand command = connection.CreateCommand();
                command.CommandText = "TeamF.GetAllEmployees";
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;


                //Create adapter
                DbDataAdapter adapter = factory.CreateDataAdapter();
                adapter.SelectCommand = command;

                //Create dataset
                DataSet dataSet = new DataSet();

                //Execute
                adapter.Fill(dataSet);

                //Convert datatable to collection
                employeeList = dataSet.Tables[0]
                   .AsEnumerable()
                   .Select(p => new EmployeeDataContract()
                   {
                       EmployeeID = p.Field<Guid>("EmployeeID"),
                       EmployeeName = p.Field<string>("EmployeeName"),
                       Email = p.Field<string>("EmployeeEmail"),
                       Mobile = p.Field<string>("Mobile"),
                       CreationDateTime = p.Field<DateTime>("CreationDateTime"),
                       LastModifiedDateTime = p.Field<DateTime>("LastModifiedDateTime"),

                   })
                   .ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return employeeList;
        }

        public List<CustomersDataContract> GetAllCustomers()
        {
            //create factory
            DbProviderFactory factory = DbProviderFactories.GetFactory(
                System.Configuration.ConfigurationManager.ConnectionStrings
                ["PecuniaConnectionString"].ProviderName);

            //create connection
            DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings
                ["PecuniaConnectionString"].ConnectionString;

            //create command
            DbCommand command = connection.CreateCommand();
            command.CommandText = "";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            //create adapter
            DbDataAdapter adapter = factory.CreateDataAdapter();
            adapter.SelectCommand = command;

            //create dataset
            DataSet ds = new DataSet();

            //Execute
            adapter.Fill(ds);

            //Convert datatable to collection
            List<CustomersDataContract> customers = ds.Tables[0].AsEnumerable()
                .Select(t => new CustomersDataContract()
                {
                    CustomerID = t.Field<Guid>("CustomerID"),
                    CustomerName = t.Field<string>("CustomerName"),
                    CustomerMobile = t.Field<string>("Customermobile"),
                    CustomerEmail = t.Field<string>("CustomerEmail"),
                    CustomerAddress = t.Field<string>("CustomerAddress"),
                    CustomerAadhaar = t.Field<string>("CustomerAadhaarNumber"),
                    CustomerPan = t.Field<string>("CustomerPanNumber"),
                    DOB = t.Field<DateTime>("DOB"),
                    CustomerGender = t.Field<string>("CustomerGender")

                }).ToList();

            return customers;




        }

        public List<AccountDataContract> GetAllAccounts()
        {
            //create factory
            DbProviderFactory factory = DbProviderFactories.GetFactory(
                System.Configuration.ConfigurationManager.ConnectionStrings
                ["PecuniaConnectionString"].ProviderName);

            //create connection
            DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings
                ["PecuniaConnectionString"].ConnectionString;

            //create command
            DbCommand command = connection.CreateCommand();
            command.CommandText = "";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            //create adapter
            DbDataAdapter adapter = factory.CreateDataAdapter();
            adapter.SelectCommand = command;

            //create dataset
            DataSet ds = new DataSet();

            //Execute
            adapter.Fill(ds);

            //Convert datatable to collection
            List<AccountDataContract> accounts = ds.Tables[0].AsEnumerable()
                .Select(t => new AccountDataContract()
                {
                    CustomerID = t.Field<Guid>("CustomerID"),
                    AccountType = t.Field<string>("AccountType"),
                    HomeBranch = t.Field<string>("HomeBranch"),
                    AccountNumber = t.Field<long>("AccountNumber"),
                    IsActive = t.Field<bool>("IsActive"),
                    AccountBalance = t.Field<decimal>("AccountBalance"),

                }).ToList();

            return accounts;

        }

        public List<CarLoanDataContract> ListAllLoansBL()
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory(
                System.Configuration.ConfigurationManager.ConnectionStrings["PecuniaConnectionString"].ProviderName
                );

            DbConnection conn = factory.CreateConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PecuniaConnectionString"].ConnectionString;

            DbCommand comm = conn.CreateCommand();
            comm.CommandText = "select * from TeamF.CarLoan";
            comm.Connection = conn;
            comm.CommandType = System.Data.CommandType.Text;


            DbDataAdapter adapter = factory.CreateDataAdapter();
            adapter.SelectCommand = comm;

            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);

            List<CarLoanDataContract> carLoans = dataSet.Tables[0]
                .AsEnumerable()
                .Select(t => new CarLoanDataContract()
                {
                    LoanID = t.Field<Guid>("LoanID"),
                    CustomerID = t.Field<Guid>("CustomerID"),
                    AmountApplied = t.Field<decimal>("AmountApplied"),
                    InterestRate = t.Field<decimal>("InterestRate"),
                    EMI_Amount = t.Field<decimal>("EMI_Amount"),
                    RepaymentPeriod = t.Field<byte>("RepaymentPeriod"),
                    DateOfApplication = t.Field<DateTime>("DateTime"),
                    Status = t.Field<string>("LoanStatus"),
                    Occupation = t.Field<string>("Occupation"),
                    GrossIncome = t.Field<decimal>("GrossIncome"),
                    SalaryDeductions = t.Field<decimal>("SalaryDeduction"),
                    Vehicle = t.Field<string>("VehicleType")
                }
                ).ToList();


            return carLoans;
        }
    }
}
   
