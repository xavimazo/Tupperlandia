namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correccionClientUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "Contact", c => c.Int(nullable: false));
            AddColumn("dbo.Clients", "Contact2", c => c.Int(nullable: false));
            AddColumn("dbo.Clients", "AddressStreet", c => c.String());
            AddColumn("dbo.Clients", "AddressNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Clients", "AddressDepartment", c => c.Int(nullable: false));
            AddColumn("dbo.Clients", "AddressFlat", c => c.String());
            AddColumn("dbo.Clients", "City", c => c.String());
            AddColumn("dbo.Clients", "Province", c => c.String());
            DropColumn("dbo.Users", "Contact");
            DropColumn("dbo.Users", "Contact2");
            DropColumn("dbo.Users", "AddressStreet");
            DropColumn("dbo.Users", "AddressNumber");
            DropColumn("dbo.Users", "AddressDepartment");
            DropColumn("dbo.Users", "AddressFlat");
            DropColumn("dbo.Users", "City");
            DropColumn("dbo.Users", "Province");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Province", c => c.String());
            AddColumn("dbo.Users", "City", c => c.String());
            AddColumn("dbo.Users", "AddressFlat", c => c.String());
            AddColumn("dbo.Users", "AddressDepartment", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "AddressNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "AddressStreet", c => c.String());
            AddColumn("dbo.Users", "Contact2", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Contact", c => c.Int(nullable: false));
            DropColumn("dbo.Clients", "Province");
            DropColumn("dbo.Clients", "City");
            DropColumn("dbo.Clients", "AddressFlat");
            DropColumn("dbo.Clients", "AddressDepartment");
            DropColumn("dbo.Clients", "AddressNumber");
            DropColumn("dbo.Clients", "AddressStreet");
            DropColumn("dbo.Clients", "Contact2");
            DropColumn("dbo.Clients", "Contact");
        }
    }
}
