namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newpropertiesinSales : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "Sale_Id", c => c.Int());
            AddColumn("dbo.Products", "Sale_Id", c => c.Int());
            AddColumn("dbo.Sales", "SaleDate", c => c.String());
            AddColumn("dbo.Sales", "SaleAmount", c => c.String());
            CreateIndex("dbo.Clients", "Sale_Id");
            CreateIndex("dbo.Products", "Sale_Id");
            AddForeignKey("dbo.Clients", "Sale_Id", "dbo.Sales", "Id");
            AddForeignKey("dbo.Products", "Sale_Id", "dbo.Sales", "Id");
            DropColumn("dbo.Sales", "Client");
            DropColumn("dbo.Sales", "ProductAndCapacity");
            DropColumn("dbo.Sales", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sales", "Date", c => c.String());
            AddColumn("dbo.Sales", "ProductAndCapacity", c => c.String());
            AddColumn("dbo.Sales", "Client", c => c.String());
            DropForeignKey("dbo.Products", "Sale_Id", "dbo.Sales");
            DropForeignKey("dbo.Clients", "Sale_Id", "dbo.Sales");
            DropIndex("dbo.Products", new[] { "Sale_Id" });
            DropIndex("dbo.Clients", new[] { "Sale_Id" });
            DropColumn("dbo.Sales", "SaleAmount");
            DropColumn("dbo.Sales", "SaleDate");
            DropColumn("dbo.Products", "Sale_Id");
            DropColumn("dbo.Clients", "Sale_Id");
        }
    }
}
