using Domain.Models;
using Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ShopDbContext : DbContext
    {
        
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Bike> Bikes { get; set; }
        public DbSet<Accessory> Accessories { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<PromoPackage> Promotions { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<PromoItem> PromoItems { get; set; }

        public ShopDbContext() { }

        public ShopDbContext(DbContextOptions options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-C8L0AG5\\LUCHI;Database=GhiniBikes;Trusted_Connection=True");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();
            builder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }

    }
}
