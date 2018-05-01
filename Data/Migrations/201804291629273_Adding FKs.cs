
namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingFKs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stocks", "CantidadStock", c => c.Int(nullable: false));
            DropColumn("dbo.Stocks", "_Stock");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stocks", "_Stock", c => c.Int(nullable: false));
            DropColumn("dbo.Stocks", "CantidadStock");
        }
    }
}
