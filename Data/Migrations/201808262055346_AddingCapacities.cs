namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingCapacities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Capacities",
                c => new
                    {
                        CapacityId = c.Int(nullable: false, identity: true),
                        CapacityDescription = c.String(),
                    })
                .PrimaryKey(t => t.CapacityId);
            
            AddColumn("dbo.Stocks", "CapacityId", c => c.Int());
            CreateIndex("dbo.Stocks", "CapacityId");
            AddForeignKey("dbo.Stocks", "CapacityId", "dbo.Capacities", "CapacityId");
            DropColumn("dbo.Stocks", "Capacity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stocks", "Capacity", c => c.Decimal(precision: 18, scale: 2));
            DropForeignKey("dbo.Stocks", "CapacityId", "dbo.Capacities");
            DropIndex("dbo.Stocks", new[] { "CapacityId" });
            DropColumn("dbo.Stocks", "CapacityId");
            DropTable("dbo.Capacities");
        }
    }
}
