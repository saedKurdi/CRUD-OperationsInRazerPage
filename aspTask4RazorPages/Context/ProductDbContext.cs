using aspTask4RazorPages.Entities.Concretes;
using Microsoft.EntityFrameworkCore;
namespace aspTask4RazorPages.Context;
public class ProductDbContext : DbContext
{
    // creating constructor (options) for db :
    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

    // adding on model creating for adding configurations : 
    protected override void OnModelCreating(ModelBuilder productBuilder)
    {
        productBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        base.OnModelCreating(productBuilder);
    }

    // creating tables for our data-base : 
    public DbSet<Product> Products { get; set; }
}
