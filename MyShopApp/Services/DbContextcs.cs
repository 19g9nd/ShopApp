using ConsoleApp5.Classes;
using Microsoft.EntityFrameworkCore;
using MyShopApp.Classes;
using MyShopApp.Config;

namespace MyShopApp.Services
{
    public class DbContextcs : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = $"Server=localhost;Database=MyShopDb;User Id=admin;Password=admin;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfig());

        }


    }

}
