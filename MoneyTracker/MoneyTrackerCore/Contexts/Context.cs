using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MoneyTrackerDataModel.Contexts
{
    public class Context : DbContext
    {
        public Context()
             : base(@"Data Source=.\SQLEXPRESS;Initial Catalog=testing;Integrated Security=True;MultipleActiveResultSets=True")
        {
            //Connect to testing when no value supplied
        }

        public Context(string connStr) : base(connStr)
        {
            Database.SetInitializer<Context>(new MigrateDatabaseToLatestVersion<Context, Migrations.Configuration>());
        }

        public DbSet<Entities.Account> Accounts { get; set; }

        public DbSet<Entities.TransactionCategory> Categories { get; set; }

        public DbSet<Entities.TransactionType> TransactionTypes { get; set; }

        public DbSet<Entities.Employer> Employers { get; set; }

        public DbSet<Entities.PaySlip> PaySlips { get; set; }

        public DbSet<Entities.Transaction> Transactions { get; set; }

        public DbSet<Entities.AutoAllocation> AutoAllocations { get; set; }
    }
}
