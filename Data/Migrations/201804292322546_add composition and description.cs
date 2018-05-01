namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcompositionanddescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Composition", c => c.String());
            AddColumn("dbo.Products", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Description");
            DropColumn("dbo.Products", "Composition");
        }
    }
}
