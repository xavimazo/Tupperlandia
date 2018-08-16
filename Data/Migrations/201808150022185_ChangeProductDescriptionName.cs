namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeProductDescriptionName : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductFullDescriptionProducts", "ProductFullDescription_ProductFullDescriptionId", "dbo.ProductFullDescriptions");
            DropForeignKey("dbo.ProductFullDescriptionProducts", "Product_ProductId", "dbo.Products");
            DropIndex("dbo.ProductFullDescriptionProducts", new[] { "ProductFullDescription_ProductFullDescriptionId" });
            DropIndex("dbo.ProductFullDescriptionProducts", new[] { "Product_ProductId" });
            DropTable("dbo.ProductFullDescriptions");
            DropTable("dbo.ProductFullDescriptionProducts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductFullDescriptionProducts",
                c => new
                    {
                        ProductFullDescription_ProductFullDescriptionId = c.Int(nullable: false),
                        Product_ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductFullDescription_ProductFullDescriptionId, t.Product_ProductId });
            
            CreateTable(
                "dbo.ProductFullDescriptions",
                c => new
                    {
                        ProductFullDescriptionId = c.Int(nullable: false, identity: true),
                        FullDescription = c.String(),
                    })
                .PrimaryKey(t => t.ProductFullDescriptionId);
            
            CreateIndex("dbo.ProductFullDescriptionProducts", "Product_ProductId");
            CreateIndex("dbo.ProductFullDescriptionProducts", "ProductFullDescription_ProductFullDescriptionId");
            AddForeignKey("dbo.ProductFullDescriptionProducts", "Product_ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
            AddForeignKey("dbo.ProductFullDescriptionProducts", "ProductFullDescription_ProductFullDescriptionId", "dbo.ProductFullDescriptions", "ProductFullDescriptionId", cascadeDelete: true);
        }
    }
}
