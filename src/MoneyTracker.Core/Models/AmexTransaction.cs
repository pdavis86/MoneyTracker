using CsvHelper.Configuration.Attributes;
using System;

namespace MoneyTracker.Core.Models
{
    public class AmexTransaction
    {
        [Name("Date")]
        public DateTime Date { get; set; }

        [Name("Description")]
        public string Description { get; set; }

        [Name("Card Member")]
        public string CardMember { get; set; }

        [Name("Account #")]
        public string AccountReference { get; set; }

        [Name("Amount")]
        public decimal Amount { get; set; }
    }
}
