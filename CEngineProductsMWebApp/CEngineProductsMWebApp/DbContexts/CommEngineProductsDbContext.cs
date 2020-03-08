using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using CEngineProductsMWebApp.Models;

namespace CEngineProductsMWebApp.DbContexts
{
    public class CommEngineProductsDbContext:DbContext
    {
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public CommEngineProductsDbContext():base("dbconnection")
        {
            Database.SetInitializer<CommEngineProductsDbContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}