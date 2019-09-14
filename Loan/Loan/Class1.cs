using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Loan
{
    public interface ILoan
    {
        long LoanID { get; set; }
        long CustomerID { get; }
        double AmountApplied { get; set; }
        DateTime DateOfApplication { get; set; }
        double Income { get; set; }
        int Tenure { get; set; }
        string Status { get; set; }
    }

    public interface ILoanService
    {
        List<HomeLoan> HomeLoans { get; set; }
        List<EduLoan> EduLoans { get; set; }
        List<CarLoan> CarLoans { get; set; }

        void GetLoan(int customerID);
        void GetStatus(long loanID);
        void ListLoanByCustomerID(int customerID);

    }

    
    public class HomeLoan : ILoan
    {
        private string _guranteer;
        private long _loanID;
        private long _customerID;
        private double _amountApplied;
        private DateTime _dateOfApplication;
        private double _income;
        private int _tenure;
        private string _status;

        public string Guranteer
        {
            set
            {
                if (Regex.IsMatch(value, "^[a-zA-Z]+$") && value.Length <= 15)
                    _guranteer = value;
                else
                    throw new Exception("Guranteer name must not exceeds 15 character !");
            }
            get
            {
                return _guranteer;
            }
        }

        public long LoanID {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public long CustomerID {
            get
            {
                return _customerID;
            }
        }

        public double AmountApplied {
            set
            {
                if (value <= 10000000)
                    _amountApplied = value;
                else
                    throw new Exception("Maximum amount limit is Rs.1 Crore!");
            }
            get
            {
                return _amountApplied;
            }
        }

        public DateTime DateOfApplication {
            set
            {
                DateTime currentTime = DateTime.Now;
                _dateOfApplication = currentTime;
            }
            get
            {
                return _dateOfApplication;
            }
        }

        public double Income {

            set
            {
                if (value >= 50000)
                    _income = value;
                else
                    throw new Exception("Minimum income must be Rs.50000!");
            }
            get
            {
                return _income;
            }
        }

        public int Tenure {
            set
            {
                if (value >= 2 && value <= 20)
                    _tenure = value;
                else
                    throw new Exception("Tenure must be between 2 to 20 years!");
            }
            get
            {
                return _tenure;
            }
        }

        public string Status {
            set
            {
                if (Regex.IsMatch(value, "[ACCEPTED | REJECTED | PROCESSING]"))
                    _status = value;
                else
                    throw new Exception("Not a valid status (ACCEPTED, REJECTED, PROECSSING)!");
            }
            get
            {
                return _status;
            }
        }
    }


    /// /////////////////////////////////////
    public class CarLoan : ILoan
    {
        private long _loanID;
        private long _customerID;
        private double _amountApplied;
        private DateTime _dateOfApplication;
        private double _income;
        private int _tenure;
        private string _status;

        public long LoanID
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public long CustomerID
        {
            get
            {
                return _customerID;
            }
        }

        public double AmountApplied
        {
            set
            {
                if (value <= 10000000)
                    _amountApplied = value;
                else
                    throw new Exception("Maximum amount limit is Rs.1 Crore!");
            }
            get
            {
                return _amountApplied;
            }
        }

        public DateTime DateOfApplication
        {
            set
            {
                DateTime currentTime = DateTime.Now;
                _dateOfApplication = currentTime;
            }
            get
            {
                return _dateOfApplication;
            }
        }

        public double Income
        {

            set
            {
                if (value >= 50000)
                    _income = value;
                else
                    throw new Exception("Minimum income must be Rs.50000!");
            }
            get
            {
                return _income;
            }
        }

        public int Tenure
        {
            set
            {
                if (value >= 2 && value <= 20)
                    _tenure = value;
                else
                    throw new Exception("Tenure must be between 2 to 20 years!");
            }
            get
            {
                return _tenure;
            }
        }

        public string Status
        {
            set
            {
                if (Regex.IsMatch(value, "[ACCEPTED | REJECTED | PROCESSING]"))
                    _status = value;
                else
                    throw new Exception("Not a valid status (ACCEPTED, REJECTED, PROECSSING)!");
            }
            get
            {
                return _status;
            }
        }
    }

    /////////////////////////////////////////////////////////
    public class EduLoan : ILoan
    {
        private long _loanID;
        private long _customerID;
        private double _amountApplied;
        private DateTime _dateOfApplication;
        private double _income;
        private int _tenure;
        private string _status;

    

        public long LoanID
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public long CustomerID
        {
            get
            {
                return _customerID;
            }
        }

        public double AmountApplied
        {
            set
            {
                if (value <= 10000000)
                    _amountApplied = value;
                else
                    throw new Exception("Maximum amount limit is Rs.1 Crore!");
            }
            get
            {
                return _amountApplied;
            }
        }

        public DateTime DateOfApplication
        {
            set
            {
                DateTime currentTime = DateTime.Now;
                _dateOfApplication = currentTime;
            }
            get
            {
                return _dateOfApplication;
            }
        }

        public double Income
        {

            set
            {
                if (value >= 50000)
                    _income = value;
                else
                    throw new Exception("Minimum income must be Rs.50000!");
            }
            get
            {
                return _income;
            }
        }

        public int Tenure
        {
            set
            {
                if (value >= 2 && value <= 20)
                    _tenure = value;
                else
                    throw new Exception("Tenure must be between 2 to 20 years!");
            }
            get
            {
                return _tenure;
            }
        }

        public string Status
        {
            set
            {
                if (Regex.IsMatch(value, "[ACCEPTED | REJECTED | PROCESSING]"))
                    _status = value;
                else
                    throw new Exception("Not a valid status (ACCEPTED, REJECTED, PROECSSING)!");
            }
            get
            {
                return _status;
            }
        }
    }

    ///////////////////////////////////////////////////
    public class LoanService : ILoanService
    {
        public List<HomeLoan> HomeLoans { get => HomeLoans; set => HomeLoans = value; }
        public List<EduLoan> EduLoans { get => EduLoans; set => EduLoans = value; }
        public List<CarLoan> CarLoans { get => CarLoans; set => CarLoans = value; }

        public void GetLoan(int customerID)
        {
            //implement here
           
        }

        public void GetStatus(long loanID)
        {
            //implement here
        }

        public void ListLoanByCustomerID(int customerID)
        {
            //implement here+9
        }
    }
    /// //////////////////////////////Exception classes
    public class InvalidAmountException : ApplicationException {
        public InvalidAmountException(string msg) : base(msg)
        {

        }
    }
}
