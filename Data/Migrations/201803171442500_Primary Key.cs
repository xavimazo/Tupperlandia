namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrimaryKey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Variations", "VariationSizes_Id", c => c.Int());
            AddColumn("dbo.Variations", "VariationTypes_Id", c => c.Int());
            CreateIndex("dbo.ProductVariations", "ProductId");
            CreateIndex("dbo.ProductVariations", "VariationsId");
            CreateIndex("dbo.Variations", "VariationSizes_Id");
            CreateIndex("dbo.Variations", "VariationTypes_Id");
            CreateIndex("dbo.Stocks", "ProductId");
            CreateIndex("dbo.StockVariations", "StockId");
            CreateIndex("dbo.StockVariations", "VariationId");
            AddForeignKey("dbo.ProductVariations", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Variations", "VariationSizes_Id", "dbo.VariationSizes", "Id");
            AddForeignKey("dbo.Variations", "VariationTypes_Id", "dbo.VariationTypes", "Id");
            AddForeignKey("dbo.ProductVariations", "VariationsId", "dbo.Variations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Stocks", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StockVariations", "StockId", "dbo.Stocks", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StockVariations", "VariationId", "dbo.Variations", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StockVariations", "VariationId", "dbo.Variations");
            DropForeignKey("dbo.StockVariations", "StockId", "dbo.Stocks");
            DropForeignKey("dbo.Stocks", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductVariations", "VariationsId", "dbo.Variations");
            DropForeignKey("dbo.Variations", "VariationTypes_Id", "dbo.VariationTypes");
            DropForeignKey("dbo.Variations", "VariationSizes_Id", "dbo.VariationSizes");
            DropForeignKey("dbo.ProductVariations", "ProductId", "dbo.Products");
            DropIndex("dbo.StockVariations", new[] { "VariationId" });
            DropIndex("dbo.StockVariations", new[] { "StockId" });
            DropIndex("dbo.Stocks", new[] { "ProductId" });
            DropIndex("dbo.Variations", new[] { "VariationTypes_Id" });
            DropIndex("dbo.Variations", new[] { "VariationSizes_Id" });
            DropIndex("dbo.ProductVariations", new[] { "VariationsId" });
            DropIndex("dbo.ProductVariations", new[] { "ProductId" });
            DropColumn("dbo.Variations", "VariationTypes_Id");
            DropColumn("dbo.Variations", "VariationSizes_Id");
        }
    }
}
