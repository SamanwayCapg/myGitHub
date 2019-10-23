using Capgemini.Pecunia.BusinessLayer.LoanBL;
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
    /// Interaction logic for ApproveHomeLoan.xaml
    /// </summary>
    public partial class ApproveHomeLoan : Window
    {
        public ApproveHomeLoan()
        {
            InitializeComponent();
        }

        private async void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            HomeLoan home = new HomeLoan();
            HomeLoanBL homeBL = new HomeLoanBL();
            home = await homeBL.GetLoanByLoanIDBL(HomeLoanIDtextBox.Text);

            //invalid loan id, exception thrown at DAL
            if (home == default(HomeLoan))
                MessageBox.Show("INvalid Loan ID");
            else
            {
                List<HomeLoan> homeLoans = new List<HomeLoan>();
                homeLoans.Add(home);
                dataGrid.ItemsSource = homeLoans;
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            var loanMainWindow = new LoanMainWindow();
            loanMainWindow.Show();
            this.Close();
        }

        private async void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            HomeLoan home = new HomeLoan();
            HomeLoanBL homeBL = new HomeLoanBL();

            LoanStatus newStatus;
            Enum.TryParse(statusComboBox.Text, out newStatus);
            home = await homeBL.ApproveLoanBL(HomeLoanIDtextBox.Text, newStatus);

            //exception thrown at DAL
            if (home == default(HomeLoan))
                MessageBox.Show("Updated Status can't be existing status");

            //showing updated status in gridbox
            home = await homeBL.GetLoanByLoanIDBL(HomeLoanIDtextBox.Text);
            List<HomeLoan> homeLoans = new List<HomeLoan>();
            homeLoans.Add(home);
            dataGrid.ItemsSource = homeLoans;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void StatusComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
