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
    /// Interaction logic for UpdateOption.xaml
    /// </summary>
    public partial class UpdateOption : Window
    {
        public UpdateOption()
        {
            InitializeComponent();
        }

        private void txtUpdateCurrent_Click(object sender, RoutedEventArgs e)
        {
            var temp = new UpdateCurrentSavings();
            temp.Show();
            this.Close();
        }

        private void txtUpdateFD_Click(object sender, RoutedEventArgs e)
        {
            var temp = new UpdateFixedDeposit();
            temp.Show();
            this.Close();
        }
    }
}
