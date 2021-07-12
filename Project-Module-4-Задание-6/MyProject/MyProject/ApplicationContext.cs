using Microsoft.EntityFrameworkCore;

namespace MyProject
{
    public class ApplicationContext : DbContext
    {
        private readonly string _connectionString = @"Data Source = localhost; Initial Catalog = DefalutBase; Trusted_Connection = True;";

        public DbSet<User> Users { get; set; }
        public DbSet<UserAddress> Addresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        public ApplicationContext(string connectionString)
        {
            _connectionString = connectionString;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
                
        }
    }
}
