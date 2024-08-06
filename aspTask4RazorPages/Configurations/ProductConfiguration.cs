using aspTask4RazorPages.Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace aspTask4RazorPages.Configurations;
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> productBuilder)
    {
        productBuilder.HasKey(p => p.Id).HasName("PK_Products_Id");
        productBuilder.HasIndex(p => p.Name).IsUnique().HasDatabaseName("UK_Products_Name");
    }
}
