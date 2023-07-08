using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using MoneyTracker.Core.Models;

namespace MoneyTracker.Core.Helpers
{
    public static class ParseHelper
    {
        //private static string GetNextLine(StreamReader streamReader)
        //{
        //    return StringHelper.ReadableAsciiOnly(streamReader.ReadLine());
        //}

        public static List<FirstDirectTransaction> LoadDataFromFirstDirect(string filePath)
        {
            const string gbCultureCode = "en-GB";

            var ukDateFormat = new CultureInfo(gbCultureCode, false).DateTimeFormat;

            var transactions = new List<FirstDirectTransaction>();

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.CurrentCulture))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    var date = csv.GetField<string>("Date");

                    if (!char.IsDigit(date[0]))
                    {
                        break;
                    }

                    transactions.Add(new FirstDirectTransaction
                    {
                        Date = Convert.ToDateTime(csv.GetField<string>("Date"), ukDateFormat),
                        //Type = csv.GetField<string>("Type"),
                        Description = csv.GetField<string>("Merchant/Description"),
                        Amount = decimal.Parse(csv.GetField<string>("Debit/Credit").Replace("£", null)),
                        Balance = decimal.Parse(csv.GetField<string>("Balance").Replace("£", null))
                    });
                }
            }

            //const string gbpSuffix = " GBP";

            ////const string prefixFrom = "From:";
            ////const string prefixAccount = "Account:";
            //const string prefixDate = "Date:";
            //const string prefixDescription = "Description:";
            //const string prefixAmount = "Amount:";
            //const string prefixBalance = "Balance:";


            //using (var streamReader = new StreamReader(filePath))
            //{
            //    //Read past the first four lines
            //    streamReader.ReadLine();
            //    streamReader.ReadLine();
            //    streamReader.ReadLine();
            //    streamReader.ReadLine();

            //    while (streamReader.EndOfStream == false)
            //    {
            //        var date = GetNextLine(streamReader).Substring(prefixDate.Length + 1);
            //        var type = ;
            //        var description = GetNextLine(streamReader).Substring(prefixDescription.Length + 1);
            //        var value = GetNextLine(streamReader).Substring(prefixAmount.Length + 1).Replace(gbpSuffix, "");
            //        var balance = GetNextLine(streamReader).Substring(prefixBalance.Length + 1).Replace(gbpSuffix, "");
            //        transactions.Add(new FirstDirectTransaction
            //        {
            //            Date = Convert.ToDateTime(date, ukDateFormat),
            //            Description = description,
            //            Value = decimal.Parse(value),
            //            Balance = decimal.Parse(balance)
            //        });

            //        //Read the blank line
            //        streamReader.ReadLine();
            //    }
            //}

            return transactions;
        }

        public static List<T> LoadData<T>(string filePath)
        {
            using (var streamReader = new StreamReader(filePath))
            using (var csv = new CsvReader(streamReader, CultureInfo.CurrentCulture))
            {
                return csv.GetRecords<T>().ToList();
            }
        }

    }
}
