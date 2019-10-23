using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capgemini.Pecunia.Entities;

namespace Pecunia.Contracts.BLContracts.ILoanBL
{
    public interface ICarLoanBL : IDisposable
    {
        Task<bool> ApplyLoanBL(CarLoan EduLoan);
        Task<LoanStatus> GetLoanStatusBL(string loanID);
        Task<CarLoan> GetLoanByCustomerIDBL(string customerID);
        Task<CarLoan> ApproveLoanBL(string loanID, LoanStatus loanStatus);
        Task<CarLoan> GetLoanByLoanIDBL(string loanID);
        Task<bool> Validate(CarLoan EduLoan);
        Task<List<CarLoan>> ListAllLoansBL();
        bool IsLoanIDExistBL(string loanID);

    }
}
