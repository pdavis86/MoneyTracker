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
        public DbSet<Entities.Account> Accounts { get; set; }

        public DbSet<Entities.TransactionCategory> Categories { get; set; }

        public DbSet<Entities.TransactionType> TransactionTypes { get; set; }

        public DbSet<Entities.Employer> Employers { get; set; }

        public DbSet<Entities.PaySlip> PaySlips { get; set; }

        public DbSet<Entities.Transaction> Transactions { get; set; }

        public DbSet<Entities.AutoAllocation> AutoAllocations { get; set; }

        //public Context()
        //{
        //    //Database.SetInitializer<Context>(null);
        //}
    }
}
