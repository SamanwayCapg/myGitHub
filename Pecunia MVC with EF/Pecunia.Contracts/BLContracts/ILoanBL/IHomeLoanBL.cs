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
        Task<List<HomeLoan>> GetLoanByCustomerIDBL(string customerID);
        Task<List<HomeLoan>> ApproveLoanBL(string loanID, string loanStatus);
        Task<List<HomeLoan>> GetLoanByLoanIDBL(string loanID);
        Task<bool> Validate(HomeLoan EduLoan);
        Task<List<HomeLoan>> ListAllLoansBL();
        bool IsLoanIDExistBL(string loanID);

    }
}
