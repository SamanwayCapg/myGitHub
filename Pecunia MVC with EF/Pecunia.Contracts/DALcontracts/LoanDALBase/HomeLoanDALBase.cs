using Capgemini.Pecunia.Entities;
using System;
using System.Collections.Generic;
using System.Data;
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
        public abstract bool ApplyLoanDAL(HomeLoan home);
        public abstract List<HomeLoan> ApproveLoanDAL(string loanID, string updatedStatus);
        public abstract List<HomeLoan> GetLoanByCustomerIDDAL(string customerID);
        public abstract List<HomeLoan> GetLoanByLoanIDDAL(string loanID);
        public abstract string GetLoanStatusDAL(string loanID);
        public abstract List<HomeLoan> ListAllLoansDAL();
        
    }
}
