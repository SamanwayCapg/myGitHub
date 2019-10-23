using Capgemini.Pecunia.BusinessLayer;
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
    /// Interaction logic for ChequeTransaction.xaml
    /// </summary>
    public partial class ChequeTransaction : Window
    {
        public ChequeTransaction()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new TransactionWindow();
            mainWindow.Show();
            this.Close();
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            TransactionBL debitCheque = new TransactionBL();
            if (Type.Text.Equals("Debit") == true)
            {
                Guid accID;
                Guid.TryParse(AccountNumber.Text, out accID);
                double amount = Convert.ToDouble(Amount.Text);
                string chequeNumber = Convert.ToString(ChequeNumber.Text);
                await debitCheque.DebitTransactionByChequeBL(accID, amount, chequeNumber);
                MessageBox.Show("Transaction Debited Successfully");
            }
            else
            {
                Guid accountID;
                Guid.TryParse(AccountNumber.Text, out accountID);
                double amt = Convert.ToDouble(Amount.Text);
                string chequeNumber = Convert.ToString(ChequeNumber.Text);
                await debitCheque.CreditTransactionByChequeBL(accountID, amt, chequeNumber);
                MessageBox.Show("Transaction Credited Successfully");
            }


            var mainWindow = new TransactionWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
