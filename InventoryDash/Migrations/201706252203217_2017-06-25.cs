namespace InventoryDash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20170625 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WeeklyInventorySandwiches", "Year", c => c.Int(nullable: false));
            AlterColumn("dbo.WeeklyInventorySandwiches", "MealId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WeeklyInventorySandwiches", "MealId", c => c.Int(nullable: false));
            DropColumn("dbo.WeeklyInventorySandwiches", "Year");
        }
    }
}
