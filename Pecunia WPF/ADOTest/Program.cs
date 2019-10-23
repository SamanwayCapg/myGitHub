using Capgemini.Pecunia.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capgemini.Pecunia.Entities;
using System.Data;
using Capgemini.Pecunia.Exceptions;

namespace Capgemini.Pecunia.ADOTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //SqlConnection conn = SQLServerUtil.getConnection(Properties.Settings.Default.Setting);
            List<Employee> employeesList = new List<Employee>();
            try
            {
                Employee employee = new Employee();

                employee.EmployeeID = Guid.NewGuid();
                employee.EmployeeName = "vdwcdc";
                employee.Email = "ckeegl@ljdshflf.com";
                employee.Password = "dcdgWsvk123#";
                employee.Mobile = "9846557567";


                SqlCommand sqlCommand = new SqlCommand("[13th Aug CLoud PT Immersive].TeamF.AddEmployees", conn);
                SqlParameter p1 = new SqlParameter("@empid", employee.EmployeeID);
                p1.DbType = DbType.Guid;
                SqlParameter p2 = new SqlParameter("@empname", employee.EmployeeName);
                SqlParameter p3 = new SqlParameter("@empemail", employee.Email);
                SqlParameter p4 = new SqlParameter("@emppassword", employee.Password);
                SqlParameter p5 = new SqlParameter("@empmobile", employee.Mobile);


                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                sqlParameters.Add(p1);
                sqlParameters.Add(p2);
                sqlParameters.Add(p3);
                sqlParameters.Add(p4);
                sqlParameters.Add(p5);
                sqlCommand.Parameters.AddRange(sqlParameters.ToArray());

                sqlCommand.CommandType = CommandType.StoredProcedure;
                conn.Open();
                sqlCommand.ExecuteNonQuery();
                


                SqlCommand sqlCommand1 = new SqlCommand("[13th Aug CLoud PT Immersive].TeamF.GetAllEmployees", conn);
                sqlCommand1.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCommand1;

                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                DataRow dataRow;
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    dataRow = dataSet.Tables[0].Rows[i];
                    Employee employee1 = new Employee();

                    employee1.EmployeeID = (Guid)dataRow["EmployeeID"];
                    employee1.EmployeeName = (string)dataRow["EmployeeName"];
                    employee1.Email = (string)dataRow["EmployeeEmail"];
                    employee1.Mobile = (string)dataRow["Mobile"];
                    employee1.CreationDateTime = (DateTime)dataRow["CreationDateTime"];
                    employee1.LastModifiedDateTime = (DateTime)dataRow["LastModifiedDateTime"];


                    employeesList.Add(employee1);
                }
                sqlCommand1.ExecuteNonQuery();
                conn.Close();
                foreach(Employee e in employeesList)
                    Console.WriteLine(e);
                Console.WriteLine("Employee added");
                    Console.ReadKey();
            }
            catch (PecuniaException)
            {

                throw new EmployeeListException("Employee List cannot be displayed.");
            }
        }
    }
}
