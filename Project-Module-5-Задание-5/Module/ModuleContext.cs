using ModuleDal.Models;
using System.Data.Entity;

namespace ModuleDal
{
    public class ModuleContext : DbContext
    {
        public ModuleContext(string connectionString = @"Server=.; DataBase=Module;Initial Catalog=Task;Trusted_Connection=True;") : base(connectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
