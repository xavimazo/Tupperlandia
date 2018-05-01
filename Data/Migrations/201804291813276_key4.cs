namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class key4 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Stocks", name: "Product_Id", newName: "ProductId");
            RenameIndex(table: "dbo.Stocks", name: "IX_Product_Id", newName: "IX_ProductId");
            DropColumn("dbo.Stocks", "Products_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stocks", "Products_Id", c => c.Int());
            RenameIndex(table: "dbo.Stocks", name: "IX_ProductId", newName: "IX_Product_Id");
            RenameColumn(table: "dbo.Stocks", name: "ProductId", newName: "Product_Id");
        }
    }
}
