using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeNamespace;

namespace EmployeeServiceNamespace
{
    interface IEmployeeService
    {
        List<Employee> Employees { get; set; } //property

        void AddEmployee();
        List<Employee> GetEmployees();
        Employee GetEmployeeByNameandPassword(string name, string password);
        Employee GetEmployeeByEmail(string email);
    }

    [Serializable]
    public class EmployeeService
    {
        //field
        private List<Employee> _employees;


        //property
        public List<Employee> Employees
        {
            set
            {
                _employees = new List<Employee>();
            }
            get
            {
                return _employees;
            }
        }

        public List<Employee> GetEmployees()
        {
            List<Employee> SortedList = Employees.OrderBy(o => o.EmployeeName).ToList();
            return SortedList;
        }

        public void AddEmployee(string name, string code, string email, string password, string mobile)
        {
            string filePath = @"C:\Pecunia\CountID";
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string content = sr.ReadToEnd();
            string num = content.Substring(8);
            long count = long.Parse(num);

            Employee employee = new Employee()
            {
                EmployeeName = name,
                EmployeeCode = code,
                EmployeeEmail = email,
                EmployeePassword = password,
                EmployeeMobile = mobile
            };
            employee.EmployeeID = count + 1;
            count++;
            string _newcontent = count.ToString();
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(_newcontent);

            Employees.Add(employee);
        }
    }
}
