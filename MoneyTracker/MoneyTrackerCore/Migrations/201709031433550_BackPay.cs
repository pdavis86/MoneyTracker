namespace MoneyTrackerDataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BackPay : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PaySlips", "BackPay", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PaySlips", "BackPay");
        }
    }
}
