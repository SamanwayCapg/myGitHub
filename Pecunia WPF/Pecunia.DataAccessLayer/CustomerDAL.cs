using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;
using Capgemini.Pecunia.Exceptions;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Capgemini.Pecunia.Helper;
using Newtonsoft.Json;
using Capgemini.Pecunia.Contracts.DALContracts;
using Capgemini.Pecunia.Entities;
using System.Data.SqlClient;
using System.Data;
using Capgemini.Pecunia.Helpers;
using Capgemini.Pecunia.Helpers;

namespace Capgemini.Pecunia.DataAccessLayer
{

    public class CustomerDAL : CustomerDALBase, IDisposable
    {
        public static List<Customer> CustomersList = new List<Customer>(); // list of customers is created by passing CustomerEntities class as data type 

        //Adding Customer
        public override bool AddCustomerDAL(Customer customer)
        {
            bool customerAdded = false;

            //////string customerID = "CUST" + custID.ToString();
            ////try
            ////{
            ////    List<Customer> customers = DeserializeFromJSON("Customerdata.txt");
            ////    customers.Add(customer);  //Customer is added in the list        
            ////    return SerialiazeIntoJSON(customers, "Customerdata.txt");
            ////}@CustomerPan char(10),@CustomerAadhaarNumber char(12),@DOB datetime,@CustomerGender varchar(12)) 

            ////catch 
            ////{
            ////    return false;
            ////}

            //Create Connection

            SqlConnection conn = SQLServerUtil.getConnetion("ndamssql\\sqlilearn", "13th Aug CLoud PT Immersive", "sqluser", "sqluser");
            try
            {

                //Create Command
                SqlCommand cmd = new SqlCommand("TeamF.AddCustomerDAL", conn);


                // 1.CustomerID Generation
                Guid CustomerID = Guid.NewGuid();
                Console.WriteLine(CustomerID);

                SqlParameter param1 = new SqlParameter("@CustomerID", customer.CustomerID);
                param1.SqlDbType = SqlDbType.UniqueIdentifier;

                //2. Passing CustomerName
                SqlParameter param2 = new SqlParameter("@CustomerName", customer.CustomerName);
                param2.SqlDbType = SqlDbType.VarChar;

                //3.Passing CustomerAddress
                SqlParameter param3 = new SqlParameter("@CustomerAddress", customer.CustomerAddress);
                param3.SqlDbType = SqlDbType.VarChar;

                //4.Passing CustomerMobile
                SqlParameter param4 = new SqlParameter("@CustomerMobile", customer.CustomerMobile);
                param4.SqlDbType = SqlDbType.Char;

                //4.Passing CustomerMobile
                SqlParameter param5 = new SqlParameter("@CustomerEmail", customer.CustomerMobile);
                param5.SqlDbType = SqlDbType.VarChar;

                //5.Passing CustomerPan
                SqlParameter param6 = new SqlParameter("@CustomerPan", customer.CustomerPan);
                param5.SqlDbType = SqlDbType.Char;

                //6.Passing CustomerAadhaar
                SqlParameter param7 = new SqlParameter("@CustomerAadhaarNumber", customer.CustomerAadhaarNumber);
                param5.SqlDbType = SqlDbType.Char;

                //7.Passing DateOfBirth
                SqlParameter param8 = new SqlParameter("@DOB", customer.DOB);
                param8.SqlDbType = SqlDbType.DateTime;

                //8Passing CustomerGender
                SqlParameter param9 = new SqlParameter("@CustomerGender", customer.CustomGender);
                param9.SqlDbType = SqlDbType.VarChar;

                List<SqlParameter> Params = new List<SqlParameter>();
                Params.Add(param1);
                Params.Add(param2);
                Params.Add(param3);
                Params.Add(param4);
                Params.Add(param5);
                Params.Add(param6);
                Params.Add(param7);
                Params.Add(param8);
                Params.Add(param9);

                cmd.Parameters.AddRange(Params.ToArray());
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                Console.WriteLine("connected to the database");
                cmd.ExecuteNonQuery();
                conn.Close();
                customerAdded = true;

            }
            catch (Exception e)
            {
                // Console.WriteLine(e.Message);

            }


            return customerAdded;

        }

        public override bool RemoveCustomerDAL(Guid CustomerID)
        {
            /*try
            {
                List<Customer> customerlist = DeserializeFromJSON("Customerdata.txt");// deserialize because we have to search list

                foreach (Customer cust in customerlist)  //foreach(dataType variable in collectionName)
                {
                    if (cust.CustomerID == CustomerID)
                    {
                        customerlist.Remove(cust);
                        SerialiazeIntoJSON(customerlist, "Customerdata.txt");// we serialize because in our original database we have to make the above changes
                        break;
                    }
                }
                return true;
            }
            catch (Exception )
            {
                return false;
            }*/
            bool isDeleted = false;
            try
            {
                SqlConnection conn = SQLServerUtil.getConnetion("ndamssql\\sqlilearn", "13th Aug CLoud PT Immersive", "sqluser", "sqluser");
                //create SqlCommand object
                SqlCommand sqlCommand = new SqlCommand("delete from Team_D.RawMaterial where RawMaterialID  = @rawmaterialid", conn);

                //add parameters
                sqlCommand.Parameters.AddWithValue("@CustomerID", CustomerID);
                sqlCommand.CommandType = CommandType.Text;

                //open connection
                conn.Open();
                //execute query
                sqlCommand.ExecuteNonQuery();
                //close connection

                conn.Close();

                isDeleted = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return isDeleted;
        }


        public override Customer GetCustomerByCustomerIDDAL(Guid CustomerID)
        {
            bool validate = false;



            Customer customer = new Customer();
            //System.Configuration.ConfigurationSettings.AppSettings["con"];
            SqlConnection conn = SQLServerUtil.getConnetion("ndamssql\\sqlilearn", "13th Aug CLoud PT Immersive", "sqluser", "sqluser");
            try
            {

                //sql command
                SqlCommand sqlCommand = new SqlCommand("select * from TeamF.Customers where CustomerID = @CustomerID", conn);
                sqlCommand.Parameters.AddWithValue("@CustomerID", CustomerID);
                sqlCommand.CommandType = CommandType.Text;

                //create SqlDataAdapter object
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCommand;

                //create DataSet object
                DataSet dtSet = new DataSet();
                sqlDataAdapter.Fill(dtSet);

                //create DataRow object
                DataRow drow;
                //if (dtSet.Tables[0].Rows.Count > 0)
                if (dtSet.Tables[0].Rows.Count > 0)
                {
                    drow = dtSet.Tables[0].Rows[0];

                    customer.CustomerID = (Guid)drow["CustomerID"];
                    customer.CustomerName = (string)drow["CustomerName"];
                    customer.CustomerAddress = (string)drow["CustomerAddress"];
                    customer.CustomerMobile = (string)drow["CustomerMobile"];
                    customer.CustomerEmail = (string)drow["CustomerEmail"];
                    customer.CustomerPan = (string)drow["CustomerPan"];
                    customer.CustomerAadhaarNumber = (string)drow["CustomerAadhaarNumber"];
                    customer.DOB = Convert.ToString(drow["DOB"]);
                    Gender gender;
                    Enum.TryParse(Convert.ToString(drow["CustomerGender"]), out gender);
                    validate = true;
                }
                else
                {
                    return default(Customer);
                }
            }
            catch (Exception e)
            {
                /*Console.WriteLine(e.Message)*/
                return default(Customer);
            }
            return customer;
        }

        public override List<Customer> GetAllCustomersDAL()

        {
            /*
            List<Customer> custlist = DeserializeFromJSON("Customerdata.txt");
            return custlist;*/
            List<Customer> customers = new List<Customer>(); try
            {
                SqlConnection conn = SQLServerUtil.getConnetion("ndamssql\\sqlilearn", "13th Aug CLoud PT Immersive", "sqluser", "sqluser");

                //Create SqlCommand object
                SqlCommand sqlCommand = new SqlCommand("select * from TeamF.Customers", conn);
                sqlCommand.CommandType = CommandType.Text;

                //create SqlDataAdapter object
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCommand;

                //create DataSet object
                DataSet dtSet = new DataSet();
                sqlDataAdapter.Fill(dtSet);

                //create DataRow object
                DataRow drow;
                for (int i = 0; i < dtSet.Tables[0].Rows.Count; i++)
                {
                    //Add values in customer object and add to list
                    drow = dtSet.Tables[0].Rows[i];
                    Customer customer = new Customer();
                    customer.CustomerID = (Guid)drow["CustomerID"];
                    customer.CustomerName = (string)drow["CustomerName"];
                    customer.CustomerAddress = (string)drow["CustomerAddress"];
                    customer.CustomerMobile = (string)drow["CustomerMobile"];
                    customer.CustomerEmail = (string)drow["CustomerEmail"];
                    customer.CustomerPan = (string)drow["CustomerPan"];
                    customer.CustomerAadhaarNumber = (string)drow["CustomerAadhaarNumber"];
                    customer.DOB = Convert.ToString(drow["DOB"]);
                    Gender gender;
                    Enum.TryParse(Convert.ToString(drow["CustomerGender"]), out gender);
                    customer.CustomGender = gender;
                    customers.Add(customer);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }

            return customers;
        }


        public override bool UpdateCustomerByCustomerIDDAL(Customer customer)
        {

            bool customerUpdated = false;

            SqlConnection conn = SQLServerUtil.getConnetion("ndamssql\\sqlilearn", "13th Aug CLoud PT Immersive", "sqluser", "sqluser");
            try
            {


                SqlCommand cmd = new SqlCommand("TeamF.UpdateCustomerByCustomerIDDAL", conn);
                conn.Open();
                Console.WriteLine("connected to database");



                SqlParameter param0 = new SqlParameter("@CustomerID", customer.CustomerID);
                param0.SqlDbType = SqlDbType.UniqueIdentifier;


                //1. Passing CustomerName
                SqlParameter param1 = new SqlParameter("@CustomerName", customer.CustomerName);
                param1.SqlDbType = SqlDbType.VarChar;

                //2.Passing CustomerAddress
                SqlParameter param2 = new SqlParameter("@CustomerAddress", customer.CustomerAddress);
                param2.SqlDbType = SqlDbType.VarChar;

                //3.Passing CustomerMobile
                SqlParameter param3 = new SqlParameter("@CustomerMobile", customer.CustomerMobile);
                param3.SqlDbType = SqlDbType.Char;

                //4.Passing CustomerMobile
                SqlParameter param4 = new SqlParameter("@CustomerEmail", customer.CustomerEmail);
                param4.SqlDbType = SqlDbType.VarChar;

                //5.Passing CustomerPan
                SqlParameter param5 = new SqlParameter("@CustomerPan", customer.CustomerPan);
                param5.SqlDbType = SqlDbType.Char;

                //6.Passing CustomerAadhaar
                SqlParameter param6 = new SqlParameter("@CustomerAadhaarNumber", customer.CustomerAadhaarNumber);
                param6.SqlDbType = SqlDbType.Char;

                //7.Passing DateOfBirth
                SqlParameter param7 = new SqlParameter("@DOB", customer.DOB);
                param7.SqlDbType = SqlDbType.DateTime;

                //8Passing CustomerGender
                SqlParameter param8 = new SqlParameter("@CustomerGender", customer.CustomGender);
                param8.SqlDbType = SqlDbType.VarChar;

                List<SqlParameter> Params = new List<SqlParameter>();
                Params.Add(param0);
                Params.Add(param1);
                Params.Add(param2);
                Params.Add(param3);
                Params.Add(param4);
                Params.Add(param5);
                Params.Add(param6);
                Params.Add(param7);
                Params.Add(param8);


                cmd.Parameters.AddRange(Params.ToArray());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                conn.Close();
                customerUpdated = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return customerUpdated;
            }
            return customerUpdated;
        }


        public override bool isCustomerIDExistDAL(Guid customerID)
        {
            List<Customer> customers = DeserializeFromJSON("Customerdata.txt");
            foreach (var cust in customers)
            {
                if (cust.CustomerID == customerID)
                    return true;
            }
            return false;
        }


        public override bool SerialiazeIntoJSON(List<Customer> CustomersList, string FileName)
        {
            try
            {
                JsonSerializer serializer = new JsonSerializer();
                using (StreamWriter sw = new StreamWriter(FileName))   //filename is used so that we can have access over our own file
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, CustomersList); // Serialize customers in customer.json
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override List<Customer> DeserializeFromJSON(string FileName)
        {
            List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(File.ReadAllText(FileName));// Done to read data from file
            using (StreamReader file = File.OpenText(FileName))
            {
                JsonSerializer serializer = new JsonSerializer();
                List<Customer> customers1 = (List<Customer>)serializer.Deserialize(file, typeof(List<Customer>));
                return customers1;
            }


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