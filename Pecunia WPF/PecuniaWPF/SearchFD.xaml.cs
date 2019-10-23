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
    /// Interaction logic for SearchFD.xaml
    /// </summary>
    public partial class SearchFD : Window
    {
        public SearchFD()
        {
            InitializeComponent();
        }

        private void TxtSearchByAccountID_Click(object sender, RoutedEventArgs e)
        {
            var item = new SearchFDByAccountID();
            item.Show();
            this.Close();
        }

        private void TxtGetAllResults_Click(object sender, RoutedEventArgs e)
        {
            List<FixedDeposit> fdList = new List<FixedDeposit>();
            FixedDepositBL fdBL = new FixedDepositBL();
            fdList = fdBL.GetAllFixedDepositBL();
            txtDataGrid.ItemsSource = fdList;

        }
    }
}
