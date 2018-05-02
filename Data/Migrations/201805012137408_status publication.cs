namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class statuspublication : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stocks", "StatusId", c => c.Int());
            CreateIndex("dbo.Stocks", "StatusId");
            AddForeignKey("dbo.Stocks", "StatusId", "dbo.PublicationStatus", "Id");
            DropColumn("dbo.Stocks", "State");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stocks", "State", c => c.String());
            DropForeignKey("dbo.Stocks", "StatusId", "dbo.PublicationStatus");
            DropIndex("dbo.Stocks", new[] { "StatusId" });
            DropColumn("dbo.Stocks", "StatusId");
        }
    }
}
