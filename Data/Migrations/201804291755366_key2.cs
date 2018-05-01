namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class key2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Stocks", name: "ProductId", newName: "Product_Id");
            RenameIndex(table: "dbo.Stocks", name: "IX_ProductId", newName: "IX_Product_Id");
            AddColumn("dbo.Stocks", "Products_Id", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stocks", "Products_Id");
            RenameIndex(table: "dbo.Stocks", name: "IX_Product_Id", newName: "IX_ProductId");
            RenameColumn(table: "dbo.Stocks", name: "Product_Id", newName: "ProductId");
        }
    }
}
