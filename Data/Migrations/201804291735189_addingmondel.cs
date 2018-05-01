namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingmondel : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Stocks", "ProductId");
            AddForeignKey("dbo.Stocks", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stocks", "ProductId", "dbo.Products");
            DropIndex("dbo.Stocks", new[] { "ProductId" });
        }
    }
}
