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
    /// Interaction logic for AddOption.xaml
    /// </summary>
    public partial class AddOption : Window
    {
        public AddOption()
        {
            InitializeComponent();
        }
        private void txtCurrentADD_Click(object sender, RoutedEventArgs e)
        {
            var temp = new AddCurrentSavings();
            temp.Show();
            this.Close();
        }

        private void txtFDADD_Click(object sender, RoutedEventArgs e)
        {
            var temp = new AddFixedDeposit();
            temp.Show();
            this.Close();
        }
    }
}
