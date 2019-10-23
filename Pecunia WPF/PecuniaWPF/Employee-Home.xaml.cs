/*
 DEVELOPED BY : AISHWARYA SARNA
 EMPLOYEE ID : 46000496
 EMPLOYEE-HOME WINDOW
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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }
        Employee employee = new Employee();
        EmployeeBL employeeBL = new EmployeeBL();
        private void LogOut_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void loadData()
        {
           
            employeeID.Text = employee.EmployeeID.ToString();
            employeeName.Text = employee.EmployeeName;
            employeeEmail.Text = employee.Email;
            employeeMobile.Text = employee.Mobile;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            employee = await employeeBL.GetEmployeeByEmployeeIDBL(Common.CurrentUserID);
            employeeID.Text = employee.EmployeeID.ToString();
            employeeName.Text = employee.EmployeeName;
            employeeEmail.Text = employee.Email;
            employeeMobile.Text = employee.Mobile;
        }

        private void CmbEmployeeMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbEmployeeMenu.SelectedIndex == 0)
            {
                var accountWindow = new CustomerMain();
                accountWindow.Show();
                this.Close();
            }
            if (cmbEmployeeMenu.SelectedIndex == 1)
            {
                var accountWindow = new AccountMenu();
                accountWindow.Show();
                this.Close();
            }
            if (cmbEmployeeMenu.SelectedIndex == 2)
            {
                var loanMainWindow = new LoanMainWindow();
                loanMainWindow.Show();
                this.Close();
            }
            if (cmbEmployeeMenu.SelectedIndex == 3)
            {
                
                var transMainWindow = new TransactionWindow();
                transMainWindow.Show();
                this.Close();
            }

        }

        private async void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                employee.EmployeeID = Guid.Parse(employeeID.Text);
                employee.EmployeeName = employeeName.Text;
                employee.Email = employeeEmail.Text;
                employee.Mobile = employeeMobile.Text;
                bool update = await employeeBL.UpdateEmployeeBL(employee);
                if (update)
                    MessageBox.Show("Your Details are updated");
                loadData();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
