namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Y : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Discounts",
                c => new
                    {
                        DiscountId = c.Int(nullable: false, identity: true),
                        DiscountPercentage = c.Int(),
                    })
                .PrimaryKey(t => t.DiscountId);
            
            AddColumn("dbo.Stocks", "DiscountId", c => c.Int());
            CreateIndex("dbo.Stocks", "DiscountId");
            CreateIndex("dbo.ShoppingCarts", "ClientId");
            AddForeignKey("dbo.Stocks", "DiscountId", "dbo.Discounts", "DiscountId");
            AddForeignKey("dbo.ShoppingCarts", "ClientId", "dbo.Clients", "ClientId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingCarts", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Stocks", "DiscountId", "dbo.Discounts");
            DropIndex("dbo.ShoppingCarts", new[] { "ClientId" });
            DropIndex("dbo.Stocks", new[] { "DiscountId" });
            DropColumn("dbo.Stocks", "DiscountId");
            DropTable("dbo.Discounts");
        }
    }
}
