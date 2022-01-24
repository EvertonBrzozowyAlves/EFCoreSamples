using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orders.Domain;

namespace Orders.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.StartDate).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
            builder.Property(p => p.OrderStatus).HasConversion<string>();
            builder.Property(p => p.DeliveryType).HasConversion<int>(); //save the enum property as int
            builder.Property(p => p.Comments).HasColumnType("VARCHAR(500)");

            builder.HasMany(order => order.OrderItems)
                .WithOne(item => item.Order)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}