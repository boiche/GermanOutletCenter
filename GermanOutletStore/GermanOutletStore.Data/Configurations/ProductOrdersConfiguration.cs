using GermanOutletStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GermanOutletStore.Data.Configurations
{
    public class ProductOrdersConfiguration : IEntityTypeConfiguration<ProductOrders>
    {
        public void Configure(EntityTypeBuilder<ProductOrders> builder)
        {
            builder.HasKey(x => new { x.OrderId, x.ProductId, x.SizeId });
            builder.HasOne(x => x.Product).WithMany(x => x.Orders);
            builder.HasOne(x => x.Order).WithMany(x => x.Products);
            builder.HasOne(x => x.Size).WithMany(x => x.ProductOrders);
        }
    }
}
