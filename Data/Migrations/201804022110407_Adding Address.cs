namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "Calle", c => c.String());
            AddColumn("dbo.Clients", "Localidad", c => c.String());
            AddColumn("dbo.Clients", "Numeracion", c => c.Int(nullable: false));
            AddColumn("dbo.Clients", "Departamento", c => c.String());
            AddColumn("dbo.Clients", "Piso", c => c.Int(nullable: false));
            AlterColumn("dbo.Clients", "EmailCliente", c => c.String());
            DropColumn("dbo.Clients", "Direccion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clients", "Direccion", c => c.String());
            AlterColumn("dbo.Clients", "EmailCliente", c => c.Int(nullable: false));
            DropColumn("dbo.Clients", "Piso");
            DropColumn("dbo.Clients", "Departamento");
            DropColumn("dbo.Clients", "Numeracion");
            DropColumn("dbo.Clients", "Localidad");
            DropColumn("dbo.Clients", "Calle");
        }
    }
}
