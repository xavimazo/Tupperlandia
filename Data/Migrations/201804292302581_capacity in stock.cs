namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class capacityinstock : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stocks", "Capacidad", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stocks", "Capacidad");
        }
    }
}
