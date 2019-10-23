using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capgemini.Pecunia.Contracts;
using Capgemini.Pecunia.Entities;
namespace Capgemini.Pecunia.Contracts.DALContracts
{
    public abstract class FixedDepositBase
    {
        public abstract bool AddFixedDepositDAL(FixedDeposit fixedDepositObject);
        public abstract bool DeleteFixedDepositDAL(Guid accountID, string feedback);
        public abstract List<FixedDeposit> GetFixedDepositByCustomerIDDAL(Guid customerID);
        public abstract List<FixedDeposit> GetAllFixedDepositsDAL();
        public abstract FixedDeposit GetFixedDepositByAccountIDDAL(Guid accountID);
        public abstract bool SerialiazeIntoJSON(List<FixedDeposit> AccountsList, string FileName);
        public abstract List<FixedDeposit> DeserializeFromJSON(string FileName);
        public abstract void SerializeUpdated(FixedDeposit account);
        public abstract bool AccountIDExists(Guid accountID);

        public static List<FixedDeposit> fixedDepositList = new List<FixedDeposit>();
    }
}
