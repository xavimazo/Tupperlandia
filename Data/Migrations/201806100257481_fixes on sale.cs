namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixesonsale : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Sales", name: "Client_Id", newName: "ClientId");
            RenameColumn(table: "dbo.Sales", name: "Dispatch_Id", newName: "DispatchId");
            RenameColumn(table: "dbo.Sales", name: "Product_Id", newName: "ProductId");
            RenameColumn(table: "dbo.Sales", name: "Stock_Id", newName: "StockId");
            RenameIndex(table: "dbo.Sales", name: "IX_Dispatch_Id", newName: "IX_DispatchId");
            RenameIndex(table: "dbo.Sales", name: "IX_Client_Id", newName: "IX_ClientId");
            RenameIndex(table: "dbo.Sales", name: "IX_Product_Id", newName: "IX_ProductId");
            RenameIndex(table: "dbo.Sales", name: "IX_Stock_Id", newName: "IX_StockId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Sales", name: "IX_StockId", newName: "IX_Stock_Id");
            RenameIndex(table: "dbo.Sales", name: "IX_ProductId", newName: "IX_Product_Id");
            RenameIndex(table: "dbo.Sales", name: "IX_ClientId", newName: "IX_Client_Id");
            RenameIndex(table: "dbo.Sales", name: "IX_DispatchId", newName: "IX_Dispatch_Id");
            RenameColumn(table: "dbo.Sales", name: "StockId", newName: "Stock_Id");
            RenameColumn(table: "dbo.Sales", name: "ProductId", newName: "Product_Id");
            RenameColumn(table: "dbo.Sales", name: "DispatchId", newName: "Dispatch_Id");
            RenameColumn(table: "dbo.Sales", name: "ClientId", newName: "Client_Id");
        }
    }
}
