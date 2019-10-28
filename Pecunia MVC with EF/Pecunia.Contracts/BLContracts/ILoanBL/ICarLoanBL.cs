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
        Task<string> GetLoanStatusBL(string loanID);
        Task<List<CarLoan>> GetLoanByCustomerIDBL(string customerID);
        Task<List<CarLoan>> ApproveLoanBL(string loanID, string loanStatus);
        Task<List<CarLoan>> GetLoanByLoanIDBL(string loanID);
        Task<bool> Validate(CarLoan EduLoan);
        Task<List<CarLoan>> ListAllLoansBL();
        

    }
}
