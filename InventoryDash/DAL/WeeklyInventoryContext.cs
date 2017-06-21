using InventoryDash.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace InventoryDash.DAL
{
    public class WeeklyInventoryContext : DbContext
    {
        public WeeklyInventoryContext() : base("WeeklyInventoryContext")
        {

        }

        public DbSet<WeeklyInventoryMain> WeeklyInventoryMains { get; set; }
        public DbSet<WeeklyInventorySandwiches> WeeklyInventorySandwiches { get; set; }
        public DbSet<WeeklyInventoryDrinks> WeeklyInventoryDrinks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}