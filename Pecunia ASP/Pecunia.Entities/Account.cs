using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capgemini.Pecunia.Helper;


namespace Capgemini.Pecunia.Entities
{
    public enum AccountType
    {
        Savings = 0,
        Current = 1,
    }

   public interface IAccount
    {
        Guid AccountID { get; set; }
        long AccountNo { get; set; }
        Guid CustomerID { get; set; }
         DateTime DateOfCreation { get; set; }
     string HomeBranch { get; set; }
        string Feedback { get; set; }
        bool IsActive { get; set; }
    }

    [Serializable]
    public class Account : IAccount
    {

        public Guid AccountID { get; set; }
        public long AccountNo { get; set; }
        public Guid CustomerID { get; set; }
        public double Balance { get;set ; }
        public DateTime DateOfCreation { get; set; }
        [Required("Home Branch CAnnot Be Blank")]
        [RegExp("[a-zA-Z]{1,20}$", "Distributor Name should contain only 1 to 20 characters.")]
        public string HomeBranch { get ; set ; }

        public string Feedback { get;set; }

        [Required("Account Type CAnnot Be Blank CAnnot Be Blank")]
        public AccountType _accType;

        public bool IsActive { get; set; }

    }

   public interface IFixedDeposit 
    {
      double FdDeposit { get; set; }
     int tenure { set; get; }
        double InterestRate { get; set; }
    }
    public class FixedDeposit : IFixedDeposit ,IAccount
    {
        public double InterestRate { get; set; }
        public Guid AccountID { get; set; }
        public long AccountNo { get; set; }
        public Guid CustomerID { get; set; }
        public DateTime DateOfCreation { get; set; }


        [Required("Home Branch CAnnot Be Blank")]
        [RegExp("[a-zA-Z]{1,20}$", "Distributor Name should contain only 1 to 20 characters.")]
        public string HomeBranch { get; set; }

        public string Feedback { get; set ; }
        public bool IsActive { get; set; }

        [Required("FD Deposit CAnnot Be Blank")]
        public double FdDeposit { get; set; }


        public int tenure { set; get; }

    }
}
