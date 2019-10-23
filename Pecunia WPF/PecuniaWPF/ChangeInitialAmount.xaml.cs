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
    /// Interaction logic for ChangeInitialAmount.xaml
    /// </summary>
    public partial class ChangeInitialAmount : Window
    {
        public ChangeInitialAmount()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FixedDeposit fd = new FixedDeposit();
            FixedDepositBL fdBl = new FixedDepositBL();
            double newAmount = Convert.ToDouble(txtNewAmount.Text);
            Guid accID;
            bool IsTrue = Guid.TryParse(txtAccountID.Text, out accID);
            if (IsTrue == false)
            {
                MessageBox.Show("Invalid Guid");
            }
            fd.AccountID = accID;
            if (fdBl.UpdateFDAmountBL(fd.AccountID, newAmount))
            {
                MessageBox.Show("FD Amount Updated");

            }
            else
            {
                MessageBox.Show("AMount Not Updated");

            }
        }
    }
}
