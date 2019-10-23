using Capgemini.Pecunia.BusinessLayer;
using Capgemini.Pecunia.Entities;
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
    /// Interaction logic for TransactionWindow.xaml
    /// </summary>
    public partial class TransactionWindow : Window
    {
        public TransactionWindow()
        {
            InitializeComponent();
        }

        private void SlipT_Click(object sender, RoutedEventArgs e)
        {
            var slipTransaction = new SlipTransaction();
            slipTransaction.Show();
            this.Close();
        }

        private void ChequeT_Click(object sender, RoutedEventArgs e)
        {
            var chequeTransaction = new ChequeTransaction();
            chequeTransaction.Show();
            this.Close();
        }


        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{

        //}

        private async void BtnSearch_Click(object sender, RoutedEventArgs e)
        {

            TransactionBL transactionBL = new TransactionBL();
            Guid accountID;
            Guid.TryParse(txtSearch.Text, out accountID);
            List<Transaction> transactions = await transactionBL.DisplayTransactionByAccountIDBL(accountID);
            dataTransactions.ItemsSource = transactions;
        }

        private void BackTransaction_Click(object sender, RoutedEventArgs e)
        {
            var backTransaction = new Window2();
            backTransaction.Show();
            this.Close();
        }
    }
}
