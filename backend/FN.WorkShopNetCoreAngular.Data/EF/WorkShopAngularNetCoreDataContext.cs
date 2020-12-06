using Microsoft.EntityFrameworkCore;

namespace FN.WorkShopNetCoreAngular.Data.EF
{
    public class WorkShopAngularNetCoreDataContext : DbContext
    {

        public WorkShopAngularNetCoreDataContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("WorkShopAngularNetCoreDB");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Maps.ClienteMap());
            modelBuilder.Seed();
        }
    }
}