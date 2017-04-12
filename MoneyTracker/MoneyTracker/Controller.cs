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
                return db.AutoAllocations.ToList();
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

        public static List<Employer> GetEmployers()
        {
            using (var db = new Context(_connStr))
            {
                return db.Employers.ToList();
            }
        }

        public static bool WriteTransactions(List<Transaction> transData)
        {
            using (var db = new Context(_connStr))
            {
                foreach (Transaction trans in transData)
                {
                    db.Transactions.Add(trans);
                }
                SaveChangesSafely(db);
            }
            return true;
        }

        public static bool WritePaySlip(PaySlip paySlip)
        {
            using (var db = new Context(_connStr))
            {
                db.PaySlips.Add(paySlip);
                SaveChangesSafely(db);
            }
            return true;
        }

        private static void SaveChangesSafely(Context db)
        {
            try
            {
                db.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex1)
            {
                foreach (var eve in ex1.EntityValidationErrors)
                {
                    foreach (var ve in eve.ValidationErrors)
                    {
                        var temp = eve.Entry.Entity.ToString() + " had error: " + ve.ErrorMessage;
                        System.Diagnostics.Debugger.Break();
                    }
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex2)
            {
                var actualException = ex2.InnerException.InnerException;
                System.Diagnostics.Debugger.Break();
            }
        }

        public static DateTime? GetMaxTransactionDate(int accountId)
        {
            using (var db = new Context(_connStr))
            {
                var trans = db.Transactions.Where(t => t.AccountId == accountId);
                if (trans.Count() > 0)
                {
                    return trans.Max(t => t.Date);
                }
                else
                {
                    return null;
                }
            }
        }

        public static DateTime? GetMaxPaySlipDate()
        {
            using (var db = new Context(_connStr))
            {
                var slips = db.PaySlips;
                if (slips.Count() > 0)
                {
                    return slips.Max(s => s.Date);
                }
                else
                {
                    return null;
                }
            }
        }

        public static List<Transaction> GetTransactionsNeedingAttention()
        {
            using (var db = new Context(_connStr))
            {
                return db.Transactions.Where(t => t.Category.Obsolete == true || t.CategoryId == null).ToList();
            }
        }

        public static bool SetTransactionCategory(int transactionId, int? categoryId)
        {
            using (var db = new Context(_connStr))
            {
                var trans = db.Transactions.Single(t => t.TransactionId == transactionId);
                if (trans != null && trans.CategoryId != categoryId)
                {
                    trans.CategoryId = categoryId;
                    SaveChangesSafely(db);
                    return true;
                }
                return false;
            }
        }

    }
}
