using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyTrackerDataModel.Contexts;
using MoneyTrackerDataModel.Entities;
using System.Data.SqlClient;

namespace MoneyTrackerTemp
{
    class Program
    {

        static string _connStr;

        static void Main(string[] args)
        {

            _connStr = "name=Testing Database";
            //_connStr = "name=Personal Database";
            //SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(GetConnectionString());
            //_connStr = builder.ToString();

            //InsertSomeData();
            GetSomeData();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
        }

        static void InsertSomeData()
        {
            try
            {
                bool setupAdminTables = false;

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

                using (var db = new Context(_connStr))
                {
                    if (setupAdminTables)
                    {
                        db.Accounts.Add(new Account { AccountId = 1, Description = "My Account" });
                        db.TransactionTypes.Add(new TransactionType { TypeId = 1, Description = "My Type" });
                        db.Categories.Add(new TransactionCategory { Description = "Category 1" });
                        db.Categories.Add(new TransactionCategory { Description = "Category 2" });
                        db.SaveChanges();
                    }
                    db.Transactions.Add(transaction1);
                    db.Transactions.Add(transaction2);
                    db.SaveChanges();
                }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex1)
            {
                foreach (var eve in ex1.EntityValidationErrors)
                {
                    foreach (var ve in eve.ValidationErrors)
                    {
                        var face = eve.Entry.Entity.ToString() + " had error: " + ve.ErrorMessage;
                    }
                }

            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex2)
            {
                var actualException = ex2.InnerException.InnerException;
                System.Diagnostics.Debugger.Break();
            }
        }

        static void GetSomeData()
        {
            using (var db = new Context(_connStr))
            {
                try
                {
                    var query = (from t in db.Transactions orderby t.TransactionId select t).ToList(); //.ToList() is necessary to avoid recalling the query
                    foreach (var row in query)
                    {
                        Console.WriteLine(row.TransactionId);
                        //Console.WriteLine(row.Category.CategoryId);
                    }
                }
                catch (System.Data.Entity.Core.EntityCommandExecutionException ex)
                {
                    var actualException = ex.InnerException;
                }

            }
        }
    }
}
