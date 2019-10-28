using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capgemini.Pecunia.Entities;

namespace Pecunia.Contracts.DALcontracts.LoanDALBase
{
    /// <summary>
    /// This abstract class acts as a base for CarLoanDAL class
    /// </summary>
    public abstract class CarLoanDALBase
    {
       
        public abstract bool ApplyLoanDAL(CarLoan home);
        public abstract List<CarLoan> ApproveLoanDAL(string loanID, string updatedStatus);
        public abstract List<CarLoan> GetLoanByCustomerIDDAL(string customerID);
        public abstract List<CarLoan> GetLoanByLoanIDDAL(string loanID);
        public abstract string GetLoanStatusDAL(string loanID);
        public abstract List<CarLoan> ListAllLoansDAL();
        
    }
}
