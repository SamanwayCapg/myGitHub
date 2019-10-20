using Capgemini.Pecunia.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.Pecunia.Contracts.BLContracts.ILoanBL
{
    public interface IHomeLoanBL : IDisposable
    {
        Task<bool> ApplyLoanBL(HomeLoan EduLoan);
        Task<string> GetLoanStatusBL(string loanID);
        Task<HomeLoan> GetLoanByCustomerIDBL(string customerID);
        Task<HomeLoan> ApproveLoanBL(string loanID, LoanStatus loanStatus);
        Task<HomeLoan> GetLoanByLoanIDBL(string loanID);
        Task<bool> Validate(HomeLoan EduLoan);
        Task<DataSet> ListAllLoansBL();
        bool IsLoanIDExistBL(string loanID);

    }
}
