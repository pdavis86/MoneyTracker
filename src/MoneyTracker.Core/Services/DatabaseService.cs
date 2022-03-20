using MoneyTracker.Data.Contexts;
using MoneyTracker.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoneyTracker.Core.Services
{
    public class DatabaseService
    {
        private readonly string _connStr;

        public DatabaseService(string nameOrConnStr)
        {
            _connStr = nameOrConnStr;
        }

        public List<AutoAllocation> GetAutoAllocations()
        {
            using (var db = new Context(_connStr))
            {
                return db.AutoAllocations.ToList();
            }
        }

        public List<TransactionType> GetTransactionTypes()
        {
            using (var db = new Context(_connStr))
            {
                return db.TransactionTypes.ToList();
            }
        }

        public List<TransactionCategory> GetTransactionCategories()
        {
            using (var db = new Context(_connStr))
            {
                return db.Categories.ToList();
            }
        }

        public List<Account> GetAccounts()
        {
            using (var db = new Context(_connStr))
            {
                return db.Accounts.ToList();
            }
        }

        public List<Employer> GetEmployers()
        {
            using (var db = new Context(_connStr))
            {
                return db.Employers.ToList();
            }
        }

        public bool WriteTransactions(List<Transaction> transData)
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

        public bool WritePaySlip(PaySlip paySlip)
        {
            using (var db = new Context(_connStr))
            {
                db.PaySlips.Add(paySlip);
                SaveChangesSafely(db);
            }
            return true;
        }

        private void SaveChangesSafely(Context db)
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
                        var validationError = eve.Entry.Entity + " had error: " + ve.ErrorMessage;
                        System.Diagnostics.Debug.WriteLine(validationError);
                        System.Diagnostics.Debugger.Break();
                    }
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex2)
            {
                var actualException = ex2.InnerException?.InnerException;
                System.Diagnostics.Debug.WriteLine(actualException);
                System.Diagnostics.Debugger.Break();
            }
        }

        public DateTime? GetMaxTransactionDate(int accountId)
        {
            using (var db = new Context(_connStr))
            {
                var trans = db.Transactions.Where(t => t.AccountId == accountId);
                if (trans.Any())
                {
                    return trans.Max(t => t.Date);
                }
                else
                {
                    return null;
                }
            }
        }

        public DateTime? GetMaxPaySlipDate()
        {
            using (var db = new Context(_connStr))
            {
                var slips = db.PaySlips;
                if (slips.Any())
                {
                    return slips.Max(s => s.Date);
                }
                else
                {
                    return null;
                }
            }
        }

        public List<Transaction> GetTransactionsNeedingAttention()
        {
            using (var db = new Context(_connStr))
            {
                return db.Transactions.Where(t => t.Category.Obsolete || t.CategoryId == null).ToList();
            }
        }

        public bool SetTransactionCategory(int transactionId, int? categoryId)
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

        public List<Transaction> GetTransactionsBetween(DateTime from, DateTime to)
        {
            using (var db = new Context(_connStr))
            {
                return db.Transactions.Where(t => 
                    !t.Category.Obsolete 
                    && t.Date >= from
                    && t.Date <= to
                ).ToList();
            }
        }

    }
}
