namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tupperwarecontext : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ProductDescriptionProducts", newName: "ProductProductDescriptions");
            DropPrimaryKey("dbo.ProductProductDescriptions");
            AddPrimaryKey("dbo.ProductProductDescriptions", new[] { "Product_ProductId", "ProductDescription_ProductDescriptionId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ProductProductDescriptions");
            AddPrimaryKey("dbo.ProductProductDescriptions", new[] { "ProductDescription_ProductDescriptionId", "Product_ProductId" });
            RenameTable(name: "dbo.ProductProductDescriptions", newName: "ProductDescriptionProducts");
        }
    }
}
