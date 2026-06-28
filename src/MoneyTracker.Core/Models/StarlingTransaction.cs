using CsvHelper.Configuration.Attributes;
using System;

namespace MoneyTracker.Core.Models
{
    public class StarlingTransaction
    {
        [Name("Date")]
        public DateTime Date { get; set; }

        [Name("Counter Party")]
        public string CounterParty { get; set; }

        [Name("Reference")]
        public string Reference { get; set; }

        [Name("Type")]
        public string Type { get; set; }

        [Name("Amount (GBP)")]
        public decimal Amount { get; set; }

        [Name("Balance (GBP)")]
        public decimal Balance { get; set; }

        [Name("Spending Category")]
        public string SpendingCategory { get; set; }

        public string Notes { get; set; }


        public string GetDesc()
        {
            var spacePos = CounterParty?.IndexOf(" ") ?? -1;
            var firstWord = spacePos < 1 ? CounterParty?.Trim() : CounterParty.Substring(0, spacePos);

            return firstWord != null 
                && Reference != null 
                && (Reference.ToLower() ?? string.Empty).Contains(firstWord.ToLower())
                ? Reference
                : CounterParty + ", " + Reference;
        }

    }
}
