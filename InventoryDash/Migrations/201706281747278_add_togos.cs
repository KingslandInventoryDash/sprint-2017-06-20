namespace InventoryDash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_togos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WeeklyInventoryToGos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        WeekId = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        ToGoId = c.Int(nullable: false),
                        QuantityToGo = c.Int(nullable: false),
                        QuantityDineIn = c.Int(nullable: false),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Income = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WeeklyInventoryToGos");
        }
    }
}
