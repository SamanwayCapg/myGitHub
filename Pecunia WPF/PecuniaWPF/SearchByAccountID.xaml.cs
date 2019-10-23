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
    /// Interaction logic for SearchByAccountID.xaml
    /// </summary>
    public partial class SearchByAccountID : Window
    {
        public SearchByAccountID()
        {
            InitializeComponent();
        }
        private async void TxtGetAccount_Click(object sender, RoutedEventArgs e)
        {
            Account account = new Account();
            Guid acc = new Guid();
            bool IsValid = Guid.TryParse(txtAccountID.Text, out acc);
            account.AccountID = acc;
            if (IsValid == false)
            {
                MessageBox.Show("Invalid guid");
            }
            AccountBL accountBL = new AccountBL();
            try
            {
                account = await accountBL.GetAccountByAccountIDBL(account.AccountID);


            }
            catch (CustomerDoesNotExistException c)
            {
                MessageBox.Show(c.Message);



            }
            List<Account> accountList = new List<Account>();
            accountList.Add(account);


            txtDataGrid.ItemsSource = accountList;


        }
    }
}
