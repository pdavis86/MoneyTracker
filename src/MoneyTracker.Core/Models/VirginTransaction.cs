using CsvHelper.Configuration.Attributes;
using System;

namespace MoneyTracker.Core.Models
{
    public class VirginTransaction
    {
        [Name("Transaction Date")]
        public DateTime TransactionDate { get; set; }

        [Name("Posting Date")]
        public DateTime PostingDate { get; set; }

        [Name("Billing Amount")]
        public decimal Amount { get; set; }

        [Name("Merchant")]
        public string Merchant { get; set; }

        [Name("Merchant City")]
        public string MerchantCity { get; set; }

        [Name("Merchant State")]
        public string MerchantState { get; set; }

        [Name("Merchant Postcode")]
        public string MerchantPostcode { get; set; }

        [Name("Reference Number")]
        public string ReferenceNumber { get; set; }

        [Name("Debit or Credit")]
        public string DebitOrCredit { get; set; }

        [Name("SICMCC Code")]
        public string SicmccCode { get; set; }

        [Name("Status")]
        public string Status { get; set; }

        [Name("Transaction Currency")]
        public string TransactionCurrency { get; set; }

        [Name("Additional Card Holder")]
        public bool IsAdditionalCardHolder { get; set; }

        [Name("Card Used")]
        public int CardUsed { get; set; }
    }
}
