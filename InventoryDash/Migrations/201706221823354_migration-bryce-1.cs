namespace InventoryDash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrationbryce1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WeeklyInventoryDrinks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        WeekId = c.Int(nullable: false),
                        DrinkId = c.Int(nullable: false),
                        QuantityToGo = c.Int(nullable: false),
                        QuantityDineIn = c.Int(nullable: false),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Income = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.WeeklyInventoryMain",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        WeekOfYear = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.WeeklyInventorySandwiches",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        WeekId = c.Int(nullable: false),
                        SandwichId = c.Int(nullable: false),
                        QuantityToGo = c.Int(nullable: false),
                        QuantityDineIn = c.Int(nullable: false),
                        MealId = c.Int(nullable: false),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Income = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WeeklyInventorySandwiches");
            DropTable("dbo.WeeklyInventoryMain");
            DropTable("dbo.WeeklyInventoryDrinks");
        }
    }
}
