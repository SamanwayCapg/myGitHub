using Capgemini.Pecunia.BusinessLayer.LoanBL;
using Capgemini.Pecunia.Entities;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for ApplyCarLoan.xaml
    /// </summary>
    public partial class ApplyCarLoan : Window
    {
        public ApplyCarLoan()
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
            CarLoan carLoan = new CarLoan();
            Guid custID;

            Guid.TryParse(customerIDTxtBox.Text, out custID);
            carLoan.CustomerID = custID;
            carLoan.AmountApplied = Convert.ToDouble(amountAppliedTxtBox.Text);
            carLoan.RepaymentPeriod = Convert.ToInt32(repaymentPeriodTxtBox.Text);
            ServiceType service;
            Enum.TryParse(occupationComboBox.Text, out service);
            carLoan.Occupation = service ;
            carLoan.GrossIncome = Convert.ToDouble(grossIncomeTxtBox.Text);
            carLoan.SalaryDeductions = Convert.ToDouble(salaryDecductionTxtBox.Text);
            VehicleType vehicle;
            Enum.TryParse(vehicleComboBox.Text, out vehicle);
            carLoan.Vehicle = vehicle;

            CarLoanBL car = new CarLoanBL();
            bool isSuccess = await car.ApplyLoanBL(carLoan);
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
