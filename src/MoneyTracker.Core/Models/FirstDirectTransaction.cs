using System;

namespace MoneyTracker.Core.Models
{
    public class FirstDirectTransaction
    {
        public DateTime Date { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public decimal Balance { get; set; }
    }
}
