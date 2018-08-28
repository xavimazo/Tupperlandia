namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingOriginAndColorClasses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        ColorId = c.Int(nullable: false, identity: true),
                        ColorDescription = c.String(),
                    })
                .PrimaryKey(t => t.ColorId);
            
            CreateTable(
                "dbo.Origins",
                c => new
                    {
                        OriginId = c.Int(nullable: false, identity: true),
                        OriginDescription = c.String(),
                    })
                .PrimaryKey(t => t.OriginId);
            
            AddColumn("dbo.Stocks", "ColorId", c => c.Int());
            AddColumn("dbo.Stocks", "OriginId", c => c.Int());
            CreateIndex("dbo.Stocks", "ColorId");
            CreateIndex("dbo.Stocks", "OriginId");
            AddForeignKey("dbo.Stocks", "ColorId", "dbo.Colors", "ColorId");
            AddForeignKey("dbo.Stocks", "OriginId", "dbo.Origins", "OriginId");
            DropColumn("dbo.Stocks", "Color");
            DropColumn("dbo.Stocks", "Origin");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stocks", "Origin", c => c.String());
            AddColumn("dbo.Stocks", "Color", c => c.String());
            DropForeignKey("dbo.Stocks", "OriginId", "dbo.Origins");
            DropForeignKey("dbo.Stocks", "ColorId", "dbo.Colors");
            DropIndex("dbo.Stocks", new[] { "OriginId" });
            DropIndex("dbo.Stocks", new[] { "ColorId" });
            DropColumn("dbo.Stocks", "OriginId");
            DropColumn("dbo.Stocks", "ColorId");
            DropTable("dbo.Origins");
            DropTable("dbo.Colors");
        }
    }
}
