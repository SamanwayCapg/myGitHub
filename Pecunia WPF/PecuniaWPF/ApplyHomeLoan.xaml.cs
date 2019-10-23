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
    /// Interaction logic for ApplyHomeLoan.xaml
    /// </summary>
    public partial class ApplyHomeLoan : Window
    {
        public ApplyHomeLoan()
        {
            InitializeComponent();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            var loanMainWindow = new LoanMainWindow();
            loanMainWindow.Show();
            this.Close();
        }

        private async void ApplyBtn_Click(object sender, RoutedEventArgs e)
        {
            HomeLoan homeLoan = new HomeLoan();
            Guid custID;

            Guid.TryParse(customerIDTxtBox.Text, out custID);
            homeLoan.CustomerID = custID;
            homeLoan.AmountApplied = Convert.ToDouble(amountAppliedTxtBox.Text);
            homeLoan.RepaymentPeriod = Convert.ToInt32(repaymentPeriodTxtBox.Text);
            ServiceType service;
            Enum.TryParse(occupationComboBox.Text, out service);
            homeLoan.Occupation = service;
            homeLoan.ServiceYears = Convert.ToInt16(workExperienceTxtBox.Text);
            homeLoan.GrossIncome = Convert.ToDouble(grossIncomeTxtBox.Text);
            homeLoan.SalaryDeductions = Convert.ToDouble(salaryDecductionTxtBox.Text);

            HomeLoanBL home = new HomeLoanBL();
            bool isSuccess = await home.ApplyLoanBL(homeLoan);
            if (isSuccess == true)
                MessageBox.Show("Loan Applied Successfully");
            else
                MessageBox.Show("Error Occured!");

            var loanMainWindow = new LoanMainWindow();
            loanMainWindow.Show();
            this.Close();
        }
    }
}
