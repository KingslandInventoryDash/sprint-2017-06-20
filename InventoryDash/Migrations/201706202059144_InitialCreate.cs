namespace InventoryDash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ingredient",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        Category = c.Int(nullable: false),
                        UsedInSandwich = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Sandwich",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(),
                        Meal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SandwichIngredient",
                c => new
                    {
                        Sandwich_ID = c.Int(nullable: false),
                        Ingredient_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Sandwich_ID, t.Ingredient_ID })
                .ForeignKey("dbo.Sandwich", t => t.Sandwich_ID, cascadeDelete: true)
                .ForeignKey("dbo.Ingredient", t => t.Ingredient_ID, cascadeDelete: true)
                .Index(t => t.Sandwich_ID)
                .Index(t => t.Ingredient_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SandwichIngredient", "Ingredient_ID", "dbo.Ingredient");
            DropForeignKey("dbo.SandwichIngredient", "Sandwich_ID", "dbo.Sandwich");
            DropIndex("dbo.SandwichIngredient", new[] { "Ingredient_ID" });
            DropIndex("dbo.SandwichIngredient", new[] { "Sandwich_ID" });
            DropTable("dbo.SandwichIngredient");
            DropTable("dbo.Sandwich");
            DropTable("dbo.Ingredient");
        }
    }
}
