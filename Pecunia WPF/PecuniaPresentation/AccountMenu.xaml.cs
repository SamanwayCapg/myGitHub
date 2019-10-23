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

namespace PecuniaPresentation
{
    /// <summary>
    /// Interaction logic for AccountMenu.xaml
    /// </summary>
    public partial class AccountMenu : Window
    {
        public AccountMenu()
        {
            InitializeComponent();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtUpdateAccount_Click(object sender, RoutedEventArgs e)
        {
            var temp = new UpdateOption();
            temp.Show();
            this.Close();
        }

        private void txtDeleteAccount_Click(object sender, RoutedEventArgs e)
        {
            var temp = new DeleteOption();
            temp.Show();
            this.Close();
        }

        private void txtAddAccount_Click(object sender, RoutedEventArgs e)
        {
            var temp = new AddOption();
            temp.Show();
            this.Close();
        }

        private void TxtSearchAccount_Click(object sender, RoutedEventArgs e)
        {
            {
                var temp = new SearchOption();
                temp.Show();
                this.Close();
            }
        }
    }

   
}
