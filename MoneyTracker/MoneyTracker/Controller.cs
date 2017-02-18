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
            return false;
        }

        public static bool WritePaySlip(PaySlip paySlip)
        {
            try
            {
                using (var db = new Context(_connStr))
                {
                    db.PaySlips.Add(paySlip);
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
            return false;
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

    }
}
