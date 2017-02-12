using MoneyTrackerDataModel.Contexts;
using MoneyTrackerDataModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MoneyTracker
{
    static class Controller
    {

        public const string DATEFORMAT_DISPLAY = "dd/MM/yyyy";

        private static string _connStr;

        public static void SetDataSource(string nameOrConnStr)
        {
            _connStr = nameOrConnStr;
        }

        public static List<AutoAllocation> GetAutoAllocations()
        {
            using (var db = new Context(_connStr))
            {
                //return (from aa in db.AutoAllocations select aa).ToList();
                //return db.AutoAllocations.Select(aa => aa).ToList();
                return db.AutoAllocations.ToList();

                //try
                //{

                //}
                //catch (System.Data.Entity.Core.EntityCommandExecutionException ex)
                //{
                //    var actualException = ex.InnerException;
                //}

            }
        }

        public static List<TransactionType> GetTransactionTypes()
        {
            using (var db = new Context(_connStr))
            {
                return db.TransactionTypes.ToList();
            }
        }

        public static List<TransactionCategory> GetTransactionCategories()
        {
            using (var db = new Context(_connStr))
            {
                return db.Categories.ToList();
            }
        }

        public static List<Account> GetAccounts()
        {
            using (var db = new Context(_connStr))
            {
                return db.Accounts.ToList();
            }
        }

        public static bool WriteToDatabase(List<Transaction> transData)
        {
            try
            {
                using (var db = new Context(_connStr))
                {
                    foreach (Transaction trans in transData)
                    {
                        db.Transactions.Add(trans);
                    }
                    db.SaveChanges();
                }
                return true;
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
            return false;
        }

        //public static List<Transaction> GetTransactions(Expression<Func<Transaction,bool>> predicate)
        //{
        //    using (var db = new Context(_connStr))
        //    {
        //        return db.Transactions..Where(predicate).ToList();
        //    }
        //}

        public static DateTime? GetMaxTransactionDate(int accountId)
        {
            using (var db = new Context(_connStr))
            {
                var trans = db.Transactions.Where(t => t.AccountId == accountId);
                if (trans.Count() > 0 )
                {
                    return trans.Max(t => t.Date);
                }
                else
                {
                    return null;
                }
            }
        }

    }
}
