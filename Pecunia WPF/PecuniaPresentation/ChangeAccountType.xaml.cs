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
using Capgemini.Pecunia.BusinessLayer;
using Capgemini.Pecunia.Entities;
using Capgemini.Pecunia.Exceptions;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for ChangeAccountType.xaml
    /// </summary>
    public partial class ChangeAccountType : Window
    {
        public ChangeAccountType()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Guid accountID = new Guid();
            Guid.TryParse(txtAccountID.Text, out accountID);

            string accountType = txtAccountType.Text;
            AccountBL accountBL = new AccountBL();
            try
            {
                if (await accountBL.ChangeAccountTypeBL(accountID, accountType))

                {
                    MessageBox.Show("Account Type CHanged");
                  
                }
                else
                {
                    MessageBox.Show("Error while changing Account");
                  
                }
            }
            catch (AccountDoesNotExistException ae)
            {

                Console.WriteLine(ae.Message);
            }
        }

        private void txtAccountType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
