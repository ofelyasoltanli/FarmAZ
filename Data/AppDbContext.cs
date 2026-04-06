using Microsoft.EntityFrameworkCore;
using FarmAZ.Entities;

namespace FarmAZ.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options){}

        public DbSet<User> Users{get; set;}

        public DbSet<Order> Orders{get; set;}

        public DbSet<Product> Products{get; set;}

        public DbSet<OrderItem> OrderItems{get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<OrderItem>()
        .HasOne(oi => oi.Product)
        .WithMany()
        .HasForeignKey(oi => oi.ProductId)
        .OnDelete(DeleteBehavior.NoAction);  

    modelBuilder.Entity<OrderItem>()
        .HasOne(oi => oi.Order)
        .WithMany(o => o.Items)
        .HasForeignKey(oi => oi.OrderId)
        .OnDelete(DeleteBehavior.Cascade);
}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    if (!optionsBuilder.IsConfigured)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=FarmAZDb;User Id=sa;Password=FarmAZ@123;TrustServerCertificate=True");
    }
}

    }
}