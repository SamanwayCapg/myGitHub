using Capgemini.Pecunia.BusinessLayer;
using Capgemini.Pecunia.Entities;
using Capgemini.Pecunia.Helper;
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
    /// Interaction logic for CustomerUpdate.xaml
    /// </summary>
    public partial class CustomerUpdate : Window
    {
        public CustomerUpdate()
        {
            InitializeComponent();
            CustomerBL customerBL = new CustomerBL();
            List<Customer> customers = customerBL.GetAllCustomerDetailsBL();
            datagrid.ItemsSource = customers;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            CustomerBL customerBL = new CustomerBL();
            Customer customer = new Customer();
            Guid customerID;
            Guid.TryParse(txtboxCustomerID.Text, out customerID);

            customer = await customerBL.GetCustomerByCustomerIDBL(customerID);
            if (customer == default(Customer))
                MessageBox.Show("invalid id");
            else
            {
                List<Customer> customerlist = new List<Customer>();
                customerlist.Add(customer);
                datagrid.ItemsSource = customerlist;
            }
        }

        private async void TxtUpdate_Click(object sender, RoutedEventArgs e)
        {
            CustomerBL customerBL = new CustomerBL();
            Customer customer = new Customer();
            Guid customerID;
            Guid.TryParse(txtboxCustomerID.Text, out customerID);
            customer.CustomerID = customerID;
            customer.CustomerName = txtName.Text;
            customer.CustomerAddress = txtAddress.Text;
            customer.CustomerMobile = txtMobile.Text;
            customer.CustomerEmail = txtEmail.Text;
            customer.CustomerPan = txtPAN.Text;
            customer.CustomerAadhaarNumber = txtAadhaar.Text;
            customer.DOB = txtDOB.Text;
            Gender gender;
            Enum.TryParse(cmbGender.Text, out gender);
            customer.CustomGender = gender;

            bool isUpdated = await customerBL.UpdateCustomerByCustomerIDBL(customer);
            if (isUpdated == true)
                MessageBox.Show("Customer is Updated");
            else
                MessageBox.Show("Customer not updated");

            var back = new MainWindow();
            back.Show();
            this.Close();
        }

        private void Datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TxtboxCustomerID_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TxtAddress_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TxtMobile_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TxtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TxtPAN_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TxtAadhaar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var back = new MainWindow();
            back.Show();
            this.Close();
        }

    }
}
