using GermanOutletStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GermanOutletStore.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Orders).WithOne(x => x.Product);
            builder.HasOne(x => x.Brand).WithMany(x => x.Products);
            builder.HasOne(x => x.Sale).WithOne(x => x.Product).HasForeignKey<Sale>(x => x.Id);
            builder.HasOne(x => x.Type).WithMany(x => x.Products);
            builder.HasMany(x => x.Reviews).WithOne(x => x.ReviewedProduct);
            builder.HasMany(x => x.AvailableSizes).WithOne(x => x.Product);
            builder.Property(x => x.Price).HasColumnType("real");
        }
    }
}
