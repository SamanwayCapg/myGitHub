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
        public abstract CarLoan ApproveLoanDAL(string loanID, LoanStatus updatedStatus);
        public abstract CarLoan GetLoanByCustomerIDDAL(string customerID);
        public abstract CarLoan GetLoanByLoanIDDAL(string loanID);
        public abstract string GetLoanStatusDAL(string loanID);
        public abstract DataSet ListAllLoansDAL();
        public abstract bool IsLoanIDExistDAL(string loanID);

    }
}
