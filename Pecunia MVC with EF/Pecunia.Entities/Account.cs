//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Capgemini.Pecunia.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Account()
        {
            this.Transactions = new HashSet<Transaction>();
        }
    
        public System.Guid AccountID { get; set; }
        public Nullable<long> AccountNumber { get; set; }
        public string HomeBranch { get; set; }
        public string Feedback { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> DateOfCreation { get; set; }
        public string AccountType { get; set; }
        public Nullable<decimal> AccountBalance { get; set; }
        public Nullable<System.Guid> CustomerID { get; set; }
    
        public virtual Customer Customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
