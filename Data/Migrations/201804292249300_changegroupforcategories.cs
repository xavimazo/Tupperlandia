namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changegroupforcategories : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stocks", "Categorie", c => c.String());
            DropColumn("dbo.Stocks", "Group");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stocks", "Group", c => c.String());
            DropColumn("dbo.Stocks", "Categorie");
        }
    }
}
