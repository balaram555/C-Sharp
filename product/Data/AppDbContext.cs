using Microsoft.EntityFrameworkCore;
using ProductApi.Models;

namespace ProductApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "Laptop",
                Price = 55000
            },
            new Product
            {
                Id = 2,
                Name = "Mouse",
                Price = 800
            },
            new Product
            {
                Id = 3,
                Name = "Keyboard",
                Price = 1500
            }
        );
    }
}