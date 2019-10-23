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
    /// Interaction logic for SearchFDByAccountID.xaml
    /// </summary>
    public partial class SearchFDByAccountID : Window
    {
        public SearchFDByAccountID()
        {
            InitializeComponent();
        }

      

        private async void TxtGetFD_Click(object sender, RoutedEventArgs e)
        {
            FixedDeposit fd = new FixedDeposit();
            Guid acc = new Guid();
            bool IsValid = Guid.TryParse(txtAccountID.Text, out acc);
            fd.AccountID = acc;
            if (IsValid == false)
            {
                MessageBox.Show("Invalid guid");
            }
            FixedDepositBL fdBL = new FixedDepositBL();
            try
            {
                fd = await fdBL.GetFixedDepositByAccountIDBL(fd.AccountID);


            }
            catch (CustomerDoesNotExistException c)
            {
                MessageBox.Show(c.Message);



            }
            List<FixedDeposit> fdList = new List<FixedDeposit>();
            fdList.Add(fd);


            txtDataGrid.ItemsSource = fdList;
        }
    }
}
