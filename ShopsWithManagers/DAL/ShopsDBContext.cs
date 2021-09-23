using Microsoft.EntityFrameworkCore;
using DAL.Entities;

namespace DAL
{
    public class ShopsDBContext : DbContext
    {
        public ShopsDBContext(DbContextOptions options)
            : base (options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Shop> Shops{ get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<ManagerWorkingHistory> ManagersWorkingHistory { get; set; }

    }
}
