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
    /// Interaction logic for DeleteOption.xaml
    /// </summary>
    public partial class DeleteOption : Window
    {
        public DeleteOption()
        {
            InitializeComponent();
        }
        private void txtDeleteCurrent_Click(object sender, RoutedEventArgs e)
        {
            var temp = new DeleteAccount();
            temp.Show();
            this.Close();
        }

        private void txtDeleteFD_Click(object sender, RoutedEventArgs e)
        {
            var temp = new DeleteFixedDepositxaml();
            temp.Show();
            this.Close();
        }
    }
}
