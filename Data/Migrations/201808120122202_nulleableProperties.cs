namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nulleableProperties : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "Contact2", c => c.Int());
            AlterColumn("dbo.Clients", "AddressNumber", c => c.Int());
            AlterColumn("dbo.Clients", "AddressDepartment", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clients", "AddressDepartment", c => c.Int(nullable: false));
            AlterColumn("dbo.Clients", "AddressNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.Clients", "Contact2", c => c.Int(nullable: false));
        }
    }
}
