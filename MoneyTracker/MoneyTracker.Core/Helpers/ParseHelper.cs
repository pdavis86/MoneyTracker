using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace MoneyTracker.Core.Helpers
{
    public static class ParseHelper
    {
        private static string GetNextLine(StreamReader streamReader)
        {
            return StringHelper.ReadableAsciiOnly(streamReader.ReadLine());
        }

        public static List<Data.Entities.Transaction> LoadDataFromSantander(string filePath)
        {
            const string gbCultureCode = "en-GB";
            const string gbpSuffix = " GBP";

            //const string prefixFrom = "From:";
            //const string prefixAccount = "Account:";
            const string prefixDate = "Date:";
            const string prefixDescription = "Description:";
            const string prefixAmount = "Amount:";
            const string prefixBalance = "Balance:";

            var transactions = new List<Data.Entities.Transaction>();
            var ukDtfi = new CultureInfo(gbCultureCode, false).DateTimeFormat;

            using (var streamReader = new StreamReader(filePath))
            {
                //Read past the first four lines
                streamReader.ReadLine();
                streamReader.ReadLine();
                streamReader.ReadLine();
                streamReader.ReadLine();

                while (streamReader.EndOfStream == false)
                {
                    var date = GetNextLine(streamReader).Substring(prefixDate.Length + 1);
                    var description = GetNextLine(streamReader).Substring(prefixDescription.Length + 1);
                    var value = GetNextLine(streamReader).Substring(prefixAmount.Length + 1).Replace(gbpSuffix, "");
                    var balance = GetNextLine(streamReader).Substring(prefixBalance.Length + 1).Replace(gbpSuffix, "");
                    transactions.Add(new Data.Entities.Transaction()
                    {
                        Date = Convert.ToDateTime(date, ukDtfi),
                        Description = description,
                        Value = decimal.Parse(value),
                        Balance = decimal.Parse(balance)
                    });

                    //Read the blank line
                    streamReader.ReadLine();
                }
            }

            return transactions;
        }

        public static List<T> LoadData<T>(string filePath)
        {
            using (var streamReader = new StreamReader(filePath))
            using (var csv = new CsvReader(streamReader))
            {
                return csv.GetRecords<T>().ToList();
            }
        }

    }
}
