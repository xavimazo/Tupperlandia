namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyinStockproperties : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Stocks", "ProductId", "dbo.Products");
            DropIndex("dbo.Stocks", new[] { "ProductId" });
            AddColumn("dbo.Stocks", "Color", c => c.String());
            AddColumn("dbo.Stocks", "Measurements", c => c.String());
            AddColumn("dbo.Stocks", "Group", c => c.String());
            AddColumn("dbo.Stocks", "Line", c => c.String());
            AddColumn("dbo.Stocks", "State", c => c.String());
            AddColumn("dbo.Stocks", "_Stock", c => c.Int(nullable: false));
            DropColumn("dbo.Stocks", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stocks", "Quantity", c => c.Int(nullable: false));
            DropColumn("dbo.Stocks", "_Stock");
            DropColumn("dbo.Stocks", "State");
            DropColumn("dbo.Stocks", "Line");
            DropColumn("dbo.Stocks", "Group");
            DropColumn("dbo.Stocks", "Measurements");
            DropColumn("dbo.Stocks", "Color");
            CreateIndex("dbo.Stocks", "ProductId");
            AddForeignKey("dbo.Stocks", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
