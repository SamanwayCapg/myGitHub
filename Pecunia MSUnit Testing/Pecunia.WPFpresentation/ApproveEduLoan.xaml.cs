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

namespace Pecunia.WPFpresentation
{
    /// <summary>
    /// Interaction logic for ApproveEduLoan.xaml
    /// </summary>
    public partial class ApproveEduLoan : Window
    {
        public ApproveEduLoan()
        {
            InitializeComponent();
        }

        private async void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            EduLoan edu = new EduLoan();
            EduLoanBL eduBL = new EduLoanBL();
            edu = await eduBL.GetLoanByLoanIDBL(EduLoanIDtextBox.Text);
            List<EduLoan> eduLoans = new List<EduLoan>();
            eduLoans.Add(edu);
            dataGrid.ItemsSource = eduLoans;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            var loanMainWindow = new LoanMainWindow();
            loanMainWindow.Show();
            this.Close();
        }

        private async void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            EduLoan edu = new EduLoan();
            EduLoanBL eduBL = new EduLoanBL();

            LoanStatus newStatus;
            Enum.TryParse(statusComboBox.Text, out newStatus);
            await eduBL.ApproveLoanBL(EduLoanIDtextBox.Text, newStatus);

            //showing updated status in gridbox
            edu = await eduBL.GetLoanByLoanIDBL(EduLoanIDtextBox.Text);
            List<EduLoan> eduLoans = new List<EduLoan>();
            eduLoans.Add(edu);
            dataGrid.ItemsSource = eduLoans;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void StatusComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
