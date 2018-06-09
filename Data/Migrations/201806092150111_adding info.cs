namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addinginfo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clients", "Sale_Id", "dbo.Sales");
            DropForeignKey("dbo.Products", "Sale_Id", "dbo.Sales");
            DropIndex("dbo.Clients", new[] { "Sale_Id" });
            DropIndex("dbo.Products", new[] { "Sale_Id" });
            AddColumn("dbo.Sales", "Client", c => c.String());
            AddColumn("dbo.Sales", "ProductAndCapacity", c => c.String());
            AddColumn("dbo.Sales", "Date", c => c.String());
            DropColumn("dbo.Clients", "SocialClient");
            DropColumn("dbo.Clients", "Sale_Id");
            DropColumn("dbo.Products", "Sale_Id");
            DropColumn("dbo.Sales", "SaleDate");
            DropColumn("dbo.Sales", "SaleAmount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sales", "SaleAmount", c => c.String());
            AddColumn("dbo.Sales", "SaleDate", c => c.String());
            AddColumn("dbo.Products", "Sale_Id", c => c.Int());
            AddColumn("dbo.Clients", "Sale_Id", c => c.Int());
            AddColumn("dbo.Clients", "SocialClient", c => c.String());
            DropColumn("dbo.Sales", "Date");
            DropColumn("dbo.Sales", "ProductAndCapacity");
            DropColumn("dbo.Sales", "Client");
            CreateIndex("dbo.Products", "Sale_Id");
            CreateIndex("dbo.Clients", "Sale_Id");
            AddForeignKey("dbo.Products", "Sale_Id", "dbo.Sales", "Id");
            AddForeignKey("dbo.Clients", "Sale_Id", "dbo.Sales", "Id");
        }
    }
}
