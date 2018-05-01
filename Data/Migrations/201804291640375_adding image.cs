namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingimage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stocks", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stocks", "Image");
        }
    }
}
