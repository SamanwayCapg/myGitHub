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
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class AddCustomer : Window
    {
        public AddCustomer()
        {
            InitializeComponent();
        }

        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {

            Customer customer = new Customer();
            CustomerBL customerBL = new CustomerBL();
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

            bool isAdded = await customerBL.AddCustomerBL(customer);

            if (isAdded == true)
                MessageBox.Show("Customer is addded");
            else
                MessageBox.Show("Customer is not added");

            var back = new MainWindow();
            back.Show();
            this.Close();

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var back = new MainWindow();
            back.Show();
            this.Close();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
