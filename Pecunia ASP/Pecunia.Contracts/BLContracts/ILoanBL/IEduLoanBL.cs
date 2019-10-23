using Capgemini.Pecunia.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.Pecunia.Contracts.BLContracts.ILoanBL
{
    public interface IEduLoanBL : IDisposable
    {
        Task<bool> ApplyLoanBL(EduLoan eduLoan);
        Task<EduLoan> ApproveLoanBL(string loanID, LoanStatus updatedStatus);
        Task<EduLoan> GetLoanByCustomerIDBL(string customerID);
        Task<string> GetLoanStatusBL(string loanID);
        Task<EduLoan> GetLoanByLoanIDBL(string loanID);
        Task<bool> Validate(EduLoan eduLoan);
        Task<DataSet> ListAllLoans();
        bool isLoanIDExistBL(string loanID);

    }
}
