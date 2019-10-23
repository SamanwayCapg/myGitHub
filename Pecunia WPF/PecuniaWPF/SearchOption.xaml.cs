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
    /// Interaction logic for SearchOption.xaml
    /// </summary>
    public partial class SearchOption : Window
    {
        public SearchOption()
        {
            InitializeComponent();
        }
        private void TxtSearchCurrent_Click(object sender, RoutedEventArgs e)
        {
            var item = new SearchCurrentSavings();
            item.Show();
            this.Close();

        }

        private void TxtSearchFD_Click(object sender, RoutedEventArgs e)
        {
            var item = new SearchFD();
            item.Show();
            this.Close();
        }
    }
}
