using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capgemini.Pecunia.Entities;

namespace Capgemini.Pecunia.Contracts.BLContracts
{
    public interface IFixedDepositBL
    {
        Task<bool> AddFixedDepositBL(FixedDeposit fixedDeposit, Guid customerID);
        Task<bool> DeleteFixedDeposit(Guid accountID, string feedback);
        List<FixedDeposit> GetFixedDepositByCustomerIDBL(Guid customerID);
        Task<FixedDeposit> GetFixedDepositByAccountIDBL(Guid accountID);
        Task<bool> ChangeBranchBL(Guid accountID, string homeBranch);
        List<FixedDeposit> GetAllFixedDepositBL();
        bool UpdateFDAmountBL(Guid accountID, double newAmount);
    }

}
