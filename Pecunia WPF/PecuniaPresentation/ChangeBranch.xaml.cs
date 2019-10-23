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
    /// Interaction logic for ChangeBranch.xaml
    /// </summary>
    public partial class ChangeBranch : Window
    {
        public ChangeBranch()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Account account = new Account();
            account.HomeBranch = txtAccountBranch.Text;

            Guid accountID = new Guid();
            Guid.TryParse(txtAccountID.Text, out accountID);

            string homebranch = txtAccountBranch.Text;
            AccountBL accountBL = new AccountBL();
            try
            {
                if (await accountBL.ChangeBranchBL(accountID, homebranch))

                {
                    MessageBox.Show("Branch CHanged");
                   
                }
                else
                {
                    MessageBox.Show("Error while changing Branch");
                 
                }
            }
            catch (AccountDoesNotExistException ae)
            {

                Console.WriteLine(ae.Message);
            }
        }

        private void txtDeleteAccountID_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
