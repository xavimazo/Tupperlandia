namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addinginfowithoutdispatch : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "SocialClient", c => c.String());
            AddColumn("dbo.Sales", "SaleUnits", c => c.Int(nullable: false));
            AddColumn("dbo.Sales", "SaleDate", c => c.String());
            AddColumn("dbo.Sales", "SaleAmount", c => c.String());
            AddColumn("dbo.Sales", "Client_Id", c => c.Int());
            AddColumn("dbo.Sales", "Product_Id", c => c.Int());
            AddColumn("dbo.Sales", "Stock_Id", c => c.Int());
            CreateIndex("dbo.Sales", "Client_Id");
            CreateIndex("dbo.Sales", "Product_Id");
            CreateIndex("dbo.Sales", "Stock_Id");
            AddForeignKey("dbo.Sales", "Client_Id", "dbo.Clients", "Id");
            AddForeignKey("dbo.Sales", "Product_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.Sales", "Stock_Id", "dbo.Stocks", "Id");
            DropColumn("dbo.Sales", "Client");
            DropColumn("dbo.Sales", "ProductAndCapacity");
            DropColumn("dbo.Sales", "Units");
            DropColumn("dbo.Sales", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sales", "Date", c => c.String());
            AddColumn("dbo.Sales", "Units", c => c.Int(nullable: false));
            AddColumn("dbo.Sales", "ProductAndCapacity", c => c.String());
            AddColumn("dbo.Sales", "Client", c => c.String());
            DropForeignKey("dbo.Sales", "Stock_Id", "dbo.Stocks");
            DropForeignKey("dbo.Sales", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Sales", "Client_Id", "dbo.Clients");
            DropIndex("dbo.Sales", new[] { "Stock_Id" });
            DropIndex("dbo.Sales", new[] { "Product_Id" });
            DropIndex("dbo.Sales", new[] { "Client_Id" });
            DropColumn("dbo.Sales", "Stock_Id");
            DropColumn("dbo.Sales", "Product_Id");
            DropColumn("dbo.Sales", "Client_Id");
            DropColumn("dbo.Sales", "SaleAmount");
            DropColumn("dbo.Sales", "SaleDate");
            DropColumn("dbo.Sales", "SaleUnits");
            DropColumn("dbo.Clients", "SocialClient");
        }
    }
}
