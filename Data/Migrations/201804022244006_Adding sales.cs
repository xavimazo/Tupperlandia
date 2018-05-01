namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addingsales : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Client = c.String(),
                        ProductAndCapacity = c.String(),
                        Units = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sales");
        }
    }
}
