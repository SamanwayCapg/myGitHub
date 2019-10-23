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
    /// Interaction logic for CustomerMain.xaml
    /// </summary>
    public partial class CustomerMain : Window
    {
        Customer customer = new Customer();
        List<Customer> customerList = new List<Customer>();

        CustomerBL customerBL = new CustomerBL();


        public CustomerMain()
        {
            InitializeComponent();
            customerList = customerBL.GetAllCustomerDetailsBL();
            txtData.ItemsSource = customerList;

        }



        private void AddCustomer(object sender, RoutedEventArgs e)
        {
            var add = new AddCustomer();
            add.Show();
            this.Close();




        }

        private void UpdateCustomer(object sender, RoutedEventArgs e)
        {
            //Window update = new Window2();
            //this.Visibility = Visibility.Collapsed;
            //update.ShowDialog();
            //this.Visibility = Visibility.Visible;

            var update = new CustomerUpdate();
            update.Show();
            this.Close();


        }


        private void GetCustomerByCustomerID(object sender, RoutedEventArgs e)
        {

        }

        private async void SearchCustomer(object sender, RoutedEventArgs e)
        {
            CustomerBL customerBL = new CustomerBL();
            Guid customerID;
            Guid.TryParse(txtCustomerID.Text, out customerID);
            Customer customer = new Customer();

            customer = await customerBL.GetCustomerByCustomerIDBL(customerID);
            if (customer == default(Customer))
                MessageBox.Show("invalid id");
            else
            {
                List<Customer> customerList = new List<Customer>();
                customerList.Add(customer);
                txtData.ItemsSource = customerList;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void TxtData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var backWindow = new Window2();
            backWindow.Show();
            this.Close();
        }
    }
}
