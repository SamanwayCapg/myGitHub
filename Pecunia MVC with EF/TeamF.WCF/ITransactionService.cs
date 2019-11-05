using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TeamF.WCF
{

    //Creating interface
    [ServiceContract]
    public interface ITransactionService
    {

        [OperationContract]
        List<TransactionDataContract> GetAllTransactions();
        [OperationContract]
        List<EmployeeDataContract> GetAllEmployees();
        [OperationContract]
        List<CustomersDataContract> GetAllCustomers();
        [OperationContract]
        List<AccountDataContract> GetAllAccounts();
        [OperationContract]
        List<CarLoanDataContract> ListAllLoansBL();

    }


    // Using the data contract to add composite types to service operations.
    [DataContract]
    public class TransactionDataContract
    {

        [DataMember]
        public System.Guid TransactionID { get; set; }

        [DataMember]
        public System.Guid AccountID { get; set; }

        [DataMember]
        public string TypeOfTransaction { get; set; }

        [DataMember]
        public decimal Amount { get; set; }

        [DataMember]
        public System.DateTime DateOfTransaction { get; set; }

        [DataMember]
        public string Mode { get; set; }

        [DataMember]
        public string ChequeNumber { get; set; }

    }
    [DataContract]
    public class EmployeeDataContract
    {

        [DataMember]
        public Guid EmployeeID { get; set; }

        [DataMember]
        public string EmployeeName { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Mobile { get; set; }

        [DataMember]
        public DateTime CreationDateTime { get; set; }

        [DataMember]
        public DateTime LastModifiedDateTime { get; set; }

    }
    [DataContract]
    public class CustomersDataContract
    {

        [DataMember]
        public System.Guid CustomerID { get; set; }


        [DataMember]
        public string CustomerName { get; set; }

        [DataMember]
        public string CustomerAddress { get; set; }

        [DataMember]
        public string CustomerMobile { get; set; }

        [DataMember]
        public string CustomerEmail { get; set; }

        [DataMember]
        public string CustomerPan { get; set; }

        [DataMember]
        public string CustomerAadhaar { get; set; }

        [DataMember]
        public DateTime DOB { get; set; }

        [DataMember]
        public string CustomerGender { get; set; }

    }
    [DataContract]
    public class AccountDataContract
    {
        [DataMember]
        public System.Guid AccountID { get; set; }
        [DataMember]
        public Nullable<long> AccountNumber { get; set; }
        [DataMember]
        public string HomeBranch { get; set; }
        [DataMember]
        public string Feedback { get; set; }
        [DataMember]
        public Nullable<bool> IsActive { get; set; }
        [DataMember]
        public Nullable<System.DateTime> DateOfCreation { get; set; }
        [DataMember]
        public string AccountType { get; set; }
        [DataMember]
        public Nullable<decimal> AccountBalance { get; set; }
        [DataMember]
        public Nullable<System.Guid> CustomerID { get; set; }
    }

    [DataContract]
    public class CarLoanDataContract
    {
        [DataMember]
        public Guid LoanID { get; set; } // system generated 

        [DataMember]
        public Guid CustomerID { get; set; } //user input 

        [DataMember]
        public decimal? AmountApplied { get; set; } // user input 

        [DataMember]
        public decimal? InterestRate { get; set; } // system fixed 

        [DataMember]
        public decimal? EMI_Amount { get; set; } // system computed 

        [DataMember]
        public byte? RepaymentPeriod { get; set; } //user input 

        [DataMember]
        public DateTime? DateOfApplication { get; set; } //system generated 

        [DataMember]
        public string Status { get; set; } // system determined 

        [DataMember]
        public string Occupation { get; set; } //user input 

        [DataMember]
        public decimal? GrossIncome { get; set; } //user input 

        [DataMember]
        public decimal? SalaryDeductions { get; set; } //user input 

        [DataMember]
        public string Vehicle { get; set; } //user input 
    }
}
