namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResidencyDetail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "ResidencyDetail", c => c.String());
            AddColumn("dbo.Sales", "SaleDetailst", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sales", "SaleDetailst");
            DropColumn("dbo.Clients", "ResidencyDetail");
        }
    }
}
