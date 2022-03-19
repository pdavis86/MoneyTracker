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
            var spacePos = CounterParty.IndexOf(" ");
            var firstWord = spacePos == -1 ? CounterParty : CounterParty.Substring(0, spacePos - 1);

            return Reference.ToLower().Contains(firstWord.ToLower())
                ? Reference
                : CounterParty + ", " + Reference;
        }

    }
}
