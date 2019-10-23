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

namespace PecuniaPresentation
{
    /// <summary>
    /// Interaction logic for SearchCurrentSavings.xaml
    /// </summary>
    public partial class SearchCurrentSavings : Window
    {
        public SearchCurrentSavings()
        {
            InitializeComponent();
        }

        private void TxtGetAllResults_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Account> accountList = new List<Account>();
                AccountBL accountBL = new AccountBL();
                accountList = accountBL.GetAllAccountsBL();
                txtDataGrid.ItemsSource = accountList;
            }
            catch(Exception f)
            {
                Console.WriteLine(f.Message);
                Console.WriteLine(f.StackTrace);
            }
         
        }

        private void TxtSearchByAccountID_Click(object sender, RoutedEventArgs e)
        {
            var temp = new SearchByAccountID();
            temp.Show();
            this.Close();
        }
    }
}
