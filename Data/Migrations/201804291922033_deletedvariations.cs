namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedvariations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductVariations", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductVariations", "VariationsId", "dbo.Variations");
            DropIndex("dbo.ProductVariations", new[] { "ProductId" });
            DropIndex("dbo.ProductVariations", new[] { "VariationsId" });
            DropTable("dbo.ProductVariations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductVariations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        VariationsId = c.Int(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.ProductVariations", "VariationsId");
            CreateIndex("dbo.ProductVariations", "ProductId");
            AddForeignKey("dbo.ProductVariations", "VariationsId", "dbo.Variations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductVariations", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
