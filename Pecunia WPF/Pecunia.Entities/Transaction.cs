using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Capgemini.Pecunia.Helper;

namespace Capgemini.Pecunia.Entities
{
    /// <summary>
    /// Interface for Transaction Entity
    /// </summary>
    public interface ITransaction
    {
        //long AccountNumber { get; set; }
        Guid AccountID { get; set; }
        TypeOfTransaction Type { get; set; }
        double Amount { get; set; }
        Guid TransactionID { get; set; }
        DateTime DateOfTransaction { get; set; }
        ModeOfTransaction Mode { get; set; }
        string ChequeNumber { get; set; }
    }

    /// <summary>
    /// Represents Mode of Transaction
    /// </summary>
    [Serializable]
    public enum ModeOfTransaction
    {
        Cheque,
        WithdrawalSlip

    }

    /// <summary>
    /// Represents Type of Transaction
    /// </summary>
    public enum TypeOfTransaction
    {
        Credit,
        Debit
    }

    /// <summary>
    /// Represents Transaction
    /// </summary>
    public class Transaction : ITransaction
    {
        /*Auto Implemented Properties*/

        //[Required("Account Number can't be blank.")]
        //public long AccountNumber { get; set; }

        [Required("Account ID can't be blank.")]
        public Guid AccountID { get; set; }

        [Required("The choice can't be blank.")]
        public TypeOfTransaction Type { get; set; }

        [Required("Amount entered can't be blank.")]
        public double Amount { get; set; }

        [Required("TransactionID can't be blank.")]
        public Guid TransactionID { get; set; }

        public DateTime DateOfTransaction { get; set; }

        [Required("The choice can't be blank")]
        public ModeOfTransaction Mode { get; set; }

        [Required("Enter valid amount can't be blank.")]
        [RegExp(@"^(\+[0-9]{6})$", "Cheque Number should contain only six numbers")]
        public string ChequeNumber { get; set; }

        /*Constructor*/
        public Transaction()
        {
            //AccountNumber = default(long);
            AccountID = default(Guid);
            Type = default(TypeOfTransaction);
            Amount = default(double);
            TransactionID = default(Guid);
            DateOfTransaction = default(DateTime);
            Mode = default(ModeOfTransaction);
            ChequeNumber = null;
        }
    }
}
