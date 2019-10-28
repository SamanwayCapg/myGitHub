using Capgemini.Pecunia.BusinessLayer;
using Capgemini.Pecunia.BusinessLayer.LoanBL;
using Capgemini.Pecunia.DataAccessLayer;
using Capgemini.Pecunia.DataAccessLayer.LoanDAL;
using Capgemini.Pecunia.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        [STAThread]
        public static void Main()
        {
            Test.doWork().Wait();
        }
    }

    class Test
    {
        public static async Task doWork()
        {
            List<Customer> customers = new List<Customer>();
            List<CarLoan> carLoans = new List<CarLoan>();
            List<EduLoan> eduLoans = new List<EduLoan>();
            List<HomeLoan> homeLoans = new List<HomeLoan>();

            EduLoan edu = new EduLoan();
            CarLoan car = new CarLoan();
            HomeLoan home = new HomeLoan();

            EduLoanBL eduLoanBL = new EduLoanBL();
            CarLoanBL carLoanBL = new CarLoanBL();
            HomeLoanBL homeLoanBL = new HomeLoanBL();

            int rowsAffected = 0;
            String status;
            Guid guid;
            Guid.TryParse("81A22477-2D0B-4DF7-AF26-94C36A4DD42D", out guid);

            EduLoanDAL eduLoanDAL = new EduLoanDAL();
            eduLoanDAL.ApproveLoanDAL("29257E8B-1F70-4A8F-92B3-22EF7A599BC9", "INVALID");

            //success
            //bool isAdded = false;
            //edu.CustomerID = guid;
            //edu.AmountApplied = 175000;
            //edu.Course = "UNDERGRADUATE";
            //edu.InstituteName = "asdfasdf";
            //edu.RepaymentPeriod = 58;
            //isAdded = await eduLoanBL.ApplyLoanBL(edu);
            //Console.WriteLine(isAdded);


            //success
            //eduLoans = await eduLoanBL.ListAllLoans();
            //foreach(EduLoan edus in eduLoans)
            //    Console.WriteLine("eduloan:" + edus.LoanID);

            //carLoans = await carLoanBL.ListAllLoansBL();
            //foreach (CarLoan edus in carLoans)
            //    Console.WriteLine("carloan:" + edus.LoanID);

            //homeLoans = await homeLoanBL.ListAllLoansBL();
            //foreach (HomeLoan edus in homeLoans)
            //    Console.WriteLine("homeloan:" + edus.LoanID);

            //success
            //status = await eduLoanBL.GetLoanStatusBL("FB938F03-6128-458D-8E7D-08DD61283138");
            //Console.WriteLine("eduloan:" + status);

            //status = await carLoanBL.GetLoanStatusBL("AFEB76EE-9045-4095-9C31-6FE07FF5E308");
            //Console.WriteLine("carloan:" + status);

            //status = await homeLoanBL.GetLoanStatusBL("13EB5DE9-5995-4446-97A9-8F7ACB0CC255");
            //Console.WriteLine("homeloan:" + status);


            //success
            //eduLoans = await eduLoanBL.GetLoanByLoanIDBL("FB938F03-6128-458D-8E7D-08DD61283138");
            //Console.WriteLine("eduloan:" + eduLoans.ElementAt(0).InstituteName);

            //carLoans = await carLoanBL.GetLoanByLoanIDBL("AFEB76EE-9045-4095-9C31-6FE07FF5E308");
            //Console.WriteLine("carloan:" + carLoans.ElementAt(0).Occupation);

            //homeLoans = await homeLoanBL.GetLoanByLoanIDBL("13EB5DE9-5995-4446-97A9-8F7ACB0CC255");
            //Console.WriteLine("homeloan:" + homeLoans.ElementAt(0).SalaryDeduction);


            //success
            //eduLoans = await eduLoanBL.GetLoanByCustomerIDBL("33EA6038-57D3-4912-8EA8-662BC1B1C413");
            //Console.WriteLine("eduloan:" + eduLoans.ElementAt(0).InstituteName);

            //carLoans = await carLoanBL.GetLoanByCustomerIDBL("DD9856B2-31D6-485F-BE76-B71BE27D6659");
            //Console.WriteLine("carloan:" + carLoans.ElementAt(0).Occupation);

            //homeLoans = await homeLoanBL.GetLoanByCustomerIDBL("DD9856B2-31D6-485F-BE76-B71BE27D6659");
            //Console.WriteLine("homeloan:" + homeLoans.ElementAt(0).SalaryDeduction);


            //failed
            //eduLoans = await eduLoanBL.ApproveLoanBL("48C6B13C-562E-40E0-9DA2-C1C5DDF6B8B6", "adfasdf");
            //Console.WriteLine("eduloan:"+ eduLoans.ElementAt(0).LoanStatus);

            //carLoans = await carLoanBL.ApproveLoanBL("AFEB76EE-9045-4095-9C31-6FE07FF5E308", "PROCESSING");
            //Console.WriteLine("carloan:" + carLoans.ElementAt(0).LoanStatus);

            //homeLoans = await homeLoanBL.ApproveLoanBL("13EB5DE9-5995-4446-97A9-8F7ACB0CC255", "PROCESSING");
            //Console.WriteLine("homeloan:" + homeLoans.ElementAt(0).LoanStatus);

            CustomerDAL customerDAL = new CustomerDAL();
            List<MyData> list = new List<MyData>();
            using(PecuniaEntities pecEnt = new PecuniaEntities())
            {
                list = (from cust
                        in pecEnt.Customers
                        select new MyData
                        {
                            CustomerID = cust.CustomerID,
                            NameMob = cust.CustomerName + cust.CustomerMobile
                        }).ToList();
            }

            foreach(MyData myData in list)
                Console.WriteLine(myData.CustomerID+ " "+myData.NameMob);
        }
    }
    public class MyData
    {
        public Guid CustomerID { get; set; }
        public string NameMob { get; set; }
    }
}
