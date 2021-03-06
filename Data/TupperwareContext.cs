namespace Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class TupperwareContext : DbContext
    {
        // Your context has been configured to use a 'Model' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Data.Model' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model' 
        // connection string in the application configuration file.
        public TupperwareContext()
            : base("name=TupperwareContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Capacity> Capacities { get; set; }
        public virtual DbSet<Categorie> Categories { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Dispatch> Dispatches { get; set; }
        public virtual DbSet<Line> Lines { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Origin> Origins { get; set; }
        public virtual DbSet<Description> Descriptions { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<Stock> Stock { get; set; }
        public virtual DbSet<StockStatus> StockStatuses { get; set; }
        public virtual DbSet<User> Users { get; set; }

    }

    //public class MyEntitys
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}