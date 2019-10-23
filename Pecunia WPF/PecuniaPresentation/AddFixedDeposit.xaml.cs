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
    /// Interaction logic for AddFixedDeposit.xaml
    /// </summary>
    public partial class AddFixedDeposit : Window
    {
        public AddFixedDeposit()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            FixedDeposit fd = new FixedDeposit();
            fd.HomeBranch = txtAccountBranch.Text;
            bool isGuid = Guid.TryParse(txtCustomerID.Text, out Guid customerID);
            if (isGuid == false)
            {
                MessageBox.Show("Invalid Guid");
            }
            fd.tenure = Convert.ToInt32(txtTenure.Text);
            fd.FdDeposit = Convert.ToDouble(txtInitialAmount.Text);
            FixedDepositBL fixedDepositBL = new FixedDepositBL();
            if (await fixedDepositBL.AddFixedDepositBL(fd, customerID))
            {
                MessageBox.Show("Account Added Sucessfully");

            }
            else
                MessageBox.Show("Account Not Added");

        }
    }
}
