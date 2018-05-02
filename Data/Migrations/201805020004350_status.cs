namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class status : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stocks", "DiscountId", c => c.Int());
            CreateIndex("dbo.Stocks", "DiscountId");
            AddForeignKey("dbo.Stocks", "DiscountId", "dbo.Discounts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stocks", "DiscountId", "dbo.Discounts");
            DropIndex("dbo.Stocks", new[] { "DiscountId" });
            DropColumn("dbo.Stocks", "DiscountId");
        }
    }
}
