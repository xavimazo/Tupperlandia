namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategorieId = c.Int(nullable: false, identity: true),
                        CategorieDescription = c.String(),
                    })
                .PrimaryKey(t => t.CategorieId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        ClientName = c.String(),
                        ClientLastName = c.String(),
                        SendAdditionalDescription = c.String(),
                        DNI = c.Int(nullable: false),
                        Contact = c.Int(nullable: false),
                        Contact2 = c.Int(),
                        AddressStreet = c.String(),
                        AddressNumber = c.Int(),
                        AddressDepartment = c.Int(),
                        AddressFlat = c.String(),
                        City = c.String(),
                        Province = c.String(),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.ClientId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Descriptions",
                c => new
                    {
                        DescriptionId = c.Int(nullable: false, identity: true),
                        DescriptionText = c.String(),
                        DescriptionTitle = c.String(),
                    })
                .PrimaryKey(t => t.DescriptionId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        ProductComposition = c.String(),
                        FullDescription = c.String(),
                        ShortDescription = c.String(),
                        Recomendations = c.String(),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        StockId = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Color = c.String(),
                        Weight = c.Decimal(precision: 18, scale: 2),
                        Lenght = c.Decimal(precision: 18, scale: 2),
                        Width = c.Decimal(precision: 18, scale: 2),
                        Height = c.Decimal(precision: 18, scale: 2),
                        Diameter = c.Decimal(precision: 18, scale: 2),
                        Capacity = c.Decimal(precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        Image = c.String(),
                        ProductId = c.Int(),
                        DiscountId = c.Int(),
                        CategorieId = c.Int(),
                        LineId = c.Int(),
                        StockStatusId = c.Int(),
                    })
                .PrimaryKey(t => t.StockId)
                .ForeignKey("dbo.Categories", t => t.CategorieId)
                .ForeignKey("dbo.Discounts", t => t.DiscountId)
                .ForeignKey("dbo.Lines", t => t.LineId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.StockStatus", t => t.StockStatusId)
                .Index(t => t.ProductId)
                .Index(t => t.DiscountId)
                .Index(t => t.CategorieId)
                .Index(t => t.LineId)
                .Index(t => t.StockStatusId);
            
            CreateTable(
                "dbo.Discounts",
                c => new
                    {
                        DiscountId = c.Int(nullable: false, identity: true),
                        DiscountPercentage = c.Int(),
                    })
                .PrimaryKey(t => t.DiscountId);
            
            CreateTable(
                "dbo.Lines",
                c => new
                    {
                        LineId = c.Int(nullable: false, identity: true),
                        LineDescription = c.String(),
                    })
                .PrimaryKey(t => t.LineId);
            
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        CartId = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        CartDate = c.String(),
                        DispatchId = c.Int(),
                        ClientId = c.Int(),
                    })
                .PrimaryKey(t => t.CartId)
                .ForeignKey("dbo.Clients", t => t.ClientId)
                .ForeignKey("dbo.Dispatches", t => t.DispatchId)
                .Index(t => t.DispatchId)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Dispatches",
                c => new
                    {
                        DispatchId = c.Int(nullable: false, identity: true),
                        DispatchDescription = c.String(),
                    })
                .PrimaryKey(t => t.DispatchId);
            
            CreateTable(
                "dbo.StockStatus",
                c => new
                    {
                        StockStatusId = c.Int(nullable: false, identity: true),
                        StockStatusDescription = c.String(),
                    })
                .PrimaryKey(t => t.StockStatusId);
            
            CreateTable(
                "dbo.ProductDescriptions",
                c => new
                    {
                        Product_ProductId = c.Int(nullable: false),
                        Description_DescriptionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_ProductId, t.Description_DescriptionId })
                .ForeignKey("dbo.Products", t => t.Product_ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Descriptions", t => t.Description_DescriptionId, cascadeDelete: true)
                .Index(t => t.Product_ProductId)
                .Index(t => t.Description_DescriptionId);
            
            CreateTable(
                "dbo.ShoppingCartStocks",
                c => new
                    {
                        ShoppingCart_CartId = c.Int(nullable: false),
                        Stock_StockId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ShoppingCart_CartId, t.Stock_StockId })
                .ForeignKey("dbo.ShoppingCarts", t => t.ShoppingCart_CartId, cascadeDelete: true)
                .ForeignKey("dbo.Stocks", t => t.Stock_StockId, cascadeDelete: true)
                .Index(t => t.ShoppingCart_CartId)
                .Index(t => t.Stock_StockId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stocks", "StockStatusId", "dbo.StockStatus");
            DropForeignKey("dbo.ShoppingCartStocks", "Stock_StockId", "dbo.Stocks");
            DropForeignKey("dbo.ShoppingCartStocks", "ShoppingCart_CartId", "dbo.ShoppingCarts");
            DropForeignKey("dbo.ShoppingCarts", "DispatchId", "dbo.Dispatches");
            DropForeignKey("dbo.ShoppingCarts", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Stocks", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Stocks", "LineId", "dbo.Lines");
            DropForeignKey("dbo.Stocks", "DiscountId", "dbo.Discounts");
            DropForeignKey("dbo.Stocks", "CategorieId", "dbo.Categories");
            DropForeignKey("dbo.ProductDescriptions", "Description_DescriptionId", "dbo.Descriptions");
            DropForeignKey("dbo.ProductDescriptions", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.Clients", "UserId", "dbo.Users");
            DropIndex("dbo.ShoppingCartStocks", new[] { "Stock_StockId" });
            DropIndex("dbo.ShoppingCartStocks", new[] { "ShoppingCart_CartId" });
            DropIndex("dbo.ProductDescriptions", new[] { "Description_DescriptionId" });
            DropIndex("dbo.ProductDescriptions", new[] { "Product_ProductId" });
            DropIndex("dbo.ShoppingCarts", new[] { "ClientId" });
            DropIndex("dbo.ShoppingCarts", new[] { "DispatchId" });
            DropIndex("dbo.Stocks", new[] { "StockStatusId" });
            DropIndex("dbo.Stocks", new[] { "LineId" });
            DropIndex("dbo.Stocks", new[] { "CategorieId" });
            DropIndex("dbo.Stocks", new[] { "DiscountId" });
            DropIndex("dbo.Stocks", new[] { "ProductId" });
            DropIndex("dbo.Clients", new[] { "UserId" });
            DropTable("dbo.ShoppingCartStocks");
            DropTable("dbo.ProductDescriptions");
            DropTable("dbo.StockStatus");
            DropTable("dbo.Dispatches");
            DropTable("dbo.ShoppingCarts");
            DropTable("dbo.Lines");
            DropTable("dbo.Discounts");
            DropTable("dbo.Stocks");
            DropTable("dbo.Products");
            DropTable("dbo.Descriptions");
            DropTable("dbo.Users");
            DropTable("dbo.Clients");
            DropTable("dbo.Categories");
        }
    }
}
