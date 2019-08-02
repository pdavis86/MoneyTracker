namespace MoneyTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class noNeedForCategories : DbMigration
    {
        public override void Up()
        {
            AlterColumn("[dbo].[Transactions]", "CategoryId", c => c.Int(true));
        }
        
        public override void Down()
        {
            
        }
    }
}
