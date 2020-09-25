namespace CollectionData
{
    using CollectionData.Entities;
    using CollectionEntities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CollectionDatabase : DbContext
    {
        // Your context has been configured to use a 'Database' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'CollectionData.Database' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Database' 
        // connection string in the application configuration file.
        public CollectionDatabase(): base("CollectionDatabase")
        {

        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<OrderDTO> Orders { get; set; }
    }
}