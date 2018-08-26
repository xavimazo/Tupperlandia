namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stocks", "Origin", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stocks", "Origin");
        }
    }
}
