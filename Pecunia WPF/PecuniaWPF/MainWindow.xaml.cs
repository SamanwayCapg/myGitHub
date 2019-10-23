/*
 DEVELOPED BY : AISHWARYA SARNA
 EMPLOYEE ID : 46000496
 MAIN WINDOW - LOGIN 
 
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PecuniaWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Admin admin = new Admin();
        AdminBL adminBL = new AdminBL();
        Employee employee = new Employee();
        EmployeeBL employeeBL = new EmployeeBL();


        //Login as admin
        private async void Admin_Login(object sender, RoutedEventArgs e)
        {
            try
            {
                admin = await adminBL.GetAdminByEmailAndPasswordBL(txtEmail.Text, txtPassword.Text);
                if (admin == default(Admin))
                    MessageBox.Show("Incorrect Email or Password");
                else
                {
                    Common.CurrentUserID = admin.AdminID;
                    var adminHome = new Window1();   //admin-home window
                    adminHome.Show();
                    this.Close();
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
                   
        }


        //login as employee
        private async void Employee_Login(object sender, RoutedEventArgs e)
        {
            try
            {
                employee = await employeeBL.GetEmployeeByEmailAndPasswordBL(txtEmail.Text, txtPassword.Text);
                if (employee == default(Employee))
                    MessageBox.Show("Incorrect Email or Password");
                else
                {
                    Common.CurrentUserID = employee.EmployeeID;
                    var employeeHome = new Window2();  //employee-home window
                    employeeHome.Show();
                    this.Close();
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message); 
            }
                        
        }

        
    }
}
