namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingFullDescriptionClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductFullDescriptions",
                c => new
                    {
                        ProductFullDescriptionId = c.Int(nullable: false, identity: true),
                        FullDescription = c.String(),
                    })
                .PrimaryKey(t => t.ProductFullDescriptionId);
            
            CreateTable(
                "dbo.ProductFullDescriptionProducts",
                c => new
                    {
                        ProductFullDescription_ProductFullDescriptionId = c.Int(nullable: false),
                        Product_ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductFullDescription_ProductFullDescriptionId, t.Product_ProductId })
                .ForeignKey("dbo.ProductFullDescriptions", t => t.ProductFullDescription_ProductFullDescriptionId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_ProductId, cascadeDelete: true)
                .Index(t => t.ProductFullDescription_ProductFullDescriptionId)
                .Index(t => t.Product_ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductFullDescriptionProducts", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductFullDescriptionProducts", "ProductFullDescription_ProductFullDescriptionId", "dbo.ProductFullDescriptions");
            DropIndex("dbo.ProductFullDescriptionProducts", new[] { "Product_ProductId" });
            DropIndex("dbo.ProductFullDescriptionProducts", new[] { "ProductFullDescription_ProductFullDescriptionId" });
            DropTable("dbo.ProductFullDescriptionProducts");
            DropTable("dbo.ProductFullDescriptions");
        }
    }
}
