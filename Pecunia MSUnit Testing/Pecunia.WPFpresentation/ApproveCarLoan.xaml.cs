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
    /// Interaction logic for ApproveCarLoan.xaml
    /// </summary>
    public partial class ApproveCarLoan : Window
    {
        public ApproveCarLoan()
        {
            InitializeComponent();
        }
        

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void StatusComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            var loanMainWindow = new LoanMainWindow();
            loanMainWindow.Show();
            this.Close();
        }

        private async void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            CarLoan car = new CarLoan();
            CarLoanBL carBL = new CarLoanBL();

            LoanStatus newStatus;
            Enum.TryParse(statusComboBox.Text, out newStatus);
            await carBL.ApproveLoanBL(CarLoanIDtextBox.Text, newStatus);

            //showing updated status in gridbox
            car = await carBL.GetLoanByLoanID_BL(CarLoanIDtextBox.Text);
            List<CarLoan> carLoans = new List<CarLoan>();
            carLoans.Add(car);
            dataGrid.ItemsSource = carLoans;
        }

        private async void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            CarLoan car = new CarLoan();
            CarLoanBL carBL = new CarLoanBL();
            car = await carBL.GetLoanByLoanID_BL(CarLoanIDtextBox.Text);
            List<CarLoan> carLoans = new List<CarLoan>();
            carLoans.Add(car);
            dataGrid.ItemsSource = carLoans;
        }
    }
}
