namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingtableproductanddescription : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductDescriptions",
                c => new
                    {
                        ProductDescriptionId = c.Int(nullable: false, identity: true),
                        PDescription = c.String(),
                    })
                .PrimaryKey(t => t.ProductDescriptionId);
            
            CreateTable(
                "dbo.ProductDescriptionProducts",
                c => new
                    {
                        ProductDescription_ProductDescriptionId = c.Int(nullable: false),
                        Product_ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductDescription_ProductDescriptionId, t.Product_ProductId })
                .ForeignKey("dbo.ProductDescriptions", t => t.ProductDescription_ProductDescriptionId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_ProductId, cascadeDelete: true)
                .Index(t => t.ProductDescription_ProductDescriptionId)
                .Index(t => t.Product_ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductDescriptionProducts", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductDescriptionProducts", "ProductDescription_ProductDescriptionId", "dbo.ProductDescriptions");
            DropIndex("dbo.ProductDescriptionProducts", new[] { "Product_ProductId" });
            DropIndex("dbo.ProductDescriptionProducts", new[] { "ProductDescription_ProductDescriptionId" });
            DropTable("dbo.ProductDescriptionProducts");
            DropTable("dbo.ProductDescriptions");
        }
    }
}
