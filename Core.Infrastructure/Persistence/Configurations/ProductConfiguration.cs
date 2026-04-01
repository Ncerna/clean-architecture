using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Infrastructure.Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("products");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name).IsRequired();
        builder.Property(p => p.Code).IsRequired();

        builder.OwnsOne(p => p.Price, price =>
        {
            price.Property(p => p.Value)
                 .HasColumnName("price");
        });

        builder.OwnsOne(p => p.Stock, stock =>
        {
            stock.Property(s => s.Value)
                 .HasColumnName("stock");
        });
    }
}