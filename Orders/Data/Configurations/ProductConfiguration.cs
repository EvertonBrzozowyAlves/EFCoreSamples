using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orders.Domain;

namespace Orders.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.BarCode).HasColumnType("VARCHAR(14)").IsRequired();
            builder.Property(p => p.Description).HasColumnType("VARCHAR(60)");
            builder.Property(p => p.Price).IsRequired();
            builder.Property(p => p.ProductType).HasConversion<string>(); //save the enum property as string
        }
    }
}