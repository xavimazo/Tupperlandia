namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeInClient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "SendAdditionalDescription", c => c.String());
            DropColumn("dbo.Clients", "SendAdrress");
            DropColumn("dbo.Clients", "SendDescription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clients", "SendDescription", c => c.String());
            AddColumn("dbo.Clients", "SendAdrress", c => c.String());
            DropColumn("dbo.Clients", "SendAdditionalDescription");
        }
    }
}
