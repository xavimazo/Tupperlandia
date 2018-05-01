namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingdescriptions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "LargeDescription", c => c.String());
            AddColumn("dbo.Products", "ShortDescription", c => c.String());
            DropColumn("dbo.Products", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Description", c => c.String());
            DropColumn("dbo.Products", "ShortDescription");
            DropColumn("dbo.Products", "LargeDescription");
        }
    }
}
