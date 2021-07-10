using Microsoft.EntityFrameworkCore;
using System;
using ModuleDal.Models;

namespace ModuleDal
{
    public class ModuleContext : DbContext
    {
        private string _connectionString = string.Empty;

        public DbSet<Payment> Payments { get; set; }
        public DbSet<Student> Students { get; set; }
        public ModuleContext(string connectionString = @"Server=.; DataBase=Module;Initial Catalog=Task;Trusted_Connection=True;")
        {
            _connectionString = connectionString;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
