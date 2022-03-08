using System;

namespace BankApp.Models
{
    public class TransactionModel
    {
        public DateTime Date { get; set; }
        public bool IsDebit { get; set; }
        public decimal Amount { get; set; }
        public string Details { get; set; }
    }
}
