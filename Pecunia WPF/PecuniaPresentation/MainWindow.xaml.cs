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
using Capgemini.Pecunia.BusinessLayer;
using Capgemini.Pecunia.Entities;
using Capgemini.Pecunia.Exceptions;

namespace PecuniaPresentation
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

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Account account = new Account();
            Guid customerID = new Guid();
            string accountType = txtAccountType.Text;
            bool IsGuid = Guid.TryParse(txtCustomerID.Text, out customerID);
            if (IsGuid == false)
            {
                MessageBox.Show("Invalid Guid");
            }
            account.HomeBranch = txtAccountBranch.Text;

            AccountBL accountBL = new AccountBL();

            if (await accountBL.AddAccountBL(account, customerID, accountType))
            {
                string Accid = account.AccountID.ToString();

                MessageBox.Show("Account Added Successfully\n", Accid);
            }
            else

            {
                MessageBox.Show("Account Addition Failed");
            }


        }

        private void txtAccountType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
