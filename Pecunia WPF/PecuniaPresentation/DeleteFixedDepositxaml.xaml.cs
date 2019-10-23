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

namespace PecuniaPresentation
{
    /// <summary>
    /// Interaction logic for DeleteFixedDepositxaml.xaml
    /// </summary>
    public partial class DeleteFixedDepositxaml : Window
    {
        public DeleteFixedDepositxaml()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            FixedDeposit fd = new FixedDeposit();
            Guid accid;
            Guid.TryParse(txtAccountID.Text, out accid);
            FixedDepositBL fixedDepositBL = new FixedDepositBL();
            string feedback = txtFeedback.Text;
            if (await fixedDepositBL.DeleteFixedDeposit(accid, feedback))
            {
                MessageBox.Show("Account Deleted Successfully");
             
            }
            else
            {
                MessageBox.Show("Error while Deleting Account");
               
            }



        }
    }
}
