using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orders.Domain;

namespace Orders.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(p => p.Phone).HasColumnType("CHAR(11)");
            builder.Property(p => p.PostalCode).HasColumnType("CHAR(8)").IsRequired();
            builder.Property(p => p.State).HasColumnType("CHAR(2)").IsRequired();
            builder.Property(p => p.City).HasMaxLength(60).IsRequired();

            builder.HasIndex(c => c.Phone).HasDatabaseName("IX_Customer_Phone").IsClustered(false);
        }
    }
}