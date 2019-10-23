using Capgemini.Pecunia.BusinessLayer;
using Capgemini.Pecunia.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        
        Admin admin = new Admin();
        AdminBL adminBL = new AdminBL();

        public Window1()
        {
            InitializeComponent();
        }

        private void loadData()
        {
            adminID.Text = admin.AdminID.ToString();
            adminName.Text = admin.AdminName;
            adminEmail.Text = admin.Email;
           
        }

            private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                admin = await adminBL.GetAdminByAdminIDBL(Common.CurrentUserID);
                adminID.Text = admin.AdminID.ToString();
                adminName.Text = admin.AdminName;
                adminEmail.Text = admin.Email;
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
              
            }          
        }

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

        private void Customer_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        

        private void cmbAdminMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            if(cmbAdminMenu.SelectedIndex == 1)
            {

                var employees = new Employees();
                employees.Show();
                this.Close();
            }
        }

        private async void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                admin.AdminID = Guid.Parse(adminID.Text);
                admin.AdminName = adminName.Text;
                admin.Email = adminEmail.Text;              
                bool update = await adminBL.UpdateAdminBL(admin);             
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
