namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class key3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Stocks", "ProductId", "dbo.Products");
            DropIndex("dbo.Stocks", new[] { "ProductId" });
            AlterColumn("dbo.Stocks", "ProductId", c => c.Int());
            CreateIndex("dbo.Stocks", "ProductId");
            AddForeignKey("dbo.Stocks", "ProductId", "dbo.Products", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stocks", "ProductId", "dbo.Products");
            DropIndex("dbo.Stocks", new[] { "ProductId" });
            AlterColumn("dbo.Stocks", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.Stocks", "ProductId");
            AddForeignKey("dbo.Stocks", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
