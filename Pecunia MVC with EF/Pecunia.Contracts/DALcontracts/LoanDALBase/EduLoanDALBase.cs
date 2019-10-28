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
    /// This abstract class acts as a base for EduLoanDAL class
    /// </summary>
    public abstract class EduLoanDALBase
    {
       
        public abstract bool ApplyLoanDAL(EduLoan home);
        public abstract List<EduLoan> ApproveLoanDAL(string loanID, string updatedStatus);
        public abstract List<EduLoan> GetLoanByCustomerIDDAL(string customerID);
        public abstract List<EduLoan> GetLoanByLoanIDDAL(string loanID);
        public abstract string GetLoanStatusDAL(string loanID);
        public abstract List<EduLoan> ListAllLoansDAL();
        
    }
}
