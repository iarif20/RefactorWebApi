using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RefactorThis.Domain.Models;

namespace RefactorThis.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext()
        {
        }

        public ProductContext(DbContextOptions<ProductContext> options): base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOption> ProductOptions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder aOptionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder aModelBuilder)
        {
            aModelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(500);
                entity.Property(e => e.DeliveryPrice).IsRequired();
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Price).IsRequired();
            });

            aModelBuilder.Entity<ProductOption>(entity =>
            {
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(500);
                entity.Property(e => e.ProductId).IsRequired();
            });
        }
    }
}