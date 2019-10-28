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
        Task<List<EduLoan>> ApproveLoanBL(string loanID, string updatedStatus);
        Task<List<EduLoan>> GetLoanByCustomerIDBL(string customerID);
        Task<string> GetLoanStatusBL(string loanID);
        Task<List<EduLoan>> GetLoanByLoanIDBL(string loanID);
        Task<bool> Validate(EduLoan eduLoan);
        Task<List<EduLoan>> ListAllLoans();
        bool isLoanIDExistBL(string loanID);

    }
}
