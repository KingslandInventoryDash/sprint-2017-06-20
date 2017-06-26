namespace InventoryDash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_year_tracking : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WeeklyInventorySandwiches", "Year", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WeeklyInventorySandwiches", "Year");
        }
    }
}
