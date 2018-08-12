namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingClientName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "ClientName", c => c.String());
            AddColumn("dbo.Clients", "ClientLastName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clients", "ClientLastName");
            DropColumn("dbo.Clients", "ClientName");
        }
    }
}
