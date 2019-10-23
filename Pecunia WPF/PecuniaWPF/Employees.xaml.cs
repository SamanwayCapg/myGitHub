/*
 DEVELOPED BY : AISHWARYA SARNA
 EMPLOYEE ID : 46000496
 EMPLOYEE -- HANDLED BY ADMIN 
 
 */



using Capgemini.Pecunia.BusinessLayer;
using Capgemini.Pecunia.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PecuniaWPF
{
    /// <summary>
    /// Interaction logic for Employees.xaml
    /// </summary>
    public partial class Employees : Window
    {
       
      
        public Employees()
        {
            InitializeComponent();
        }

        //load data 
        private async void loadData()
        {
            List<Employee> employeeList = new List<Employee>();
            try
            {
                using (EmployeeBL employeeBL = new EmployeeBL())
                {
                    employeeList = await employeeBL.GetAllEmployeesBL();
                    if (employeeList.Count > 0)
                    {
                        employeesGrid.ItemsSource = employeeList;
                      
                    }
                }
            }
            catch (Exception ex)
            {              
                MessageBox.Show(ex.Message);
            }
        }

        //load data when window opens
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                loadData();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //add employee
        private async void Add_Employee_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Employee employee = new Employee();

                employee.EmployeeName = employeeName.Text;
                employee.Email = email.Text;
                employee.Password = employeePassword.Text;
                employee.Mobile = mobile.Text;

                using (EmployeeBL employeeBL = new EmployeeBL())
                {
                    bool isAdded = await employeeBL.AddEmployeeBL(employee);
                    if (isAdded)
                    {
                        MessageBox.Show($"Employee {employee.EmployeeName} added");
                        loadData();
                    }
                }
            }
            catch (Exception ex)
            {              
                MessageBox.Show(ex.Message);
            }
        }


        //back to admin-home window
        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var adminHome = new Window1();
                adminHome.Show();
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        //delete employee
        private async void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                 Employee employee = new Employee();

                employee.EmployeeID = Guid.Parse(employeeID.Text);

                using (EmployeeBL employeeBL = new EmployeeBL())
                {
                    bool isDeleted = await employeeBL.DeleteEmployeeBL(employee.EmployeeID);
                    if (isDeleted)
                    {
                        MessageBox.Show($"Employee {employee.EmployeeName} removed");
                        loadData();
                    }
                }
            }
            catch (Exception ex)
            {               
                MessageBox.Show(ex.Message);
            }
        }

       

            //select employee
        private void EmployeesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int rowIndex = employeesGrid.SelectedIndex;
            if (rowIndex < 0)
                return;
            employeeID.Text = getCellData(employeesGrid, rowIndex, 0);
            employeeName.Text = getCellData(employeesGrid, rowIndex, 1);
            email.Text = getCellData(employeesGrid, rowIndex, 2);
            mobile.Text = getCellData(employeesGrid, rowIndex, 4);
        }

        private string getCellData(DataGrid dataGrid, int rowIndex, int cellIndex)
        {
            DataGridRow dataGridRow = employeesGrid.ItemContainerGenerator.ContainerFromIndex(rowIndex) as DataGridRow;
            var CellContent = employeesGrid.Columns[cellIndex].GetCellContent(dataGridRow) as TextBlock;
            return CellContent.Text;
        }

        private void Refresh_Button_Click(object sender, RoutedEventArgs e)
        {
            employeeID.Text = "";
            employeeName.Text = "";
            email.Text = "";
            mobile.Text = "";
        }
    }
}
