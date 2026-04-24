using Microsoft.EntityFrameworkCore;
using FarmAZ.Entities;

namespace FarmAZ.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Card> Cards { get; set; }           
        public DbSet<CardItem> CardItems { get; set; }   
        public DbSet<Notification> Notifications { get; set; } 
        public DbSet<Payment> Payments { get; set; }     

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

            modelBuilder.Entity<CardItem>()
                .HasOne(ci => ci.Card)
                .WithMany(c => c.Items)
                .HasForeignKey(ci => ci.CardId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CardItem>()
                .HasOne(ci => ci.Product)
                .WithMany()
                .HasForeignKey(ci => ci.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
             .HasPrecision(18, 2);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=localhost;Database=FarmAZDb;User Id=sa;Password=12345;"
                );
            }
        }
    }
}