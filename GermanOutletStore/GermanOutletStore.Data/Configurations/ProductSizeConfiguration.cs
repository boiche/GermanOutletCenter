using GermanOutletStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GermanOutletStore.Data.Configurations
{
    public class ProductSizeConfiguration : IEntityTypeConfiguration<ProductSize>
    {
        public void Configure(EntityTypeBuilder<ProductSize> builder)
        {
            builder.HasKey(x => new { x.ProductId, x.SizeId });
            builder.HasOne(x => x.Size).WithMany(x => x.Products);
            builder.HasOne(x => x.Product).WithMany(x => x.AvailableSizes);
        }
    }
}
