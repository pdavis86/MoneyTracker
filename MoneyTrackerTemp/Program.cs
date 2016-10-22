using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyTrackerDataModel.Contexts;
using MoneyTrackerDataModel.Entities;

namespace MoneyTrackerTemp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Connect to (localdb)\mssqllocaldb to see what gets inserted
            InsertSomeData();
            GetSomeData();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
        }

        static void InsertSomeData()
        {
            try
            {
                bool insertCategories = false;

                var transaction1 = new Transaction
                {
                    AccountId = 1,
                    CategoryId = 1,
                    TypeId = 1,
                    Date = DateTime.Now,
                    Description = "1",
                    Value = 1
                };
                var transaction2 = new Transaction
                {
                    AccountId = 2,
                    CategoryId = 2,
                    TypeId = 2,
                    Date = DateTime.Now,
                    Description = "2",
                    Value = 2
                };

                using (var db = new Context())
                {
                    if (insertCategories)
                    {
                        db.Categories.Add(new TransactionCategory { Description = "Category 1" });
                        db.Categories.Add(new TransactionCategory { Description = "Category 2" });
                        db.SaveChanges();
                    }
                    db.Transactions.Add(transaction1);
                    db.Transactions.Add(transaction2);
                    db.SaveChanges();
                }

            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                var actualException = ex.InnerException.InnerException;
                System.Diagnostics.Debugger.Break();
            }
        }

        static void GetSomeData()
        {
            using (var db = new Context())
            {
                var query = from t in db.Transactions orderby t.TransactionId select t;
                foreach (var row in query)
                {
                    //Console.WriteLine(row.TransactionId);
                    Console.WriteLine(row.Category.CategoryId);
                }
            }
        }
    }
}
