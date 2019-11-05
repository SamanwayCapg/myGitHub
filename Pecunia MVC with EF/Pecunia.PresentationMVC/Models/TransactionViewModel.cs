using Capgemini.Pecunia.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcTransaction.Models
{
    public class TransactionViewModel
    {
        
        public System.Guid TransactionID { get; set; } //system generated primary key

        [Required(ErrorMessage = "Account ID can't be blank")]
        [RegularExpression("^[0-9a-fA-F-]{36}$", ErrorMessage ="Invalid Account ID")]
        public System.Guid? AccountID { get; set; } //user input
        public string TypeOfTransaction { get; set; } //user input

        [Required(ErrorMessage = "Amount value can't be blank")]
        [Range(0 ,50000, ErrorMessage ="Enter valid amount")]
        public decimal? Amount { get; set; } //user input

        public string Mode { get; set; } //user input

        [Required(ErrorMessage = "Cheque Number can't be blank")]
        [RegularExpression("^[0-9]{6}$", ErrorMessage ="Enter valid Cheque number of 6 digits")]
        [Range(0, 999999)]
        public string ChequeNumber { get; set; } //user input
        public DateTime? DateOfTransaction { get; set; }
        
    }

    
}