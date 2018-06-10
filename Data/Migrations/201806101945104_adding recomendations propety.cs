namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingrecomendationspropety : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Recomendations", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Recomendations");
        }
    }
}
