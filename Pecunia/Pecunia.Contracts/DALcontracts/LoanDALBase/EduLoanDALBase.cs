using Capgemini.Pecunia.Entities;
using System;
using System.Collections.Generic;
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
        public abstract EduLoan ApproveLoanDAL(string loanID, LoanStatus updatedStatus);
        public abstract EduLoan GetLoanByCustomerIDDAL(string customerID);
        public abstract EduLoan GetLoanByLoanIDDAL(string loanID);
        public abstract LoanStatus GetLoanStatusDAL(string loanID);
        public abstract List<EduLoan> ListAllLoansDAL();
        public abstract bool IsLoanIDExistDAL(string loanID);
    }
}
