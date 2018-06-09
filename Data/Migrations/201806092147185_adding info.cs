namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addinginfo : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Clients", new[] { "Sale_Id" });
            DropIndex("dbo.Products", new[] { "Sale_Id" });
            RenameColumn(table: "dbo.Sales", name: "Sale_Id", newName: "Client_Id");
            RenameColumn(table: "dbo.Sales", name: "Sale_Id", newName: "Product_Id");
            CreateTable(
                "dbo.Dispatches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DispatchType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Sales", "SaleUnits", c => c.Int(nullable: false));
            AddColumn("dbo.Sales", "Dispatch_Id", c => c.Int());
            AddColumn("dbo.Sales", "Stock_Id", c => c.Int());
            CreateIndex("dbo.Sales", "Client_Id");
            CreateIndex("dbo.Sales", "Dispatch_Id");
            CreateIndex("dbo.Sales", "Product_Id");
            CreateIndex("dbo.Sales", "Stock_Id");
            AddForeignKey("dbo.Sales", "Dispatch_Id", "dbo.Dispatches", "Id");
            AddForeignKey("dbo.Sales", "Stock_Id", "dbo.Stocks", "Id");
            DropColumn("dbo.Clients", "Sale_Id");
            DropColumn("dbo.Products", "Sale_Id");
            DropColumn("dbo.Sales", "Units");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sales", "Units", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Sale_Id", c => c.Int());
            AddColumn("dbo.Clients", "Sale_Id", c => c.Int());
            DropForeignKey("dbo.Sales", "Stock_Id", "dbo.Stocks");
            DropForeignKey("dbo.Sales", "Dispatch_Id", "dbo.Dispatches");
            DropIndex("dbo.Sales", new[] { "Stock_Id" });
            DropIndex("dbo.Sales", new[] { "Product_Id" });
            DropIndex("dbo.Sales", new[] { "Dispatch_Id" });
            DropIndex("dbo.Sales", new[] { "Client_Id" });
            DropColumn("dbo.Sales", "Stock_Id");
            DropColumn("dbo.Sales", "Dispatch_Id");
            DropColumn("dbo.Sales", "SaleUnits");
            DropTable("dbo.Dispatches");
            RenameColumn(table: "dbo.Sales", name: "Product_Id", newName: "Sale_Id");
            RenameColumn(table: "dbo.Sales", name: "Client_Id", newName: "Sale_Id");
            CreateIndex("dbo.Products", "Sale_Id");
            CreateIndex("dbo.Clients", "Sale_Id");
        }
    }
}
