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
    /// Interaction logic for LoanMainWindow.xaml
    /// </summary>
    public partial class LoanMainWindow : Window
    {
        public LoanMainWindow()
        {
            InitializeComponent();
            
        }
        
        private void ApplyHomeLoan_Click(object sender, RoutedEventArgs e)
        {
            var applyHomeLoanHome = new ApplyHomeLoan();
            applyHomeLoanHome.Show();
            this.Close();
        }

        private void Button_Click_ApplyCarLoan(object sender, RoutedEventArgs e)
        {
            var applyCarLoanHome = new ApplyCarLoan();
            applyCarLoanHome.Show();
            this.Close();
        }

        private void ApplyEduLoan_Click(object sender, RoutedEventArgs e)
        {
            var applyEduLoanHome = new ApplyEduLoan();
            applyEduLoanHome.Show();
            this.Close();
        }

        private void ApproveCarLoan_Click(object sender, RoutedEventArgs e)
        {
            var approveCarLoan = new ApproveCarLoan();
            approveCarLoan.Show();
            this.Close();
        }

        private void ApproveHomeLoan_Click(object sender, RoutedEventArgs e)
        {
            var approveHomeLoanWindow = new ApproveHomeLoan();
            approveHomeLoanWindow.Show();
            this.Close();
        }

        private void ApproveEduLoan_Click(object sender, RoutedEventArgs e)
        {
            var approveEduLoanWindow = new ApproveEduLoan();
            approveEduLoanWindow.Show();
            this.Close();
        }

        private async void SearchLoanBtn_Click(object sender, RoutedEventArgs e)
        {
            HomeLoanBL home = new HomeLoanBL();
            CarLoanBL car = new CarLoanBL();
            EduLoanBL edu = new EduLoanBL();
            
            if(SearchLoanComboBox.Text.Equals("By Customer ID") == true)
            {
                if(selectLoanTypeComboBox.Text.Equals("Home Loan") == true)
                {
                    List<HomeLoan> homeLoans = new List<HomeLoan>();
                    HomeLoan homeLoan = await home.GetLoanByCustomerIDBL(IDtextBox.Text);
                    if (homeLoan == default(HomeLoan))
                        MessageBox.Show("Invalid ID!");
                    else
                    {
                        homeLoans.Add(homeLoan);
                        dataGrid.ItemsSource = homeLoans;
                    }
                }
                else if (selectLoanTypeComboBox.Text.Equals("Car Loan") == true)
                {
                    List<CarLoan> carLoans = new List<CarLoan>();
                    CarLoan carLoan = await car.GetLoanByCustomerID_BL(IDtextBox.Text);
                    if (carLoan == default(CarLoan))
                        MessageBox.Show("Invalid ID");
                    else
                    {
                        carLoans.Add(carLoan);
                        dataGrid.ItemsSource = carLoans;
                    }
                }
                else if(selectLoanTypeComboBox.Text.Equals("Edu Loan") == true)// edu loan is selected
                {
                    List<EduLoan> eduLoans = new List<EduLoan>();
                    EduLoan eduLoan = await edu.GetLoanByCustomerIDBL(IDtextBox.Text);
                    if (eduLoan == default(EduLoan))
                        MessageBox.Show("Invalid ID");
                    else
                    {
                        eduLoans.Add(eduLoan);
                        dataGrid.ItemsSource = eduLoans;
                    }
                }
                else
                {
                    MessageBox.Show("Please Select a Loan Type!");
                }
            }
            else if (SearchLoanComboBox.Text.Equals("By Loan ID") == true)// By Loan ID selected
            {
                if (selectLoanTypeComboBox.Text.Equals("Home Loan") == true)
                {
                    List<HomeLoan> homeLoans = new List<HomeLoan>();
                    HomeLoan homeLoan = await home.GetLoanByLoanIDBL(IDtextBox.Text);
                    if (homeLoan == default(HomeLoan))
                        MessageBox.Show("Invalid ID");
                    else
                    {
                        homeLoans.Add(homeLoan);
                        dataGrid.ItemsSource = homeLoans;
                    }
                }
                else if (selectLoanTypeComboBox.Text.Equals("Car Loan") == true)
                {
                    List<CarLoan> carLoans = new List<CarLoan>();
                    CarLoan carLoan = await car.GetLoanByLoanID_BL(IDtextBox.Text);
                    if (carLoan == default(CarLoan))
                        MessageBox.Show("Invalid ID");
                    else
                    {
                        carLoans.Add(carLoan);
                        dataGrid.ItemsSource = carLoans;
                    }
                }
                else if(selectLoanTypeComboBox.Text.Equals("Edu Loan") == true)// edu loan is selected
                {
                    List<EduLoan> eduLoans = new List<EduLoan>();
                    EduLoan eduLoan = await edu.GetLoanByLoanIDBL(IDtextBox.Text);
                    if (eduLoan == default(EduLoan))
                        MessageBox.Show("Invalid ID");
                    else
                    {
                        eduLoans.Add(eduLoan);
                        dataGrid.ItemsSource = eduLoans;
                    }
                }
                else
                {
                    MessageBox.Show("Please Select a Loan Type!");
                }
            }
            else
            {
                MessageBox.Show("Please Select a ID Type!");
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void SelectLoanTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void ShowAllCarLoans_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
