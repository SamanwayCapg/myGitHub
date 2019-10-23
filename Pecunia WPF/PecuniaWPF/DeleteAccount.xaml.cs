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

namespace PecuniaWPF
{
    /// <summary>
    /// Interaction logic for DeleteAccount.xaml
    /// </summary>
    public partial class DeleteAccount : Window
    {
        public DeleteAccount()
        {
            InitializeComponent();
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            Guid accountID = new Guid();
            Guid.TryParse(txtDeleteAccountID.Text, out accountID);
            string feedback = txtFeedback.Text;
            AccountBL accountBL = new AccountBL();
            try
            {
                if (await accountBL.DeleteAccount(accountID, feedback))
                {
                    MessageBox.Show("Account Deleted Successfully");


                }
                else
                {
                    Console.WriteLine("Error while Deleting Account");


                }
            }
            catch (AccountDoesNotExistException f)
            {

                Console.WriteLine(f.Message);
            }
        }

        private void txtDeleteAccountID_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
