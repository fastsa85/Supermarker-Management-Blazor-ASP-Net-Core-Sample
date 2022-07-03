using CoreBusiness.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins.DataStore.SQL
{
    public class MarketContext : DbContext
    {
        public MarketContext(DbContextOptions options) : base(options)
        {            
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Transaction> Transaction { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            // seeding some data
            modelBuilder.Entity<Category>().HasData(
                new Category() { CategoryId = 1, Name = "Beverage", Description = "Beverage" },
                new Category() { CategoryId = 2, Name = "Bakery", Description = "Bakery" },
                new Category() { CategoryId = 3, Name = "Meat", Description = "Meat" }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product() { ProductId = 1, CategoryId = 1, Name = "Iced Tea", Quantity = 100, Price = 1.99m },
                new Product() { ProductId = 2, CategoryId = 1, Name = "Ginger Ale", Quantity = 99, Price = 0.99m },
                new Product() { ProductId = 3, CategoryId = 2, Name = "Whole Wheat Bread", Quantity = 199, Price = 1.19m },
                new Product() { ProductId = 4, CategoryId = 2, Name = "White Bread", Quantity = 88, Price = 1.50m },
                new Product() { ProductId = 5, CategoryId = 2, Name = "Donut", Quantity = 51, Price = 0.55m },
                new Product() { ProductId = 6, CategoryId = 3, Name = "Pork", Quantity = 24, Price = 5.01m },
                new Product() { ProductId = 7, CategoryId = 3, Name = "Beef", Quantity = 19, Price = 4.69m },
                new Product() { ProductId = 8, CategoryId = 3, Name = "Chicken", Quantity = 12, Price = 3.99m }
                );

            modelBuilder.Entity<Transaction>().HasData(
                new Transaction { TransactionId = 1, ProductId = 1, ProductName = "Iced Tea", Price = 1.98m, BeforeQuantity = 110, SoldQuantity = 10, CashierName = "Alex", Timestamp = DateTime.Now }
                );
        }
    }
}
