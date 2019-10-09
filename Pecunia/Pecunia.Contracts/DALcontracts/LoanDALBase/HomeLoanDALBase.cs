using Capgemini.Pecunia.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.Pecunia.Contracts.DALcontracts.LoanDALBase
{
    /// <summary>
    /// This abstract class acts as a base for HomeLoanDAL class
    /// </summary>
    public abstract class HomeLoanDALBase
    {
        //Collection of HomeLoans
        public static string fileName = "HomeLoans.txt";
        public abstract bool ApplyLoanDAL(HomeLoan home);
        public abstract HomeLoan ApproveLoanDAL(string loanID, LoanStatus updatedStatus);
        public abstract HomeLoan GetLoanByCustomerIDDAL(string customerID);
        public abstract HomeLoan GetLoanByLoanIDDAL(string loanID);
        public abstract LoanStatus GetLoanStatusDAL(string loanID);
        public abstract List<HomeLoan> ListAllLoansDAL();
        public abstract bool IsLoanIDExistDAL(string loanID);
        
    }
}
