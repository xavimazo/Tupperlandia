namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIMGVARIATIONTYPE : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductVariations", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductVariations", "Image");
        }
    }
}
