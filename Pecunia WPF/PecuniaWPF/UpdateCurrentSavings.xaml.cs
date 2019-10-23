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
    /// Interaction logic for UpdateCurrentSavings.xaml
    /// </summary>
    public partial class UpdateCurrentSavings : Window
    {
        public UpdateCurrentSavings()
        {
            InitializeComponent();
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            var temp = new ChangeBranch();
            temp.Show();
            this.Close();

        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            var temp = new ChangeAccountType();
            temp.Show();
            this.Close();

        }
    }
}
