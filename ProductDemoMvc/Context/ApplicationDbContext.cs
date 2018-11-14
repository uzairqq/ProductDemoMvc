using System;
using Microsoft.EntityFrameworkCore;
using ProductDemoMvc.DataModels;

namespace ProductDemoMvc.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(p =>
            {
                p
                    .HasOne(i => i.Orders)
                    .WithMany(i => i.Product)
                    .HasForeignKey(i => i.OrderId);

                p
                    .HasData(
                        new Product { Id = 1, Name = "Apple", Price = 1.2M, OrderId = 1},
                        new Product { Id = 2, Name = "Orange", Price = 2.4M, OrderId = 1},
                        new Product { Id = 3, Name = "Graphes", Price = 3.4M, OrderId = 2});
            });

            modelBuilder.Entity<Order>(o =>
            {
                o
                    .HasMany(i => i.Product)
                    .WithOne(i => i.Orders)
                    .HasForeignKey(i => i.OrderId);

                o
                    .HasData(
                        new Order { Id = 1, Name = "Order1", CreatedOn = DateTime.Now },
                        new Order { Id = 2, Name = "Order1", CreatedOn = DateTime.Now },
                        new Order { Id = 3, Name = "Order2", CreatedOn = DateTime.UtcNow });
            });
        }
    }
}
