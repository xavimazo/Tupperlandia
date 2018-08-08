namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class x : DbMigration
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
                        SendAdrress = c.String(),
                        SendDescription = c.String(),
                        DNI = c.Int(nullable: false),
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
                        Contact = c.Int(nullable: false),
                        Contact2 = c.Int(nullable: false),
                        AddressStreet = c.String(),
                        AddressNumber = c.Int(nullable: false),
                        AddressDepartment = c.Int(nullable: false),
                        AddressFlat = c.String(),
                        City = c.String(),
                        Province = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Dispatches",
                c => new
                    {
                        DispatchId = c.Int(nullable: false, identity: true),
                        DispatchDescription = c.String(),
                    })
                .PrimaryKey(t => t.DispatchId);
            
            CreateTable(
                "dbo.Lines",
                c => new
                    {
                        LineId = c.Int(nullable: false, identity: true),
                        LineDescription = c.String(),
                    })
                .PrimaryKey(t => t.LineId);
            
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
                        CategorieId = c.Int(),
                        LineId = c.Int(),
                        StockStatusId = c.Int(),
                    })
                .PrimaryKey(t => t.StockId)
                .ForeignKey("dbo.Categories", t => t.CategorieId)
                .ForeignKey("dbo.Lines", t => t.LineId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.StockStatus", t => t.StockStatusId)
                .Index(t => t.ProductId)
                .Index(t => t.CategorieId)
                .Index(t => t.LineId)
                .Index(t => t.StockStatusId);
            
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
                .ForeignKey("dbo.Dispatches", t => t.DispatchId)
                .Index(t => t.DispatchId);
            
            CreateTable(
                "dbo.StockStatus",
                c => new
                    {
                        StockStatusId = c.Int(nullable: false, identity: true),
                        StockStatusDescription = c.String(),
                    })
                .PrimaryKey(t => t.StockStatusId);
            
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
            DropForeignKey("dbo.Stocks", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Stocks", "LineId", "dbo.Lines");
            DropForeignKey("dbo.Stocks", "CategorieId", "dbo.Categories");
            DropForeignKey("dbo.Clients", "UserId", "dbo.Users");
            DropIndex("dbo.ShoppingCartStocks", new[] { "Stock_StockId" });
            DropIndex("dbo.ShoppingCartStocks", new[] { "ShoppingCart_CartId" });
            DropIndex("dbo.ShoppingCarts", new[] { "DispatchId" });
            DropIndex("dbo.Stocks", new[] { "StockStatusId" });
            DropIndex("dbo.Stocks", new[] { "LineId" });
            DropIndex("dbo.Stocks", new[] { "CategorieId" });
            DropIndex("dbo.Stocks", new[] { "ProductId" });
            DropIndex("dbo.Clients", new[] { "UserId" });
            DropTable("dbo.ShoppingCartStocks");
            DropTable("dbo.StockStatus");
            DropTable("dbo.ShoppingCarts");
            DropTable("dbo.Stocks");
            DropTable("dbo.Products");
            DropTable("dbo.Lines");
            DropTable("dbo.Dispatches");
            DropTable("dbo.Users");
            DropTable("dbo.Clients");
            DropTable("dbo.Categories");
        }
    }
}
