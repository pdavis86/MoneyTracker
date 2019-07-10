using CsvHelper.Configuration.Attributes;
using System;

namespace MoneyTracker.Core.Models.CapitalOne
{
    public class Transaction
    {
        [Name("date")]
        public DateTime Date { get; set; }

        [Name("postedDate")]
        public DateTime PostedDate { get; set; }

        [Name("amount")]
        public decimal Amount { get; set; }

        [Name("description")]
        public string Description { get; set; }

        [Name("recurringPayment")]
        public bool RecurringPayment { get; set; }

        [Name("originalCurrencyAmount")]
        public decimal OriginalCurrencyAmount { get; set; }

        [Name("conversionRate")]
        public string ConversionRate { get; set; }

        [Name("type")]
        public string Type { get; set; }

        [Name("currency")]
        public string Currency { get; set; }

        [Name("debitCreditCode")]
        public string DebitCreditCode { get; set; }

        [Name("merchant.name")]
        public string MerchantName { get; set; }

        [Name("merchant.town")]
        public string MerchantTown { get; set; }

        [Name("merchant.postCode")]
        public string MerchantPostCode { get; set; }

        [Name("merchant.country")]
        public string MerchantCountry { get; set; }
    }
}
