namespace InventoryDash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20170623 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WeeklyInventorySandwiches", "MealId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WeeklyInventorySandwiches", "MealId", c => c.Int(nullable: false));
        }
    }
}
