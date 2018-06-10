namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingDispatch : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dispatches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DispatchType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Sales", "Dispatch_Id", c => c.Int());
            CreateIndex("dbo.Sales", "Dispatch_Id");
            AddForeignKey("dbo.Sales", "Dispatch_Id", "dbo.Dispatches", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sales", "Dispatch_Id", "dbo.Dispatches");
            DropIndex("dbo.Sales", new[] { "Dispatch_Id" });
            DropColumn("dbo.Sales", "Dispatch_Id");
            DropTable("dbo.Dispatches");
        }
    }
}
