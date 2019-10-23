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
    /// Interaction logic for UpdateFixedDeposit.xaml
    /// </summary>
    public partial class UpdateFixedDeposit : Window
    {
        public UpdateFixedDeposit()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var temp = new ChangeFDBranch();
            temp.Show();
            this.Close();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            var temp = new ChangeInitialAmount();
            temp.Show();
            this.Close();
        }
    }
}
