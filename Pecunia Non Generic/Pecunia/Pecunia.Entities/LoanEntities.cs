using System;
using Capgemini.Pecunia.Helper;

namespace Capgemini.Pecunia.Entities
{
    public enum LoanType
    {
        EDULOAN = 0, HOMELOAN = 1, CARLOAN = 2
    }
    public enum LoanStatus
    {
        APPLIED, PROCESSING, REJECTED, APPROVED, INVALID
    }

    public enum ServiceType
    {
        AGRICULTURE, BUSINESS, OTHERS, RETIRED, SELF_EMPLOYED, SERVICE, OTHRES
    }

    public enum VehicleType
    {
        TWO_WHEELER, FOUR_WHEELER, MULTI_AXLE, OTHERS
    }

    public enum CourseType
    {
        UNDERGRADUATE, MASTERS, PHD, M_PHIL, OTHERS 
    }
    public interface ILoanEntities
    {
        Guid LoanID { get; set; }
        Guid CustomerID { get; set; }
        double AmountApplied { get; set; }
        double InterestRate { get; set; }
        double EMI_Amount { get; set; }
        int RepaymentPeriod { get; set; }
        DateTime DateOfApplication { get; set; }
        LoanStatus Status { get; set; }
        
    }

    public abstract class LoanEntities : ILoanEntities
    {
        [Required("Loan ID can't be blank")]
        public Guid LoanID { get; set; }

        [Required("Customer ID can't be blank")]
        public Guid CustomerID { get; set; }

        [Required("You must specify the amount of loan to be applied")]
        public double AmountApplied { get; set; }

        public double InterestRate { get; set; }
        public double EMI_Amount { get; set; }

        [Required("You must specify the repayment period")]
        public int RepaymentPeriod { get; set; }
        public DateTime DateOfApplication { get; set; }
        public LoanStatus Status { get; set; }
        
    }

    public class HomeLoan : LoanEntities
    {
        [Required("Occupation can't be blank")]
        public ServiceType Occupation { get; set; }

        [Required("Experience can't be blank")]
        public int ServiceYears { get; set; }

        [Required("Monthly Income can't be blank")]
        public double GrossIncome { get; set; }

        [Required("Deductions can't be blank")]
        public double SalaryDeductions { get; set; }

        
    }

    public class EduLoan : LoanEntities
    {
        [Required("Course can't be blank")]
        public CourseType Course { get; set; }

        [Required("Course duration can't be blank")]
        public int CourseDuration {get; set;}

        [Required("Institute name can't be blank")]
        [RegExp("[a-zA-Z,]$", "Institute name should contains only alphabets and comma(,)")]
        public string InstituteName { get; set; }

        [Required("Student ID can't be blank")]
        [RegExp("[a-zA-Z0-9]", "Institute ID can contains only alphabets and digits only")]
        public string StudentID { get; set; }

        public int RepaymentHoliday { get; set; }
    }

    public class CarLoan : LoanEntities
    {
        [Required("Occupation can't be blank")]
        public ServiceType Occupation { get; set; }

        [Required("Gross income can't be blank")]
        public double GrossIncome { get; set; }

        [Required("Gross income can't be blank")]
        public double SalaryDeductions { get; set; }

        [Required("Vehicle can't be blank")]
        public VehicleType Vehicle { get; set; }
    }
}
