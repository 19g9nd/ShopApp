using ConsoleApp5.Classes;
using Microsoft.EntityFrameworkCore;
using MyShopApp.Classes;
using MyShopApp.Config;

namespace ConsoleApp5
{
    public class DbContextcs : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = $"Server=localhost;Database=MyShopDb;Trusted_Connection=True;TrustServerCertificate=True;";
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
