namespace MoneyTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedWorkingFromHome : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PaySlips", "WorkingFromHome", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PaySlips", "WorkingFromHome");
        }
    }
}
