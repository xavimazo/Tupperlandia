namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingpublicationstatuses : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StockVariations", "StockId", "dbo.Stocks");
            DropForeignKey("dbo.Variations", "VariationSizes_Id", "dbo.VariationSizes");
            DropForeignKey("dbo.Variations", "VariationTypes_Id", "dbo.VariationTypes");
            DropForeignKey("dbo.StockVariations", "VariationId", "dbo.Variations");
            DropIndex("dbo.StockVariations", new[] { "StockId" });
            DropIndex("dbo.StockVariations", new[] { "VariationId" });
            DropIndex("dbo.Variations", new[] { "VariationSizes_Id" });
            DropIndex("dbo.Variations", new[] { "VariationTypes_Id" });
            CreateTable(
                "dbo.PublicationStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.StockVariations");
            DropTable("dbo.Variations");
            DropTable("dbo.VariationSizes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.VariationSizes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Diameter = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Height = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Width = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Length = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Variations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VariationsTypeId = c.Int(nullable: false),
                        Value = c.String(),
                        VariationSizes_Id = c.Int(),
                        VariationTypes_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StockVariations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StockId = c.Int(nullable: false),
                        VariationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.PublicationStatus");
            CreateIndex("dbo.Variations", "VariationTypes_Id");
            CreateIndex("dbo.Variations", "VariationSizes_Id");
            CreateIndex("dbo.StockVariations", "VariationId");
            CreateIndex("dbo.StockVariations", "StockId");
            AddForeignKey("dbo.StockVariations", "VariationId", "dbo.Variations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Variations", "VariationTypes_Id", "dbo.VariationTypes", "Id");
            AddForeignKey("dbo.Variations", "VariationSizes_Id", "dbo.VariationSizes", "Id");
            AddForeignKey("dbo.StockVariations", "StockId", "dbo.Stocks", "Id", cascadeDelete: true);
        }
    }
}
