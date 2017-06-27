namespace InventoryDash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedNumPortions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ingredient", "NumPortions", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ingredient", "NumPortions");
        }
    }
}
