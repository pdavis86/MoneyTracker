using System.Data.Entity;

namespace MoneyTracker.Data.Contexts
{
    public class Context : DbContext
    {
        public Context(string connStr) : base(connStr)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Migrations.Configuration>(true));

            ////Force an update
            //var dbMigrator = new System.Data.Entity.Migrations.DbMigrator(new Migrations.Configuration());
            //dbMigrator.Update();
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
