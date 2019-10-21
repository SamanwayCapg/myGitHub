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
    /// Interaction logic for ApplyEduLoan.xaml
    /// </summary>
    public partial class ApplyEduLoan : Window
    {
        public ApplyEduLoan()
        {
            InitializeComponent();
        }

        private async void ApplyBtn_Click(object sender, RoutedEventArgs e)
        {
            EduLoan eduLoan = new EduLoan();
            Guid custID;
            Guid.TryParse(customerIDTxtBox.Text, out custID);
            eduLoan.CustomerID = custID;
            eduLoan.AmountApplied = Convert.ToDouble(amountAppliedTxtBox.Text);
            eduLoan.RepaymentPeriod = Convert.ToInt32(repaymentPeriodTxtBox.Text);
            CourseType course;
            Enum.TryParse(courseComboBox.Text, out course);
            eduLoan.Course = course;
            eduLoan.CourseDuration = Convert.ToInt16(courseDurationTxtBox.Text);
            eduLoan.InstituteName = instituteNameTxtBox.Text;
            eduLoan.StudentID = studentIDTxtBox.Text;

            EduLoanBL edu = new EduLoanBL();
            await edu.ApplyLoanBL(eduLoan);

            var loanMainWindow = new LoanMainWindow();
            loanMainWindow.Show();
            this.Close();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            var loanMainWindow = new LoanMainWindow();
            loanMainWindow.Show();
            this.Close();
        }
    }
}
